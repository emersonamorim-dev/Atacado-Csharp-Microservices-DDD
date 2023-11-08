using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MicroservicoFinancas.Application.DTOs;
using MicroservicoFinancas.Domain.Entities;
using MicroservicoFinancas.Domain.Interfaces;

namespace MicroservicoFinancas.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProcessamentoPagamentosController : ControllerBase
    {
        private readonly IProcessamentoPagamentosService _processamentoPagamentosService;

        public ProcessamentoPagamentosController(IProcessamentoPagamentosService processamentoPagamentosService)
        {
            _processamentoPagamentosService = processamentoPagamentosService;
        }

        [HttpGet()]
        public async Task<IActionResult> Get()
        {
            try
            {
                var processamentos = await _processamentoPagamentosService.ObterTodos();
                var processamentoDTOs = processamentos.Select(p => MapearParaDTO(p)).ToList();
                return Ok(processamentoDTOs);
            }
            catch (Exception ex)
            {
                var errorResponse = new
                {
                    Message = "Erro ao consultar processamentos de pagamentos",
                    Error = ex.Message
                };

                return BadRequest(errorResponse);
            }
        }

        [HttpPost()]
        public async Task<IActionResult> Post([FromBody] ProcessamentoPagamentosDTO processamentoDto)
        {
            try
            {
                var processamento = MapearParaEntidade(processamentoDto);
                var novoProcessamento = await _processamentoPagamentosService.Adicionar(processamento);
                var novoProcessamentoDTO = MapearParaDTO(novoProcessamento);
                return Ok(novoProcessamentoDTO);
            }
            catch (Exception ex)
            {
                var errorResponse = new
                {
                    Message = "Erro ao adicionar processamento de pagamento",
                    Error = ex.Message
                };

                return BadRequest(errorResponse);
            }
        }

        [HttpPut()]
        public async Task<IActionResult> Put([FromBody] ProcessamentoPagamentosDTO processamentoDto)
        {
            try
            {
                var processamento = MapearParaEntidade(processamentoDto);
                var processamentoAtualizado = await _processamentoPagamentosService.Atualizar(processamento);
                var processamentoAtualizadoDTO = MapearParaDTO(processamentoAtualizado);
                return Ok(processamentoAtualizadoDTO);
            }
            catch (Exception ex)
            {
                var errorResponse = new
                {
                    Message = "Erro ao atualizar processamento de pagamento",
                    Error = ex.Message
                };

                return BadRequest(errorResponse);
            }
        }

        [HttpDelete("{processamentoId}")]
        public IActionResult Delete(string processamentoId)
        {
            try
            {
                _processamentoPagamentosService.Remover(processamentoId);
                return Ok($"Processamento de pagamento {processamentoId} removido com sucesso");
            }
            catch (Exception ex)
            {
                var errorResponse = new
                {
                    Message = "Erro ao remover processamento de pagamento",
                    Error = ex.Message
                };

                return BadRequest(errorResponse);
            }
        }

        private ProcessamentoPagamentos MapearParaEntidade(ProcessamentoPagamentosDTO dto)
        {
            return new ProcessamentoPagamentos
            {
                Id = dto.Id,
                DataProcessamento = dto.DataProcessamento,
                UsuarioId = dto.UsuarioId,
                Transacoes = dto.Transacoes.Select(t => new Transacao
                {
                    TransacaoId = t.TransacaoId,
                    Descricao = t.Descricao,
                    Valor = t.Valor,
                    DataTransacao = t.DataTransacao,
                    StatusTransacao = (StatusTransacao)t.StatusTransacao
                }).ToList(),
                Status = (StatusProcessamentoPagamentos)dto.Status,
                TotalProcessado = dto.TotalProcessado,
                Observacoes = dto.Observacoes
            };
        }

        private ProcessamentoPagamentosDTO MapearParaDTO(ProcessamentoPagamentos processamento)
        {
            return new ProcessamentoPagamentosDTO
            {
                Id = processamento.Id,
                DataProcessamento = processamento.DataProcessamento,
                UsuarioId = processamento.UsuarioId,
                Transacoes = processamento.Transacoes.Select(t => new TransacaoDTO
                {
                    TransacaoId = t.TransacaoId,
                    Descricao = t.Descricao,
                    Valor = t.Valor,
                    DataTransacao = t.DataTransacao,
                    StatusTransacao = (StatusTransacaoDTO)t.StatusTransacao
                }).ToList(),
                Status = (StatusProcessamentoPagamentosDTO)processamento.Status,
                TotalProcessado = processamento.TotalProcessado,
                Observacoes = processamento.Observacoes
            };
        }
    }
}
