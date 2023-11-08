using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MicroservicoLogistica.Domain.Entities;

namespace MicroservicoLogistica.Domain.Interfaces
{
    public interface IRastreamentoEntregasService
    {
        Task<List<RastreamentoEntregas>> ObterTodosRastreamentos();
        Task<RastreamentoEntregas> AdicionarRastreamento(RastreamentoEntregas rastreamento);
        Task<RastreamentoEntregas> AtualizarRastreamento(RastreamentoEntregas rastreamento);
        void RemoverRastreamento(string rastreamentoId);
    }
}
