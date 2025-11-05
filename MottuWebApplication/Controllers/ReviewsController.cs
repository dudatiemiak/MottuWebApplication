using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MottuWebApplication.Application.Services;
using MottuWebApplication.Domain.Entities;
using MottuWebApplication.Infrastructure.Data;


namespace MottuWebApplication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReviewsController : ControllerBase
    {
        private readonly AppDbContext _context;
        private readonly IPredictionService _predictionService;

        public ReviewsController(AppDbContext context, IPredictionService predictionService)
        {
            _context = context;
            _predictionService = predictionService;
        }

        // GET: api/Reviews
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Review>>> GetReviews()
        {
            return await _context.Reviews.ToListAsync();
        }

        // GET: api/Reviews/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Review>> GetReview(int id)
        {
            var review = await _context.Reviews.FindAsync(id);

            if (review == null)
            {
                return NotFound();
            }

            return review;
        }

        // POST: api/Reviews  
        [HttpPost]
        public async Task<ActionResult<Review>> PostReview(CreateReview reviewDto)
        {
            var modelInput = new ModelInput
            {
                KmRodados = reviewDto.KmRodados,
                DiasDesdeUltimaManutencao = reviewDto.DiasDesdeUltimaManutencao
            };

            // Use the wrapper service (easy to mock in tests)  
            var prediction = _predictionService.PredictManutencao(modelInput);

            var review = new Review
            {
                KmRodados = reviewDto.KmRodados,
                DiasDesdeUltimaManutencao = reviewDto.DiasDesdeUltimaManutencao,
                PredictedManutencao = prediction.PredicaoPrecisaManutencao ? "Positivo" : "Negativo",
                ManutencaoScore = prediction.Score
            };

            _context.Reviews.Add(review);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetReview), new { id = review.Id }, review);
        }

        // DELETE: api/Reviews/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteReview(int id)
        {
            var review = await _context.Reviews.FindAsync(id);
            if (review == null)
            {
                return NotFound();
            }

            _context.Reviews.Remove(review);
            await _context.SaveChangesAsync();

            return NoContent();
        }


    }
}