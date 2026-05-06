// Program: UploadFile
// Difficulty: High
// Description: Uploads a file using HTTP multipart form-data with HttpClient.
using System;
using System.IO;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

class UploadFile
{
    static async Task Main(string[] args)
    {
        // Create a temp file to "upload"
        string path = Path.Combine(Path.GetTempPath(), "upload_test.txt");
        File.WriteAllText(path, "Hello from C# upload example!");

        using var client = new HttpClient();
        client.Timeout = TimeSpan.FromSeconds(10);

        try
        {
            using var form = new MultipartFormDataContent();
            using var fileContent = new ByteArrayContent(File.ReadAllBytes(path));
            fileContent.Headers.ContentType = new MediaTypeHeaderValue("text/plain");
            form.Add(fileContent, "file", Path.GetFileName(path));
            form.Add(new StringContent("test upload"), "description");

            string url = "https://httpbin.org/post";
            Console.WriteLine($"Uploading to {url}...");
            var response = await client.PostAsync(url, form);
            Console.WriteLine($"Status: {response.StatusCode}");
            string body = await response.Content.ReadAsStringAsync();
            Console.WriteLine("Response (snippet): " + (body.Length > 200 ? body[..200] : body));
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Upload failed (no network?): {ex.Message}");
        }
        finally
        {
            File.Delete(path);
        }
    }
}
