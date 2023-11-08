using MicroservicoEstoque.Application.Interfaces;
using MicroservicoEstoque.Domain.Entities;
using MicroservicoEstoque.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MicroservicoEstoque.Application.Services
{
    public class ControleQualidadeService : IControleQualidadeService
    {
        private readonly IControleQualidadeRepository _controleQualidadeRepository;

        public ControleQualidadeService(IControleQualidadeRepository controleQualidadeRepository)
        {
            _controleQualidadeRepository = controleQualidadeRepository;
        }

        public Task<List<ControleQualidade>> ObterTodos()
        {
            return _controleQualidadeRepository.GetControleQualidadeAsync();
        }

        public async Task<ControleQualidade> Adicionar(ControleQualidade controleQualidade)
        {
            if (controleQualidade == null)
                throw new Exception("Dados inválidos.");

            return await _controleQualidadeRepository.CreateControleQualidadeAsync(controleQualidade);
        }

        public async Task<ControleQualidade> Atualizar(ControleQualidade controleQualidade)
        {
            if (controleQualidade == null)
                throw new Exception("Dados inválidos.");

            var controlesQualidade = await _controleQualidadeRepository.GetControleQualidadeAsync();
            var existeControleQualidade = controlesQualidade.FirstOrDefault(c => c.Id == controleQualidade.Id);

            if (existeControleQualidade == null)
                throw new Exception("O controle de qualidade informado não existe");

            var atualizacao = await _controleQualidadeRepository.UpdateControleQualidadeAsync(controleQualidade);

            return atualizacao;
        }

        public void Remover(string controleQualidadeId)
        {
            if (string.IsNullOrEmpty(controleQualidadeId))
                throw new Exception("O Id do controle de qualidade é inválido");

            _controleQualidadeRepository.DeleteControleQualidadeAsync(controleQualidadeId);
        }
    }
}
