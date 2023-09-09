using JwtTokenAuth.Sample.Interface;
using JwtTokenAuth.Sample.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JwtTokenAuth.Sample.Concrete
{
    public class AuthService : IAuthService
    {
        private readonly ITokenService _tservice;

        public AuthService(ITokenService tservice)
        {
            _tservice = tservice;
        }
        //Login işlemleri 
        public async Task<UserLoginResponse> LoginUserAsync(UserLoginRequest request)
        {
            UserLoginResponse response = new();

            if (string.IsNullOrEmpty(request.UserName) || string.IsNullOrEmpty(request.Password))
            {
                //kullanıcı adı veya şifre boşsa hata gönder
                throw new ArgumentNullException(nameof(request));
            }

            if (request.UserName == "Nida" && request.Password == "123456")
            {
                //kullanıcı adı ve şifre doğru ise aşağıdaki değerleri ata

                var  generatedtokenInformation = await _tservice.GenerateToken(new GenerateTokenRequest
                {
                    UserName = request.UserName
                });

                response.AccessTokenExpireDate = generatedtokenInformation.TokenExpireDate;
                response.AuthenticateResult = true;
                response.AuthToken = generatedtokenInformation.Token;
            }

            return response;
        }
    }
}
