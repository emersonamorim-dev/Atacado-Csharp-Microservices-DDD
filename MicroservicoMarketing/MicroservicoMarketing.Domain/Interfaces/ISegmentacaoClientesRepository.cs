using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MicroservicoMarketing.Domain.Entities;

namespace MicroservicoMarketing.Domain.Interfaces
{
    public interface ISegmentacaoClientesRepository
    {
        Task<List<SegmentacaoClientes>> GetSegmentacoesAsync();
        Task<SegmentacaoClientes> CreateSegmentacaoAsync(SegmentacaoClientes segmentacao);
        Task<SegmentacaoClientes> UpdateSegmentacaoAsync(SegmentacaoClientes segmentacao);
        Task DeleteSegmentacaoAsync(string segmentacaoId);
    }
}
