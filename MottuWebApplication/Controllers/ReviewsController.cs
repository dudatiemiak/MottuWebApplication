using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MottuWebApplication.Application.Services;
using MottuWebApplication.Domain.Entities;
using MottuWebApplication.Infrastructure.Data;


namespace MottuWebApplication.Controllers
{
    /// <summary>
    /// Controller responsável por operações relacionadas a avaliações (Reviews).
    /// Integra com o serviço de predição ML.NET para estimar necessidade de manutenção
    /// com base nos dados informados (km rodados e dias desde a última manutenção).
    /// </summary>
    [Authorize]
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

        /// <summary>
        /// Retorna todas as avaliações cadastradas.
        /// </summary>
        /// <returns>Lista de <see cref="Review"/>.</returns>
        // GET: api/Reviews
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Review>>> GetReviews()
        {
            return await _context.Reviews.ToListAsync();
        }

        /// <summary>
        /// Retorna uma avaliação específica por Id.
        /// </summary>
        /// <param name="id">Identificador da avaliação.</param>
        /// <returns>A avaliação solicitada ou NotFound se não existir.</returns>
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

    /// <summary>
    /// Recebe dados de uma avaliação (km rodados e dias desde a última manutenção),
    /// executa a predição de necessidade de manutenção usando o serviço ML.NET e
    /// persiste o resultado no banco.
    /// </summary>
    /// <param name="reviewDto">Dados usados para predição e persistência.</param>
    /// <returns>Objeto <see cref="Review"/> criado com o resultado da predição.</returns>
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

        /// <summary>
        /// Remove uma avaliação existente.
        /// </summary>
        /// <param name="id">Identificador da avaliação a ser removida.</param>
        /// <returns>NoContent em caso de sucesso, NotFound se não existir.</returns>
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