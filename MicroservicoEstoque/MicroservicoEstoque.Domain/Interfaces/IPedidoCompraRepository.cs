using MicroservicoEstoque.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MicroservicoEstoque.Domain.Interfaces
{
    public interface IPedidoCompraRepository
    {
        Task<List<PedidoCompra>> GetPedidoCompraAsync();
        Task<PedidoCompra> CreatePedidoCompraAsync(PedidoCompra pedidoCompra);
        Task<PedidoCompra> UpdatePedidoCompraAsync(PedidoCompra pedidoCompra);
        Task DeletePedidoCompraAsync(string pedidoCompraId);
    }
}
