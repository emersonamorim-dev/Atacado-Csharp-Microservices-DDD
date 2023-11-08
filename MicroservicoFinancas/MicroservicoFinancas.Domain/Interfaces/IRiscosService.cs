using MicroservicoFinancas.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MicroservicoFinancas.Application.Interfaces
{
    public interface IRiscosService
    {
        Task<List<Riscos>> ObterTodos();
        Task<Riscos> Adicionar(Riscos riscos);
        Task<Riscos> Atualizar(Riscos riscos);
        void Remover(string riscosId);
    }
}
