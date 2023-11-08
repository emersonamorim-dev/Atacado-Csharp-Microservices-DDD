using System;
using System.Linq;
using System.Threading.Tasks;
using MicroservicoLogistica.Application.DTOs;
using MicroservicoLogistica.Domain.Entities;
using MicroservicoLogistica.Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;


namespace MicroservicoLogistica.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class GestaoPedidosController : ControllerBase
    {
        private readonly IGestaoPedidosService _gestaoPedidosService;

        public GestaoPedidosController(IGestaoPedidosService gestaoPedidosService)
        {
            _gestaoPedidosService = gestaoPedidosService;
        }

        [HttpGet()]
        public async Task<IActionResult> Get()
        {
            try
            {
                var pedidos = await _gestaoPedidosService.ObterTodos();
                var pedidosDTOs = pedidos.Select(p => MapearParaDTO(p)).ToList();
                return Ok(pedidosDTOs);
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
        public async Task<IActionResult> Post([FromBody] GestaoPedidosDTO pedidoDto)
        {
            try
            {
                var pedido = MapearParaEntidade(pedidoDto);
                var novoPedido = await _gestaoPedidosService.Adicionar(pedido);
                var novoPedidoDTO = MapearParaDTO(novoPedido);
                return Ok(novoPedidoDTO);
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
        public async Task<IActionResult> Put([FromBody] GestaoPedidosDTO pedidoDto)
        {
            try
            {
                var pedido = MapearParaEntidade(pedidoDto);
                var pedidoAtualizado = await _gestaoPedidosService.Atualizar(pedido);
                var pedidoAtualizadoDTO = MapearParaDTO(pedidoAtualizado);
                return Ok(pedidoAtualizadoDTO);
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
                _gestaoPedidosService.Remover(pedidoId);
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

        private GestaoPedidos MapearParaEntidade(GestaoPedidosDTO dto)
        {
            return new GestaoPedidos
            {
                Id = dto.Id,
                NumeroPedido = dto.NumeroPedido,
                DataPedido = dto.DataPedido,
                ItensPedido = dto.ItensPedido.Select(item => new ItemPedido
                {
                    ProdutoId = item.ProdutoId,
                    Quantidade = item.Quantidade,
                    PrecoUnitario = item.PrecoUnitario
                }).ToList(),
                Status = (StatusPedido)dto.Status,
                DataEntregaEstimada = dto.DataEntregaEstimada,
                DataEntregaReal = dto.DataEntregaReal,
                EnderecoEntrega = dto.EnderecoEntrega,
                Observacoes = dto.Observacoes
            };
        }

        private GestaoPedidosDTO MapearParaDTO(GestaoPedidos pedido)
        {
            return new GestaoPedidosDTO
            {
                Id = pedido.Id,
                NumeroPedido = pedido.NumeroPedido,
                DataPedido = pedido.DataPedido,
                ItensPedido = pedido.ItensPedido.Select(item => new ItemPedidoDTO
                {
                    ProdutoId = item.ProdutoId,
                    Quantidade = item.Quantidade,
                    PrecoUnitario = item.PrecoUnitario
                }).ToList(),
                Status = (StatusPedidoDTO)pedido.Status,
                DataEntregaEstimada = pedido.DataEntregaEstimada,
                DataEntregaReal = pedido.DataEntregaReal,
                EnderecoEntrega = pedido.EnderecoEntrega,
                Observacoes = pedido.Observacoes
            };
        }
    }
}
