using MicroservicoFinancas.Application.Interfaces;
using MicroservicoFinancas.Domain.Entities;
using MicroservicoFinancas.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MicroservicoFinancas.Application.Services
{
    public class AnaliseFinanceiraService : IAnaliseFinanceiraService
    {
        private readonly IAnaliseFinanceiraRepository _analiseFinanceiraRepository;

        public AnaliseFinanceiraService(IAnaliseFinanceiraRepository analiseFinanceiraRepository)
        {
            _analiseFinanceiraRepository = analiseFinanceiraRepository;
        }

        public Task<List<AnaliseFinanceira>> ObterTodas()
        {
            return _analiseFinanceiraRepository.GetAnalisesFinanceirasAsync();
        }

        public async Task<AnaliseFinanceira> Adicionar(AnaliseFinanceira analiseFinanceira)
        {
            if (analiseFinanceira == null)
                throw new Exception("Dados inválidos.");

            return await _analiseFinanceiraRepository.CreateAnaliseFinanceiraAsync(analiseFinanceira);
        }

        public async Task<AnaliseFinanceira> Atualizar(AnaliseFinanceira analiseFinanceira)
        {
            if (analiseFinanceira == null)
                throw new Exception("Dados inválidos.");

            var analisesFinanceiras = await _analiseFinanceiraRepository.GetAnalisesFinanceirasAsync();
            var existeAnaliseFinanceira = analisesFinanceiras.FirstOrDefault(a => a.Id == analiseFinanceira.Id);

            if (existeAnaliseFinanceira == null)
                throw new Exception("A análise financeira informada não existe");

            var atualizacao = await _analiseFinanceiraRepository.UpdateAnaliseFinanceiraAsync(analiseFinanceira);

            return atualizacao;
        }

        public void Remover(string analiseFinanceiraId)
        {
            if (string.IsNullOrEmpty(analiseFinanceiraId))
                throw new Exception("O Id da análise financeira é inválido");

            _analiseFinanceiraRepository.DeleteAnaliseFinanceiraAsync(analiseFinanceiraId);
        }
    }
}
