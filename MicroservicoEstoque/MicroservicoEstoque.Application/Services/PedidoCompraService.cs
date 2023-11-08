using MicroservicoEstoque.Application.Interfaces;
using MicroservicoEstoque.Domain.Entities;
using MicroservicoEstoque.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MicroservicoEstoque.Application.Services
{
    public class PedidoCompraService : IPedidoCompraService
    {
        private readonly IPedidoCompraRepository _pedidoCompraRepository;

        public PedidoCompraService(IPedidoCompraRepository pedidoCompraRepository)
        {
            _pedidoCompraRepository = pedidoCompraRepository;
        }

        public Task<List<PedidoCompra>> ObterTodos()
        {
            return _pedidoCompraRepository.GetPedidoCompraAsync();
        }

        public async Task<PedidoCompra> Adicionar(PedidoCompra pedidoCompra)
        {
            if (pedidoCompra == null)
                throw new Exception("Dados inválidos.");

            return await _pedidoCompraRepository.CreatePedidoCompraAsync(pedidoCompra);
        }

        public async Task<PedidoCompra> Atualizar(PedidoCompra pedidoCompra)
        {
            if (pedidoCompra == null)
                throw new Exception("Dados inválidos.");

            var pedidosCompra = await _pedidoCompraRepository.GetPedidoCompraAsync();
            var existePedidoCompra = pedidosCompra.FirstOrDefault(p => p.Id == pedidoCompra.Id);

            if (existePedidoCompra == null)
                throw new Exception("O pedido de compra informado não existe");

            var atualizacao = await _pedidoCompraRepository.UpdatePedidoCompraAsync(pedidoCompra);

            return atualizacao;
        }

        public void Remover(string pedidoCompraId)
        {
            if (string.IsNullOrEmpty(pedidoCompraId))
                throw new Exception("O Id do pedido de compra é inválido");

            _pedidoCompraRepository.DeletePedidoCompraAsync(pedidoCompraId);
        }
    }
}
