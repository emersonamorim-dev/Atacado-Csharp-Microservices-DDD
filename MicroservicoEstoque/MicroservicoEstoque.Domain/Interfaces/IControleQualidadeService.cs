using MicroservicoEstoque.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MicroservicoEstoque.Application.Interfaces
{
    public interface IControleQualidadeService
    {
        Task<List<ControleQualidade>> ObterTodos();
        Task<ControleQualidade> Adicionar(ControleQualidade controleQualidade);
        Task<ControleQualidade> Atualizar(ControleQualidade controleQualidade);
        void Remover(string controleQualidadeId);
    }
}
