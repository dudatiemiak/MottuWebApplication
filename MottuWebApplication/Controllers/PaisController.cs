using Microsoft.AspNetCore.Mvc;
using MottuWebApplication.MottuWebApplication.Domain.Entities;
using MottuWebApplication.Application.Interfaces;

namespace MottuWebApplication.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PaisController : ControllerBase
    {
    private readonly IPaisService _service;

    public PaisController(IPaisService service) => _service = service;

        /// <summary>
        /// Retorna todos os países cadastrados.
        /// </summary>
        /// <returns>Lista de países.</returns>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Pais>>> Get()
        {
            return Ok(await _service.GetAllPaisesAsync());
        }

        /// <summary>
        /// Retorna um país pelo seu id.
        /// </summary>
        /// <param name="idPais">Id do país.</param>
        [HttpGet("{idPais}", Name = "GetPais")]
        public async Task<ActionResult<Pais>> Get(int idPais)
        {
            var pais = await _service.GetPaisByIdAsync(idPais);
            if (pais == null)
                return NotFound(); // 404 Not Found quando não encontrado
            return Ok(pais); // 200 OK com a entidade
        }

        /// <summary>
        /// Cadastra um novo país.
        /// </summary>
        /// <param name="pais">Dados do país.</param>
        [HttpPost]
        public async Task<ActionResult> Post(Pais pais)
        {
            await _service.CreatePaisAsync(pais);
            return CreatedAtRoute("GetPais", new { idPais = pais.IdPais }, pais);
        }

        /// <summary>
        /// Atualiza um país existente.
        /// </summary>
        /// <param name="idPais">Id do país.</param>
        /// <param name="pais">Dados do país.</param>
        [HttpPut("{idPais}")]
        public async Task<ActionResult> Put(int idPais, Pais paisIn)
        {
            if (idPais != paisIn.IdPais)
                return BadRequest(new { StatusCode = 400, Message = "ID da rota não corresponde ao objeto enviado." });
            var ok = await _service.UpdatePaisAsync(idPais, paisIn);
            if (!ok) return NotFound();
            return NoContent();
        }

        /// <summary>
        /// Remove um país pelo seu id.
        /// </summary>
        /// <param name="idPais">Id do país.</param>
        [HttpDelete("{idPais}")]
        public async Task<ActionResult> Delete(int idPais)
        {
            var existente = await _service.GetPaisByIdAsync(idPais);
            if (existente == null) return NotFound();
            var ok = await _service.DeletePaisAsync(idPais);
            if (!ok) return StatusCode(500, "Ocorreu um erro ao remover o país."); // 500 em falha de exclusão 

            return NoContent(); // 204 No Content
        }
    }
}
