using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using SeriesApp.Models.Usuarios;
using SeriesApp.Configurations;
using Microsoft.Extensions.Configuration;

namespace SeriesApp.Services
{
    public class TokenService : IAuthenticationService
    {
        private readonly IConfiguration _configuration;
        public TokenService(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public string GenerateToken(UsuarioViewModelOutput usuarioViewModelOutput)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_configuration.GetSection("JwtConfigurations:Secret").Value); //comitando a chave
            var tokenDescriptor = new SecurityTokenDescriptor  //configurando a descrição do token
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                   // new Claim(ClaimTypes.Name, user.Username.ToString()),
                  //  new Claim(ClaimTypes.Role, user.Role.ToString())

                     new Claim(ClaimTypes.NameIdentifier, usuarioViewModelOutput.Codigo.ToString()),
                     new Claim(ClaimTypes.Name, usuarioViewModelOutput.Codigo.ToString()),
                     new Claim(ClaimTypes.Email, usuarioViewModelOutput.Codigo.ToString()),
                }),
                Expires = DateTime.UtcNow.AddHours(2),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature) // algoritmo de criptografia do token
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }
}
