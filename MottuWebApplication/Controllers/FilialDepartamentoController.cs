using Microsoft.AspNetCore.Mvc;
using MottuWebApplication.MottuWebApplication.Domain.Entities;
using MottuWebApplication.Application.Interfaces;

namespace MottuWebApplication.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class FilialDepartamentoController : ControllerBase
    {
    private readonly IFilialDepartamentoService _service;

    public FilialDepartamentoController(IFilialDepartamentoService service) => _service = service;

        /// <summary>
        /// Retorna todas as relações filial-departamento cadastradas.
        /// </summary>
        /// <returns>Lista de relações filial-departamento.</returns>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<FilialDepartamento>>> Get()
        {
            return Ok(await _service.GetAllFilialDepartamentosAsync()); // 200 OK com a lista de relações
        }

        /// <summary>
        /// Retorna uma relação filial-departamento pelo seu id.
        /// </summary>
        /// <param name="idFilialDepartamento">Id da relação.</param>
        [HttpGet("{idFilialDepartamento}", Name = "GetFilialDepartamento")]
        public async Task<ActionResult<FilialDepartamento>> Get(int idFilialDepartamento)
        {
            var filialDepartamento = await _service.GetFilialDepartamentoByIdAsync(idFilialDepartamento);

            if (filialDepartamento == null)
                return NotFound(); // 404 Not Found quando não encontrado
            return Ok(filialDepartamento); // 200 OK com a entidade
        }

        /// <summary>
        /// Cadastra uma nova relação filial-departamento.
        /// </summary>
        /// <param name="filialDepartamento">Dados da relação.</param>
        [HttpPost]
        public async Task<ActionResult> Post(FilialDepartamento filialDepartamento)
        {
            if (filialDepartamento.DtEntrada == default)
                return BadRequest(new { StatusCode = 400, Message = "A data de entrada é obrigatória." }); // 400 Bad Request (validação de entrada)

            await _service.CreateFilialDepartamentoAsync(filialDepartamento);
            return CreatedAtRoute("GetFilialDepartamento", new { idFilialDepartamento = filialDepartamento.IdFilialDepartamento }, filialDepartamento); // 201 Created com Location e corpo do recurso criado
        }

        /// <summary>
        /// Atualiza uma relação filial-departamento existente.
        /// </summary>
        /// <param name="idFilialDepartamento">Id da relação.</param>
        /// <param name="filialDepartamento">Dados da relação.</param>
        [HttpPut("{idFilialDepartamento}")]
        public async Task<ActionResult> Put(int idFilialDepartamento, FilialDepartamento filialDepartamentoIn)
        {
            if (idFilialDepartamento != filialDepartamentoIn.IdFilialDepartamento)
                return BadRequest(new { StatusCode = 400, Message = "ID da rota não corresponde ao objeto enviado." }); // 400 Bad Request (ID divergente)
            var ok = await _service.UpdateFilialDepartamentoAsync(idFilialDepartamento, filialDepartamentoIn);
            if (!ok) return NotFound(); // 404 Not Found quando não existir para atualização
            return NoContent(); // 204 No Content
        }

        /// <summary>
        /// Remove uma relação filial-departamento pelo seu id.
        /// </summary>
        /// <param name="idFilialDepartamento">Id da relação.</param>
        [HttpDelete("{idFilialDepartamento}")]
        public async Task<ActionResult> Delete(int idFilialDepartamento)
        {
            var existente = await _service.GetFilialDepartamentoByIdAsync(idFilialDepartamento);
            if (existente == null) return NotFound(); // 404 Not Found quando não há registro para excluir
            var ok = await _service.DeleteFilialDepartamentoAsync(idFilialDepartamento);
            if (!ok) return StatusCode(500, "Ocorreu um erro ao remover a relação filial-departamento.");

            return NoContent(); // Retorna 204 No Content
        }
    }
}
