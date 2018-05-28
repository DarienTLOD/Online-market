using System.Net.WebSockets;
using System.Text;
using System.Threading.Tasks;

namespace OnlineMarket.Web.WebSocket
{
    public class RatesWebSocketHandler : WebSocketHandler
    {
        public RatesWebSocketHandler(WebSocketConnectionManager webSocketConnectionManager) : base(webSocketConnectionManager)
        {
        }
    }
}
