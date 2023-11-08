using MicroservicoEstoque.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MicroservicoEstoque.Application.Interfaces
{
    public interface IPedidoCompraService
    {
        Task<List<PedidoCompra>> ObterTodos();
        Task<PedidoCompra> Adicionar(PedidoCompra pedidoCompra);
        Task<PedidoCompra> Atualizar(PedidoCompra pedidoCompra);
        void Remover(string pedidoCompraId);
    }
}
