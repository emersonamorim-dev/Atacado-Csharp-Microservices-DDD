using MicroservicoEstoque.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MicroservicoEstoque.Domain.Interfaces
{
    public interface IInventarioRepository
    {
        Task<List<Inventario>> GetInventarioAsync();
        Task<Inventario> CreateInventarioAsync(Inventario inventario);
        Task<Inventario> UpdateInventarioAsync(Inventario inventario);
        Task DeleteInventarioAsync(string inventarioId);
    }
}
