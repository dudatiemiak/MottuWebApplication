using Microsoft.AspNetCore.Mvc;
using MottuWebApplication.MottuWebApplication.Domain.Entities;
using MottuWebApplication.Application.Interfaces;

namespace MottuWebApplication.Controllers
{
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
            var clientes = await _service.GetAllAsync();
            return Ok(clientes);
        }

        /// <summary>
        /// Retorna um cliente específico pelo seu id.
        /// </summary>
        /// <param name="idCliente">Id do cliente.</param>
        [HttpGet("{idCliente}", Name = "GetCliente")]
        public async Task<ActionResult<Cliente>> Get(int idCliente)
        {
            var cliente = await _service.GetByIdAsync(idCliente);
            if (cliente == null) return NotFound(); // 404 Not Found se não existir
            return Ok(cliente); // 200 OK com o recurso
        }

        /// <summary>
        /// Cria um novo cliente.
        /// </summary>
        /// <param name="cliente">Dados do cliente.</param>
        [HttpPost]
        public async Task<ActionResult> Post(Cliente cliente)
        {
            var created = await _service.CreateAsync(cliente);
            return CreatedAtRoute("GetCliente", new { idCliente = created.IdCliente }, created); // 201 Created com header 'Location' para o novo recurso
        }

        /// <summary>
        /// Atualiza um cliente existente.
        /// </summary>
        /// <param name="idCliente">Id do cliente.</param>
        /// <param name="cliente">Dados do cliente.</param>
        [HttpPut("{idCliente}")]
        public async Task<ActionResult> Put(int idCliente, Cliente cliente)
        {
            if (idCliente != cliente.IdCliente) return BadRequest(); // 400 Bad Request quando ID da rota não bate com o do corpo

            var existente = await _service.GetByIdAsync(idCliente);
            if (existente == null) return NotFound(); // 404 Not Found se não existir para atualizar

            try
            {
                await _service.UpdateAsync(cliente);
                return NoContent(); // 204 No Content
            }
            catch (Exception)
            {
                return StatusCode(500, "Ocorreu um erro ao atualizar o cliente."); // 500 (concorrência/falha)
            }
        }

        /// <summary>
        /// Remove um cliente pelo seu id.
        /// </summary>
        /// <param name="idCliente">Id do cliente.</param>
        [HttpDelete("{idCliente}")]
        public async Task<ActionResult> Delete(int idCliente)
        {
            var existente = await _service.GetByIdAsync(idCliente);
            if (existente == null) return NotFound(); // 404 Not Found se não existir para exclusão

            var ok = await _service.DeleteAsync(idCliente);
            if (!ok) return StatusCode(500, "Ocorreu um erro ao remover o cliente."); // 500 em falha de exclusão
            return NoContent(); // 204 No Content
        }

        /// <summary>
        /// Busca clientes pelo nome (contém, case-insensitive).
        /// </summary>
        /// <param name="nome">Parte do nome do cliente.</param>
        [HttpGet("nome/{nome}")]
        public async Task<ActionResult<IEnumerable<Cliente>>> GetByNome(string nome)
        {
            var clientes = await _service.GetByNomeAsync(nome);
            return Ok(clientes);
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
            return Ok(clientes);
        }

        /// <summary>
        /// Busca clientes por e-mail (contém, case-insensitive).
        /// </summary>
        /// <param name="email">E-mail do cliente.</param>
        [HttpGet("email/{email}")]
        public async Task<ActionResult<IEnumerable<Cliente>>> GetByEmail(string email)
        {
            var clientes = await _service.GetByEmailAsync(email);
            return Ok(clientes);
        }
    }
}
