using MicroservicoEstoque.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MicroservicoEstoque.Domain.Interfaces
{
    public interface IControleQualidadeRepository
    {
        Task<List<ControleQualidade>> GetControleQualidadeAsync();
        Task<ControleQualidade> CreateControleQualidadeAsync(ControleQualidade controleQualidade);
        Task<ControleQualidade> UpdateControleQualidadeAsync(ControleQualidade controleQualidade);
        Task DeleteControleQualidadeAsync(string controleQualidadeId);
    }
}
