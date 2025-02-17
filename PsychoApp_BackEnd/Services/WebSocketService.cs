using System;
using System.Collections.Concurrent;
using System.Net.WebSockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace psychoApp.Services
{
    public class WebSocketService
    {
        private readonly ConcurrentDictionary<Guid, WebSocket> _connections = new();

        public async Task HandleConnectionAsync(WebSocket webSocket)
        {
            var connectionId = Guid.NewGuid();
            _connections.TryAdd(connectionId, webSocket);

            var buffer = new byte[1024 * 4];

            try
            {
                while (webSocket.State == WebSocketState.Open)
                {
                    var result = await webSocket.ReceiveAsync(new ArraySegment<byte>(buffer), CancellationToken.None);
                    if (result.MessageType == WebSocketMessageType.Close)
                    {
                        break;
                    }

                    var receivedMessage = Encoding.UTF8.GetString(buffer, 0, result.Count);
                    var responseMessage = GetResponse(receivedMessage);

                    await webSocket.SendAsync(Encoding.UTF8.GetBytes(responseMessage), WebSocketMessageType.Text, true, CancellationToken.None);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"WebSocket Error: {ex.Message}");
            }
            finally
            {
                _connections.TryRemove(connectionId, out _);
                await webSocket.CloseAsync(WebSocketCloseStatus.NormalClosure, "Connection closed", CancellationToken.None);
            }
        }

        private string GetResponse(string message)
        {
            return message switch
            {
                "hi" => "hello how are you?",
                "what time is it?" => $"Current time: {DateTime.Now:T}",
                _ => "I don't understand your message."
            };
        }
    }
}
