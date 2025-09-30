using Microsoft.AspNetCore.Mvc;
using MottuWebApplication.MottuWebApplication.Domain.Entities;
using MottuWebApplication.Application.Interfaces;

namespace MottuWebApplication.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CidadeController : ControllerBase
    {
    private readonly ICidadeService _service;

    public CidadeController(ICidadeService service) => _service = service;


        /// <summary>
        /// Retorna todas as cidades cadastradas.
        /// </summary>
        /// <returns>Lista de cidades.</returns>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Cidade>>> Get()
        {
            return Ok(await _service.GetAllAsync());
        }

        /// <summary>
        /// Retorna uma cidade específica pelo seu id.
        /// </summary>
        /// <param name="idCidade">Id da cidade.</param>
        [HttpGet("{idCidade}", Name = "GetCidade")]
        public async Task<ActionResult<Cidade>> Get(int idCidade)
        {
            var cidade = await _service.GetByIdAsync(idCidade);

            if (cidade == null)
                return NotFound(); // 404 Not Found quando não encontrado
            return Ok(cidade); // 200 OK com a entidade
        }

        /// <summary>
        /// Cria uma nova cidade.
        /// </summary>
        /// <param name="cidade">Dados da cidade.</param>
        [HttpPost]
        public async Task<ActionResult> Post(Cidade cidade)
        {
            var created = await _service.CreateAsync(cidade);
            return CreatedAtRoute("GetCidade", new { idCidade = created.IdCidade }, created); // 201 Created com header 'Location'
        }

        /// <summary>
        /// Atualiza uma cidade existente.
        /// </summary>
        /// <param name="idCidade">Id da cidade.</param>
        /// <param name="cidade">Dados da cidade.</param>
        [HttpPut("{idCidade}")]
        public async Task<ActionResult> Put(int idCidade, Cidade cidade)
        {
            if (idCidade != cidade.IdCidade)
                return BadRequest(new { StatusCode = 400, Message = "ID da rota não corresponde ao objeto enviado." }); // 400 Bad Request quando o ID da rota não bate com o do corpo
            var existente = await _service.GetByIdAsync(idCidade);
            if (existente == null) return NotFound(); // 404 Not Found se não existir para atualizar

            try
            {
                await _service.UpdateAsync(cidade);
                return NoContent(); // Retorna 204 No Content
            }
            catch (Exception)
            {
                return StatusCode(500, "Ocorreu um erro ao atualizar a cidade."); // 500 Internal Server Error (concorrência/falha)
            }
        }

        /// <summary>
        /// Remove uma cidade pelo seu id.
        /// </summary>
        /// <param name="idCidade">Id da cidade.</param>
        [HttpDelete("{idCidade}")]
        public async Task<ActionResult> Delete(int idCidade)
        {
            var ok = await _service.DeleteAsync(idCidade);
            if (!ok) return NotFound(); // 404 Not Found quando não há o que remover

            return NoContent(); // 204 No Content
        }
    }
}
