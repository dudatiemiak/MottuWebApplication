using Microsoft.AspNetCore.Mvc;
using MottuWebApplication.MottuWebApplication.Domain.Entities;
using MottuWebApplication.Application.Interfaces;

namespace MottuWebApplication.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LogradouroController : ControllerBase
    {
    private readonly ILogradouroService _service;

    public LogradouroController(ILogradouroService service) => _service = service;

        /// <summary>
        /// Retorna todos os logradouros.
        /// </summary>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Logradouro>>> Get() => Ok(await _service.GetAllAsync());

        /// <summary>
        /// Retorna um logradouro pelo identificador.
        /// </summary>
        /// <param name="idLogradouro">Identificador do logradouro.</param>
        [HttpGet("{idLogradouro}", Name = "GetLogradouro")]
        public async Task<ActionResult<Logradouro>> Get(int idLogradouro)
        {
            var logradouro = await _service.GetByIdAsync(idLogradouro);

            if (logradouro == null)
                return NotFound(); // 404 Not Found quando não encontrado

            return Ok(logradouro); // 200 OK com a entidade
        }

        /// <summary>
        /// Cadastra um novo logradouro.
        /// </summary>
        /// <param name="logradouro">Dados do logradouro.</param>
        [HttpPost]
        public async Task<ActionResult> Post(Logradouro logradouro)
        {
            var created = await _service.CreateAsync(logradouro);
            return CreatedAtRoute("GetLogradouro", new { idLogradouro = created.IdLogradouro }, created); // 201 Created com header 'Location'
        }

        /// <summary>
        /// Atualiza um logradouro existente.
        /// </summary>
        /// <param name="idLogradouro">Identificador do logradouro.</param>
        /// <param name="logradouro">Dados do logradouro.</param>
        [HttpPut("{idLogradouro}")]
        public async Task<ActionResult> Put(int idLogradouro, Logradouro logradouro)
        {
            if (idLogradouro != logradouro.IdLogradouro)
                return BadRequest(new { StatusCode = 400, Message = "ID da rota não corresponde ao objeto enviado." });
            var existente = await _service.GetByIdAsync(idLogradouro);
            if (existente == null) return NotFound();
            try
            {
                await _service.UpdateAsync(logradouro);
                return NoContent(); // Retorna 204 No Content
            }
            catch (Exception)
            {
                // Pode indicar um problema de concorrência ou falha na atualização
                return StatusCode(500, "Ocorreu um erro ao atualizar o logradouro.");
            }
        }

        /// <summary>
        /// Remove um logradouro pelo seu identificador.
        /// </summary>
        /// <param name="idLogradouro">Identificador do logradouro.</param>
        [HttpDelete("{idLogradouro}")]
        public async Task<ActionResult> Delete(int idLogradouro)
        {
            var existente = await _service.GetByIdAsync(idLogradouro);
            if (existente == null) return NotFound();
            var ok = await _service.DeleteAsync(idLogradouro);
            if (!ok) return StatusCode(500, "Ocorreu um erro ao remover o logradouro.");

            return NoContent(); // Retorna 204 No Content
        }
    }
}
