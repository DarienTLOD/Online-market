using Microsoft.Extensions.Logging;

namespace OnlineMarket.Web.WebSocket
{
    public class OnlineMarketWebSocketHandler : WebSocketHandler
    {
        public OnlineMarketWebSocketHandler(WebSocketConnectionManager webSocketConnectionManager, ILogger<WebSocketHandler> logger) : base(webSocketConnectionManager, logger)
        {
        }
    }
}
