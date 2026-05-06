// Program: UdpServerExample
// Difficulty: High
// Description: UDP echo server that receives and responds to datagrams.
using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

class UdpServerExample
{
    static async Task Main(string[] args)
    {
        using var server = new UdpClient(9003);
        Console.WriteLine("UDP echo server on port 9003 (waiting 2 seconds)...");

        server.Client.ReceiveTimeout = 2000;
        try
        {
            var result = await server.ReceiveAsync();
            string msg = Encoding.UTF8.GetString(result.Buffer);
            Console.WriteLine($"Received from {result.RemoteEndPoint}: {msg}");
            byte[] response = Encoding.UTF8.GetBytes("Echo: " + msg);
            await server.SendAsync(response, response.Length, result.RemoteEndPoint);
            Console.WriteLine("Echoed back.");
        }
        catch (Exception)
        {
            Console.WriteLine("Timeout - no message received (demo mode).");
        }
        Console.WriteLine("Server stopped.");
    }
}
