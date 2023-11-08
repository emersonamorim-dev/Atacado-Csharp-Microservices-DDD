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
    public class DevolucaoController : ControllerBase
    {
        private readonly IDevolucaoService _devolucaoService;

        public DevolucaoController(IDevolucaoService devolucaoService)
        {
            _devolucaoService = devolucaoService;
        }

        [HttpGet()]
        public async Task<IActionResult> Get()
        {
            try
            {
                var devolucoes = await _devolucaoService.ObterTodos();
                return Ok(devolucoes);
            }
            catch (Exception ex)
            {
                var errorResponse = new
                {
                    Message = "Erro ao consultar devoluções",
                    Error = ex.Message
                };

                return BadRequest(errorResponse);
            }
        }

        [HttpPost()]
        public async Task<IActionResult> Post([FromBody] DevolucaoDTO devolucaoDto)
        {
            try
            {
                Devolucao MapearParaEntidade(DevolucaoDTO dto)
                {
                    return new Devolucao
                    {
                        Id = dto.Id,
                        PedidoId = dto.PedidoId,
                        ClienteId = dto.ClienteId,
                        MotivoDevolucao = dto.MotivoDevolucao,
                        DataDevolucao = dto.DataDevolucao,
                        Status = Enum.Parse<StatusDevolucao>(dto.StatusDevolucao, true),
                        ItensDevolvidos = dto.ItensDevolvidos.Select(item => new ItemDevolvido
                        {
                            ProdutoId = item.ProdutoId,
                            NomeProduto = item.NomeProduto,
                            Quantidade = item.Quantidade,
                            PrecoUnitario = item.PrecoUnitario
                        }).ToList()
                    };
                }

                var devolucao = MapearParaEntidade(devolucaoDto);
                var novaDevolucao = await _devolucaoService.Adicionar(devolucao);
                return Ok(novaDevolucao);
            }
            catch (Exception ex)
            {
                var errorResponse = new
                {
                    Message = "Erro ao adicionar devolução",
                    Error = ex.Message
                };

                return BadRequest(errorResponse);
            }
        }

        [HttpPut()]
        public async Task<IActionResult> Put([FromBody] DevolucaoDTO devolucaoDto)
        {
            try
            {
                Devolucao MapearParaEntidade(DevolucaoDTO dto)
                {
                    return new Devolucao
                    {
                        Id = dto.Id,
                        PedidoId = dto.PedidoId,
                        ClienteId = dto.ClienteId,
                        MotivoDevolucao = dto.MotivoDevolucao,
                        DataDevolucao = dto.DataDevolucao,
                        Status = Enum.Parse<StatusDevolucao>(dto.StatusDevolucao, true),
                        ItensDevolvidos = dto.ItensDevolvidos.Select(item => new ItemDevolvido
                        {
                            ProdutoId = item.ProdutoId,
                            NomeProduto = item.NomeProduto,
                            Quantidade = item.Quantidade,
                            PrecoUnitario = item.PrecoUnitario
                        }).ToList()
                    };
                }

                var devolucao = MapearParaEntidade(devolucaoDto);
                var devolucaoAtualizada = await _devolucaoService.Atualizar(devolucao);
                return Ok(devolucaoAtualizada);
            }
            catch (Exception ex)
            {
                var errorResponse = new
                {
                    Message = "Erro ao atualizar devolução",
                    Error = ex.Message
                };

                return BadRequest(errorResponse);
            }
        }

        [HttpDelete("{devolucaoId}")]
        public IActionResult Delete(string devolucaoId)
        {
            try
            {
                _devolucaoService.Remover(devolucaoId);
                return Ok($"Devolução {devolucaoId} removida com sucesso");
            }
            catch (Exception ex)
            {
                var errorResponse = new
                {
                    Message = "Erro ao remover devolução",
                    Error = ex.Message
                };

                return BadRequest(errorResponse);
            }
        }
    }
}
