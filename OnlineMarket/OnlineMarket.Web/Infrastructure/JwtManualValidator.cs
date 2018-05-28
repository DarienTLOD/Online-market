using System;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Text;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace OnlineMarket.Web.Infrastructure
{
    public class JwtManualValidator
    {
        private readonly JwtSettings _settings;
        private readonly ILogger _logger;

        public JwtManualValidator(IOptions<JwtSettings> settings, ILogger<JwtManualValidator> logger)
        {
            _settings = settings.Value;
            _logger = logger;
        }

        public string GetUserIdFromToken(string token)
        {
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_settings.SecretKey));
            var validator = new JwtSecurityTokenHandler();

            var validationParameters = new TokenValidationParameters
            {
                ValidIssuer = _settings.Issuer,
                ValidAudience = _settings.Audience,
                IssuerSigningKey = key,
                ValidateIssuerSigningKey = true,
                ValidateAudience = true
            };

            if (validator.CanReadToken(token))
            {
                try
                {
                    var principal = validator.ValidateToken(token, validationParameters, out _);
                    if (principal.HasClaim(c => c.Type == "userId"))
                    {
                        return principal.Claims.First(c => c.Type == "userId").Value;
                    }
                }
                catch (Exception e)
                {
                    _logger.LogError(null, e);
                }
            }

            return string.Empty;
        }
    }
}
