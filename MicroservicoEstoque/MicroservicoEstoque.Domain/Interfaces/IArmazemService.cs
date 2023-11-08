using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MicroservicoEstoque.Domain.Entities;

namespace MicroservicoEstoque.Domain.Interfaces
{
    public interface IArmazemService
    {
        Task<List<Armazem>> ObterTodos();
        Task<Armazem> Adicionar(Armazem armazem);
        Task<Armazem> Atualizar(Armazem armazem);
        void Remover(string armazemId);
    }
}

