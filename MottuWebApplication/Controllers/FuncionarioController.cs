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
            return Ok(await _service.GetAllFuncionariosAsync()); // 200 OK com a lista de funcionários
        }

    /// <summary>
    /// Retorna um funcionário pelo seu id.
    /// </summary>
    /// <param name="idFuncionario">Id do funcionário.</param>
        [HttpGet("{idFuncionario}", Name = "GetFuncionario")]
        public async Task<ActionResult<Funcionario>> Get(int idFuncionario)
        {
            var funcionario = await _service.GetFuncionarioByIdAsync(idFuncionario);

            if (funcionario == null)
                return NotFound(); // 404 Not Found quando não encontrado

            return Ok(funcionario); // 200 OK com o funcionário solicitado
        }

        /// <summary>
        /// Cadastra um novo funcionário.
        /// </summary>
        /// <param name="funcionario">Dados do funcionário.</param>
        [HttpPost]
        public async Task<ActionResult> Post(Funcionario funcionario)
        {
            await _service.CreateFuncionarioAsync(funcionario);
            return CreatedAtRoute("GetFuncionario", new { idFuncionario = funcionario.IdFuncionario }, funcionario); // 201 Created com Location e corpo do funcionário criado
        }

        /// <summary>
        /// Atualiza um funcionário existente.
        /// </summary>
        /// <param name="idFuncionario">Id do funcionário.</param>
        /// <param name="funcionario">Dados do funcionário.</param>
        [HttpPut("{idFuncionario}")]
        public async Task<ActionResult> Put(int idFuncionario, Funcionario funcionarioIn)
        {
            if (idFuncionario != funcionarioIn.IdFuncionario)
                return BadRequest(new { StatusCode = 400, Message = "ID informado não corresponde ao funcionário enviado." }); // 400 Bad Request (ID divergente)
            var ok = await _service.UpdateFuncionarioAsync(idFuncionario, funcionarioIn);
            if (!ok) return NotFound(); // 404 Not Found quando não existir para atualização
            return NoContent(); // 204 No Content
        }

        /// <summary>
        /// Remove um funcionário pelo seu id.
        /// </summary>
        /// <param name="idFuncionario">Id do funcionário.</param>
        [HttpDelete("{idFuncionario}")]
        public async Task<ActionResult> Delete(int idFuncionario)
        {
            var existente = await _service.GetFuncionarioByIdAsync(idFuncionario);
            if (existente == null) return NotFound(); // 404 Not Found quando não há registro para excluir
            var ok = await _service.DeleteFuncionarioAsync(idFuncionario);
            if (!ok) return StatusCode(500, "Ocorreu um erro ao remover o funcionário."); // 500 Internal Server Error em falha de exclusão

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
            return Ok(funcionarios); // 200 OK com a lista filtrada por nome
        }

        /// <summary>
        /// Retorna funcionários pelo cargo exato informado.
        /// </summary>
        /// <param name="cargo">Nome do cargo.</param>
        [HttpGet("cargo/{cargo}")]
        public async Task<ActionResult<IEnumerable<Funcionario>>> GetByCargo(string cargo)
        {
            var funcionarios = await _service.GetByCargoAsync(cargo);
            return Ok(funcionarios); // 200 OK com a lista filtrada por cargo
        }

        /// <summary>
        /// Retorna funcionários por e-mail corporativo.
        /// </summary>
        /// <param name="email">E-mail corporativo (contém, case-insensitive).</param>
        [HttpGet("email/{email}")]
        public async Task<ActionResult<IEnumerable<Funcionario>>> GetByEmail(string email)
        {
            var funcionarios = await _service.GetByEmailAsync(email);
            return Ok(funcionarios); // 200 OK com a lista filtrada por e-mail
        }
    }
}
