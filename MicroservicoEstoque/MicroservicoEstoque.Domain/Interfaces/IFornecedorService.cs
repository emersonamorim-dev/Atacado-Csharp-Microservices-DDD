using MicroservicoEstoque.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MicroservicoEstoque.Application.Interfaces
{
    public interface IFornecedorService
    {
        Task<List<Fornecedor>> ObterTodos();
        Task<Fornecedor> Adicionar(Fornecedor fornecedor);
        Task<Fornecedor> Atualizar(Fornecedor fornecedor);
        void Remover(string fornecedorId);
    }
}
