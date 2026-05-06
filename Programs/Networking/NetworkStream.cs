// Program: NetworkStream
// Difficulty: High
// Description: Uses NetworkStream for bidirectional TCP communication.
using System;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

class NetworkStreamExample
{
    const int PORT = 9011;

    static async Task RunServer()
    {
        var listener = new TcpListener(IPAddress.Loopback, PORT);
        listener.Start();
        Console.WriteLine($"Server on port {PORT}");
        using var client = await listener.AcceptTcpClientAsync();
        using var stream = new StreamReader(client.GetStream(), Encoding.UTF8);
        using var writer = new StreamWriter(client.GetStream(), Encoding.UTF8) { AutoFlush = true };
        string line = await stream.ReadLineAsync();
        Console.WriteLine($"Server got: {line}");
        await writer.WriteLineAsync($"Echo: {line}");
        listener.Stop();
    }

    static async Task Main(string[] args)
    {
        var serverTask = RunServer();
        await Task.Delay(100);

        using var client = new TcpClient();
        await client.ConnectAsync(IPAddress.Loopback, PORT);
        using var stream = new NetworkStream(client.Client);
        using var reader = new StreamReader(stream, Encoding.UTF8);
        using var writer = new StreamWriter(stream, Encoding.UTF8) { AutoFlush = true };
        await writer.WriteLineAsync("Hello NetworkStream!");
        string response = await reader.ReadLineAsync();
        Console.WriteLine($"Client received: {response}");
        await serverTask;
    }
}
