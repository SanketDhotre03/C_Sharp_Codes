// Program: WebSocketClient
// Difficulty: High
// Description: Demonstrates WebSocket client communication.
using System;
using System.Net.WebSockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

class WebSocketClient
{
    static async Task Main(string[] args)
    {
        // Using a public WebSocket echo server for demo
        string uri = "wss://echo.websocket.events";
        Console.WriteLine($"Connecting to WebSocket: {uri}");

        using var ws = new ClientWebSocket();
        ws.Options.SetRequestHeader("Origin", "http://localhost");

        try
        {
            using var cts = new CancellationTokenSource(TimeSpan.FromSeconds(5));
            await ws.ConnectAsync(new Uri(uri), cts.Token);
            Console.WriteLine($"Connected. State: {ws.State}");

            string msg = "Hello WebSocket!";
            var sendBuffer = Encoding.UTF8.GetBytes(msg);
            await ws.SendAsync(new ArraySegment<byte>(sendBuffer), WebSocketMessageType.Text, true, cts.Token);
            Console.WriteLine($"Sent: {msg}");

            var recvBuffer = new byte[1024];
            var result = await ws.ReceiveAsync(new ArraySegment<byte>(recvBuffer), cts.Token);
            string received = Encoding.UTF8.GetString(recvBuffer, 0, result.Count);
            Console.WriteLine($"Received: {received}");

            await ws.CloseAsync(WebSocketCloseStatus.NormalClosure, "Done", CancellationToken.None);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"WebSocket error (may require network): {ex.Message}");
        }
    }
}
