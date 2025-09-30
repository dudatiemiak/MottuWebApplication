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
            return Ok(await _service.GetAllAsync());
        }

        /// <summary>
        /// Retorna um país pelo seu id.
        /// </summary>
        /// <param name="idPais">Id do país.</param>
        [HttpGet("{idPais}", Name = "GetPais")]
        public async Task<ActionResult<Pais>> Get(int idPais)
        {
            var pais = await _service.GetByIdAsync(idPais);
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
            var created = await _service.CreateAsync(pais);
            return CreatedAtRoute("GetPais", new { idPais = created.IdPais }, created); // 201 Created com header 'Location'
        }

        /// <summary>
        /// Atualiza um país existente.
        /// </summary>
        /// <param name="idPais">Id do país.</param>
        /// <param name="pais">Dados do país.</param>
        [HttpPut("{idPais}")]
        public async Task<ActionResult> Put(int idPais, Pais pais)
        {
            if (idPais != pais.IdPais)
                return BadRequest(new { StatusCode = 400, Message = "ID da rota não corresponde ao objeto enviado." }); // 400 Bad Request id mismatch
            var existente = await _service.GetByIdAsync(idPais);
            if (existente == null) return NotFound(); // 404 Not Found se não existir
            try
            {
                await _service.UpdateAsync(pais);
                return NoContent(); // Retorna 204 No Content
            }
            catch (Exception)
            {
                return StatusCode(500, "Ocorreu um erro ao atualizar o país."); // 500 Internal Server Error (concorrência/falha)
            }
        }

        /// <summary>
        /// Remove um país pelo seu id.
        /// </summary>
        /// <param name="idPais">Id do país.</param>
        [HttpDelete("{idPais}")]
        public async Task<ActionResult> Delete(int idPais)
        {
            var existente = await _service.GetByIdAsync(idPais);
            if (existente == null) return NotFound();
            var ok = await _service.DeleteAsync(idPais);
            if (!ok) return StatusCode(500, "Ocorreu um erro ao remover o país."); // 500 em falha de exclusão 

            return NoContent(); // 204 No Content
        }
    }
}
