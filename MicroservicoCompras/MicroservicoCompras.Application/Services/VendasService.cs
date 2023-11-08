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
    public class VendasService : IVendasService
    {
        private readonly IVendasRepository _vendasRepository;

        public VendasService(IVendasRepository vendasRepository)
        {
            _vendasRepository = vendasRepository;
        }

        public Task<List<Venda>> ObterTodos()
        {
            return _vendasRepository.GetVendaAsync();
        }

        public async Task<Venda> Adicionar(Venda venda)
        {
            if (venda == null)
                throw new Exception("Dados inválidos.");

            return await _vendasRepository.CreateVendaAsync(venda);
        }

        public async Task<Venda> Atualizar(Venda venda)
        {
            if (venda == null)
                throw new Exception("Dados inválidos.");

            var vendas = await _vendasRepository.GetVendaAsync();
            var existeVenda = vendas.FirstOrDefault(v => v.Id == venda.Id);

            if (existeVenda == null)
                throw new Exception("A venda informada não existe");

            var atualizacao = await _vendasRepository.UpdateVendaAsync(venda);

            return atualizacao;
        }

        public void Remover(string vendaId)
        {
            if (string.IsNullOrEmpty(vendaId))
                throw new Exception("O Id da venda é inválido");

            _vendasRepository.DeleteVendaAsync(vendaId);
        }
    }
}
