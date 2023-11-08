using MicroservicoEstoque.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MicroservicoEstoque.Domain.Interfaces
{
    public interface ISegurancaConformidadeRepository
    {
        Task<List<SegurancaConformidade>> GetSegurancaConformidadeAsync();
        Task<SegurancaConformidade> CreateSegurancaConformidadeAsync(SegurancaConformidade segurancaConformidade);
        Task<SegurancaConformidade> UpdateSegurancaConformidadeAsync(SegurancaConformidade segurancaConformidade);
        Task DeleteSegurancaConformidadeAsync(string segurancaConformidadeId);
    }
}
