using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Microsoft.IdentityModel.Tokens;

namespace SH.Framework.Application.Common.Authentication;

public class TokenBuilder
{
    private string Issuer { get; set; } = string.Empty;
    private string Audience { get; set; } = string.Empty;
    private byte[] Secret { get; set; } = [];
    private DateTime Expiration { get; set; } = DateTime.UtcNow.AddDays(1);
    private DateTime NotBefore { get; set; } = DateTime.UtcNow;
    private List<Claim> Claims { get; } = new();
    private string SecurityAlgorithm { get; set; } = SecurityAlgorithms.HmacSha256;
    
    public static TokenBuilder Instance() => new();

    public TokenBuilder WithIssuer(string issuer)
    {
        Issuer = issuer;
        return this;
    }

    public TokenBuilder WithAudience(string audience)
    {
        Audience = audience;
        return this;
    }

    public TokenBuilder WithSecret(byte[] secret)
    {
        Secret = secret;
        return this;
    }
    
    public TokenBuilder WithExpiration(DateTime expiration)
    {
        Expiration = expiration;
        return this;
    }
    
    public TokenBuilder WithNotBefore(DateTime notBefore)
    {
        NotBefore = notBefore;
        return this;
    }
    
    public TokenBuilder WithClaim(Claim claim)
    {
        Claims.Add(claim);
        return this;
    }

    public TokenBuilder WithSecurityAlgorithm(string securityAlgorithm)
    {
        SecurityAlgorithm = securityAlgorithm;
        return this;
    }

    public string Build()
    {
        var handler = new JwtSecurityTokenHandler();
        Claims.Add(new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()));
        var descriptor = new SecurityTokenDescriptor()
        {
            Issuer = Issuer,
            Audience = Audience,
            Subject = new ClaimsIdentity(Claims),
            Expires = Expiration,
            NotBefore = NotBefore,
            SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(Secret), SecurityAlgorithm)
        };
        
        var token = handler.CreateToken(descriptor);
        
        return handler.WriteToken(token);
    }
}