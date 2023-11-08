using System.Collections.Generic;
using System.Threading.Tasks;
using MicroservicoCompras.Domain.Entities;

namespace MicroservicoCompras.Domain.Interfaces
{
    public interface IPedidosRepository
    {
        Task<List<Pedidos>> GetPedidoAsync();
        Task<Pedidos> CreatePedidoAsync(Pedidos pedido);
        Task<Pedidos> UpdatePedidoAsync(Pedidos pedido);
        Task DeletePedidoAsync(string pedidoId);
    }
}
