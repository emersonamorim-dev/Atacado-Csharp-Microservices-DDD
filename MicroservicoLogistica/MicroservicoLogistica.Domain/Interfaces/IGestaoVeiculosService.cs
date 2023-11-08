using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MicroservicoLogistica.Domain.Entities;

namespace MicroservicoLogistica.Domain.Interfaces
{
    public interface IGestaoVeiculosService
    {
        Task<List<GestaoVeiculos>> ObterTodos();
        Task<GestaoVeiculos> Adicionar(GestaoVeiculos veiculo);
        Task<GestaoVeiculos> Atualizar(GestaoVeiculos veiculo);
        void Remover(string veiculoId);
    }
}
