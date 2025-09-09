using System.IdentityModel.Tokens.Jwt;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using MoodPlus.Model;

namespace MoodPlus.Authentication
{
    public class TokenService
    {
        public string Generate(User user)
        {
            // Creates a instance of JwtSecurityTokenHandler
            var handler = new JwtSecurityTokenHandler();

            // Encodes the private key coming from the configuration class
            var key = Encoding.ASCII.GetBytes(Configuration.PrivateKey);
            var credentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                SigningCredentials = credentials,
                // Within 5 hours the token will expire
                Expires = DateTime.UtcNow.AddHours(5),
            };

            // Creates a token
            var token = handler.CreateToken(tokenDescriptor);

            // Creates a string of the token
            return handler.WriteToken(token);
        }
    }
}
