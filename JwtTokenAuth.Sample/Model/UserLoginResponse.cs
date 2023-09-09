using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JwtTokenAuth.Sample.Model
{
    public class UserLoginResponse
    {
        //Sisteme giriş yapan kullanıcı için Authorization-yetkilendirme yapılır
        public bool AuthenticateResult { get; set; }
        public string AuthToken { get; set; }
        public DateTime AccessTokenExpireDate { get; set; }
    }
}
