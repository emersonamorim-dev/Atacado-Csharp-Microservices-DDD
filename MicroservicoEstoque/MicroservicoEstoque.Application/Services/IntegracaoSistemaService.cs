using MicroservicoEstoque.Application.Interfaces;
using MicroservicoEstoque.Domain.Entities;
using MicroservicoEstoque.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MicroservicoEstoque.Application.Services
{
    public class IntegracaoSistemaService : IIntegracaoSistemaService
    {
        private readonly IIntegracaoSistemaRepository _integracaoSistemaRepository;

        public IntegracaoSistemaService(IIntegracaoSistemaRepository integracaoSistemaRepository)
        {
            _integracaoSistemaRepository = integracaoSistemaRepository;
        }

        public Task<List<IntegracaoSistema>> ObterTodos()
        {
            return _integracaoSistemaRepository.GetIntegracaoSistemaAsync();
        }

        public async Task<IntegracaoSistema> Adicionar(IntegracaoSistema integracaoSistema)
        {
            if (integracaoSistema == null)
                throw new Exception("Dados inválidos.");

            return await _integracaoSistemaRepository.CreateIntegracaoSistemaAsync(integracaoSistema);
        }

        public async Task<IntegracaoSistema> Atualizar(IntegracaoSistema integracaoSistema)
        {
            if (integracaoSistema == null)
                throw new Exception("Dados inválidos.");

            var integracoesSistema = await _integracaoSistemaRepository.GetIntegracaoSistemaAsync();
            var existeIntegracaoSistema = integracoesSistema.FirstOrDefault(i => i.Id == integracaoSistema.Id);

            if (existeIntegracaoSistema == null)
                throw new Exception("A integração de sistema informada não existe");

            var atualizacao = await _integracaoSistemaRepository.UpdateIntegracaoSistemaAsync(integracaoSistema);

            return atualizacao;
        }

        public void Remover(string integracaoSistemaId)
        {
            if (string.IsNullOrEmpty(integracaoSistemaId))
                throw new Exception("O Id da integração de sistema é inválido");

            _integracaoSistemaRepository.DeleteIntegracaoSistemaAsync(integracaoSistemaId);
        }
    }
}
