using Microsoft.AspNetCore.Mvc;
using MottuWebApplication.MottuWebApplication.Domain.Entities;
using MottuWebApplication.Application.Interfaces;
using Microsoft.AspNetCore.Authorization;

namespace MottuWebApplication.Controllers
{
    [Authorize]
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
            return Ok(await _service.GetAllCidadesAsync()); // 200 OK com a lista de cidades
        }

        /// <summary>
        /// Retorna uma cidade específica pelo seu id.
        /// </summary>
        /// <param name="idCidade">Id da cidade.</param>
        [HttpGet("{idCidade}", Name = "GetCidade")]
        public async Task<ActionResult<Cidade>> Get(int idCidade)
        {
            var cidade = await _service.GetCidadeByIdAsync(idCidade);

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
            await _service.CreateCidadeAsync(cidade);
            return CreatedAtRoute("GetCidade", new { idCidade = cidade.IdCidade }, cidade); // 201 Created com Location apontando para o recurso e corpo com a cidade criada
        }

        /// <summary>
        /// Atualiza uma cidade existente.
        /// </summary>
        /// <param name="idCidade">Id da cidade.</param>
        /// <param name="cidade">Dados da cidade.</param>
        [HttpPut("{idCidade}")]
        public async Task<ActionResult> Put(int idCidade, Cidade cidadeIn)
        {
            if (idCidade != cidadeIn.IdCidade)
                return BadRequest(new { StatusCode = 400, Message = "ID da rota não corresponde ao objeto enviado." }); // 400 Bad Request (ID divergente)
            var ok = await _service.UpdateCidadeAsync(idCidade, cidadeIn);
            if (!ok) return NotFound(); // 404 Not Found caso não exista para atualizar
            return NoContent(); // 204 No Content (atualização bem-sucedida, sem corpo)
        }

        /// <summary>
        /// Remove uma cidade pelo seu id.
        /// </summary>
        /// <param name="idCidade">Id da cidade.</param>
        [HttpDelete("{idCidade}")]
        public async Task<ActionResult> Delete(int idCidade)
        {
            var ok = await _service.DeleteCidadeAsync(idCidade);
            if (!ok) return NotFound(); // 404 Not Found quando não há o que remover

            return NoContent(); // 204 No Content
        }
    }
}
