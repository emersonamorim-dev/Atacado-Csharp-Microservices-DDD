using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MicroservicoCompras.Domain.Entities;
using MicroservicoCompras.Infra.Repositories;
using MongoDB.Driver;
using MicroservicoCompras.Application.Interfaces;
using MicroservicoCompras.Infra.Interfaces;

namespace MicroservicoCompras.Application.Services
{
    public class ClienteService : IClienteService
    {
        private readonly IClienteRepository _clienteRepository;

        public ClienteService(IClienteRepository clienteRepository)
        {
            _clienteRepository = clienteRepository;
        }

        public Task<List<Cliente>> ObterTodos()
        {
            return _clienteRepository.GetClienteAsync();
        }

        public async Task<Cliente> Adicionar(Cliente cliente)
        {
            if (cliente == null)
                throw new Exception("Dados inválidos.");

            return await _clienteRepository.CreateClienteAsync(cliente);
        }


        public async Task<Cliente> Atualizar(Cliente cliente)
        {
            if (cliente == null)
                throw new Exception("Dados inválidos.");

            var clientes = await _clienteRepository.GetClienteAsync();
            var existeCliente = clientes.FirstOrDefault(c => c.Id == cliente.Id);

            if (existeCliente == null)
                throw new Exception("O cliente informado não existe");

            var atualizacao = await _clienteRepository.UpdateClienteAsync(cliente);

            return atualizacao;
        }

        public void Remover(string clienteId)
        {
            if (string.IsNullOrEmpty(clienteId))
                throw new Exception("O Id do cliente é inválido");

            _clienteRepository.DeleteClienteAsync(clienteId);
        }

    }
}
