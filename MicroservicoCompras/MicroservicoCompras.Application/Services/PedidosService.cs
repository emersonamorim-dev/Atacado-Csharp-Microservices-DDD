using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MicroservicoCompras.Domain.Entities;
using MicroservicoCompras.Application.Interfaces;
using MicroservicoCompras.Infra.Interfaces;
using MicroservicoCompras.Domain.Interfaces;

namespace MicroservicoCompras.Application.Services
{
    public class PedidosService : IPedidosService
    {
        private readonly IPedidosRepository _pedidosRepository;

        public PedidosService(IPedidosRepository pedidosRepository)
        {
            _pedidosRepository = pedidosRepository;
        }

        public async Task<List<Pedidos>> ObterTodos()
        {
            return await _pedidosRepository.GetPedidoAsync();
        }

        public async Task<Pedidos> Adicionar(Pedidos pedido)
        {
            if (pedido == null)
                throw new Exception("Dados inválidos.");

            return await _pedidosRepository.CreatePedidoAsync(pedido);
        }

        public async Task<Pedidos> Atualizar(Pedidos pedido)
        {
            if (pedido == null)
                throw new Exception("Dados inválidos.");

            var pedidos = await _pedidosRepository.GetPedidoAsync();
            var existePedido = pedidos.FirstOrDefault(p => p.Id == pedido.Id);

            if (existePedido == null)
                throw new Exception("O pedido informado não existe");

            var atualizacao = await _pedidosRepository.UpdatePedidoAsync(pedido);

            return atualizacao;
        }


        public void Remover(string pedidoId)
        {
            if (string.IsNullOrEmpty(pedidoId))
                throw new Exception("O Id do pedido é inválido");

            _pedidosRepository.DeletePedidoAsync(pedidoId);
        }
    }
}
