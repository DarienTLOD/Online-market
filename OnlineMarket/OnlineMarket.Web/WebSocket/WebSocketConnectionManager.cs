using System;
using System.Collections.Concurrent;
using System.Linq;
using System.Net.WebSockets;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;

namespace OnlineMarket.Web.WebSocket
{
    public class WebSocketConnectionManager
    {
        private readonly ConcurrentDictionary<string, System.Net.WebSockets.WebSocket> _sockets = new ConcurrentDictionary<string, System.Net.WebSockets.WebSocket>();
        private readonly ILogger<WebSocketConnectionManager> _logger;
        public WebSocketConnectionManager(ILogger<WebSocketConnectionManager> logger)
        {
            _logger = logger;
        }

        public System.Net.WebSockets.WebSocket GetSocketById(string id)
        {
            return _sockets.FirstOrDefault(p => p.Key == id).Value;
        }

        public ConcurrentDictionary<string, System.Net.WebSockets.WebSocket> GetAll()
        {
            return _sockets;
        }

        public string GetId(System.Net.WebSockets.WebSocket socket)
        {
            return _sockets.FirstOrDefault(p => p.Value == socket).Key;
        }

        public void AddSocket(System.Net.WebSockets.WebSocket socket, string userId)
        {
            _sockets.TryAdd(userId, socket);
        }

        public async Task RemoveSocket(string id)
        {
            try
            {
                _sockets.TryRemove(id, out var socket);
                await socket.CloseOutputAsync(WebSocketCloseStatus.NormalClosure, string.Empty , CancellationToken.None);
            }
            catch (Exception exception)
            {
                _logger.LogError(null, exception);
            }
        }
    }
}
