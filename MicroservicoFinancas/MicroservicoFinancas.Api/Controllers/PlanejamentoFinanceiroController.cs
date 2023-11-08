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
    public class PlanejamentoFinanceiroController : ControllerBase
    {
        private readonly IPlanejamentoFinanceiroService _planejamentoFinanceiroService;

        public PlanejamentoFinanceiroController(IPlanejamentoFinanceiroService planejamentoFinanceiroService)
        {
            _planejamentoFinanceiroService = planejamentoFinanceiroService;
        }

        [HttpGet()]
        public async Task<IActionResult> Get()
        {
            try
            {
                var planejamentos = await _planejamentoFinanceiroService.ObterTodos();
                var planejamentoDTOs = planejamentos.Select(p => MapearParaDTO(p)).ToList();
                return Ok(planejamentoDTOs);
            }
            catch (Exception ex)
            {
                var errorResponse = new
                {
                    Message = "Erro ao consultar planejamentos financeiros",
                    Error = ex.Message
                };

                return BadRequest(errorResponse);
            }
        }

        [HttpPost()]
        public async Task<IActionResult> Post([FromBody] PlanejamentoFinanceiroDTO planejamentoDto)
        {
            try
            {
                var planejamento = MapearParaEntidade(planejamentoDto);
                var novoPlanejamento = await _planejamentoFinanceiroService.Adicionar(planejamento);
                var novoPlanejamentoDTO = MapearParaDTO(novoPlanejamento);
                return Ok(novoPlanejamentoDTO);
            }
            catch (Exception ex)
            {
                var errorResponse = new
                {
                    Message = "Erro ao adicionar planejamento financeiro",
                    Error = ex.Message
                };

                return BadRequest(errorResponse);
            }
        }

        [HttpPut()]
        public async Task<IActionResult> Put([FromBody] PlanejamentoFinanceiroDTO planejamentoDto)
        {
            try
            {
                var planejamento = MapearParaEntidade(planejamentoDto);
                var planejamentoAtualizado = await _planejamentoFinanceiroService.Atualizar(planejamento);
                var planejamentoAtualizadoDTO = MapearParaDTO(planejamentoAtualizado);
                return Ok(planejamentoAtualizadoDTO);
            }
            catch (Exception ex)
            {
                var errorResponse = new
                {
                    Message = "Erro ao atualizar planejamento financeiro",
                    Error = ex.Message
                };

                return BadRequest(errorResponse);
            }
        }

        [HttpDelete("{planejamentoId}")]
        public IActionResult Delete(string planejamentoId)
        {
            try
            {
                _planejamentoFinanceiroService.Remover(planejamentoId);
                return Ok($"Planejamento financeiro {planejamentoId} removido com sucesso");
            }
            catch (Exception ex)
            {
                var errorResponse = new
                {
                    Message = "Erro ao remover planejamento financeiro",
                    Error = ex.Message
                };

                return BadRequest(errorResponse);
            }
        }

        private PlanejamentoFinanceiro MapearParaEntidade(PlanejamentoFinanceiroDTO dto)
        {
            return new PlanejamentoFinanceiro
            {
                Id = dto.Id,
                DataCriacao = dto.DataCriacao,
                UsuarioId = dto.UsuarioId,
                MetasFinanceiras = dto.MetasFinanceiras.Select(mf => new MetaFinanceira
                {
                    Descricao = mf.Descricao,
                    Valor = mf.Valor,
                    DataPrevista = mf.DataPrevista,
                    Status = (StatusMetaFinanceira)mf.Status
                }).ToList(),
                DespesasPlanejadas = dto.DespesasPlanejadas.Select(dp => new DespesaPlanejada
                {
                    Descricao = dp.Descricao,
                    Valor = dp.Valor,
                    DataPrevista = dp.DataPrevista,
                    Categoria = dp.Categoria
                }).ToList(),
                ReceitasEsperadas = dto.ReceitasEsperadas,
                TotalEconomizado = dto.TotalEconomizado,
                Observacoes = dto.Observacoes
            };
        }

        private PlanejamentoFinanceiroDTO MapearParaDTO(PlanejamentoFinanceiro planejamento)
        {
            return new PlanejamentoFinanceiroDTO
            {
                Id = planejamento.Id,
                DataCriacao = planejamento.DataCriacao,
                UsuarioId = planejamento.UsuarioId,
                MetasFinanceiras = planejamento.MetasFinanceiras.Select(mf => new MetaFinanceiraDTO
                {
                    Descricao = mf.Descricao,
                    Valor = mf.Valor,
                    DataPrevista = mf.DataPrevista,
                    Status = (StatusMetaFinanceiraDTO)mf.Status
                }).ToList(),
                DespesasPlanejadas = planejamento.DespesasPlanejadas.Select(dp => new DespesaPlanejadaDTO
                {
                    Descricao = dp.Descricao,
                    Valor = dp.Valor,
                    DataPrevista = dp.DataPrevista,
                    Categoria = dp.Categoria
                }).ToList(),
                ReceitasEsperadas = planejamento.ReceitasEsperadas,
                TotalEconomizado = planejamento.TotalEconomizado,
                Observacoes = planejamento.Observacoes
            };
        }
    }
}
