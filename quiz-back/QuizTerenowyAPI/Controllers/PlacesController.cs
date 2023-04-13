using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using QuizTerenowyAPI.Models;

namespace QuizTerenowyAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlacesController : ControllerBase
    {
        private readonly AppDbContext context;
        public PlacesController(AppDbContext context)
        {
            this.context = context;
        }
        // GET: api/<PlacesController>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Place>>> Get()
        {
            var places = await (context.Places
                .Include(p => p.Questions)
                .Select(p => new
                {
                    id = p.Id,
                    name = p.Name,
                    description = p.Description,
                    lon = p.Lon,
                    lat = p.Lat,
                    //questions = p.Questions.ToArray(),
                    questions = p.Questions.Select(q => new
                    {
                        qDescription = q.Description,
                        qAnswer = q.Answer,
                        qOptions = new string[] { q.Option1, q.Option2, q.Option3 }
                    }).ToArray()
                    /* new []
                    {
                        
                        qDescription = p.Questions.Select(q=>q.Description),
                        qAnswer = p.Questions.Select(q=>q.Answer),
                        qOpt1 = p.Questions.Select(q=>q.Option1),
                        qOpt2 = p.Questions.Select(q=>q.Option2),
                        qOpt3 = p.Questions.Select(q=>q.Option3)
                    }*/
                })
                .ToListAsync());
            return Ok(places);        
        }

        // GET api/<PlacesController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Place>> Get(int id)
        {
            var place = await(context.Places
                .Include(p=>p.Questions)
                .FirstOrDefaultAsync(x => x.Id == id));
            return Ok(place);
        }
    }
}
