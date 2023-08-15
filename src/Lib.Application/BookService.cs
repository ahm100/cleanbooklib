using lib.Domain;
using Lib.Application.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lib.Application
{
    public class BookService : IBookService
    {
        private readonly IBookRepository _bookRepository;

        public BookService(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }

       
        public async Task<bookDto> GetBookAsync(int id)
        {
            var book = await _bookRepository.GetBookAsync(id);
            return book;
        }
    }
}
