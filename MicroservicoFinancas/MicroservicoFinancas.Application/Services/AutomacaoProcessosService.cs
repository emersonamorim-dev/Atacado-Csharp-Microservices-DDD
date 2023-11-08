using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MicroservicoFinancas.Domain.Entities;
using MicroservicoFinancas.Domain.Interfaces;

namespace MicroservicoFinancas.Application.Services
{
    public class AutomacaoProcessosService : IAutomacaoProcessosService
    {
        private readonly IAutomacaoProcessosRepository _automacaoProcessosRepository;

        public AutomacaoProcessosService(IAutomacaoProcessosRepository automacaoProcessosRepository)
        {
            _automacaoProcessosRepository = automacaoProcessosRepository;
        }

        public Task<List<AutomacaoProcessos>> ObterTodos()
        {
            return _automacaoProcessosRepository.GetAutomacaoProcessosAsync();
        }

        public async Task<AutomacaoProcessos> Adicionar(AutomacaoProcessos automacaoProcessos)
        {
            if (automacaoProcessos == null)
                throw new Exception("Dados inválidos.");

            return await _automacaoProcessosRepository.CreateAutomacaoProcessosAsync(automacaoProcessos);
        }

        public async Task<AutomacaoProcessos> Atualizar(AutomacaoProcessos automacaoProcessos)
        {
            if (automacaoProcessos == null)
                throw new Exception("Dados inválidos.");

            var automacoesProcessos = await _automacaoProcessosRepository.GetAutomacaoProcessosAsync();
            var existeAutomacaoProcessos = automacoesProcessos.FirstOrDefault(a => a.Id == automacaoProcessos.Id);

            if (existeAutomacaoProcessos == null)
                throw new Exception("O processo de automação informado não existe");

            return await _automacaoProcessosRepository.UpdateAutomacaoProcessosAsync(automacaoProcessos);
        }

        public void Remover(string automacaoProcessosId)
        {
            if (string.IsNullOrEmpty(automacaoProcessosId))
                throw new Exception("O Id do processo de automação é inválido");

            _automacaoProcessosRepository.DeleteAutomacaoProcessosAsync(automacaoProcessosId);
        }
    }
}
