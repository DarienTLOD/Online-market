using System;
using System.Net.WebSockets;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using OnlineMarket.Contract.ContractModels;
using OnlineMarket.Web.Infrastructure;

namespace OnlineMarket.Web.WebSocket
{
    public class WebSocketManagerMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly WebSocketHandler _webSocketHandler;
        private readonly UserManager<UserContractModel> _userManager;
        private readonly JwtManualValidator _validator;

        public WebSocketManagerMiddleware(RequestDelegate next, WebSocketHandler webSocketHandler, UserManager<UserContractModel> userManager, JwtManualValidator validator)
        {
            _next = next;
            _webSocketHandler = webSocketHandler;
            _userManager = userManager;
            _validator = validator;
        }

        public async Task Invoke(HttpContext context)
        {
            if (!context.WebSockets.IsWebSocketRequest)
            {
                await _next.Invoke(context);
                return;
            }

            var token = context.Request.Query["access_token"].ToString();

            if (string.IsNullOrWhiteSpace(token))
            {
                return;
            }

            var userId = _validator.GetUserIdFromToken(token);

            if (string.IsNullOrWhiteSpace(userId))
            {
                return;
            }

            var user = await _userManager.FindByIdAsync(userId);

            if (user == null)
            {
                return;
            }

            var socket = await context.WebSockets.AcceptWebSocketAsync();

            _webSocketHandler.OnConnected(socket, user.Id);

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
