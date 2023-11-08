using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MicroservicoMarketing.Application.DTOs;
using MicroservicoMarketing.Domain.Entities;
using MicroservicoMarketing.Domain.Interfaces;

namespace MicroservicoMarketing.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SegmentacaoClientesController : ControllerBase
    {
        private readonly ISegmentacaoClientesService _segmentacaoClientesService;

        public SegmentacaoClientesController(ISegmentacaoClientesService segmentacaoClientesService)
        {
            _segmentacaoClientesService = segmentacaoClientesService;
        }

        [HttpGet()]
        public async Task<IActionResult> Get()
        {
            try
            {
                var segmentacoes = await _segmentacaoClientesService.ObterTodos();
                var segmentacoesDTOs = segmentacoes.Select(s => MapearParaDTO(s)).ToList();
                return Ok(segmentacoesDTOs);
            }
            catch (Exception ex)
            {
                var errorResponse = new
                {
                    Message = "Erro ao consultar segmentações de clientes",
                    Error = ex.Message
                };

                return BadRequest(errorResponse);
            }
        }

        [HttpPost()]
        public async Task<IActionResult> Post([FromBody] SegmentacaoClientesDTO segmentacaoDto)
        {
            try
            {
                var segmentacao = MapearParaEntidade(segmentacaoDto);
                var novaSegmentacao = await _segmentacaoClientesService.Adicionar(segmentacao);
                var novaSegmentacaoDTO = MapearParaDTO(novaSegmentacao);
                return Ok(novaSegmentacaoDTO);
            }
            catch (Exception ex)
            {
                var errorResponse = new
                {
                    Message = "Erro ao adicionar segmentação de clientes",
                    Error = ex.Message
                };

                return BadRequest(errorResponse);
            }
        }

        [HttpPut()]
        public async Task<IActionResult> Put([FromBody] SegmentacaoClientesDTO segmentacaoDto)
        {
            try
            {
                var segmentacao = MapearParaEntidade(segmentacaoDto);
                var segmentacaoAtualizada = await _segmentacaoClientesService.Atualizar(segmentacao);
                var segmentacaoAtualizadaDTO = MapearParaDTO(segmentacaoAtualizada);
                return Ok(segmentacaoAtualizadaDTO);
            }
            catch (Exception ex)
            {
                var errorResponse = new
                {
                    Message = "Erro ao atualizar segmentação de clientes",
                    Error = ex.Message
                };

                return BadRequest(errorResponse);
            }
        }

        [HttpDelete("{segmentacaoId}")]
        public IActionResult Delete(string segmentacaoId)
        {
            try
            {
                _segmentacaoClientesService.Remover(segmentacaoId);
                return Ok($"Segmentação {segmentacaoId} removida com sucesso");
            }
            catch (Exception ex)
            {
                var errorResponse = new
                {
                    Message = "Erro ao remover segmentação de clientes",
                    Error = ex.Message
                };

                return BadRequest(errorResponse);
            }
        }

        private SegmentacaoClientes MapearParaEntidade(SegmentacaoClientesDTO dto)
        {
            return new SegmentacaoClientes
            {
                Id = dto.Id,
                NomeSegmento = dto.NomeSegmento,
                Critérios = dto.Critérios,
                DataCriacao = dto.DataCriacao,
                ClientesIds = dto.ClientesIds,
                Ativo = dto.Ativo
            };
        }

        private SegmentacaoClientesDTO MapearParaDTO(SegmentacaoClientes segmentacao)
        {
            return new SegmentacaoClientesDTO
            {
                Id = segmentacao.Id,
                NomeSegmento = segmentacao.NomeSegmento,
                Critérios = segmentacao.Critérios,
                DataCriacao = segmentacao.DataCriacao,
                ClientesIds = segmentacao.ClientesIds,
                Ativo = segmentacao.Ativo
            };
        }
    }
}
