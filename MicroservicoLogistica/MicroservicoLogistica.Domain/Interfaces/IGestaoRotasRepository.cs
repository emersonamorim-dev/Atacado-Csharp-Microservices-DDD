using System.Collections.Generic;
using System.Threading.Tasks;
using MicroservicoLogistica.Domain.Entities;

namespace MicroservicoLogistica.Domain.Interfaces
{
    public interface IGestaoRotasRepository
    {
        Task<List<GestaoRotas>> GetRotasAsync();
        Task<GestaoRotas> GetRotaByIdAsync(string rotaId);
        Task<GestaoRotas> CreateRotaAsync(GestaoRotas rota);
        Task UpdateRotaAsync(GestaoRotas rota);
        Task DeleteRotaAsync(string rotaId);
    }
}
