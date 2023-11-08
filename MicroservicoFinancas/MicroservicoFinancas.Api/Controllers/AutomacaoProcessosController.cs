using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MicroservicoFinancas.Application.DTOs;
using MicroservicoFinancas.Domain.Interfaces;
using MicroservicoFinancas.Domain.Entities;

namespace MicroservicoFinancas.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AutomacaoProcessosController : ControllerBase
    {
        private readonly IAutomacaoProcessosService _automacaoProcessosService;

        public AutomacaoProcessosController(IAutomacaoProcessosService automacaoProcessosService)
        {
            _automacaoProcessosService = automacaoProcessosService;
        }

        [HttpGet()]
        public async Task<IActionResult> Get()
        {
            try
            {
                var processos = await _automacaoProcessosService.ObterTodos();
                var processosDTOs = processos.Select(p => MapearParaDTO(p)).ToList();
                return Ok(processosDTOs);
            }
            catch (Exception ex)
            {
                var errorResponse = new
                {
                    Message = "Erro ao consultar processos de automação",
                    Error = ex.Message
                };

                return BadRequest(errorResponse);
            }
        }

        [HttpPost()]
        public async Task<IActionResult> Post([FromBody] AutomacaoProcessosDTO processoDto)
        {
            try
            {
                var processo = MapearParaEntidade(processoDto);
                var novoProcesso = await _automacaoProcessosService.Adicionar(processo);
                var novoProcessoDTO = MapearParaDTO(novoProcesso);
                return Ok(novoProcessoDTO);
            }
            catch (Exception ex)
            {
                var errorResponse = new
                {
                    Message = "Erro ao adicionar processo de automação",
                    Error = ex.Message
                };

                return BadRequest(errorResponse);
            }
        }

        [HttpPut()]
        public async Task<IActionResult> Put([FromBody] AutomacaoProcessosDTO processoDto)
        {
            try
            {
                var processo = MapearParaEntidade(processoDto);
                var processoAtualizado = await _automacaoProcessosService.Atualizar(processo);
                var processoAtualizadoDTO = MapearParaDTO(processoAtualizado);
                return Ok(processoAtualizadoDTO);
            }
            catch (Exception ex)
            {
                var errorResponse = new
                {
                    Message = "Erro ao atualizar processo de automação",
                    Error = ex.Message
                };

                return BadRequest(errorResponse);
            }
        }

        [HttpDelete("{processoId}")]
        public IActionResult Delete(string processoId)
        {
            try
            {
                _automacaoProcessosService.Remover(processoId);
                return Ok($"Processo de automação {processoId} removido com sucesso");
            }
            catch (Exception ex)
            {
                var errorResponse = new
                {
                    Message = "Erro ao remover processo de automação",
                    Error = ex.Message
                };

                return BadRequest(errorResponse);
            }
        }

        private AutomacaoProcessos MapearParaEntidade(AutomacaoProcessosDTO dto)
        {
            return new AutomacaoProcessos
            {
                Id = dto.Id,
                DataCriacao = dto.DataCriacao,
                UsuarioId = dto.UsuarioId,
                NomeProcesso = dto.NomeProcesso,
                DescricaoProcesso = dto.DescricaoProcesso,
                PassosProcesso = dto.PassosProcesso.Select(pp => new PassoProcesso
                {
                    Ordem = pp.Ordem,
                    Descricao = pp.Descricao,
                    DataExecucao = pp.DataExecucao,
                    Status = (StatusPassoProcesso)pp.Status
                }).ToList(),
                Status = (StatusAutomacaoProcessos)dto.Status,
                Observacoes = dto.Observacoes
            };
        }

        private AutomacaoProcessosDTO MapearParaDTO(AutomacaoProcessos processo)
        {
            return new AutomacaoProcessosDTO
            {
                Id = processo.Id,
                DataCriacao = processo.DataCriacao,
                UsuarioId = processo.UsuarioId,
                NomeProcesso = processo.NomeProcesso,
                DescricaoProcesso = processo.DescricaoProcesso,
                PassosProcesso = processo.PassosProcesso.Select(pp => new PassoProcessoDTO
                {
                    Ordem = pp.Ordem,
                    Descricao = pp.Descricao,
                    DataExecucao = pp.DataExecucao,
                    Status = (StatusPassoProcessoDTO)pp.Status
                }).ToList(),
                Status = (StatusAutomacaoProcessosDTO)processo.Status,
                Observacoes = processo.Observacoes
            };
        }
    }
}
