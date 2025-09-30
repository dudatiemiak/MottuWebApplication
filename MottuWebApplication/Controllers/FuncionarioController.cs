using Microsoft.AspNetCore.Mvc;
using MottuWebApplication.MottuWebApplication.Domain.Entities;
using MottuWebApplication.Application.Interfaces;

namespace MottuWebApplication.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class FuncionarioController : ControllerBase
    {
    private readonly IFuncionarioService _service;

    public FuncionarioController(IFuncionarioService service) => _service = service;

        /// <summary>
        /// Retorna todos os funcionários cadastrados.
        /// </summary>
        /// <returns>Lista de funcionários.</returns>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Funcionario>>> Get()
        {
            return Ok(await _service.GetAllAsync());
        }

    /// <summary>
    /// Retorna um funcionário pelo seu id.
    /// </summary>
    /// <param name="idFuncionario">Id do funcionário.</param>
        [HttpGet("{idFuncionario}", Name = "GetFuncionario")]
        public async Task<ActionResult<Funcionario>> Get(int idFuncionario)
        {
            var funcionario = await _service.GetByIdAsync(idFuncionario);

            if (funcionario == null)
                return NotFound(); // 404 Not Found quando não encontrado

            return Ok(funcionario); // 200 OK com a entidade
        }

        /// <summary>
        /// Cadastra um novo funcionário.
        /// </summary>
        /// <param name="funcionario">Dados do funcionário.</param>
        [HttpPost]
        public async Task<ActionResult> Post(Funcionario funcionario)
        {
            var created = await _service.CreateAsync(funcionario);
            return CreatedAtRoute("GetFuncionario", new { idFuncionario = created.IdFuncionario }, created); // 201 Created com header 'Location'
        }

        /// <summary>
        /// Atualiza um funcionário existente.
        /// </summary>
        /// <param name="idFuncionario">Id do funcionário.</param>
        /// <param name="funcionario">Dados do funcionário.</param>
        [HttpPut("{idFuncionario}")]
        public async Task<ActionResult> Put(int idFuncionario, Funcionario funcionario)
        {
            if (idFuncionario != funcionario.IdFuncionario)
                return BadRequest(new { StatusCode = 400, Message = "ID informado não corresponde ao funcionário enviado." });
            var existente = await _service.GetByIdAsync(idFuncionario);
            if (existente == null) return NotFound();
            try
            {
                await _service.UpdateAsync(funcionario);
                return NoContent(); // Retorna 204 No Content
            }
            catch (Exception)
            {
                // Pode indicar um problema de concorrência ou falha na atualização
                return StatusCode(500, "Ocorreu um erro ao atualizar o funcionário.");
            }
        }

        /// <summary>
        /// Remove um funcionário pelo seu id.
        /// </summary>
        /// <param name="idFuncionario">Id do funcionário.</param>
        [HttpDelete("{idFuncionario}")]
        public async Task<ActionResult> Delete(int idFuncionario)
        {
            var existente = await _service.GetByIdAsync(idFuncionario);
            if (existente == null) return NotFound();
            var ok = await _service.DeleteAsync(idFuncionario);
            if (!ok) return StatusCode(500, "Ocorreu um erro ao remover o funcionário.");

            return NoContent(); // Retorna 204 No Content
        }

        /// <summary>
        /// Retorna funcionários cujo nome contenha o valor informado.
        /// </summary>
        /// <param name="nome">Parte do nome do funcionário.</param>
        [HttpGet("nome/{nome}")]
        public async Task<ActionResult<IEnumerable<Funcionario>>> GetByNome(string nome)
        {
            var funcionarios = await _service.GetByNomeAsync(nome);
            return Ok(funcionarios);
        }

        /// <summary>
        /// Retorna funcionários pelo cargo exato informado.
        /// </summary>
        /// <param name="cargo">Nome do cargo.</param>
        [HttpGet("cargo/{cargo}")]
        public async Task<ActionResult<IEnumerable<Funcionario>>> GetByCargo(string cargo)
        {
            var funcionarios = await _service.GetByCargoAsync(cargo);
            return Ok(funcionarios);
        }

        /// <summary>
        /// Retorna funcionários por e-mail corporativo.
        /// </summary>
        /// <param name="email">E-mail corporativo (contém, case-insensitive).</param>
        [HttpGet("email/{email}")]
        public async Task<ActionResult<IEnumerable<Funcionario>>> GetByEmail(string email)
        {
            var funcionarios = await _service.GetByEmailAsync(email);
            return Ok(funcionarios);
        }
    }
}
