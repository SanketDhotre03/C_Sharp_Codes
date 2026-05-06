// Program: UdpClientExample
// Difficulty: High
// Description: UDP client that sends datagrams to a server.
using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

class UdpClientExample
{
    static async Task Main(string[] args)
    {
        using var client = new UdpClient();
        var endpoint = new IPEndPoint(IPAddress.Loopback, 9002);
        string message = "Hello UDP!";
        byte[] data = Encoding.UTF8.GetBytes(message);

        Console.WriteLine($"Sending UDP datagram to {endpoint}: {message}");
        int sent = await client.SendAsync(data, data.Length, endpoint);
        Console.WriteLine($"Sent {sent} bytes");

        // Try to receive response (with timeout)
        client.Client.ReceiveTimeout = 500;
        try
        {
            var result = await client.ReceiveAsync();
            string response = Encoding.UTF8.GetString(result.Buffer);
            Console.WriteLine($"Response from {result.RemoteEndPoint}: {response}");
        }
        catch (Exception)
        {
            Console.WriteLine("No response received (expected - no UDP server running).");
        }
    }
}
