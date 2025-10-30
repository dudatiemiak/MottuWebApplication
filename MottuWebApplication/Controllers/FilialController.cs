using Microsoft.AspNetCore.Mvc;
using MottuWebApplication.MottuWebApplication.Domain.Entities;
using MottuWebApplication.Application.Interfaces;
using Microsoft.AspNetCore.Authorization;

namespace MottuWebApplication.Controllers
{
    [Authorize]
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
            return Ok(await _service.GetAllFiliaisAsync()); // 200 OK com a lista de filiais
        }

        /// <summary>
        /// Retorna uma filial específica pelo seu id.
        /// </summary>
        /// <param name="idFilial">Id da filial.</param>
        [HttpGet("{idFilial}", Name = "GetFilial")]
        public async Task<ActionResult<Filial>> Get(int idFilial)
        {
            var filial = await _service.GetFilialByIdAsync(idFilial);

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
            await _service.CreateFilialAsync(filial);
            return CreatedAtRoute("GetFilial", new { idFilial = filial.IdFilial }, filial); // 201 Created com Location e corpo da filial criada
        }

        /// <summary>
        /// Atualiza uma filial existente.
        /// </summary>
        /// <param name="idFilial">Id da filial.</param>
        /// <param name="filial">Dados da filial.</param>
        [HttpPut("{idFilial}")]
        public async Task<ActionResult> Put(int idFilial, Filial filialIn)
        {
            if (idFilial != filialIn.IdFilial)
                return BadRequest(new { StatusCode = 400, Message = "ID da rota não bate com o objeto enviado." }); // 400 Bad Request (ID divergente)
            var ok = await _service.UpdateFilialAsync(idFilial, filialIn);
            if (!ok) return NotFound(); // 404 Not Found se não existir para atualizar
            return NoContent(); // 204 No Content
        }

    /// <summary>
        /// Remove uma filial pelo seu id.
        /// </summary>
        /// <param name="idFilial">Id da filial.</param>
        [HttpDelete("{idFilial}")]
        public async Task<ActionResult> Delete(int idFilial)
        {
            var existente = await _service.GetFilialByIdAsync(idFilial);
            if (existente == null) return NotFound(); // 404 Not Found quando não há registro para excluir
            var ok = await _service.DeleteFilialAsync(idFilial);
            if (!ok) return StatusCode(500, "Ocorreu um erro ao remover a filial."); // 500 Internal Server Error em falha de exclusão

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
            return Ok(filiais); // 200 OK com a lista filtrada por nome
        }
    }    
}
