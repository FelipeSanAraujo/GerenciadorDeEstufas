using GerenciadorDeEstufasAPI.DTOs;
using GerenciadorDeEstufasAPI.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace GerenciadorDeEstufasAPI.Controllers
{
    [Route("api/[Controller]")]
    [ApiController]
    public class EstufaController : ControllerBase
    {
        private readonly IEstufaService _service;

        public EstufaController(IEstufaService service)
        {
            _service = service;
        }

        [HttpPost]
        public IActionResult Criar(EstufaDTO estufa)
        {
            try
            {
                _service.CriarAsync(estufa);
                return Ok();
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        [HttpPut("{id:guid}")]
        public IActionResult Atualizar(EstufaDTO estufaDTO, Guid id)
        {
            try
            {
                _service.AtualizarAsync(estufaDTO, id);
                return NoContent();
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        [HttpGet]
        public async Task<IActionResult> ConsultarAsync()
        {
            try
            {
                return Ok(await _service.ConsultarAsync());
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }
    }
}
