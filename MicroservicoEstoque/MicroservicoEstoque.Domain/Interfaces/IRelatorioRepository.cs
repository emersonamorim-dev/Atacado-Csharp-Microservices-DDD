using MicroservicoEstoque.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MicroservicoEstoque.Domain.Interfaces
{
    public interface IRelatorioRepository
    {
        Task<List<Relatorio>> GetRelatorioAsync();
        Task<Relatorio> CreateRelatorioAsync(Relatorio relatorio);
        Task<Relatorio> UpdateRelatorioAsync(Relatorio relatorio);
        Task DeleteRelatorioAsync(string relatorioId);
    }
}
