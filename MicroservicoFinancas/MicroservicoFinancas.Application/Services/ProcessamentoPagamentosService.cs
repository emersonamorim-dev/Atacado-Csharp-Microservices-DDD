using MicroservicoFinancas.Application.Interfaces;
using MicroservicoFinancas.Domain.Entities;
using MicroservicoFinancas.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MicroservicoFinancas.Application.Services
{
    public class ProcessamentoPagamentosService : IProcessamentoPagamentosService
    {
        private readonly IProcessamentoPagamentosRepository _processamentoPagamentosRepository;

        public ProcessamentoPagamentosService(IProcessamentoPagamentosRepository processamentoPagamentosRepository)
        {
            _processamentoPagamentosRepository = processamentoPagamentosRepository;
        }

        public Task<List<ProcessamentoPagamentos>> ObterTodos()
        {
            return _processamentoPagamentosRepository.GetProcessamentosPagamentosAsync();
        }

        public async Task<ProcessamentoPagamentos> Adicionar(ProcessamentoPagamentos processamentoPagamentos)
        {
            if (processamentoPagamentos == null)
                throw new Exception("Dados inválidos.");

            return await _processamentoPagamentosRepository.CreateProcessamentoPagamentosAsync(processamentoPagamentos);
        }

        public async Task<ProcessamentoPagamentos> Atualizar(ProcessamentoPagamentos processamentoPagamentos)
        {
            if (processamentoPagamentos == null)
                throw new Exception("Dados inválidos.");

            var processamentos = await _processamentoPagamentosRepository.GetProcessamentosPagamentosAsync();
            var existeProcessamento = processamentos.FirstOrDefault(p => p.Id == processamentoPagamentos.Id);

            if (existeProcessamento == null)
                throw new Exception("O processamento de pagamentos informado não existe");

            var atualizacao = await _processamentoPagamentosRepository.UpdateProcessamentoPagamentosAsync(processamentoPagamentos);

            return atualizacao;
        }

        public void Remover(string processamentoPagamentosId)
        {
            if (string.IsNullOrEmpty(processamentoPagamentosId))
                throw new Exception("O Id do processamento de pagamentos é inválido");

            _processamentoPagamentosRepository.DeleteProcessamentoPagamentosAsync(processamentoPagamentosId);
        }
    }
}
