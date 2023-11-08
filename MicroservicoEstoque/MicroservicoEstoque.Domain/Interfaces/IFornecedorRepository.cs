using MicroservicoEstoque.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MicroservicoEstoque.Domain.Interfaces
{
    public interface IFornecedorRepository
    {
        Task<List<Fornecedor>> GetFornecedorAsync();
        Task<Fornecedor> CreateFornecedorAsync(Fornecedor fornecedor);
        Task<Fornecedor> UpdateFornecedorAsync(Fornecedor fornecedor);
        Task DeleteFornecedorAsync(string fornecedorId);
    }
}