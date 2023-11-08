using MicroservicoEstoque.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MicroservicoEstoque.Domain.Interfaces
{
    public interface IIntegracaoSistemaRepository
    {
        Task<List<IntegracaoSistema>> GetIntegracaoSistemaAsync();
        Task<IntegracaoSistema> CreateIntegracaoSistemaAsync(IntegracaoSistema integracaoSistema);
        Task<IntegracaoSistema> UpdateIntegracaoSistemaAsync(IntegracaoSistema integracaoSistema);
        Task DeleteIntegracaoSistemaAsync(string integracaoSistemaId);
    }
}
