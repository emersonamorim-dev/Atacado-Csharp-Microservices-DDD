using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MicroservicoCompras.Domain.Entities;
using MicroservicoCompras.Infra.Repositories;
using MongoDB.Driver;
using MicroservicoCompras.Application.Interfaces;
using MicroservicoCompras.Infra.Interfaces;

namespace MicroservicoCompras.Application.Services
{
    public class PagamentoService : IPagamentoService
    {
        private readonly IPagamentoRepository _pagamentoRepository;

        public PagamentoService(IPagamentoRepository pagamentoRepository)
        {
            _pagamentoRepository = pagamentoRepository;
        }

        public Task<List<Pagamento>> ObterTodos()
        {
            return _pagamentoRepository.GetPagamentoAsync();
        }

        public async Task<Pagamento> Adicionar(Pagamento pagamento)
        {
            if (pagamento == null)
                throw new Exception("Dados inválidos.");

            return await _pagamentoRepository.CreatePagamentoAsync(pagamento);
        }

        public async Task<Pagamento> Atualizar(Pagamento pagamento)
        {
            if (pagamento == null)
                throw new Exception("Dados inválidos.");

            var pagamentos = await _pagamentoRepository.GetPagamentoAsync();
            var existePagamento = pagamentos.FirstOrDefault(p => p.Id == pagamento.Id);

            if (existePagamento == null)
                throw new Exception("O pagamento informado não existe");

            var atualizacao = await _pagamentoRepository.UpdatePagamentoAsync(pagamento);

            return atualizacao;
        }

        public void Remover(string pagamentoId)
        {
            if (string.IsNullOrEmpty(pagamentoId))
                throw new Exception("O Id do pagamento é inválido");

            _pagamentoRepository.DeletePagamentoAsync(pagamentoId);
        }
    }
}

