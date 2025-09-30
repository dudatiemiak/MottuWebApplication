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
            return Ok(await _service.GetAllAsync());
        }

        /// <summary>
        /// Retorna um modelo de moto pelo seu id.
        /// </summary>
        /// <param name="idModelo">Id do modelo.</param>
        [HttpGet("{idModelo}", Name = "GetModelo")]
        public async Task<ActionResult<Modelo>> Get(int idModelo)
        {
            var modelo = await _service.GetByIdAsync(idModelo);
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
            var created = await _service.CreateAsync(modelo);
            return CreatedAtRoute("GetModelo", new { idModelo = created.IdModelo }, created); // 201 Created com header 'Location'
        }

        /// <summary>
        /// Atualiza um modelo existente.
        /// </summary>
        /// <param name="idModelo">Id do modelo.</param>
        /// <param name="modelo">Dados do modelo.</param>
        [HttpPut("{idModelo}")]
        public async Task<ActionResult> Put(int idModelo, Modelo modelo)
        {
            if (idModelo != modelo.IdModelo)
                return BadRequest(new { StatusCode = 400, Message = "ID da rota não corresponde ao objeto enviado." });
            var existente = await _service.GetByIdAsync(idModelo);
            if (existente == null) return NotFound();
            try
            {
                await _service.UpdateAsync(modelo);
                return NoContent(); // Retorna 204 No Content
            }
            catch (Exception)
            {
                // Pode indicar um problema de concorrência ou falha na atualização
                return StatusCode(500, "Ocorreu um erro ao atualizar o modelo.");
            }
        }

        /// <summary>
        /// Remove um modelo pelo seu id.
        /// </summary>
        /// <param name="idModelo">Id do modelo.</param>
        [HttpDelete("{idModelo}")]
        public async Task<ActionResult> Delete(int idModelo)
        {
            var existente = await _service.GetByIdAsync(idModelo);
            if (existente == null) return NotFound();
            var ok = await _service.DeleteAsync(idModelo);
            if (!ok) return StatusCode(500, "Ocorreu um erro ao remover o modelo.");

            return NoContent(); // Retorna 204 No Content
        }
    }
}
