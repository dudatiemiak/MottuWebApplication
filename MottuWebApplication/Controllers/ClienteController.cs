using Microsoft.AspNetCore.Mvc;
using MottuWebApplication.MottuWebApplication.Domain.Entities;
using MottuWebApplication.Application.Interfaces;
using Microsoft.AspNetCore.Authorization;

namespace MottuWebApplication.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class ClienteController : ControllerBase
    {
        private readonly IClienteService _service;

        public ClienteController(IClienteService service)
        {
            _service = service;
        }

        /// <summary>
        /// Retorna todos os clientes cadastrados.
        /// </summary>
        /// <returns>Lista de clientes.</returns>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Cliente>>> Get()
        {
            var clientes = await _service.GetAllClientesAsync();
            return Ok(clientes); // 200 OK com a lista de clientes
        }

        /// <summary>
        /// Retorna um cliente específico pelo seu id.
        /// </summary>
        /// <param name="idCliente">Id do cliente.</param>
        [HttpGet("{idCliente}", Name = "GetCliente")]
        public async Task<ActionResult<Cliente>> Get(int idCliente)
        {
            var cliente = await _service.GetClienteByIdAsync(idCliente);
            if (cliente == null) return NotFound(); // 404 Not Found se não existir
            return Ok(cliente); // 200 OK com o cliente solicitado
        }

        /// <summary>
        /// Cria um novo cliente.
        /// </summary>
        /// <param name="cliente">Dados do cliente.</param>
        [HttpPost]
        public async Task<ActionResult> Post(Cliente cliente)
        {
            await _service.CreateClienteAsync(cliente);
            return CreatedAtRoute("GetCliente", new { idCliente = cliente.IdCliente }, cliente); // 201 Created com Location e corpo do cliente criado
        }

        /// <summary>
        /// Atualiza um cliente existente.
        /// </summary>
        /// <param name="idCliente">Id do cliente.</param>
        /// <param name="cliente">Dados do cliente.</param>
        [HttpPut("{idCliente}")]
        public async Task<ActionResult> Put(int idCliente, Cliente clienteIn)
        {
            if (idCliente != clienteIn.IdCliente) return BadRequest(); // 400 Bad Request (ID divergente)
            var ok = await _service.UpdateClienteAsync(idCliente, clienteIn);
            if (!ok) return NotFound(); // 404 Not Found quando não há registro para atualizar
            return NoContent(); // 204 No Content
        }

        /// <summary>
        /// Remove um cliente pelo seu id.
        /// </summary>
        /// <param name="idCliente">Id do cliente.</param>
        [HttpDelete("{idCliente}")]
        public async Task<ActionResult> Delete(int idCliente)
        {
            var existente = await _service.GetClienteByIdAsync(idCliente);
            if (existente == null) return NotFound(); // 404 Not Found se não existir para exclusão

            var ok = await _service.DeleteClienteAsync(idCliente);
            if (!ok) return StatusCode(500, "Ocorreu um erro ao remover o cliente."); // 500 Internal Server Error em falha de exclusão
            return NoContent(); // 204 No Content em exclusão bem-sucedida
        }

        /// <summary>
        /// Busca clientes pelo nome (contém, case-insensitive).
        /// </summary>
        /// <param name="nome">Parte do nome do cliente.</param>
        [HttpGet("nome/{nome}")]
        public async Task<ActionResult<IEnumerable<Cliente>>> GetByNome(string nome)
        {
            var clientes = await _service.GetByNomeAsync(nome);
            return Ok(clientes); // 200 OK com a lista filtrada por nome
        }

        /// <summary>
        /// Busca clientes por CPF.
        /// </summary>
        /// <param name="cpf">CPF do cliente (somente números).</param>
        [HttpGet("cpf/{cpf}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<IEnumerable<Cliente>>> GetByCpf(string cpf)
        {
            var clientes = await _service.GetByCpfAsync(cpf);
            return Ok(clientes); // 200 OK com a lista filtrada por CPF
        }

        /// <summary>
        /// Busca clientes por e-mail (contém, case-insensitive).
        /// </summary>
        /// <param name="email">E-mail do cliente.</param>
        [HttpGet("email/{email}")]
        public async Task<ActionResult<IEnumerable<Cliente>>> GetByEmail(string email)
        {
            var clientes = await _service.GetByEmailAsync(email);
            return Ok(clientes); // 200 OK com a lista filtrada por e-mail
        }
    }
}
