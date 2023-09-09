using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JwtTokenAuth.Sample.Model
{
    public class GenerateTokenResponse
    {
        public string Token { get; set; }
        public DateTime TokenExpireDate { get; set; }
    }
}
