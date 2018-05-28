using System.Net.WebSockets;
using System.Text;
using System.Threading.Tasks;

namespace OnlineMarket.Web.WebSocket
{
    public class RecentActivitiesWebSocketHandler : WebSocketHandler
    {
        public RecentActivitiesWebSocketHandler(WebSocketConnectionManager webSocketConnectionManager) : base(webSocketConnectionManager)
        {
        }
    }
}
