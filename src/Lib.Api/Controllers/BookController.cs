using lib.Domain;
using Lib.Application;
using Lib.Application.Contracts;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Lib.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BooksController : ControllerBase
    {

        private readonly IBookService _bookService;

        public BooksController(IBookService bookService)
        {
            _bookService = bookService;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<bookDto>> Get(int id)
        {
            var book = await _bookService.GetBookAsync(id);

            return Ok(book);
        }

    }
}
