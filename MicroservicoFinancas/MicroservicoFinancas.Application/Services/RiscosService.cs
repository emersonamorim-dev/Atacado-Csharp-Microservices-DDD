using MicroservicoFinancas.Application.Interfaces;
using MicroservicoFinancas.Domain.Entities;
using MicroservicoFinancas.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MicroservicoFinancas.Application.Services
{
    public class RiscosService : IRiscosService
    {
        private readonly IRiscosRepository _riscosRepository;

        public RiscosService(IRiscosRepository riscosRepository)
        {
            _riscosRepository = riscosRepository;
        }

        public Task<List<Riscos>> ObterTodos()
        {
            return _riscosRepository.GetRiscosAsync();
        }

        public async Task<Riscos> Adicionar(Riscos riscos)
        {
            ValidarRiscos(riscos);
            return await _riscosRepository.CreateRiscosAsync(riscos);
        }

        public async Task<Riscos> Atualizar(Riscos riscos)
        {
            ValidarRiscos(riscos);

            var riscosList = await _riscosRepository.GetRiscosAsync();
            var existeRiscos = riscosList.FirstOrDefault(r => r.Id == riscos.Id);

            if (existeRiscos == null)
                throw new Exception("Os riscos informados não existem");

            return await _riscosRepository.UpdateRiscosAsync(riscos);
        }

        public void Remover(string riscosId)
        {
            if (string.IsNullOrEmpty(riscosId))
                throw new Exception("O Id dos riscos é inválido");

            _riscosRepository.DeleteRiscosAsync(riscosId);
        }

        private void ValidarRiscos(Riscos riscos)
        {
            if (riscos == null)
                throw new Exception("Dados inválidos.");
        }
    }
}
