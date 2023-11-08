using MicroservicoEstoque.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MicroservicoEstoque.Application.Interfaces
{
    public interface IDevolucaoService
    {
        Task<List<Devolucao>> ObterTodos();
        Task<Devolucao> Adicionar(Devolucao devolucao);
        Task<Devolucao> Atualizar(Devolucao devolucao);
        void Remover(string devolucaoId);
    }
}
