using Microsoft.AspNetCore.Mvc;
using MottuWebApplication.MottuWebApplication.Domain.Entities;
using MottuWebApplication.Application.Interfaces;

namespace MottuWebApplication.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ManutencaoController : ControllerBase
    {
    private readonly IManutencaoService _service;

    public ManutencaoController(IManutencaoService service) => _service = service;

        /// <summary>
        /// Retorna todas as manutenções cadastradas.
        /// </summary>
        /// <returns>Lista de manutenções.</returns>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Manutencao>>> Get() => Ok(await _service.GetAllManutencoesAsync());

        /// <summary>
        /// Retorna uma manutenção específica pelo id.
        /// </summary>
        /// <param name="idManutencao">Id da manutenção.</param>
    [HttpGet("{idManutencao}", Name = "GetManutencao")]
        public async Task<ActionResult<Manutencao>> Get(int idManutencao)
        {
            var manutencao = await _service.GetManutencaoByIdAsync(idManutencao);

            if (manutencao == null)
                return NotFound(); // 404 Not Found quando não encontrado

            return Ok(manutencao); // 200 OK com a entidade
        }

        /// <summary>
        /// Cria uma nova manutenção.
        /// </summary>
        /// <param name="manutencao">Dados da manutenção.</param>
        [HttpPost]
        public async Task<ActionResult> Post(Manutencao manutencao)
        {
            await _service.CreateManutencaoAsync(manutencao);
            return CreatedAtRoute("GetManutencao", new { idManutencao = manutencao.IdManutencao }, manutencao);
        }

        /// <summary>
        /// Atualiza uma manutenção existente.
        /// </summary>
        /// <param name="idManutencao">Id da manutenção.</param>
        /// <param name="manutencao">Dados da manutenção.</param>
        [HttpPut("{idManutencao}")]
        public async Task<ActionResult> Put(int idManutencao, Manutencao manutencaoIn)
        {
            if (idManutencao != manutencaoIn.IdManutencao)
                return BadRequest(new { StatusCode = 400, Message = "ID da manutenção não corresponde ao objeto enviado." });
            var ok = await _service.UpdateManutencaoAsync(idManutencao, manutencaoIn);
            if (!ok) return NotFound();
            return NoContent();
        }

        /// <summary>
        /// Remove uma manutenção pelo seu id.
        /// </summary>
        /// <param name="idManutencao">Id da manutenção.</param>
        [HttpDelete("{idManutencao}")]
        public async Task<ActionResult> Delete(int idManutencao)
        {
            var ok = await _service.DeleteManutencaoAsync(idManutencao);
            if (!ok) return NotFound();

            return NoContent(); // Retorna 204 No Content
        }

        /// <summary>
        /// Retorna todas as manutenções de uma moto específica.
        /// </summary>
        [HttpGet("moto/{idMoto}")]
        public async Task<ActionResult<IEnumerable<Manutencao>>> GetByMoto(int idMoto)
        {
            var manutencoes = await _service.GetByMotoAsync(idMoto);
            return Ok(manutencoes);
        }

        /// <summary>
        /// Retorna manutenções realizadas a partir de uma determinada data.
        /// </summary>
        [HttpGet("dataentrada/{data}")]
        public async Task<ActionResult<IEnumerable<Manutencao>>> GetByDataEntrada(DateTime data)
        {
            var manutencoes = await _service.GetByDataEntradaAsync(data);
            return Ok(manutencoes);
        }
    }
}
