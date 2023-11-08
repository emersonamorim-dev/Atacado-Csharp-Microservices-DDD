using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MicroservicoLogistica.Domain.Entities;

namespace MicroservicoLogistica.Domain.Interfaces
{
    public interface IRastreamentoEntregasRepository
    {
        Task<List<RastreamentoEntregas>> GetRastreamentosAsync();
        Task<RastreamentoEntregas> CreateRastreamentoAsync(RastreamentoEntregas rastreamento);
        Task<RastreamentoEntregas> UpdateRastreamentoAsync(RastreamentoEntregas rastreamento);
        Task DeleteRastreamentoAsync(string rastreamentoId);
    }
}
