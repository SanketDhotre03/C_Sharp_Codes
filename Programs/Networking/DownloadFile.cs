// Program: DownloadFile
// Difficulty: Medium
// Description: Downloads a file from a URL using HttpClient.
using System;
using System.IO;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

class DownloadFile
{
    static async Task DownloadAsync(string url, string outputPath, IProgress<long> progress = null)
    {
        using var client = new HttpClient();
        using var response = await client.GetAsync(url, HttpCompletionOption.ResponseHeadersRead);
        response.EnsureSuccessStatusCode();

        long? total = response.Content.Headers.ContentLength;
        using var stream = await response.Content.ReadAsStreamAsync();
        using var file = File.Create(outputPath);
        byte[] buffer = new byte[8192];
        long downloaded = 0;
        int read;
        while ((read = await stream.ReadAsync(buffer, 0, buffer.Length)) > 0)
        {
            await file.WriteAsync(buffer, 0, read);
            downloaded += read;
            progress?.Report(downloaded);
        }
    }

    static async Task Main(string[] args)
    {
        string url = "https://httpbin.org/bytes/1024";
        string path = Path.Combine(Path.GetTempPath(), "downloaded.bin");

        Console.WriteLine($"Downloading from {url}...");
        try
        {
            var progress = new Progress<long>(bytes => Console.WriteLine($"  Downloaded: {bytes} bytes"));
            await DownloadAsync(url, path, progress);
            Console.WriteLine($"Saved to: {path} ({new FileInfo(path).Length} bytes)");
            File.Delete(path);
        }
        catch (Exception ex) { Console.WriteLine($"Error: {ex.Message}"); }
    }
}
