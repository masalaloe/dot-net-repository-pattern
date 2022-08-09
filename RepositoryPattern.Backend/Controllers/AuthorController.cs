using Microsoft.AspNetCore.Mvc;
using RepositoryPattern.DataAccess.Interfaces;
using RepositoryPattern.Entity.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace RepositoryPattern.Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger<BookController> _logger;

        public AuthorController(IUnitOfWork unitOfWork, ILogger<BookController> logger)
        {
            _unitOfWork = unitOfWork;
            _logger = logger;
        }

        // GET: api/<AuthorController>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var authors = await _unitOfWork.Authors.GetAllAsync();

            return Ok(authors);
        }

        // GET api/<AuthorController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }
        
        // GET api/<AuthorController>/5/Books
        [HttpGet("{id}/Books")]
        public async Task<IActionResult> GetBooksByAuthor(int id)
        {
            var books = await _unitOfWork.Books.GetBooksByAuthorAsync(id);

            return Ok(books);
        }

        // POST api/<AuthorController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] string authorName)
        {
            await _unitOfWork.Authors.CreateAsync(new Author { Name = authorName });

            await _unitOfWork.SaveChangesAsync();

            return Ok();
        }

        // PUT api/<AuthorController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<AuthorController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
