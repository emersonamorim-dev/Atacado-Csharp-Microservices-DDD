using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MicroservicoLogistica.Domain.Entities;
using MicroservicoLogistica.Domain.Interfaces;

namespace MicroservicoLogistica.Application.Services
{
    public class GestaoVeiculosService : IGestaoVeiculosService
    {
        private readonly IGestaoVeiculosRepository _gestaoVeiculosRepository;

        public GestaoVeiculosService(IGestaoVeiculosRepository gestaoVeiculosRepository)
        {
            _gestaoVeiculosRepository = gestaoVeiculosRepository;
        }

        public Task<List<GestaoVeiculos>> ObterTodos()
        {
            return _gestaoVeiculosRepository.GetVeiculosAsync();
        }

        public async Task<GestaoVeiculos> Adicionar(GestaoVeiculos veiculo)
        {
            if (veiculo == null)
                throw new Exception("Dados inválidos.");

            return await _gestaoVeiculosRepository.CreateVeiculoAsync(veiculo);
        }

        public async Task<GestaoVeiculos> Atualizar(GestaoVeiculos veiculo)
        {
            if (veiculo == null)
                throw new Exception("Dados inválidos.");

            var veiculos = await _gestaoVeiculosRepository.GetVeiculosAsync();
            var existeVeiculo = veiculos.FirstOrDefault(v => v.Id == veiculo.Id);

            if (existeVeiculo == null)
                throw new Exception("O veículo informado não existe");

            return await _gestaoVeiculosRepository.UpdateVeiculoAsync(veiculo);
        }

        public void Remover(string veiculoId)
        {
            if (string.IsNullOrEmpty(veiculoId))
                throw new Exception("O Id do veículo é inválido");

            _gestaoVeiculosRepository.DeleteVeiculoAsync(veiculoId);
        }
    }
}
