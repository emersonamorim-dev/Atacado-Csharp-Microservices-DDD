using System;
using System.Linq;
using System.Threading.Tasks;
using MicroservicoEstoque.Application.DTOs;
using MicroservicoEstoque.Application.Interfaces;
using MicroservicoEstoque.Domain.Entities;
using MicroservicoEstoque.Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace MicroservicoEstoque.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ArmazemController : ControllerBase
    {
        private readonly IArmazemService _armazemService;

        public ArmazemController(IArmazemService armazemService)
        {
            _armazemService = armazemService;
        }

        [HttpGet()]
        public async Task<IActionResult> Get()
        {
            try
            {
                var armazens = await _armazemService.ObterTodos();
                return Ok(armazens);
            }
            catch (Exception ex)
            {
                var errorResponse = new
                {
                    Message = "Erro ao consultar armazéns",
                    Error = ex.Message
                };

                return BadRequest(errorResponse);
            }
        }

        [HttpPost()]
        public async Task<IActionResult> Post([FromBody] ArmazemDTO armazemDto)
        {
            try
            {
                Armazem MapearParaEntidade(ArmazemDTO dto)
                {
                    return new Armazem
                    {
                        Id = dto.Id,
                        NomeArmazem = dto.NomeArmazem,
                        Localizacao = dto.Localizacao,
                        CapacidadeTotal = dto.CapacidadeTotal,
                        EspacoOcupado = dto.EspacoOcupado,
                        ItensArmazenados = dto.ItensArmazenados.Select(ia => new ItemArmazenado
                        {
                            ProdutoId = ia.ProdutoId,
                            NomeProduto = ia.NomeProduto,
                            Quantidade = ia.Quantidade,
                            LocalizacaoNoArmazem = ia.LocalizacaoNoArmazem
                        }).ToList(),
                        DataUltimaAtualizacao = dto.DataUltimaAtualizacao,
                        Status = Enum.Parse<StatusArmazem>(dto.StatusArmazem)
                    };
                }

                var armazem = MapearParaEntidade(armazemDto);
                var novoArmazem = await _armazemService.Adicionar(armazem);
                return Ok(novoArmazem);
            }
            catch (Exception ex)
            {
                var errorResponse = new
                {
                    Message = "Erro ao adicionar armazém",
                    Error = ex.Message
                };

                return BadRequest(errorResponse);
            }
        }

        [HttpPut()]
        public async Task<IActionResult> Put([FromBody] ArmazemDTO armazemDto)
        {
            try
            {
                Armazem MapearParaEntidade(ArmazemDTO dto)
                {
                    return new Armazem
                    {
                        Id = dto.Id,
                        NomeArmazem = dto.NomeArmazem,
                        Localizacao = dto.Localizacao,
                        CapacidadeTotal = dto.CapacidadeTotal,
                        EspacoOcupado = dto.EspacoOcupado,
                        ItensArmazenados = dto.ItensArmazenados.Select(ia => new ItemArmazenado
                        {
                            ProdutoId = ia.ProdutoId,
                            NomeProduto = ia.NomeProduto,
                            Quantidade = ia.Quantidade,
                            LocalizacaoNoArmazem = ia.LocalizacaoNoArmazem
                        }).ToList(),
                        DataUltimaAtualizacao = dto.DataUltimaAtualizacao,
                        Status = Enum.Parse<StatusArmazem>(dto.StatusArmazem)
                    };
                }

                var armazem = MapearParaEntidade(armazemDto);
                var armazemAtualizado = await _armazemService.Atualizar(armazem);
                return Ok(armazemAtualizado);
            }
            catch (Exception ex)
            {
                var errorResponse = new
                {
                    Message = "Erro ao atualizar armazém",
                    Error = ex.Message
                };

                return BadRequest(errorResponse);
            }
        }

        [HttpDelete("{armazemId}")]
        public IActionResult Delete(string armazemId)
        {
            try
            {
                _armazemService.Remover(armazemId);
                return Ok($"Armazém {armazemId} removido com sucesso");
            }
            catch (Exception ex)
            {
                var errorResponse = new
                {
                    Message = "Erro ao remover armazém",
                    Error = ex.Message
                };

                return BadRequest(errorResponse);
            }
        }
    }
}
