using Microsoft.AspNetCore.Mvc;
using MottuWebApplication.MottuWebApplication.Domain.Entities;
using MottuWebApplication.Application.Interfaces;
using Microsoft.AspNetCore.Authorization;

namespace MottuWebApplication.Controllers
{
    [Authorize]
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
            return Ok(await _service.GetAllEstadosAsync()); // 200 OK com a lista de estados
        }

        /// <summary>
        /// Retorna um estado específico pelo seu id.
        /// </summary>
        /// <param name="idEstado">Id do estado.</param>
        [HttpGet("{idEstado}", Name = "GetEstado")]
        public async Task<ActionResult<Estado>> Get(int idEstado)
        {
            var estado = await _service.GetEstadoByIdAsync(idEstado);

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
            await _service.CreateEstadoAsync(estado);
            return CreatedAtRoute("GetEstado", new { idEstado = estado.IdEstado }, estado); // 201 Created com Location e corpo do estado criado
        }

        /// <summary>
        /// Atualiza um estado existente.
        /// </summary>
        /// <param name="idEstado">Id do estado.</param>
        /// <param name="estado">Dados do estado.</param>
        [HttpPut("{idEstado}")]
        public async Task<ActionResult> Put(int idEstado, Estado estadoIn)
        {
            if (idEstado != estadoIn.IdEstado)
                return BadRequest(new { StatusCode = 400, Message = "ID da rota não corresponde ao objeto enviado." }); // 400 Bad Request (ID divergente)
            var ok = await _service.UpdateEstadoAsync(idEstado, estadoIn);
            if (!ok) return NotFound(); // 404 Not Found se não existir para atualizar
            return NoContent(); // 204 No Content
        }

        /// <summary>
        /// Remove um estado pelo seu id.
        /// </summary>
    /// <param name="idEstado">Id do estado.</param>
        [HttpDelete("{idEstado}")]
        public async Task<ActionResult> Delete(int idEstado)
        {
            var existente = await _service.GetEstadoByIdAsync(idEstado);
            if (existente == null) return NotFound(); // 404 Not Found quando não há registro para excluir

            var ok = await _service.DeleteEstadoAsync(idEstado);
            if (!ok) return StatusCode(500, "Ocorreu um erro ao remover o estado."); // 500 Internal Server Error em falha de exclusão

            return NoContent(); // 204 No Content
        }
    }
}
