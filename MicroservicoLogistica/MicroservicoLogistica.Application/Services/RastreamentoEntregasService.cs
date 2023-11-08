using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MicroservicoLogistica.Domain.Entities;
using MicroservicoLogistica.Domain.Interfaces;

namespace MicroservicoLogistica.Application.Services
{
    public class RastreamentoEntregasService : IRastreamentoEntregasService
    {
        private readonly IRastreamentoEntregasRepository _rastreamentoEntregasRepository;

        public RastreamentoEntregasService(IRastreamentoEntregasRepository rastreamentoEntregasRepository)
        {
            _rastreamentoEntregasRepository = rastreamentoEntregasRepository;
        }

        public Task<List<RastreamentoEntregas>> ObterTodosRastreamentos()
        {
            return _rastreamentoEntregasRepository.GetRastreamentosAsync();
        }

        public async Task<RastreamentoEntregas> AdicionarRastreamento(RastreamentoEntregas rastreamento)
        {
            if (rastreamento == null)
                throw new Exception("Dados inválidos.");

            return await _rastreamentoEntregasRepository.CreateRastreamentoAsync(rastreamento);
        }

        public async Task<RastreamentoEntregas> AtualizarRastreamento(RastreamentoEntregas rastreamento)
        {
            if (rastreamento == null)
                throw new Exception("Dados inválidos.");

            var rastreamentos = await _rastreamentoEntregasRepository.GetRastreamentosAsync();
            var existeRastreamento = rastreamentos.FirstOrDefault(r => r.Id == rastreamento.Id);

            if (existeRastreamento == null)
                throw new Exception("O rastreamento informado não existe");

            return await _rastreamentoEntregasRepository.UpdateRastreamentoAsync(rastreamento);
        }

        public void RemoverRastreamento(string rastreamentoId)
        {
            if (string.IsNullOrEmpty(rastreamentoId))
                throw new Exception("O Id do rastreamento é inválido");

            _rastreamentoEntregasRepository.DeleteRastreamentoAsync(rastreamentoId);
        }
    }
}
