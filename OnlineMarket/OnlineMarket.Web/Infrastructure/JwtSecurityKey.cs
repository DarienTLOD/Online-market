using System.Text;
using Microsoft.IdentityModel.Tokens;

namespace OnlineMarket.Web.Infrastructure
{
    public class JwtSecurityKey
    {
        public static SymmetricSecurityKey Create(string secret)
        {
            return new SymmetricSecurityKey(Encoding.ASCII.GetBytes(secret));
        }
    }
}
