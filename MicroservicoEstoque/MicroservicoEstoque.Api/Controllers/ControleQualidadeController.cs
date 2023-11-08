using System;
using System.Linq;
using System.Threading.Tasks;
using MicroservicoEstoque.Application.DTOs;
using MicroservicoEstoque.Application.Interfaces;
using MicroservicoEstoque.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace MicroservicoEstoque.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ControleQualidadeController : ControllerBase
    {
        private readonly IControleQualidadeService _controleQualidadeService;

        public ControleQualidadeController(IControleQualidadeService controleQualidadeService)
        {
            _controleQualidadeService = controleQualidadeService;
        }

        [HttpGet()]
        public async Task<IActionResult> Get()
        {
            try
            {
                var controles = await _controleQualidadeService.ObterTodos();
                return Ok(controles);
            }
            catch (Exception ex)
            {
                var errorResponse = new
                {
                    Message = "Erro ao consultar controles de qualidade",
                    Error = ex.Message
                };

                return BadRequest(errorResponse);
            }
        }

        [HttpPost()]
        public async Task<IActionResult> Post([FromBody] ControleQualidadeDTO controleDto)
        {
            try
            {
                ControleQualidade MapearParaEntidade(ControleQualidadeDTO dto)
                {
                    return new ControleQualidade
                    {
                        Id = dto.Id,
                        ProdutoId = dto.ProdutoId,
                        NomeProduto = dto.NomeProduto,
                        DataInspecao = dto.DataInspecao,
                        Resultado = Enum.Parse<ResultadoInspecao>(dto.ResultadoInspecao, true),
                        Detalhes = dto.Detalhes,
                        InspecaoPor = dto.InspecaoPor
                    };
                }

                var controle = MapearParaEntidade(controleDto);
                var novoControle = await _controleQualidadeService.Adicionar(controle);
                return Ok(novoControle);
            }
            catch (Exception ex)
            {
                var errorResponse = new
                {
                    Message = "Erro ao adicionar controle de qualidade",
                    Error = ex.Message
                };

                return BadRequest(errorResponse);
            }
        }

        [HttpPut()]
        public async Task<IActionResult> Put([FromBody] ControleQualidadeDTO controleDto)
        {
            try
            {
                ControleQualidade MapearParaEntidade(ControleQualidadeDTO dto)
                {
                    return new ControleQualidade
                    {
                        Id = dto.Id,
                        ProdutoId = dto.ProdutoId,
                        NomeProduto = dto.NomeProduto,
                        DataInspecao = dto.DataInspecao,
                        Resultado = Enum.Parse<ResultadoInspecao>(dto.ResultadoInspecao, true),
                        Detalhes = dto.Detalhes,
                        InspecaoPor = dto.InspecaoPor
                    };
                }

                var controle = MapearParaEntidade(controleDto);
                var controleAtualizado = await _controleQualidadeService.Atualizar(controle);
                return Ok(controleAtualizado);
            }
            catch (Exception ex)
            {
                var errorResponse = new
                {
                    Message = "Erro ao atualizar controle de qualidade",
                    Error = ex.Message
                };

                return BadRequest(errorResponse);
            }
        }

        [HttpDelete("{controleId}")]
        public IActionResult Delete(string controleId)
        {
            try
            {
                _controleQualidadeService.Remover(controleId);
                return Ok($"Controle de qualidade {controleId} removido com sucesso");
            }
            catch (Exception ex)
            {
                var errorResponse = new
                {
                    Message = "Erro ao remover controle de qualidade",
                    Error = ex.Message
                };

                return BadRequest(errorResponse);
            }
        }
    }
}
