using System.Net.WebSockets;
using System.Text;
using System.Threading.Tasks;

namespace OnlineMarket.Web.WebSocket
{
    public class OnlineMarketWebSocketHandler : WebSocketHandler
    {
        public OnlineMarketWebSocketHandler(WebSocketConnectionManager webSocketConnectionManager) : base(webSocketConnectionManager)
        {
        }
    }
}
