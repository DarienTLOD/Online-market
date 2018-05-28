using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using Microsoft.IdentityModel.Tokens;
using OnlineMarket.Web.Infrastructure;

namespace OnlineMarket.Web.Infrastructure
{
    public class JwtTokenBuilder
    {
        private readonly JwtSettings _settings;

        public JwtTokenBuilder(JwtSettings settings)
        {
            _settings = settings;
        }

        private readonly Dictionary<string, string> _claims = new Dictionary<string, string>();
        private int _expiryInMinutes = 60;

        public JwtTokenBuilder AddClaim(string type, string value)
        {
            _claims.Add(type, value);
            return this;
        }

        public JwtTokenBuilder AddClaims(Dictionary<string, string> claims)
        {
            _claims.Union(claims);
            return this;
        }

        public JwtTokenBuilder AddExpiry(int expiryInMinutes)
        {
            _expiryInMinutes = expiryInMinutes;
            return this;
        }

        public JwtToken Build(string userName, string userRole, string userId)
        {
            EnsureArguments();

            var claims = new List<Claim>
            {
              new Claim(ClaimsIdentity.DefaultNameClaimType, userName),
              new Claim(ClaimsIdentity.DefaultRoleClaimType, userRole),
              new Claim("userId", userId),
              new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
            }
            .Union(_claims.Select(item => new Claim(item.Key, item.Value)));

            var token = new JwtSecurityToken(_settings.Issuer, _settings.Audience, claims, expires: DateTime.UtcNow.AddMinutes(_expiryInMinutes), signingCredentials:
                new SigningCredentials(JwtSecurityKey.Create(_settings.SecretKey), SecurityAlgorithms.HmacSha256));

            return new JwtToken(token);
        }

        private void EnsureArguments()
        {
            if (_settings.SecretKey == null)
                throw new ArgumentNullException(nameof(_settings.SecretKey));

            if (string.IsNullOrEmpty(_settings.Issuer))
                throw new ArgumentNullException(nameof(_settings.Issuer));

            if (string.IsNullOrEmpty(_settings.Audience))
                throw new ArgumentNullException(nameof(_settings.Audience));
        }
    }
}
