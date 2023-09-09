using JwtTokenAuth.Sample.Interface;
using JwtTokenAuth.Sample.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
//using System.Web.Mvc;

namespace JwtTokenAuth.Sample.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private readonly IBookService _bservice;
        public BookController(IBookService bservice)
        {
            _bservice= bservice;
        }

        [HttpPost("GetBookTitles")]
        [AllowAnonymous] //yetkisiz kullanılabilir
        public async Task<ActionResult<List<BookTitle>>> GetBookTitle()
        {
            var result = await _bservice.GetBookTitleAsync();
            return (result);
        }

        [HttpPost("GetBookInformationById")]
        [Authorize] //kullanmak için yetki gerekir
        //todo tanımlanan kullanıcı gibi giriş yapıyorum ama yetki vermiyor
        public async Task<ActionResult<BookInformation>> GetBookInformationById([FromBody] GetBookInformationByIdRequest request)
        {
            var result = await _bservice.GetBookInformationByIdAsync(request);
            return (result);
        }
    }
}
