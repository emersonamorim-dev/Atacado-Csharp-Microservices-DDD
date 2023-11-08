using MicroservicoEstoque.Domain.Entities;
using MicroservicoEstoque.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace MicroservicoEstoque.Application.Services
{
    public class ArmazemService : IArmazemService
    {
        private readonly IArmazemRepository _armazemRepository;

        public ArmazemService(IArmazemRepository armazemRepository)
        {
            _armazemRepository = armazemRepository;
        }

        public Task<List<Armazem>> ObterTodos()
        {
            return _armazemRepository.GetArmazemAsync();
        }

        public async Task<Armazem> Adicionar(Armazem armazem)
        {
            if (armazem == null)
                throw new Exception("Dados inválidos.");

            return await _armazemRepository.CreateArmazemAsync(armazem);
        }

        public async Task<Armazem> Atualizar(Armazem armazem)
        {
            if (armazem == null)
                throw new Exception("Dados inválidos.");

            var armazens = await _armazemRepository.GetArmazemAsync();
            var existeArmazem = armazens.FirstOrDefault(a => a.Id == armazem.Id);

            if (existeArmazem == null)
                throw new Exception("O armazém informado não existe");

            var atualizacao = await _armazemRepository.UpdateArmazemAsync(armazem);

            return atualizacao;
        }

        public void Remover(string armazemId)
        {
            if (string.IsNullOrEmpty(armazemId))
                throw new Exception("O Id do armazém é inválido");

            _armazemRepository.DeleteArmazemAsync(armazemId);
        }
    }
}

