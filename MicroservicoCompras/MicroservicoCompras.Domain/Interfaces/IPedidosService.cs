using System.Collections.Generic;
using System.Threading.Tasks;
using MicroservicoCompras.Domain.Entities;

namespace MicroservicoCompras.Domain.Interfaces
{
    public interface IPedidosService
    {
        Task<List<Pedidos>> ObterTodos();
        Task<Pedidos> Adicionar(Pedidos pedido);
        Task<Pedidos> Atualizar(Pedidos pedido);
        void Remover(string pedidoId);
    }
}
