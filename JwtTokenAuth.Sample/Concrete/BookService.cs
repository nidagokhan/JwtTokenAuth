using JwtTokenAuth.Sample.Interface;
using JwtTokenAuth.Sample.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JwtTokenAuth.Sample.Concrete
{
    public class BookService : IBookService
    {
        static readonly List<BookInformation> bookInformations = new List<BookInformation> {
            new BookInformation { BookId = 1, Title ="Kürk Mantolu MAdonna",  AuthorName = "Sabahattin Ali",  Description = "Bütün bunları değiştirme şansınız olsaydı?" },
            new BookInformation { BookId = 2,  Title ="Aşk-ı Memnu",  AuthorName = "Halit Ziya Uşaklıgil" ,  Description = "Beni beni Bihterini!" },
            new BookInformation { BookId = 3,  Title ="Uçurtma Avcısı",  AuthorName = " Khaled Hosseini",  Description = "Dostluk, arkadaşlık, sevgi..." }
        };
        public Task<BookInformation> GetBookInformationByIdAsync(GetBookInformationByIdRequest request)
        {
            //Id ye göre listeleme
            var loadedBookInformation = bookInformations.FirstOrDefault(a => a.BookId == request.BookId);
            return Task.FromResult(loadedBookInformation);
        }

        public Task<List<BookTitle>> GetBookTitleAsync()
        {
            //Kitapları listeleme
            var bookTitleList = bookInformations.Select(a => GetBookTitleForList(a)).ToList();
            return Task.FromResult(bookTitleList);
        }

        private static BookTitle GetBookTitleForList(BookInformation book)
        {
            return new BookTitle
            {
                BookId = book.BookId,
                Title = book.Title
            };
        }
    }
}
