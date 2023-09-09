using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JwtTokenAuth.Sample.Model
{
    public class BookInformation
    {
        public int BookId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string AuthorName { get; set; }
    }
}
