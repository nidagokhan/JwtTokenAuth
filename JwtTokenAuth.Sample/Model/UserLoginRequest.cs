using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JwtTokenAuth.Sample.Model
{
    public class UserLoginRequest
    {
        //Authentication-kimlik doğrulama için kullanıcı giriş yapar
        public string UserName { get; set; }
        public string Password { get; set; }
    }
}
