using MicroservicoEstoque.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MicroservicoEstoque.Domain.Interfaces
{
    public interface IDevolucaoRepository
    {
        Task<List<Devolucao>> GetDevolucaoAsync();
        Task<Devolucao> CreateDevolucaoAsync(Devolucao devolucao);
        Task<Devolucao> UpdateDevolucaoAsync(Devolucao devolucao);
        Task DeleteDevolucaoAsync(string devolucaoId);
    }
}
