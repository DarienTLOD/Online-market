using System;
using System.Collections.Concurrent;
using System.Linq;
using System.Net.WebSockets;
using System.Threading;
using System.Threading.Tasks;

namespace OnlineMarket.Web.WebSocket
{
    public class WebSocketConnectionManager
    {
        private readonly ConcurrentDictionary<string, System.Net.WebSockets.WebSocket> _sockets = new ConcurrentDictionary<string, System.Net.WebSockets.WebSocket>();

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

        public void AddSocket(System.Net.WebSockets.WebSocket socket)
        {
            var sId = CreateConnectionId();
            while (!_sockets.TryAdd(sId, socket))
            {
                sId = CreateConnectionId();
            }
        }

        public async Task RemoveSocket(string id)
        {
            try
            {
                _sockets.TryRemove(id, out var socket);
                await socket.CloseOutputAsync(WebSocketCloseStatus.NormalClosure, null, CancellationToken.None);
            }
            catch (Exception)
            {

            }
        }

        private string CreateConnectionId()
        {
            return Guid.NewGuid().ToString();
        }
    }
}
