using MicroservicoEstoque.Application.Interfaces;
using MicroservicoEstoque.Domain.Entities;
using MicroservicoEstoque.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MicroservicoEstoque.Application.Services
{
    public class FornecedorService : IFornecedorService
    {
        private readonly IFornecedorRepository _fornecedorRepository;

        public FornecedorService(IFornecedorRepository fornecedorRepository)
        {
            _fornecedorRepository = fornecedorRepository;
        }

        public Task<List<Fornecedor>> ObterTodos()
        {
            return _fornecedorRepository.GetFornecedorAsync();
        }

        public async Task<Fornecedor> Adicionar(Fornecedor fornecedor)
        {
            if (fornecedor == null)
                throw new Exception("Dados inválidos.");

            return await _fornecedorRepository.CreateFornecedorAsync(fornecedor);
        }

        public async Task<Fornecedor> Atualizar(Fornecedor fornecedor)
        {
            if (fornecedor == null)
                throw new Exception("Dados inválidos.");

            var fornecedores = await _fornecedorRepository.GetFornecedorAsync();
            var existeFornecedor = fornecedores.FirstOrDefault(f => f.Id == fornecedor.Id);

            if (existeFornecedor == null)
                throw new Exception("O fornecedor informado não existe");

            var atualizacao = await _fornecedorRepository.UpdateFornecedorAsync(fornecedor);

            return atualizacao;
        }

        public void Remover(string fornecedorId)
        {
            if (string.IsNullOrEmpty(fornecedorId))
                throw new Exception("O Id do fornecedor é inválido");

            _fornecedorRepository.DeleteFornecedorAsync(fornecedorId);
        }
    }
}
