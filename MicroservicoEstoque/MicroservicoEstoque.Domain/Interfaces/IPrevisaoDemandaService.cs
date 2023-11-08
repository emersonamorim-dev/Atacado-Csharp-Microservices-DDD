using MicroservicoEstoque.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MicroservicoEstoque.Application.Interfaces
{
    public interface IPrevisaoDemandaService
    {
        Task<List<PrevisaoDemanda>> ObterTodos();
        Task<PrevisaoDemanda> Adicionar(PrevisaoDemanda previsaoDemanda);
        Task<PrevisaoDemanda> Atualizar(PrevisaoDemanda previsaoDemanda);
        void Remover(string previsaoDemandaId);
    }
}
