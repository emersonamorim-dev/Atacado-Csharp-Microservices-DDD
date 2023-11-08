using MicroservicoLogistica.Domain.Entities;
using MicroservicoLogistica.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MicroservicoLogistica.Application.Services
{
    public class GestaoPedidosService : IGestaoPedidosService
    {
        private readonly IGestaoPedidosRepository _gestaoPedidosRepository;

        public GestaoPedidosService(IGestaoPedidosRepository gestaoPedidosRepository)
        {
            _gestaoPedidosRepository = gestaoPedidosRepository;
        }

        public Task<List<GestaoPedidos>> ObterTodos()
        {
            return _gestaoPedidosRepository.GetPedidosAsync();
        }

        public async Task<GestaoPedidos> Adicionar(GestaoPedidos pedido)
        {
            if (pedido == null)
                throw new Exception("Dados inválidos.");

            return await _gestaoPedidosRepository.CreatePedidoAsync(pedido);
        }

        public async Task<GestaoPedidos> Atualizar(GestaoPedidos pedido)
        {
            if (pedido == null)
                throw new Exception("Dados inválidos.");

            var pedidos = await _gestaoPedidosRepository.GetPedidosAsync();
            var existePedido = pedidos.FirstOrDefault(p => p.Id == pedido.Id);

            if (existePedido == null)
                throw new Exception("O pedido informado não existe");

            return await _gestaoPedidosRepository.UpdatePedidoAsync(pedido);
        }

        public void Remover(string pedidoId)
        {
            if (string.IsNullOrEmpty(pedidoId))
                throw new Exception("O Id do pedido é inválido");

            _gestaoPedidosRepository.DeletePedidoAsync(pedidoId);
        }
    }
}
