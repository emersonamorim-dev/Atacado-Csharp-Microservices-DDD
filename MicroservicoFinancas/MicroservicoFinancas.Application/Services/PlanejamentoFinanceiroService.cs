using MicroservicoFinancas.Application.Interfaces;
using MicroservicoFinancas.Domain.Entities;
using MicroservicoFinancas.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MicroservicoFinancas.Application.Services
{
    public class PlanejamentoFinanceiroService : IPlanejamentoFinanceiroService
    {
        private readonly IPlanejamentoFinanceiroRepository _planejamentoFinanceiroRepository;

        public PlanejamentoFinanceiroService(IPlanejamentoFinanceiroRepository planejamentoFinanceiroRepository)
        {
            _planejamentoFinanceiroRepository = planejamentoFinanceiroRepository;
        }

        public Task<List<PlanejamentoFinanceiro>> ObterTodos()
        {
            return _planejamentoFinanceiroRepository.GetPlanejamentosFinanceirosAsync();
        }

        public async Task<PlanejamentoFinanceiro> Adicionar(PlanejamentoFinanceiro planejamentoFinanceiro)
        {
            ValidarPlanejamentoFinanceiro(planejamentoFinanceiro);
            return await _planejamentoFinanceiroRepository.CreatePlanejamentoFinanceiroAsync(planejamentoFinanceiro);
        }

        public async Task<PlanejamentoFinanceiro> Atualizar(PlanejamentoFinanceiro planejamentoFinanceiro)
        {
            ValidarPlanejamentoFinanceiro(planejamentoFinanceiro);

            var planejamentos = await _planejamentoFinanceiroRepository.GetPlanejamentosFinanceirosAsync();
            var existePlanejamento = planejamentos.FirstOrDefault(p => p.Id == planejamentoFinanceiro.Id);

            if (existePlanejamento == null)
                throw new Exception("O planejamento financeiro informado não existe");

            return await _planejamentoFinanceiroRepository.UpdatePlanejamentoFinanceiroAsync(planejamentoFinanceiro);
        }

        public void Remover(string planejamentoId)
        {
            if (string.IsNullOrEmpty(planejamentoId))
                throw new Exception("O Id do planejamento financeiro é inválido");

            _planejamentoFinanceiroRepository.DeletePlanejamentoFinanceiroAsync(planejamentoId);
        }

        private void ValidarPlanejamentoFinanceiro(PlanejamentoFinanceiro planejamentoFinanceiro)
        {
            if (planejamentoFinanceiro == null)
                throw new Exception("Dados inválidos.");
        }
    }
}
