using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MicroservicoFinancas.Domain.Entities;

namespace MicroservicoFinancas.Domain.Interfaces
{
    public interface IRiscosRepository
    {
        Task<List<Riscos>> GetRiscosAsync();
        Task<Riscos> CreateRiscosAsync(Riscos riscos);
        Task DeleteRiscosAsync(string riscosId);
        Task<Riscos> UpdateRiscosAsync(Riscos riscos);
    }
}
