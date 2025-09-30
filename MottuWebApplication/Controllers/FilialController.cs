using Microsoft.AspNetCore.Mvc;
using MottuWebApplication.MottuWebApplication.Domain.Entities;
using MottuWebApplication.Application.Interfaces;

namespace MottuWebApplication.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class FilialController : ControllerBase
    {
    private readonly IFilialService _service;

    public FilialController(IFilialService service) => _service = service;

        /// <summary>
        /// Retorna todas as filiais cadastradas.
        /// </summary>
        /// <returns>Lista de filiais.</returns>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Filial>>> Get()
        {
            return Ok(await _service.GetAllAsync());
        }

        /// <summary>
        /// Retorna uma filial específica pelo seu id.
        /// </summary>
        /// <param name="idFilial">Id da filial.</param>
        [HttpGet("{idFilial}", Name = "GetFilial")]
        public async Task<ActionResult<Filial>> Get(int idFilial)
        {
            var filial = await _service.GetByIdAsync(idFilial);

            if (filial == null)
                return NotFound(); // 404 Not Found quando não encontrado

            return Ok(filial); // 200 OK com a entidade
        }

        /// <summary>
        /// Cria uma nova filial.
        /// </summary>
        /// <param name="filial">Dados da filial.</param>
        [HttpPost]
        public async Task<ActionResult> Post(Filial filial)
        {
            var created = await _service.CreateAsync(filial);
            return CreatedAtRoute("GetFilial", new { idFilial = created.IdFilial }, created); // 201 Created com header 'Location'
        }

        /// <summary>
        /// Atualiza uma filial existente.
        /// </summary>
        /// <param name="idFilial">Id da filial.</param>
        /// <param name="filial">Dados da filial.</param>
        [HttpPut("{idFilial}")]
        public async Task<ActionResult> Put(int idFilial, Filial filial)
        {
            if (idFilial != filial.IdFilial)
                return BadRequest(new { StatusCode = 400, Message = "ID da rota não bate com o objeto enviado." }); // 400 Bad Request id mismatch
            var existente = await _service.GetByIdAsync(idFilial);
            if (existente == null) return NotFound(); // 404 Not Found se não existir
            try
            {
                await _service.UpdateAsync(filial);
                return NoContent(); // Retorna 204 No Content
            }
            catch (Exception)
            {
                return StatusCode(500, "Ocorreu um erro ao atualizar a filial."); // 500 Internal Server Error (concorrência/falha)
            }
        }

    /// <summary>
        /// Remove uma filial pelo seu id.
        /// </summary>
        /// <param name="idFilial">Id da filial.</param>
        [HttpDelete("{idFilial}")]
        public async Task<ActionResult> Delete(int idFilial)
        {
            var existente = await _service.GetByIdAsync(idFilial);
            if (existente == null) return NotFound();
            var ok = await _service.DeleteAsync(idFilial);
            if (!ok) return StatusCode(500, "Ocorreu um erro ao remover a filial."); // 500 em falha de exclusão

            return NoContent(); // 204 No Content
        }

        /// <summary>
        /// Retorna todas as filiais cujo nome contenha o valor informado.
        /// </summary>
        [HttpGet("nome/{nome}")]
        public async Task<ActionResult<IEnumerable<Filial>>> GetByNome(string nome)
        {
            // optional custom filter preserved via service
            var filiais = await _service.GetByNomeAsync(nome);
            return Ok(filiais);
        }
    }    
}
