using MicroservicoEstoque.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MicroservicoEstoque.Application.Interfaces
{
    public interface ISegurancaConformidadeService
    {
        Task<List<SegurancaConformidade>> ObterTodos();
        Task<SegurancaConformidade> Adicionar(SegurancaConformidade segurancaConformidade);
        Task<SegurancaConformidade> Atualizar(SegurancaConformidade segurancaConformidade);
        void Remover(string segurancaConformidadeId);
    }
}
