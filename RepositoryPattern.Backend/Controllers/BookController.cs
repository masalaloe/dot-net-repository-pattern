using Microsoft.AspNetCore.Mvc;
using RepositoryPattern.DataAccess.Interfaces;
using RepositoryPattern.Entity.Models;

namespace RepositoryPattern.Backend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BookController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger<BookController> _logger;

        public BookController(IUnitOfWork unitOfWork, ILogger<BookController> logger)
        {
            _unitOfWork = unitOfWork;
            _logger = logger;
        }

        // GET: api/<BookController>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var books = await _unitOfWork.Books.GetAllAsync();

            return Ok(books);
        }

        // GET api/<BookController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<BookController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] string bookName, int? authorId)
        {
            var item = new Book
            {
                Name = bookName,
                AuthorId = authorId
            };

            await _unitOfWork.Books.CreateAsync(entity: item);

            _unitOfWork.SaveChanges();

            return Ok();
        }


        // PUT api/<BookController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<BookController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }

    }
}