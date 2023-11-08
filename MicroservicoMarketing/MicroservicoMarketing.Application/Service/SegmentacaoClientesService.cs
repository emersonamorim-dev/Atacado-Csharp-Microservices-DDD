using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MicroservicoMarketing.Domain.Entities;
using MicroservicoMarketing.Domain.Interfaces;

namespace MicroservicoMarketing.Application.Service
{
    public class SegmentacaoClientesService : ISegmentacaoClientesService
    {
        private readonly ISegmentacaoClientesRepository _segmentacaoClientesRepository;

        public SegmentacaoClientesService(ISegmentacaoClientesRepository segmentacaoClientesRepository)
        {
            _segmentacaoClientesRepository = segmentacaoClientesRepository;
        }

        public Task<List<SegmentacaoClientes>> ObterTodos()
        {
            return _segmentacaoClientesRepository.GetSegmentacoesAsync();
        }

        public async Task<SegmentacaoClientes> Adicionar(SegmentacaoClientes segmentacao)
        {
            if (segmentacao == null)
                throw new Exception("Dados inválidos.");

            return await _segmentacaoClientesRepository.CreateSegmentacaoAsync(segmentacao);
        }

        public async Task<SegmentacaoClientes> Atualizar(SegmentacaoClientes segmentacao)
        {
            if (segmentacao == null)
                throw new Exception("Dados inválidos.");

            var segmentacoes = await _segmentacaoClientesRepository.GetSegmentacoesAsync();
            var existeSegmentacao = segmentacoes.FirstOrDefault(s => s.Id == segmentacao.Id);

            if (existeSegmentacao == null)
                throw new Exception("A segmentação informada não existe");

            return await _segmentacaoClientesRepository.UpdateSegmentacaoAsync(segmentacao);
        }

        public void Remover(string segmentacaoId)
        {
            if (string.IsNullOrEmpty(segmentacaoId))
                throw new Exception("O Id da segmentação é inválido");

            _segmentacaoClientesRepository.DeleteSegmentacaoAsync(segmentacaoId);
        }
    }
}
