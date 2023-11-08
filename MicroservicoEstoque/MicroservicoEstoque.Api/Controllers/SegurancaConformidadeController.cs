using System;
using System.Threading.Tasks;
using MicroservicoEstoque.Application.DTOs;
using MicroservicoEstoque.Application.Interfaces;
using MicroservicoEstoque.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace MicroservicoEstoque.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SegurancaConformidadeController : ControllerBase
    {
        private readonly ISegurancaConformidadeService _segurancaConformidadeService;

        public SegurancaConformidadeController(ISegurancaConformidadeService segurancaConformidadeService)
        {
            _segurancaConformidadeService = segurancaConformidadeService;
        }

        [HttpGet()]
        public async Task<IActionResult> Get()
        {
            try
            {
                var segurancasConformidade = await _segurancaConformidadeService.ObterTodos();
                return Ok(segurancasConformidade);
            }
            catch (Exception ex)
            {
                var errorResponse = new
                {
                    Message = "Erro ao consultar seguranças e conformidades",
                    Error = ex.Message
                };

                return BadRequest(errorResponse);
            }
        }

        [HttpPost()]
        public async Task<IActionResult> Post([FromBody] SegurancaConformidadeDTO segurancaConformidadeDto)
        {
            try
            {
                SegurancaConformidade MapearParaEntidade(SegurancaConformidadeDTO dto)
                {
                    return new SegurancaConformidade
                    {
                        Id = dto.Id,
                        Nome = dto.Nome,
                        Descricao = dto.Descricao,
                        DataVerificacao = dto.DataVerificacao,
                        Status = Enum.Parse<StatusConformidade>(dto.Status.ToString()),
                        Detalhes = dto.Detalhes,
                        Responsavel = dto.Responsavel
                    };
                }

                var segurancaConformidade = MapearParaEntidade(segurancaConformidadeDto);
                var novaSegurancaConformidade = await _segurancaConformidadeService.Adicionar(segurancaConformidade);
                return Ok(novaSegurancaConformidade);
            }
            catch (Exception ex)
            {
                var errorResponse = new
                {
                    Message = "Erro ao adicionar segurança e conformidade",
                    Error = ex.Message
                };

                return BadRequest(errorResponse);
            }
        }

        [HttpPut()]
        public async Task<IActionResult> Put([FromBody] SegurancaConformidadeDTO segurancaConformidadeDto)
        {
            try
            {
                SegurancaConformidade MapearParaEntidade(SegurancaConformidadeDTO dto)
                {
                    return new SegurancaConformidade
                    {
                        Id = dto.Id,
                        Nome = dto.Nome,
                        Descricao = dto.Descricao,
                        DataVerificacao = dto.DataVerificacao,
                        Status = Enum.Parse<StatusConformidade>(dto.Status.ToString()),
                        Detalhes = dto.Detalhes,
                        Responsavel = dto.Responsavel
                    };
                }

                var segurancaConformidade = MapearParaEntidade(segurancaConformidadeDto);
                var segurancaConformidadeAtualizada = await _segurancaConformidadeService.Atualizar(segurancaConformidade);
                return Ok(segurancaConformidadeAtualizada);
            }
            catch (Exception ex)
            {
                var errorResponse = new
                {
                    Message = "Erro ao atualizar segurança e conformidade",
                    Error = ex.Message
                };

                return BadRequest(errorResponse);
            }
        }

        [HttpDelete("{segurancaConformidadeId}")]
        public IActionResult Delete(string segurancaConformidadeId)
        {
            try
            {
                _segurancaConformidadeService.Remover(segurancaConformidadeId);
                return Ok($"Segurança e conformidade {segurancaConformidadeId} removida com sucesso");
            }
            catch (Exception ex)
            {
                var errorResponse = new
                {
                    Message = "Erro ao remover segurança e conformidade",
                    Error = ex.Message
                };

                return BadRequest(errorResponse);
            }
        }
    }
}
