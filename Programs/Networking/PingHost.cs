// Program: PingHost
// Difficulty: Medium
// Description: Pings a host and measures round-trip time.
using System;
using System.Net.NetworkInformation;

class PingHost
{
    static void PingTarget(string host)
    {
        using var ping = new Ping();
        var options = new PingOptions { DontFragment = true };
        byte[] buffer = new byte[32];

        Console.WriteLine($"Pinging {host}...");
        for (int i = 0; i < 3; i++)
        {
            try
            {
                var reply = ping.Send(host, 1000, buffer, options);
                if (reply.Status == IPStatus.Success)
                    Console.WriteLine($"  Reply from {reply.Address}: time={reply.RoundtripTime}ms TTL={reply.Options?.Ttl}");
                else
                    Console.WriteLine($"  Ping failed: {reply.Status}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"  Error: {ex.Message}");
            }
        }
    }

    static void Main(string[] args)
    {
        PingTarget("127.0.0.1");  // localhost always reachable
    }
}
