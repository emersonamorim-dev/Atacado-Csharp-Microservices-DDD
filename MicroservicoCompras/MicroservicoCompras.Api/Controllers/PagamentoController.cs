using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MicroservicoCompras.Application.Services;
using MicroservicoCompras.Application.Interfaces;
using MicroservicoCompras.Domain.Entities;

namespace MicroservicoCompras.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PagamentoController : ControllerBase
    {
        private IPagamentoService _pagamentoService;

        public PagamentoController(IPagamentoService pagamentoService)
        {
            _pagamentoService = pagamentoService;
        }

        [HttpGet()]
        public async Task<IActionResult> Get()
        {
            try
            {
                var pagamentos = await _pagamentoService.ObterTodos();
                return Ok(pagamentos);
            }
            catch (Exception ex)
            {
                var errorResponse = new
                {
                    Message = "Erro ao consultar pagamento",
                    Error = ex.Message
                };

                return BadRequest(errorResponse);
            }
        }

        [HttpPost()]
        public async Task<IActionResult> Post([FromBody] Pagamento pagamento)
        {
            try
            {
                var novoPagamento = await _pagamentoService.Adicionar(pagamento);
                return Ok(novoPagamento);
            }
            catch (Exception ex)
            {
                var errorResponse = new
                {
                    Message = "Erro ao adicionar pagamento",
                    Error = ex.Message
                };

                return BadRequest(errorResponse);
            }
        }

        [HttpPut()]
        public async Task<IActionResult> Put([FromBody] Pagamento pagamento)
        {
            try
            {
                var pagamentoAtualizado = await _pagamentoService.Atualizar(pagamento);
                return Ok(pagamentoAtualizado);
            }
            catch (Exception ex)
            {
                var errorResponse = new
                {
                    Message = "Erro ao atualizar pagamento",
                    Error = ex.Message
                };

                return BadRequest(errorResponse);
            }
        }

        [HttpDelete()]
        [Route("/Pagamento/{pagamentoId}")]
        public IActionResult Delete(string pagamentoId)
        {
            try
            {
                _pagamentoService.Remover(pagamentoId);
                return Ok($"Pagamento {pagamentoId} removido com sucesso");
            }
            catch (Exception ex)
            {
                var errorResponse = new
                {
                    Message = "Erro ao remover pagamento",
                    Error = ex.Message
                };

                return BadRequest(errorResponse);
            }
        }
    }
}
