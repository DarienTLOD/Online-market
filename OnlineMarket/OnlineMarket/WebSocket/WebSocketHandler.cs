using System;
using System.Net.WebSockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace OnlineMarket.Web.WebSocket
{
    public abstract class WebSocketHandler
    {
        public WebSocketConnectionManager WebSocketConnectionManager { get; set; }

        protected WebSocketHandler(WebSocketConnectionManager webSocketConnectionManager)
        {
            WebSocketConnectionManager = webSocketConnectionManager;
        }

        public virtual void OnConnected(System.Net.WebSockets.WebSocket socket)
        {
            WebSocketConnectionManager.AddSocket(socket);
        }

        public virtual async Task OnDisconnected(System.Net.WebSockets.WebSocket socket)
        {
            await WebSocketConnectionManager.RemoveSocket(WebSocketConnectionManager.GetId(socket));
        }

        public async Task SendMessageAsync(System.Net.WebSockets.WebSocket socket, string message)
        {
            if (socket.State != WebSocketState.Open)
                return;

          await socket.SendAsync(new ArraySegment<byte>(Encoding.ASCII.GetBytes(message), 0, message.Length),
              WebSocketMessageType.Text, true, CancellationToken.None);
        }

        public async Task SendMessageAsync(string socketId, string message)
        {
            try
            {
                await SendMessageAsync(WebSocketConnectionManager.GetSocketById(socketId), message);
            }
            catch (Exception)
            {

            }
        }

        public async Task SendMessageToAllAsync(string message)
        {
            foreach (var pair in WebSocketConnectionManager.GetAll())
            {
                if (pair.Value.State == WebSocketState.Open) await SendMessageAsync(pair.Value, message);
            }
        }
    }
}
