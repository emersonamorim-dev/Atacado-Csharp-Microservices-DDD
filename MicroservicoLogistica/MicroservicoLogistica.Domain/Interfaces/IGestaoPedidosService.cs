using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MicroservicoLogistica.Domain.Entities;

namespace MicroservicoLogistica.Domain.Interfaces
{
    public interface IGestaoPedidosService
    {
        Task<List<GestaoPedidos>> ObterTodos();
        Task<GestaoPedidos> Adicionar(GestaoPedidos pedido);
        Task<GestaoPedidos> Atualizar(GestaoPedidos pedido);
        void Remover(string pedidoId);
    }
}
