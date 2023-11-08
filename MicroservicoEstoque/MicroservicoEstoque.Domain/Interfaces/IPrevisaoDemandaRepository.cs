using MicroservicoEstoque.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MicroservicoEstoque.Domain.Interfaces
{
    public interface IPrevisaoDemandaRepository
    {
        Task<List<PrevisaoDemanda>> GetPrevisaoDemandaAsync();
        Task<PrevisaoDemanda> CreatePrevisaoDemandaAsync(PrevisaoDemanda previsaoDemanda);
        Task<PrevisaoDemanda> UpdatePrevisaoDemandaAsync(PrevisaoDemanda previsaoDemanda);
        Task DeletePrevisaoDemandaAsync(string previsaoDemandaId);
    }
}
