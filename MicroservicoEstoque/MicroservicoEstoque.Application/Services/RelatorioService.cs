using MicroservicoEstoque.Application.Interfaces;
using MicroservicoEstoque.Domain.Entities;
using MicroservicoEstoque.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MicroservicoEstoque.Application.Services
{
    public class RelatorioService : IRelatorioService
    {
        private readonly IRelatorioRepository _relatorioRepository;

        public RelatorioService(IRelatorioRepository relatorioRepository)
        {
            _relatorioRepository = relatorioRepository;
        }

        public Task<List<Relatorio>> ObterTodos()
        {
            return _relatorioRepository.GetRelatorioAsync();
        }

        public async Task<Relatorio> Adicionar(Relatorio relatorio)
        {
            if (relatorio == null)
                throw new Exception("Dados inválidos.");

            return await _relatorioRepository.CreateRelatorioAsync(relatorio);
        }

        public async Task<Relatorio> Atualizar(Relatorio relatorio)
        {
            if (relatorio == null)
                throw new Exception("Dados inválidos.");

            var relatorios = await _relatorioRepository.GetRelatorioAsync();
            var existeRelatorio = relatorios.FirstOrDefault(r => r.Id == relatorio.Id);

            if (existeRelatorio == null)
                throw new Exception("O relatório informado não existe");

            var atualizacao = await _relatorioRepository.UpdateRelatorioAsync(relatorio);

            return atualizacao;
        }

        public void Remover(string relatorioId)
        {
            if (string.IsNullOrEmpty(relatorioId))
                throw new Exception("O Id do relatório é inválido");

            _relatorioRepository.DeleteRelatorioAsync(relatorioId);
        }
    }
}
