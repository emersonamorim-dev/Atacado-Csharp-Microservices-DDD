using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MicroservicoLogistica.Application.DTOs;
using MicroservicoLogistica.Domain.Entities;
using MicroservicoLogistica.Domain.Interfaces;

namespace MicroservicoLogistica.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class RastreamentoEntregasController : ControllerBase
    {
        private readonly IRastreamentoEntregasService _rastreamentoEntregasService;

        public RastreamentoEntregasController(IRastreamentoEntregasService rastreamentoEntregasService)
        {
            _rastreamentoEntregasService = rastreamentoEntregasService;
        }

        [HttpGet()]
        public async Task<IActionResult> Get()
        {
            try
            {
                var rastreamentos = await _rastreamentoEntregasService.ObterTodosRastreamentos();
                var rastreamentosDTOs = rastreamentos.Select(r => MapearParaDTO(r)).ToList();
                return Ok(rastreamentosDTOs);
            }
            catch (Exception ex)
            {
                var errorResponse = new
                {
                    Message = "Erro ao consultar rastreamentos",
                    Error = ex.Message
                };

                return BadRequest(errorResponse);
            }
        }

        [HttpPost()]
        public async Task<IActionResult> Post([FromBody] RastreamentoEntregasDTO rastreamentoDto)
        {
            try
            {
                var rastreamento = MapearParaEntidade(rastreamentoDto);
                var novoRastreamento = await _rastreamentoEntregasService.AdicionarRastreamento(rastreamento);
                var novoRastreamentoDTO = MapearParaDTO(novoRastreamento);
                return Ok(novoRastreamentoDTO);
            }
            catch (Exception ex)
            {
                var errorResponse = new
                {
                    Message = "Erro ao adicionar rastreamento",
                    Error = ex.Message
                };

                return BadRequest(errorResponse);
            }
        }

        [HttpPut()]
        public async Task<IActionResult> Put([FromBody] RastreamentoEntregasDTO rastreamentoDto)
        {
            try
            {
                var rastreamento = MapearParaEntidade(rastreamentoDto);
                var rastreamentoAtualizado = await _rastreamentoEntregasService.AtualizarRastreamento(rastreamento);
                var rastreamentoAtualizadoDTO = MapearParaDTO(rastreamentoAtualizado);
                return Ok(rastreamentoAtualizadoDTO);
            }
            catch (Exception ex)
            {
                var errorResponse = new
                {
                    Message = "Erro ao atualizar rastreamento",
                    Error = ex.Message
                };

                return BadRequest(errorResponse);
            }
        }

        [HttpDelete("{rastreamentoId}")]
        public IActionResult Delete(string rastreamentoId)
        {
            try
            {
                _rastreamentoEntregasService.RemoverRastreamento(rastreamentoId);
                return Ok($"Rastreamento {rastreamentoId} removido com sucesso");
            }
            catch (Exception ex)
            {
                var errorResponse = new
                {
                    Message = "Erro ao remover rastreamento",
                    Error = ex.Message
                };

                return BadRequest(errorResponse);
            }
        }

        private RastreamentoEntregas MapearParaEntidade(RastreamentoEntregasDTO dto)
        {
            return new RastreamentoEntregas
            {
                Id = dto.Id,
                EntregaId = dto.EntregaId,
                LocalizacaoAtual = dto.LocalizacaoAtual,
                Status = (StatusEntrega)dto.Status,
                DataHoraUltimaAtualizacao = dto.DataHoraUltimaAtualizacao,
                Observacoes = dto.Observacoes
            };
        }

        private RastreamentoEntregasDTO MapearParaDTO(RastreamentoEntregas rastreamento)
        {
            return new RastreamentoEntregasDTO
            {
                Id = rastreamento.Id,
                EntregaId = rastreamento.EntregaId,
                LocalizacaoAtual = rastreamento.LocalizacaoAtual,
                Status = (StatusEntregaDTO)rastreamento.Status,
                DataHoraUltimaAtualizacao = rastreamento.DataHoraUltimaAtualizacao,
                Observacoes = rastreamento.Observacoes
            };
        }
    }
}
