using Microsoft.AspNetCore.Mvc;
using MottuWebApplication.MottuWebApplication.Domain.Entities;
using MottuWebApplication.Application.Interfaces;

namespace MottuWebApplication.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EstadoController : ControllerBase
    {
    private readonly IEstadoService _service;

    public EstadoController(IEstadoService service) => _service = service;

        /// <summary>
        /// Retorna todos os estados cadastrados.
        /// </summary>
        /// <returns>Lista de estados.</returns>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Estado>>> Get()
        {
            return Ok(await _service.GetAllAsync());
        }

        /// <summary>
        /// Retorna um estado específico pelo seu id.
        /// </summary>
        /// <param name="idEstado">Id do estado.</param>
        [HttpGet("{idEstado}", Name = "GetEstado")]
        public async Task<ActionResult<Estado>> Get(int idEstado)
        {
            var estado = await _service.GetByIdAsync(idEstado);

            if (estado == null)
                return NotFound(); // 404 Not Found quando não encontrado
            return Ok(estado); // 200 OK com a entidade
        }

        /// <summary>
        /// Cria um novo estado.
        /// </summary>
        /// <param name="estado">Dados do estado.</param>
        [HttpPost]
        public async Task<ActionResult> Post(Estado estado)
        {
            var created = await _service.CreateAsync(estado);
            return CreatedAtRoute("GetEstado", new { idEstado = created.IdEstado }, created); // 201 Created com header 'Location'
        }

        /// <summary>
        /// Atualiza um estado existente.
        /// </summary>
        /// <param name="idEstado">Id do estado.</param>
        /// <param name="estado">Dados do estado.</param>
        [HttpPut("{idEstado}")]
        public async Task<ActionResult> Put(int idEstado, Estado estado)
        {
            if (idEstado != estado.IdEstado)
                return BadRequest(new { StatusCode = 400, Message = "ID da rota não corresponde ao objeto enviado." }); // 400 Bad Request quando IDs não correspondem
            var existente = await _service.GetByIdAsync(idEstado);
            if (existente == null) return NotFound(); // 404 Not Found se não existir para atualizar
            try
            {
                await _service.UpdateAsync(estado);
                return NoContent(); // Retorna 204 No Content
            }
            catch (Exception)
            {
                return StatusCode(500, "Ocorreu um erro ao atualizar o estado."); // 500 Internal Server Error (concorrência/falha)
            }
        }

        /// <summary>
        /// Remove um estado pelo seu id.
        /// </summary>
    /// <param name="idEstado">Id do estado.</param>
        [HttpDelete("{idEstado}")]
        public async Task<ActionResult> Delete(int idEstado)
        {
            var existente = await _service.GetByIdAsync(idEstado);
            if (existente == null) return NotFound();

            var ok = await _service.DeleteAsync(idEstado);
            if (!ok) return StatusCode(500, "Ocorreu um erro ao remover o estado."); // 500 em falha de exclusão

            return NoContent(); // 204 No Content
        }
    }
}
