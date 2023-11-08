using MicroservicoEstoque.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MicroservicoEstoque.Domain.Interfaces
{
    public interface IArmazemRepository
    {
        Task<List<Armazem>> GetArmazemAsync();
        Task<Armazem> CreateArmazemAsync(Armazem armazem);
        Task DeleteArmazemAsync(string armazemId);
        Task<Armazem> UpdateArmazemAsync(Armazem armazem);
    }
}