// Program: TcpServerExample
// Difficulty: High
// Description: TCP echo server that accepts connections and echoes back messages.
using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

class TcpServerExample
{
    static async Task HandleClient(TcpClient client)
    {
        Console.WriteLine($"Client connected: {client.Client.RemoteEndPoint}");
        using var stream = client.GetStream();
        byte[] buffer = new byte[1024];
        int read = await stream.ReadAsync(buffer, 0, buffer.Length);
        string msg = Encoding.UTF8.GetString(buffer, 0, read);
        Console.WriteLine($"Received: {msg}");
        byte[] echo = Encoding.UTF8.GetBytes("Echo: " + msg);
        await stream.WriteAsync(echo, 0, echo.Length);
        client.Close();
    }

    static async Task Main(string[] args)
    {
        var listener = new TcpListener(IPAddress.Loopback, 9001);
        listener.Start();
        Console.WriteLine("TCP Echo Server started on port 9001 (accepting 1 connection)...");
        using var cts = new CancellationTokenSource(TimeSpan.FromSeconds(2));
        try
        {
            var client = await listener.AcceptTcpClientAsync();
            await HandleClient(client);
        }
        catch (Exception)
        {
            Console.WriteLine("Timeout waiting for client (demo mode).");
        }
        listener.Stop();
        Console.WriteLine("Server stopped.");
    }
}
