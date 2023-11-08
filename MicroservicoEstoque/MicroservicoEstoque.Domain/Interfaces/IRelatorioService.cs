using MicroservicoEstoque.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MicroservicoEstoque.Application.Interfaces
{
    public interface IRelatorioService
    {
        Task<List<Relatorio>> ObterTodos();
        Task<Relatorio> Adicionar(Relatorio relatorio);
        Task<Relatorio> Atualizar(Relatorio relatorio);
        void Remover(string relatorioId);
    }
}
