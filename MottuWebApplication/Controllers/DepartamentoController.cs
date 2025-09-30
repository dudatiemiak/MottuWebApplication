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
            return Ok(await _service.GetAllAsync());
        }

        /// <summary>
        /// Retorna um departamento específico pelo seu id.
        /// </summary>
        /// <param name="idDepartamento">Id do departamento.</param>
        [HttpGet("{idDepartamento}", Name = "GetDepartamento")]
        public async Task<ActionResult<Departamento>> Get(int idDepartamento)
        {
            var departamento = await _service.GetByIdAsync(idDepartamento);

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
            var created = await _service.CreateAsync(departamento);
            return CreatedAtRoute("GetDepartamento", new { idDepartamento = created.IdDepartamento }, created); // 201 Created com header 'Location'
        }

        /// <summary>
        /// Atualiza um departamento existente.
        /// </summary>
        /// <param name="idDepartamento">Id do departamento.</param>
        /// <param name="departamento">Dados do departamento.</param>
        [HttpPut("{idDepartamento}")]
        public async Task<ActionResult> Put(int idDepartamento, Departamento departamento)
        {
            if (idDepartamento != departamento.IdDepartamento)
                return BadRequest(new { StatusCode = 400, Message = "ID da rota não corresponde ao objeto enviado." }); // 400 Bad Request quando ID da rota não bate com o do corpo
            var existente = await _service.GetByIdAsync(idDepartamento);
            if (existente == null) return NotFound(); // 404 Not Found se não existir para atualizar
            try
            {
                await _service.UpdateAsync(departamento);
                return NoContent(); // Retorna 204 No Content
            }
            catch (Exception)
            {
                return StatusCode(500, "Ocorreu um erro ao atualizar o departamento."); // 500 Internal Server Error (concorrência/falha)
            }
        }

        /// <summary>
        /// Remove um departamento pelo seu id.
        /// </summary>
        /// <param name="idDepartamento">Id do departamento.</param>
        [HttpDelete("{idDepartamento}")]
        public async Task<ActionResult> Delete(int idDepartamento)
        {
            var existente = await _service.GetByIdAsync(idDepartamento);
            if (existente == null) return NotFound();

            var ok = await _service.DeleteAsync(idDepartamento);
            if (!ok) return StatusCode(500, "Ocorreu um erro ao remover o departamento."); // 500 em falha de exclusão

            return NoContent(); // 204 No Content
        }
    }
}
