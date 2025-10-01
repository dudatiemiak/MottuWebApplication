using Microsoft.AspNetCore.Mvc;
using MottuWebApplication.MottuWebApplication.Domain.Entities;
using MottuWebApplication.Application.Interfaces;

namespace MottuWebApplication.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DepartamentoController : ControllerBase
    {
        private readonly IDepartamentoService _service;

        public DepartamentoController(IDepartamentoService service)
            => _service = service;

        /// <summary>
        /// Retorna todos os departamentos cadastrados.
        /// </summary>
        /// <returns>Lista de departamentos.</returns>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Departamento>>> Get()
        {
            return Ok(await _service.GetAllDepartamentosAsync()); // 200 OK com a lista de departamentos
        }

        /// <summary>
        /// Retorna um departamento específico pelo seu id.
        /// </summary>
        /// <param name="idDepartamento">Id do departamento.</param>
        [HttpGet("{idDepartamento}", Name = "GetDepartamento")]
        public async Task<ActionResult<Departamento>> Get(int idDepartamento)
        {
            var departamento = await _service.GetDepartamentoByIdAsync(idDepartamento);

            if (departamento == null)
                return NotFound(); // 404 Not Found quando não encontrado
            return Ok(departamento); // 200 OK com a entidade
        }

        /// <summary>
        /// Cria um novo departamento.
        /// </summary>
        /// <param name="departamento">Dados do departamento.</param>
        [HttpPost]
        public async Task<ActionResult> Post(Departamento departamento)
        {
            await _service.CreateDepartamentoAsync(departamento);
            return CreatedAtRoute("GetDepartamento", new { idDepartamento = departamento.IdDepartamento }, departamento); // 201 Created com Location e corpo do departamento criado
        }

        /// <summary>
        /// Atualiza um departamento existente.
        /// </summary>
        /// <param name="idDepartamento">Id do departamento.</param>
        /// <param name="departamento">Dados do departamento.</param>
        [HttpPut("{idDepartamento}")]
        public async Task<ActionResult> Put(int idDepartamento, Departamento departamentoIn)
        {
            if (idDepartamento != departamentoIn.IdDepartamento)
                return BadRequest(new { StatusCode = 400, Message = "ID da rota não corresponde ao objeto enviado." }); // 400 Bad Request (ID divergente)
            var ok = await _service.UpdateDepartamentoAsync(idDepartamento, departamentoIn);
            if (!ok) return NotFound(); // 404 Not Found se não existir para atualizar
            return NoContent(); // 204 No Content
        }

        /// <summary>
        /// Remove um departamento pelo seu id.
        /// </summary>
        /// <param name="idDepartamento">Id do departamento.</param>
        [HttpDelete("{idDepartamento}")]
        public async Task<ActionResult> Delete(int idDepartamento)
        {
            var existente = await _service.GetDepartamentoByIdAsync(idDepartamento);
            if (existente == null) return NotFound(); // 404 Not Found quando não há registro para excluir

            var ok = await _service.DeleteDepartamentoAsync(idDepartamento);
            if (!ok) return StatusCode(500, "Ocorreu um erro ao remover o departamento."); // 500 Internal Server Error em falha de exclusão

            return NoContent(); // 204 No Content
        }
    }
}
