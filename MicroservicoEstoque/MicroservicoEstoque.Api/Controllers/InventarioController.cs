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
    public class InventarioController : ControllerBase
    {
        private readonly IInventarioService _inventarioService;

        public InventarioController(IInventarioService inventarioService)
        {
            _inventarioService = inventarioService;
        }

        [HttpGet()]
        public async Task<IActionResult> Get()
        {
            try
            {
                var inventarios = await _inventarioService.ObterTodos();
                return Ok(inventarios);
            }
            catch (Exception ex)
            {
                var errorResponse = new
                {
                    Message = "Erro ao consultar inventários",
                    Error = ex.Message
                };

                return BadRequest(errorResponse);
            }
        }

        [HttpPost()]
        public async Task<IActionResult> Post([FromBody] InventarioDTO inventarioDto)
        {
            try
            {
                Inventario MapearParaEntidade(InventarioDTO dto)
                {
                    return new Inventario
                    {
                        Id = dto.Id,
                        ProdutoId = dto.ProdutoId,
                        NomeProduto = dto.NomeProduto,
                        QuantidadeEmEstoque = dto.QuantidadeEmEstoque,
                        LocalizacaoArmazem = dto.LocalizacaoArmazem,
                        DataUltimaAtualizacao = dto.DataUltimaAtualizacao,
                        Status = Enum.Parse<StatusInventario>(dto.StatusInventario, true)
                    };
                }

                var inventario = MapearParaEntidade(inventarioDto);
                var novoInventario = await _inventarioService.Adicionar(inventario);
                return Ok(novoInventario);
            }
            catch (Exception ex)
            {
                var errorResponse = new
                {
                    Message = "Erro ao adicionar inventário",
                    Error = ex.Message
                };

                return BadRequest(errorResponse);
            }
        }

        [HttpPut()]
        public async Task<IActionResult> Put([FromBody] InventarioDTO inventarioDto)
        {
            try
            {
                Inventario MapearParaEntidade(InventarioDTO dto)
                {
                    return new Inventario
                    {
                        Id = dto.Id,
                        ProdutoId = dto.ProdutoId,
                        NomeProduto = dto.NomeProduto,
                        QuantidadeEmEstoque = dto.QuantidadeEmEstoque,
                        LocalizacaoArmazem = dto.LocalizacaoArmazem,
                        DataUltimaAtualizacao = dto.DataUltimaAtualizacao,
                        Status = Enum.Parse<StatusInventario>(dto.StatusInventario, true)
                    };
                }

                var inventario = MapearParaEntidade(inventarioDto);
                var inventarioAtualizado = await _inventarioService.Atualizar(inventario);
                return Ok(inventarioAtualizado);
            }
            catch (Exception ex)
            {
                var errorResponse = new
                {
                    Message = "Erro ao atualizar inventário",
                    Error = ex.Message
                };

                return BadRequest(errorResponse);
            }
        }

        [HttpDelete("{inventarioId}")]
        public IActionResult Delete(string inventarioId)
        {
            try
            {
                _inventarioService.Remover(inventarioId);
                return Ok($"Inventário {inventarioId} removido com sucesso");
            }
            catch (Exception ex)
            {
                var errorResponse = new
                {
                    Message = "Erro ao remover inventário",
                    Error = ex.Message
                };

                return BadRequest(errorResponse);
            }
        }
    }
}
