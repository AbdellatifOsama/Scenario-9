using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Scenario_9_Backend.API.Dtos;
using Scenario_9_Backend.BLL.Interfaces;
using Scenario_9_Backend.BLL.Specifications.BooksSpecification;
using Scenario_9_Backend.BLL.Specifications.BooksSpecification.Filters;
using Scenario_9_Backend.DAL.Entities;

namespace Scenario_9_Backend.API.Controllers
{
    public class BooksController : BaseController
    {
        private readonly IBookRepository bookRepository;

        public BooksController(IBookRepository bookRepository)
        {
            this.bookRepository = bookRepository;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllBooks([FromQuery]BooksParams booksParams)
        {
            var bookspec = new BooksSpecification(booksParams);
            var books = await bookRepository.GetAllWithSpecAsync(bookspec);
            var CountSpec = new BookCountSpecification(booksParams);
            var booksCount = (await bookRepository.GetAllWithSpecAsync(CountSpec)).Count;
            return Ok(new PaginationDto<BookEntity>(booksParams.PageIndex,booksParams.PageSize, booksCount, books));
        }
        [HttpGet("Category")]
        public async Task<IActionResult> GetAllCategories()
        {
            var Categories = await bookRepository.GetCategories();
            return Ok(Categories);
        }
        [HttpGet("Filters")]
        public async Task<IActionResult> GetBooksWithFilters([FromQuery]BookFiltersParams bookFiltersParams)
        {
            var spec = new BookFiltersSpecification(bookFiltersParams);
            var items = (IReadOnlyList<BookEntity>) await bookRepository.GetBooksWithFilters(spec);
            var Count = (await bookRepository.GetBooksWithFilters(new GetFiltersCountSpec(bookFiltersParams))).Count();
            return Ok(new PaginationDto<BookEntity>(bookFiltersParams.PageIndex, bookFiltersParams.PageSize, Count,items));
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetBook(int id)
        {
            var book = await bookRepository.Get(id);
            if (book is not null)
                return Ok(book);
            return NotFound();
        }
    }
}
