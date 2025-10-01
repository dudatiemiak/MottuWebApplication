using Microsoft.AspNetCore.Mvc;
using MottuWebApplication.MottuWebApplication.Domain.Entities;
using MottuWebApplication.Application.Interfaces;

namespace MottuWebApplication.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BairroController : ControllerBase
    {
    private readonly IBairroService _service;

    public BairroController(IBairroService service) => _service = service;

        /// <summary>
        /// Retorna todos os bairros cadastrados.
        /// </summary>
        /// <returns>Lista de bairros.</returns>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Bairro>>> Get()
        {
            return Ok(await _service.GetAllBairrosAsync()); // 200 OK com a lista de bairros
        }

        /// <summary>
        /// Retorna um bairro específico pelo seu id.
        /// </summary>
    /// <param name="idBairro">Id do bairro.</param>
        [HttpGet("{idBairro}", Name = "GetBairro")]
        public async Task<ActionResult<Bairro>> Get(int idBairro)
        {
            var bairro = await _service.GetBairroByIdAsync(idBairro);

            if (bairro == null) return NotFound(); // 404 Not Found
            return Ok(bairro); // 200 OK com a entidade
        }

        /// <summary>
        /// Cria um novo bairro.
        /// </summary>
        /// <param name="bairro">Dados do bairro.</param>
        [HttpPost]
        public async Task<ActionResult> Post(Bairro bairro)
        {
            await _service.CreateBairroAsync(bairro);
            return CreatedAtRoute("GetBairro", new { idBairro = bairro.IdBairro }, bairro); // 201 Created com header Location e corpo do bairro criado
        }

        /// <summary>
        /// Atualiza um bairro existente.
        /// </summary>
        /// <param name="idBairro">Id do bairro.</param>
        /// <param name="bairro">Dados do bairro.</param>
        [HttpPut("{idBairro}")]
        public async Task<ActionResult> Put(int idBairro, Bairro bairroIn)
        {
            if (idBairro != bairroIn.IdBairro)
                return BadRequest(new { StatusCode = 400, Message = "ID da rota não corresponde ao objeto enviado." }); // 400 Bad Request (ID da rota difere do corpo)
            var ok = await _service.UpdateBairroAsync(idBairro, bairroIn);
            if (!ok) return NotFound(); // 404 Not Found quando não encontrado para atualização
            return NoContent(); // Retorna 204 No Content
        }

        /// <summary>
        /// Remove um bairro pelo seu id.
        /// </summary>
        /// <param name="idBairro">Id do bairro.</param>
        [HttpDelete("{idBairro}")]
        public async Task<ActionResult> Delete(int idBairro)
        {
            var existente = await _service.GetBairroByIdAsync(idBairro);
            if (existente == null) return NotFound(); // 404 Not Found quando não há registro para excluir
            var ok = await _service.DeleteBairroAsync(idBairro);
            if (!ok) return StatusCode(500, "Ocorreu um erro ao remover o bairro.");

            return NoContent(); // Retorna 204 No Content
        }
    }
}
