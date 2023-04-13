using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using QuizTerenowyAPI.Models;

namespace QuizTerenowyAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QuestionsController : ControllerBase
    {
        private readonly AppDbContext context;
        public QuestionsController(AppDbContext context)
        {
            this.context = context;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Question>> GetById(int id)
        {
            var question = await (context.Questions
                .FirstOrDefaultAsync(q=>q.Id==id));
            return question != null ? Ok(question) : NotFound();
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Question>>> GetAll()
        {
            var questions = await (context.Questions.ToListAsync());
            return Ok(questions);
        }
        [HttpPost]
        public async Task<ActionResult<Question>> Create(Question question)
        {
            context.Questions.Add(question);
            await context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetById), new { Id = question.Id }, question);
        }

    }
}
