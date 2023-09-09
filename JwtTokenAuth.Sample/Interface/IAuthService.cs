using JwtTokenAuth.Sample.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JwtTokenAuth.Sample.Interface
{
    public interface IAuthService
    {
        public Task<UserLoginResponse> LoginUserAsync(UserLoginRequest request);
    }
}
