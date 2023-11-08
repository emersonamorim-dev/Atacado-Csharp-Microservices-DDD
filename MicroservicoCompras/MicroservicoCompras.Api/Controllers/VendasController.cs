using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MicroservicoCompras.Application.Services;
using MongoDB.Bson;
using MicroservicoCompras.Application.Interfaces;
using MicroservicoCompras.Domain.Entities;
using System.Runtime.ConstrainedExecution;
using MicroservicoCompras.Application.DTOs;

namespace MicroservicoCompras.API.Controllers
{

    [ApiController]
    [Route("[controller]")]
    public class VendasController : ControllerBase
    {
        private IVendasService _vendasService;

        public VendasController(IVendasService vendasService)
        {
            _vendasService = vendasService;
        }

        [HttpGet()]
        public async Task<IActionResult> Get()
        {
            try
            {
                var vendas = await _vendasService.ObterTodos();
                return Ok(vendas);
            }
            catch (Exception ex)
            {
                var errorResponse = new
                {
                    Message = "Erro ao consultar vendas",
                    Error = ex.Message
                };

                return BadRequest(errorResponse);
            }
        }


        [HttpPost()]
        public async Task<IActionResult> Post([FromBody] VendasDTO vendaDto)
        {
            try
            {
                // Mapear VendasDTO para Venda
                var venda = new Venda
                {
                    Id = vendaDto.Id,
                    Produto = Enum.Parse<TipoProduto>(vendaDto.Produto.ToString()),
                    Status = Enum.Parse<StatusVenda>(vendaDto.Status.ToString()),
                    ValorTotal = vendaDto.ValorTotal,
                    DataVenda = vendaDto.DataVenda
                };

                var novaVenda = await _vendasService.Adicionar(venda);
                return Ok(novaVenda);
            }
            catch (Exception ex)
            {
                var errorResponse = new
                {
                    Message = "Erro ao adicionar venda",
                    Error = ex.Message
                };

                return BadRequest(errorResponse);
            }
        }




        [HttpPut()]
        public async Task<IActionResult> Put([FromBody] Venda venda)
        {
            try
            {
                var vendaAtualizada = await _vendasService.Atualizar(venda);
                return Ok(vendaAtualizada);
            }
            catch (Exception ex)
            {
                var errorResponse = new
                {
                    Message = "Erro ao atualizar venda",
                    Error = ex.Message
                };

                return BadRequest(errorResponse);
            }
        }


        [HttpDelete()]
        [Route("/Vendas/{vendaId}")]
        public IActionResult Delete(string vendaId)
        {
            try
            {
                _vendasService.Remover(vendaId);
                return Ok($"Venda {vendaId} removida com sucesso");
            }
            catch (Exception ex)
            {
                var errorResponse = new
                {
                    Message = "Erro ao remover venda",
                    Error = ex.Message
                };

                return BadRequest(errorResponse);
            }
        }
    }
}

