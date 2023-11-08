using MicroservicoEstoque.Application.Interfaces;
using MicroservicoEstoque.Domain.Entities;
using MicroservicoEstoque.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MicroservicoEstoque.Application.Services
{
    public class InventarioService : IInventarioService
    {
        private readonly IInventarioRepository _inventarioRepository;

        public InventarioService(IInventarioRepository inventarioRepository)
        {
            _inventarioRepository = inventarioRepository;
        }

        public Task<List<Inventario>> ObterTodos()
        {
            return _inventarioRepository.GetInventarioAsync();
        }

        public async Task<Inventario> Adicionar(Inventario inventario)
        {
            if (inventario == null)
                throw new Exception("Dados inválidos.");

            return await _inventarioRepository.CreateInventarioAsync(inventario);
        }

        public async Task<Inventario> Atualizar(Inventario inventario)
        {
            if (inventario == null)
                throw new Exception("Dados inválidos.");

            var inventarios = await _inventarioRepository.GetInventarioAsync();
            var existeInventario = inventarios.FirstOrDefault(i => i.Id == inventario.Id);

            if (existeInventario == null)
                throw new Exception("O inventário informado não existe");

            var atualizacao = await _inventarioRepository.UpdateInventarioAsync(inventario);

            return atualizacao;
        }

        public void Remover(string inventarioId)
        {
            if (string.IsNullOrEmpty(inventarioId))
                throw new Exception("O Id do inventário é inválido");

            _inventarioRepository.DeleteInventarioAsync(inventarioId);
        }
    }
}
