using JwtTokenAuth.Sample.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JwtTokenAuth.Sample.Interface
{
    public interface ITokenService
    {
        public Task<GenerateTokenResponse> GenerateToken(GenerateTokenRequest request);
    }
}
