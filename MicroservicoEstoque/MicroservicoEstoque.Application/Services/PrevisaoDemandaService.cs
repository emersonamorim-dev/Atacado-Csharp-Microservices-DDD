using MicroservicoEstoque.Application.Interfaces;
using MicroservicoEstoque.Domain.Entities;
using MicroservicoEstoque.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MicroservicoEstoque.Application.Services
{
    public class PrevisaoDemandaService : IPrevisaoDemandaService
    {
        private readonly IPrevisaoDemandaRepository _previsaoDemandaRepository;

        public PrevisaoDemandaService(IPrevisaoDemandaRepository previsaoDemandaRepository)
        {
            _previsaoDemandaRepository = previsaoDemandaRepository;
        }

        public Task<List<PrevisaoDemanda>> ObterTodos()
        {
            return _previsaoDemandaRepository.GetPrevisaoDemandaAsync();
        }

        public async Task<PrevisaoDemanda> Adicionar(PrevisaoDemanda previsaoDemanda)
        {
            if (previsaoDemanda == null)
                throw new Exception("Dados inválidos.");

            return await _previsaoDemandaRepository.CreatePrevisaoDemandaAsync(previsaoDemanda);
        }

        public async Task<PrevisaoDemanda> Atualizar(PrevisaoDemanda previsaoDemanda)
        {
            if (previsaoDemanda == null)
                throw new Exception("Dados inválidos.");

            var previsoesDemanda = await _previsaoDemandaRepository.GetPrevisaoDemandaAsync();
            var existePrevisaoDemanda = previsoesDemanda.FirstOrDefault(p => p.Id == previsaoDemanda.Id);

            if (existePrevisaoDemanda == null)
                throw new Exception("A previsão de demanda informada não existe");

            var atualizacao = await _previsaoDemandaRepository.UpdatePrevisaoDemandaAsync(previsaoDemanda);

            return atualizacao;
        }

        public void Remover(string previsaoDemandaId)
        {
            if (string.IsNullOrEmpty(previsaoDemandaId))
                throw new Exception("O Id da previsão de demanda é inválido");

            _previsaoDemandaRepository.DeletePrevisaoDemandaAsync(previsaoDemandaId);
        }
    }
}
