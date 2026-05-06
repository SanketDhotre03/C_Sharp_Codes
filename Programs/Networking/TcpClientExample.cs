// Program: TcpClientExample
// Difficulty: High
// Description: TCP client that connects to a server and sends/receives data.
using System;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

class TcpClientExample
{
    static async Task Main(string[] args)
    {
        // Try to connect to a local echo server on port 9000
        string host = "localhost";
        int port = 9000;
        try
        {
            using var client = new TcpClient();
            Console.WriteLine($"Connecting to {host}:{port}...");
            await client.ConnectAsync(host, port);
            Console.WriteLine("Connected!");

            using var stream = client.GetStream();
            byte[] msg = Encoding.UTF8.GetBytes("Hello, Server!");
            await stream.WriteAsync(msg, 0, msg.Length);

            byte[] buffer = new byte[1024];
            int read = await stream.ReadAsync(buffer, 0, buffer.Length);
            Console.WriteLine("Response: " + Encoding.UTF8.GetString(buffer, 0, read));
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Connection failed (no server running): {ex.Message}");
            Console.WriteLine("This is expected if no TCP server is running on port 9000.");
        }
    }
}
