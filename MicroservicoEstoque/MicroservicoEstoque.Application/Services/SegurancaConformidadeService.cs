using MicroservicoEstoque.Application.Interfaces;
using MicroservicoEstoque.Domain.Entities;
using MicroservicoEstoque.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MicroservicoEstoque.Application.Services
{
    public class SegurancaConformidadeService : ISegurancaConformidadeService
    {
        private readonly ISegurancaConformidadeRepository _segurancaConformidadeRepository;

        public SegurancaConformidadeService(ISegurancaConformidadeRepository segurancaConformidadeRepository)
        {
            _segurancaConformidadeRepository = segurancaConformidadeRepository;
        }

        public Task<List<SegurancaConformidade>> ObterTodos()
        {
            return _segurancaConformidadeRepository.GetSegurancaConformidadeAsync();
        }

        public async Task<SegurancaConformidade> Adicionar(SegurancaConformidade segurancaConformidade)
        {
            if (segurancaConformidade == null)
                throw new Exception("Dados inválidos.");

            return await _segurancaConformidadeRepository.CreateSegurancaConformidadeAsync(segurancaConformidade);
        }

        public async Task<SegurancaConformidade> Atualizar(SegurancaConformidade segurancaConformidade)
        {
            if (segurancaConformidade == null)
                throw new Exception("Dados inválidos.");

            var segurancasConformidade = await _segurancaConformidadeRepository.GetSegurancaConformidadeAsync();
            var existeSegurancaConformidade = segurancasConformidade.FirstOrDefault(s => s.Id == segurancaConformidade.Id);

            if (existeSegurancaConformidade == null)
                throw new Exception("A segurança e conformidade informada não existe");

            var atualizacao = await _segurancaConformidadeRepository.UpdateSegurancaConformidadeAsync(segurancaConformidade);

            return atualizacao;
        }

        public void Remover(string segurancaConformidadeId)
        {
            if (string.IsNullOrEmpty(segurancaConformidadeId))
                throw new Exception("O Id da segurança e conformidade é inválido");

            _segurancaConformidadeRepository.DeleteSegurancaConformidadeAsync(segurancaConformidadeId);
        }
    }
}
