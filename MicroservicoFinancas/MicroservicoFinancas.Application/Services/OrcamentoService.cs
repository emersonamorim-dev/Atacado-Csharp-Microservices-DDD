using MicroservicoFinancas.Application.Interfaces;
using MicroservicoFinancas.Domain.Entities;
using MicroservicoFinancas.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MicroservicoFinancas.Application.Services
{
    public class OrcamentoService : IOrcamentoService
    {
        private readonly IOrcamentoRepository _orcamentoRepository;

        public OrcamentoService(IOrcamentoRepository orcamentoRepository)
        {
            _orcamentoRepository = orcamentoRepository;
        }

        public Task<List<Orcamento>> ObterTodos()
        {
            return _orcamentoRepository.GetOrcamentosAsync();
        }

        public async Task<Orcamento> Adicionar(Orcamento orcamento)
        {
            ValidarOrcamento(orcamento);
            return await _orcamentoRepository.CreateOrcamentoAsync(orcamento);
        }

        public async Task<Orcamento> Atualizar(Orcamento orcamento)
        {
            ValidarOrcamento(orcamento);

            var orcamentos = await _orcamentoRepository.GetOrcamentosAsync();
            var existeOrcamento = orcamentos.FirstOrDefault(o => o.Id == orcamento.Id);

            if (existeOrcamento == null)
                throw new Exception("O orçamento informado não existe");

            return await _orcamentoRepository.UpdateOrcamentoAsync(orcamento);
        }

        public void Remover(string orcamentoId)
        {
            if (string.IsNullOrEmpty(orcamentoId))
                throw new Exception("O Id do orçamento é inválido");

            _orcamentoRepository.DeleteOrcamentoAsync(orcamentoId);
        }

        private void ValidarOrcamento(Orcamento orcamento)
        {
            if (orcamento == null)
                throw new Exception("Dados inválidos.");
        }
    }
}
