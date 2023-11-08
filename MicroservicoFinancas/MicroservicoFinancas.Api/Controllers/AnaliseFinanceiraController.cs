using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MicroservicoFinancas.Application.DTOs;
using MicroservicoFinancas.Application.Interfaces;
using MicroservicoFinancas.Domain.Entities;

namespace MicroservicoFinancas.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AnaliseFinanceiraController : ControllerBase
    {
        private readonly IAnaliseFinanceiraService _analiseFinanceiraService;

        public AnaliseFinanceiraController(IAnaliseFinanceiraService analiseFinanceiraService)
        {
            _analiseFinanceiraService = analiseFinanceiraService;
        }

        [HttpGet()]
        public async Task<IActionResult> Get()
        {
            try
            {
                var analises = await _analiseFinanceiraService.ObterTodas();
                var analiseDTOs = analises.Select(a => MapearParaDTO(a)).ToList();
                return Ok(analiseDTOs);
            }
            catch (Exception ex)
            {
                var errorResponse = new
                {
                    Message = "Erro ao consultar análises financeiras",
                    Error = ex.Message
                };

                return BadRequest(errorResponse);
            }
        }

        [HttpPost()]
        public async Task<IActionResult> Post([FromBody] AnaliseFinanceiraDTO analiseFinanceiraDto)
        {
            try
            {
                var analiseFinanceira = MapearParaEntidade(analiseFinanceiraDto);
                var novaAnalise = await _analiseFinanceiraService.Adicionar(analiseFinanceira);
                var novaAnaliseDTO = MapearParaDTO(novaAnalise);
                return Ok(novaAnaliseDTO);
            }
            catch (Exception ex)
            {
                var errorResponse = new
                {
                    Message = "Erro ao adicionar análise financeira",
                    Error = ex.Message
                };

                return BadRequest(errorResponse);
            }
        }

        [HttpPut()]
        public async Task<IActionResult> Put([FromBody] AnaliseFinanceiraDTO analiseFinanceiraDto)
        {
            try
            {
                var analiseFinanceira = MapearParaEntidade(analiseFinanceiraDto);
                var analiseAtualizada = await _analiseFinanceiraService.Atualizar(analiseFinanceira);
                var analiseAtualizadaDTO = MapearParaDTO(analiseAtualizada);
                return Ok(analiseAtualizadaDTO);
            }
            catch (Exception ex)
            {
                var errorResponse = new
                {
                    Message = "Erro ao atualizar análise financeira",
                    Error = ex.Message
                };

                return BadRequest(errorResponse);
            }
        }

        [HttpDelete("{analiseFinanceiraId}")]
        public IActionResult Delete(string analiseFinanceiraId)
        {
            try
            {
                _analiseFinanceiraService.Remover(analiseFinanceiraId);
                return Ok($"Análise financeira {analiseFinanceiraId} removida com sucesso");
            }
            catch (Exception ex)
            {
                var errorResponse = new
                {
                    Message = "Erro ao remover análise financeira",
                    Error = ex.Message
                };

                return BadRequest(errorResponse);
            }
        }

        private AnaliseFinanceira MapearParaEntidade(AnaliseFinanceiraDTO dto)
        {
            return new AnaliseFinanceira
            {
                Id = dto.Id,
                DataAnalise = dto.DataAnalise,
                ClienteId = dto.ClienteId,
                RendaMensal = dto.RendaMensal,
                DespesasMensais = dto.DespesasMensais,
                ScoreCredito = dto.ScoreCredito,
                LimiteCreditoRecomendado = dto.LimiteCreditoRecomendado,
                Status = (StatusAnaliseFinanceira)dto.Status,
                Observacoes = dto.Observacoes
            };
        }

        private AnaliseFinanceiraDTO MapearParaDTO(AnaliseFinanceira analiseFinanceira)
        {
            return new AnaliseFinanceiraDTO
            {
                Id = analiseFinanceira.Id,
                DataAnalise = analiseFinanceira.DataAnalise,
                ClienteId = analiseFinanceira.ClienteId,
                RendaMensal = analiseFinanceira.RendaMensal,
                DespesasMensais = analiseFinanceira.DespesasMensais,
                ScoreCredito = analiseFinanceira.ScoreCredito,
                LimiteCreditoRecomendado = analiseFinanceira.LimiteCreditoRecomendado,
                Status = (StatusAnaliseFinanceiraDTO)analiseFinanceira.Status,
                Observacoes = analiseFinanceira.Observacoes
            };
        }
    }
}
