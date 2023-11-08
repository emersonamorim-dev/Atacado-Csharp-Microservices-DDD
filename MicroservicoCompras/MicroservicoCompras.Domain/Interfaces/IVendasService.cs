using System.Collections.Generic;
using System.Threading.Tasks;
using MicroservicoCompras.Domain.Entities;

namespace MicroservicoCompras.Application.Interfaces
{
    public interface IVendasService
    {
        Task<List<Venda>> ObterTodos();
        Task<Venda> Adicionar(Venda venda);
        Task<Venda> Atualizar(Venda venda);
        void Remover(string vendaId);
    }
}
