using System.Text;
using Microsoft.IdentityModel.Tokens;

namespace SH.Framework.Application.Common.Authentication;

public class AuthenticationOptions
{
    public bool ValidateIssuer { get; set; } = true;
    public bool ValidateAudience { get; set; } = true;
    public bool ValidateLifetime { get; set; } = true;
    public bool ValidateIssuerSigningKey { get; set; } = true;
    public List<string> ValidAudiences { get; set; } = new();
    public List<string> ValidIssuers { get; set; } = new();
    public string IssuerSigningKey { get; set; } = string.Empty;
    public string Expiration { get; set; } = "1d";
    public string NotBefore { get; set; } = "";
    
    public TokenValidationParameters TokenValidationParameters()
    {
        return new TokenValidationParameters()
        {
            ValidateIssuer = ValidateIssuer,
            ValidateAudience = ValidateAudience,
            ValidateLifetime = ValidateLifetime,
            ValidateIssuerSigningKey = ValidateIssuerSigningKey,
            ValidAudiences = ValidAudiences,
            ValidIssuers = ValidIssuers,
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(IssuerSigningKey)),
            ClockSkew = TimeSpan.Zero
        };
    }
}