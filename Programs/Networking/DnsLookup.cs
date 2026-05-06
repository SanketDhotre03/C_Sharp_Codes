// Program: DnsLookup
// Difficulty: Medium
// Description: Performs DNS lookups using System.Net.Dns.
using System;
using System.Net;
using System.Net.Sockets;

class DnsLookup
{
    static void Lookup(string host)
    {
        Console.WriteLine($"Looking up: {host}");
        try
        {
            var entry = Dns.GetHostEntry(host);
            Console.WriteLine($"  Hostname: {entry.HostName}");
            Console.WriteLine($"  Aliases: {string.Join(", ", entry.Aliases)}");
            Console.WriteLine("  Addresses:");
            foreach (var addr in entry.AddressList)
                Console.WriteLine($"    {addr} ({addr.AddressFamily})");
        }
        catch (Exception ex) { Console.WriteLine($"  Error: {ex.Message}"); }
    }

    static void Main(string[] args)
    {
        Lookup("localhost");
        Lookup("127.0.0.1");

        // Show local machine info
        string hostName = Dns.GetHostName();
        Console.WriteLine($"\nLocal hostname: {hostName}");
        var local = Dns.GetHostEntry(hostName);
        Console.WriteLine("Local IPs:");
        foreach (var ip in local.AddressList)
            if (ip.AddressFamily == AddressFamily.InterNetwork)
                Console.WriteLine("  " + ip);
    }
}
