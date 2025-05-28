using GerenciadorDeEstufasAPI.Context;
using GerenciadorDeEstufasAPI.DTOs;
using GerenciadorDeEstufasAPI.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace GerenciadorDeEstufasAPI.Controllers
{
    [Route("api/estufa")]
    [ApiController]
    public class EstufaController : ControllerBase
    {
        private readonly IEstufaService _service;
        readonly GerenciadorContext _context;
        public EstufaController(IEstufaService service)
        {
            _service = service;
        }

        [HttpPost]
        public async Task<IActionResult> Criar(EstufaDTO estufa)
        {
            try
            {
                await _service.CriarAsync(estufa);
                return Ok();
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        [Route("encher")]
        [HttpPost]
        public async Task<IActionResult> EncherEstufa(SequenciaDTO sequencia, int numeroEstufa)
        {
            try
            {
                await _service.EncherEstufa(sequencia, numeroEstufa);
                return Ok();
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        [Route("encher-com-pulo")]
        [HttpPost]
        public async Task<IActionResult> EncherEstufa(List<SequenciaDTO> sequencia, int numeroEstufa)
        {
            try
            {
                await _service.EncherEstufa(sequencia, numeroEstufa);
                return Ok();
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        [HttpPut("{id:guid}")]
        public async Task<IActionResult> Atualizar(EstufaDTO estufaDTO, Guid id)
        {
            try
            {
                await _service.AtualizarAsync(estufaDTO, id);
                return Ok();
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

        [Route("com-amostras")]
        [HttpGet]
        public async Task<IActionResult> ConsultarComAmostrasAsync(int numeroIdentificacao)
        {
            try
            {
                return Ok(await _service.ConsultarComIdEAmostrasAsync(numeroIdentificacao));
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }
    }
}
