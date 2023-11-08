using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MicroservicoMarketing.Domain.Entities;

namespace MicroservicoMarketing.Domain.Interfaces
{
    public interface ISegmentacaoClientesService
    {
        Task<List<SegmentacaoClientes>> ObterTodos();
        Task<SegmentacaoClientes> Adicionar(SegmentacaoClientes segmentacao);
        Task<SegmentacaoClientes> Atualizar(SegmentacaoClientes segmentacao);
        void Remover(string segmentacaoId);
    }
}
