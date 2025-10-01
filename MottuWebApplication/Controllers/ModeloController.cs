using Microsoft.AspNetCore.Mvc;
using MottuWebApplication.MottuWebApplication.Domain.Entities;
using MottuWebApplication.Application.Interfaces;

namespace MottuWebApplication.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ModeloController : ControllerBase
    {
    private readonly IModeloService _service;

        public ModeloController(IModeloService service)
            => _service = service;

        /// <summary>
        /// Retorna todos os modelos cadastrados.
        /// </summary>
        /// <returns>Lista de modelos.</returns>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Modelo>>> Get()
        {
            return Ok(await _service.GetAllModelosAsync());
        }

        /// <summary>
        /// Retorna um modelo de moto pelo seu id.
        /// </summary>
        /// <param name="idModelo">Id do modelo.</param>
        [HttpGet("{idModelo}", Name = "GetModelo")]
        public async Task<ActionResult<Modelo>> Get(int idModelo)
        {
            var modelo = await _service.GetModeloByIdAsync(idModelo);
            if (modelo == null)
                return NotFound(); // 404 Not Found quando não encontrado
            return Ok(modelo); // 200 OK com a entidade
        }

        /// <summary>
        /// Cadastra um novo modelo.
        /// </summary>
        /// <param name="modelo">Dados do modelo.</param>
        [HttpPost]
        public async Task<ActionResult> Post(Modelo modelo)
        {
            await _service.CreateModeloAsync(modelo);
            return CreatedAtRoute("GetModelo", new { idModelo = modelo.IdModelo }, modelo);
        }

        /// <summary>
        /// Atualiza um modelo existente.
        /// </summary>
        /// <param name="idModelo">Id do modelo.</param>
        /// <param name="modelo">Dados do modelo.</param>
        [HttpPut("{idModelo}")]
        public async Task<ActionResult> Put(int idModelo, Modelo modeloIn)
        {
            if (idModelo != modeloIn.IdModelo)
                return BadRequest(new { StatusCode = 400, Message = "ID da rota não corresponde ao objeto enviado." });
            var ok = await _service.UpdateModeloAsync(idModelo, modeloIn);
            if (!ok) return NotFound();
            return NoContent();
        }

        /// <summary>
        /// Remove um modelo pelo seu id.
        /// </summary>
        /// <param name="idModelo">Id do modelo.</param>
        [HttpDelete("{idModelo}")]
        public async Task<ActionResult> Delete(int idModelo)
        {
            var existente = await _service.GetModeloByIdAsync(idModelo);
            if (existente == null) return NotFound();
            var ok = await _service.DeleteModeloAsync(idModelo);
            if (!ok) return StatusCode(500, "Ocorreu um erro ao remover o modelo.");

            return NoContent(); // Retorna 204 No Content
        }
    }
}
