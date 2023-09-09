using JwtTokenAuth.Sample.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JwtTokenAuth.Sample.Interface
{
    public interface IBookService
    {
        public Task<List<BookTitle>> GetBookTitleAsync();
        public Task<BookInformation> GetBookInformationByIdAsync(GetBookInformationByIdRequest request);
    }
}
