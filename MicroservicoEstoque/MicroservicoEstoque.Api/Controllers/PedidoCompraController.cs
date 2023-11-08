using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MicroservicoEstoque.Application.DTOs;
using MicroservicoEstoque.Application.Interfaces;
using MicroservicoEstoque.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace MicroservicoEstoque.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PedidoCompraController : ControllerBase
    {
        private readonly IPedidoCompraService _pedidoCompraService;

        public PedidoCompraController(IPedidoCompraService pedidoCompraService)
        {
            _pedidoCompraService = pedidoCompraService;
        }

        [HttpGet()]
        public async Task<IActionResult> Get()
        {
            try
            {
                var pedidosCompra = await _pedidoCompraService.ObterTodos();
                return Ok(pedidosCompra);
            }
            catch (Exception ex)
            {
                var errorResponse = new
                {
                    Message = "Erro ao consultar pedidos de compra",
                    Error = ex.Message
                };

                return BadRequest(errorResponse);
            }
        }

        [HttpPost()]
        public async Task<IActionResult> Post([FromBody] PedidoCompraDTO pedidoCompraDto)
        {
            try
            {
                PedidoCompra MapearParaEntidade(PedidoCompraDTO dto)
                {
                    return new PedidoCompra
                    {
                        Id = dto.Id,
                        FornecedorId = dto.FornecedorId,
                        ValorTotal = dto.ValorTotal,
                        DataPedido = dto.DataPedido,
                        Status = Enum.Parse<StatusPedidoCompra>(dto.Status, true),
                        Itens = dto.Itens.ConvertAll(item => new ItemPedidoCompra
                        {
                            ProdutoId = item.ProdutoId,
                            NomeProduto = item.NomeProduto,
                            Quantidade = item.Quantidade,
                            PrecoUnitario = item.PrecoUnitario
                        })
                    };
                }

                var pedidoCompra = MapearParaEntidade(pedidoCompraDto);
                var novoPedidoCompra = await _pedidoCompraService.Adicionar(pedidoCompra);
                return Ok(novoPedidoCompra);
            }
            catch (Exception ex)
            {
                var errorResponse = new
                {
                    Message = "Erro ao adicionar pedido de compra",
                    Error = ex.Message
                };

                return BadRequest(errorResponse);
            }
        }

        [HttpPut()]
        public async Task<IActionResult> Put([FromBody] PedidoCompraDTO pedidoCompraDto)
        {
            try
            {
                PedidoCompra MapearParaEntidade(PedidoCompraDTO dto)
                {
                    return new PedidoCompra
                    {
                        Id = dto.Id,
                        FornecedorId = dto.FornecedorId,
                        ValorTotal = dto.ValorTotal,
                        DataPedido = dto.DataPedido,
                        Status = Enum.Parse<StatusPedidoCompra>(dto.Status, true),
                        Itens = dto.Itens.ConvertAll(item => new ItemPedidoCompra
                        {
                            ProdutoId = item.ProdutoId,
                            NomeProduto = item.NomeProduto,
                            Quantidade = item.Quantidade,
                            PrecoUnitario = item.PrecoUnitario
                        })
                    };
                }

                var pedidoCompra = MapearParaEntidade(pedidoCompraDto);
                var pedidoCompraAtualizado = await _pedidoCompraService.Atualizar(pedidoCompra);
                return Ok(pedidoCompraAtualizado);
            }
            catch (Exception ex)
            {
                var errorResponse = new
                {
                    Message = "Erro ao atualizar pedido de compra",
                    Error = ex.Message
                };

                return BadRequest(errorResponse);
            }
        }

        [HttpDelete("{pedidoCompraId}")]
        public IActionResult Delete(string pedidoCompraId)
        {
            try
            {
                _pedidoCompraService.Remover(pedidoCompraId);
                return Ok($"Pedido de compra {pedidoCompraId} removido com sucesso");
            }
            catch (Exception ex)
            {
                var errorResponse = new
                {
                    Message = "Erro ao remover pedido de compra",
                    Error = ex.Message
                };

                return BadRequest(errorResponse);
            }
        }
    }
}
