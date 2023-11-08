using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MicroservicoLogistica.Domain.Entities;

namespace MicroservicoLogistica.Domain.Interfaces
{
    public interface IGestaoVeiculosRepository
    {
        Task<List<GestaoVeiculos>> GetVeiculosAsync();
        Task<GestaoVeiculos> CreateVeiculoAsync(GestaoVeiculos veiculo);
        Task<GestaoVeiculos> UpdateVeiculoAsync(GestaoVeiculos veiculo);
        Task DeleteVeiculoAsync(string veiculoId);
    }
}
