using System;
using System.Net.WebSockets;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace OnlineMarket.Web.WebSocket
{
    public class WebSocketManagerMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly WebSocketHandler _webSocketHandler;

        public WebSocketManagerMiddleware(RequestDelegate next, WebSocketHandler webSocketHandler)
        {
            _next = next;
            _webSocketHandler = webSocketHandler;
        }

        public async Task Invoke(HttpContext context)
        {
            if (!context.WebSockets.IsWebSocketRequest)
            {
                await _next(context);
                return;
            }

            var socket = await context.WebSockets.AcceptWebSocketAsync();

            _webSocketHandler.OnConnected(socket);

            await Receive(socket, async (result, buffer) =>
            {
                if (result.MessageType == WebSocketMessageType.Close)
                {
                    await _webSocketHandler.OnDisconnected(socket);
                }

            });
        }

        private async Task Receive(System.Net.WebSockets.WebSocket socket, Action<WebSocketReceiveResult, byte[]> handleMessage)
        {
            try
            {
                var buffer = new byte[1024 * 4];

                while (socket.State == WebSocketState.Open)
                {
                    var result = await socket.ReceiveAsync(new ArraySegment<byte>(buffer),
                        CancellationToken.None);

                    handleMessage(result, buffer);
                }
            }
            catch (Exception ex)
            {

            }

        }
    }
}
