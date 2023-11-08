using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MicroservicoCompras.Application.DTOs;
using MicroservicoCompras.Application.Interfaces;
using MicroservicoCompras.Domain.Entities;
using MicroservicoCompras.Domain.Interfaces;

namespace MicroservicoCompras.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PedidosController : ControllerBase
    {
        private readonly IPedidosService _pedidosService;

        public PedidosController(IPedidosService pedidosService)
        {
            _pedidosService = pedidosService;
        }

        [HttpGet()]
        public async Task<IActionResult> Get()
        {
            try
            {
                var pedidos = await _pedidosService.ObterTodos();
                return Ok(pedidos);
            }
            catch (Exception ex)
            {
                var errorResponse = new
                {
                    Message = "Erro ao consultar pedidos",
                    Error = ex.Message
                };

                return BadRequest(errorResponse);
            }
        }

        [HttpPost()]
        public async Task<IActionResult> Post([FromBody] PedidosDTO pedidoDto)
        {
            try
            {
                Pedidos MapearParaEntidade(PedidosDTO dto)
                {
                    return new Pedidos
                    {
                        Id = dto.Id,
                        ClienteId = dto.ClienteId,
                        Itens = dto.Itens.Select(item => new ItemPedidos
                        {
                            ProdutoId = item.ProdutoId,
                            NomeProduto = item.NomeProduto,
                            Quantidade = item.Quantidade,
                            PrecoUnitario = item.PrecoUnitario,
                            TotalItem = item.TotalItem
                        }).ToList(),
                        ValorTotal = dto.ValorTotal,
                        DataPedido = dto.DataPedido,
                        Status = Enum.Parse<StatusPedidos>(dto.Status) 
                    };
                }

                var pedido = MapearParaEntidade(pedidoDto);
                var novoPedido = await _pedidosService.Adicionar(pedido);
                return Ok(novoPedido);
            }
            catch (Exception ex)
            {
                var errorResponse = new
                {
                    Message = "Erro ao adicionar pedido",
                    Error = ex.Message
                };

                return BadRequest(errorResponse);
            }
        }


        [HttpPut()]
        public async Task<IActionResult> Put([FromBody] PedidosDTO pedidoDto)
        {
            try
            {
                Pedidos MapearParaEntidade(PedidosDTO dto)
                {
                    return new Pedidos
                    {
                        Id = dto.Id,
                        ClienteId = dto.ClienteId,
                        Itens = dto.Itens.Select(item => new ItemPedidos
                        {
                            ProdutoId = item.ProdutoId,
                            NomeProduto = item.NomeProduto,
                            Quantidade = item.Quantidade,
                            PrecoUnitario = item.PrecoUnitario,
                            TotalItem = item.TotalItem
                        }).ToList(),
                        ValorTotal = dto.ValorTotal,
                        DataPedido = dto.DataPedido,
                        Status = Enum.Parse<StatusPedidos>(dto.Status) 
                    };
                }

                var pedido = MapearParaEntidade(pedidoDto);
                var pedidoAtualizado = await _pedidosService.Atualizar(pedido);
                return Ok(pedidoAtualizado);
            }
            catch (Exception ex)
            {
                var errorResponse = new
                {
                    Message = "Erro ao atualizar pedido",
                    Error = ex.Message
                };

                return BadRequest(errorResponse);
            }
        }


        [HttpDelete("{pedidoId}")]
        public IActionResult Delete(string pedidoId)
        {
            try
            {
                _pedidosService.Remover(pedidoId);
                return Ok($"Pedido {pedidoId} removido com sucesso");
            }
            catch (Exception ex)
            {
                var errorResponse = new
                {
                    Message = "Erro ao remover pedido",
                    Error = ex.Message
                };

                return BadRequest(errorResponse);
            }
        }
    }
}
