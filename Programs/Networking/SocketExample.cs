// Program: SocketExample
// Difficulty: High
// Description: Low-level socket programming for TCP communication.
using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

class SocketExample
{
    const int PORT = 9010;

    static void Server()
    {
        var endpoint = new IPEndPoint(IPAddress.Loopback, PORT);
        using var server = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
        server.Bind(endpoint);
        server.Listen(5);
        Console.WriteLine($"Server listening on {endpoint}");
        using var client = server.Accept();
        byte[] buffer = new byte[1024];
        int received = client.Receive(buffer);
        string msg = Encoding.UTF8.GetString(buffer, 0, received);
        Console.WriteLine($"Server received: {msg}");
        client.Send(Encoding.UTF8.GetBytes("ACK: " + msg));
    }

    static async Task Main(string[] args)
    {
        var serverTask = Task.Run(Server);
        await Task.Delay(100);

        using var client = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
        client.Connect(IPAddress.Loopback, PORT);
        byte[] msg = Encoding.UTF8.GetBytes("Hello Socket!");
        client.Send(msg);
        byte[] buffer = new byte[1024];
        int received = client.Receive(buffer);
        Console.WriteLine($"Client received: {Encoding.UTF8.GetString(buffer, 0, received)}");
        client.Shutdown(SocketShutdown.Both);

        await serverTask;
    }
}
