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
            return Ok(await _service.GetAllAsync());
        }

        /// <summary>
        /// Retorna uma relação filial-departamento pelo seu id.
        /// </summary>
        /// <param name="idFilialDepartamento">Id da relação.</param>
        [HttpGet("{idFilialDepartamento}", Name = "GetFilialDepartamento")]
        public async Task<ActionResult<FilialDepartamento>> Get(int idFilialDepartamento)
        {
            var filialDepartamento = await _service.GetByIdAsync(idFilialDepartamento);

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
            try
            {
                if (filialDepartamento.DtEntrada == default)
                    return BadRequest(new { StatusCode = 400, Message = "A data de entrada é obrigatória." });

                var created = await _service.CreateAsync(filialDepartamento);
                return CreatedAtRoute("GetFilialDepartamento", new { idFilialDepartamento = created.IdFilialDepartamento }, created); // Retorna 201 Created com o header 'Location' para o novo recurso.
            }
            catch (Exception ex)
            {
                return BadRequest(new { StatusCode = 400, Message = $"Erro ao cadastrar relação filial-departamento: {ex.Message}" });
            }
        }

        /// <summary>
        /// Atualiza uma relação filial-departamento existente.
        /// </summary>
        /// <param name="idFilialDepartamento">Id da relação.</param>
        /// <param name="filialDepartamento">Dados da relação.</param>
        [HttpPut("{idFilialDepartamento}")]
        public async Task<ActionResult> Put(int idFilialDepartamento, FilialDepartamento filialDepartamento)
        {
            if (idFilialDepartamento != filialDepartamento.IdFilialDepartamento)
                return BadRequest(new { StatusCode = 400, Message = "ID da rota não corresponde ao objeto enviado." });
            var existente = await _service.GetByIdAsync(idFilialDepartamento);
            if (existente == null) return NotFound();
            try
            {
                await _service.UpdateAsync(filialDepartamento);
                return NoContent(); // Retorna 204 No Content
            }
            catch (Exception)
            {
                // Pode indicar um problema de concorrência ou falha na atualização
                return StatusCode(500, "Ocorreu um erro ao atualizar a relação filial-departamento.");
            }
        }

        /// <summary>
        /// Remove uma relação filial-departamento pelo seu id.
        /// </summary>
        /// <param name="idFilialDepartamento">Id da relação.</param>
        [HttpDelete("{idFilialDepartamento}")]
        public async Task<ActionResult> Delete(int idFilialDepartamento)
        {
            var existente = await _service.GetByIdAsync(idFilialDepartamento);
            if (existente == null) return NotFound();
            var ok = await _service.DeleteAsync(idFilialDepartamento);
            if (!ok) return StatusCode(500, "Ocorreu um erro ao remover a relação filial-departamento.");

            return NoContent(); // Retorna 204 No Content
        }
    }
}
