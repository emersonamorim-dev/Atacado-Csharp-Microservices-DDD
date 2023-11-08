using MicroservicoEstoque.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MicroservicoEstoque.Application.Interfaces
{
    public interface IIntegracaoSistemaService
    {
        Task<List<IntegracaoSistema>> ObterTodos();
        Task<IntegracaoSistema> Adicionar(IntegracaoSistema integracaoSistema);
        Task<IntegracaoSistema> Atualizar(IntegracaoSistema integracaoSistema);
        void Remover(string integracaoSistemaId);
    }
}
