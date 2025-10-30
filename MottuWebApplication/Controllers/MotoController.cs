using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MottuWebApplication.MottuWebApplication.Domain.Entities;
using MottuWebApplication.Application.Interfaces;
using Microsoft.AspNetCore.Authorization;

namespace MottuWebApplication.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class MotoController : ControllerBase
    {
        private readonly IMotoService _motoService;

        public MotoController(IMotoService motoService) => _motoService = motoService;

        /// <summary>
        /// Retorna todas as motos cadastradas.
        /// </summary>
        /// <returns>Lista de motos.</returns>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Moto>>> Get()
        {
            return Ok(await _motoService.GetAllMotosAsync());
        }

        /// <summary>
        /// Retorna uma moto específica pelo id.
        /// </summary>
        /// <param name="idMoto">Id da moto.</param>
        [HttpGet("{idMoto}", Name = "GetMoto")]
        public async Task<ActionResult<Moto>> Get(int idMoto)
        {
            var moto = await _motoService.GetMotoByIdAsync(idMoto);

            if (moto == null)
                return NotFound(); // 404 Not Found quando não encontrado

            return Ok(moto); // 200 OK com a entidade
        }

        /// <summary>
        /// Cria uma nova moto.
        /// </summary>
        /// <param name="moto">Dados da moto.</param>
        [HttpPost]
        public async Task<ActionResult> Post(Moto moto)
        {
            await _motoService.CreateMotoAsync(moto);
            return CreatedAtRoute("GetMoto", new { idMoto = moto.IdMoto }, moto);
        }

        /// <summary>
        /// Atualiza uma moto existente.
        /// </summary>
        /// <param name="idMoto">Id da moto.</param>
        /// <param name="moto">Dados da moto.</param>
        [HttpPut("{idMoto}")]
        public async Task<ActionResult> Put(int idMoto, Moto motoIn)
        {
            if (idMoto != motoIn.IdMoto)
                return BadRequest(new { StatusCode = 400, Message = "ID da moto não corresponde ao objeto enviado." });
            var ok = await _motoService.UpdateMotoAsync(idMoto, motoIn);
            if (!ok) return NotFound();
            return NoContent();
        }

        /// <summary>
        /// Remove uma moto pelo seu id.
        /// </summary>
        /// <param name="idMoto">Id da moto.</param>
        [HttpDelete("{idMoto}")]
        public async Task<ActionResult> Delete(int idMoto)
        {
            var existente = await _motoService.GetMotoByIdAsync(idMoto);
            if (existente == null) return NotFound();
            var ok = await _motoService.DeleteMotoAsync(idMoto);
            if (!ok) return StatusCode(500, "Ocorreu um erro ao remover a moto.");

            return NoContent(); // Retorna 204 No Content
        }

        /// <summary>
        /// Filtra motos pela placa exata.
        /// </summary>
        [HttpGet("placa/{placa}")]
        public async Task<ActionResult<IEnumerable<Moto>>> GetByPlaca(string placa)
        {
            var motos = await _motoService.GetByPlacaAsync(placa);
            return Ok(motos);
        }

        /// <summary>
        /// Filtra motos pelo status.
        /// </summary>
        [HttpGet("status/{status}")]
        public async Task<ActionResult<IEnumerable<Moto>>> GetByStatus(string status)
        {
            var motos = await _motoService.GetByStatusAsync(status);
            return Ok(motos);
        }

        /// <summary>
        /// Filtra motos por id de FilialDepartamento.
        /// </summary>
        [HttpGet("filialdepartamento/{idFilialDepartamento}")]
        public async Task<ActionResult<IEnumerable<Moto>>> GetByFilialDepartamento(int idFilialDepartamento)
        {
            var motos = await _motoService.GetByFilialDepartamentoAsync(idFilialDepartamento);
            return Ok(motos);
        }
    }
}
