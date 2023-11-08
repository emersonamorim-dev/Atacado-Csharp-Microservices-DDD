using MicroservicoEstoque.Application.Interfaces;
using MicroservicoEstoque.Domain.Entities;
using MicroservicoEstoque.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MicroservicoEstoque.Application.Services
{
    public class DevolucaoService : IDevolucaoService
    {
        private readonly IDevolucaoRepository _devolucaoRepository;

        public DevolucaoService(IDevolucaoRepository devolucaoRepository)
        {
            _devolucaoRepository = devolucaoRepository;
        }

        public Task<List<Devolucao>> ObterTodos()
        {
            return _devolucaoRepository.GetDevolucaoAsync();
        }

        public async Task<Devolucao> Adicionar(Devolucao devolucao)
        {
            if (devolucao == null)
                throw new Exception("Dados inválidos.");

            return await _devolucaoRepository.CreateDevolucaoAsync(devolucao);
        }

        public async Task<Devolucao> Atualizar(Devolucao devolucao)
        {
            if (devolucao == null)
                throw new Exception("Dados inválidos.");

            var devolucoes = await _devolucaoRepository.GetDevolucaoAsync();
            var existeDevolucao = devolucoes.FirstOrDefault(d => d.Id == devolucao.Id);

            if (existeDevolucao == null)
                throw new Exception("A devolução informada não existe");

            var atualizacao = await _devolucaoRepository.UpdateDevolucaoAsync(devolucao);

            return atualizacao;
        }

        public void Remover(string devolucaoId)
        {
            if (string.IsNullOrEmpty(devolucaoId))
                throw new Exception("O Id da devolução é inválido");

            _devolucaoRepository.DeleteDevolucaoAsync(devolucaoId);
        }
    }
}
