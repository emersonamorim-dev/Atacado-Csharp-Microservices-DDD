using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MicroservicoLogistica.Domain.Entities;

namespace MicroservicoLogistica.Domain.Interfaces
{
    public interface IGestaoPedidosRepository
    {
        Task<List<GestaoPedidos>> GetPedidosAsync();
        Task<GestaoPedidos> CreatePedidoAsync(GestaoPedidos pedido);
        Task<GestaoPedidos> UpdatePedidoAsync(GestaoPedidos pedido);
        Task DeletePedidoAsync(string pedidoId);
    }
}
