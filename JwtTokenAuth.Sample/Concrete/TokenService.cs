using JwtTokenAuth.Sample.Interface;
using JwtTokenAuth.Sample.Model;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace JwtTokenAuth.Sample.Concrete
{
    public class TokenService : ITokenService
    {
        private readonly IConfiguration _config; //appsettings içindeki değeri okuyabilmek için bu sınıf DI içeri alınır
        public TokenService(IConfiguration config)
        {
            _config= config;
        }
        public Task<GenerateTokenResponse> GenerateToken(GenerateTokenRequest request)
        {
            SymmetricSecurityKey symmetricSecurityKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(_config["AppSettings:Secret"]));

            var dateTimeNow = DateTime.UtcNow;

            JwtSecurityToken jwt = new JwtSecurityToken(
                issuer:_config["Appsettings:ValidIssuer"], //kim tarafından dağıltığı (biz)
                audience:_config["Appsettings:ValidAudience"], //kimler tarafından kullanılacağı
                claims: new List<Claim> //token içinde hangi bilgilerin yer alacağı -claim-
                {
                    new Claim("UserName",request.UserName)
                },
                notBefore:dateTimeNow, //token bilgisinin aktif olmaya başlayacağı zaman 
                expires:dateTimeNow.Add(TimeSpan.FromMinutes(500)), //token geçerlilik süresi
                signingCredentials: new SigningCredentials(symmetricSecurityKey,SecurityAlgorithms.HmacSha256) //secret değerinin şifreleme algoritması
                );

            return Task.FromResult(new GenerateTokenResponse
            {
                Token=new JwtSecurityTokenHandler().WriteToken(jwt),
                TokenExpireDate=dateTimeNow.Add(TimeSpan.FromMinutes(500))
            });
            //metod token ve token nın geçerlilik süresini geri döner
        }
    }
}
