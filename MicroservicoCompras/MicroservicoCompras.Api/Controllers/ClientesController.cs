using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MicroservicoCompras.Application.Services;
using MongoDB.Bson;
using MicroservicoCompras.Application.Interfaces;
using MicroservicoCompras.Domain.Entities;
using System.Runtime.ConstrainedExecution;

namespace MicroservicoCompras.API.Controllers
{

    [ApiController]
    [Route("[controller]")]
    public class ClienteController : ControllerBase
    {
        private IClienteService _clienteService;

        public ClienteController(IClienteService clienteService)
        {
            _clienteService = clienteService;
        }

        [HttpGet()]
        public async Task<IActionResult> Get()
        {
            try
            {
                var clientes = await _clienteService.ObterTodos();
                return Ok(clientes);
            }
            catch (Exception ex)
            {
                var errorResponse = new
                {
                    Message = "Erro ao consultar cliente",
                    Error = ex.Message
                };

                return BadRequest(errorResponse);
            }
        }


        [HttpPost()]
        public async Task<IActionResult> Post([FromBody] Cliente cliente)
        {
            try
            {
                var novoCliente = await _clienteService.Adicionar(cliente);
                return Ok(novoCliente);
            }
            catch (Exception ex)
            {
                var errorResponse = new
                {
                    Message = "Erro ao adicionar cliente",
                    Error = ex.Message
                };

                return BadRequest(errorResponse);
            }
        }


        [HttpPut()]
        public async Task<IActionResult> Put([FromBody] Cliente cliente)
        {
            try
            {
                var clienteAtualizado = await _clienteService.Atualizar(cliente);
                return Ok(clienteAtualizado);
            }
            catch (Exception ex)
            {
                var errorResponse = new
                {
                    Message = "Erro ao atualizar cliente",
                    Error = ex.Message
                };

                return BadRequest(errorResponse);
            }
        }
        

        [HttpDelete()]
        [Route("/Cliente/{clienteId}")]
        public IActionResult Delete(string clienteId)
        {
            try
            {
                _clienteService.Remover(clienteId);
                return Ok($"Cliente {clienteId} removido com sucesso");
            }
            catch (Exception ex)
            {
                var errorResponse = new
                {
                    Message = "Erro ao remover cliente",
                    Error = ex.Message
                };

                return BadRequest(errorResponse);
            }
        }
    }
}

