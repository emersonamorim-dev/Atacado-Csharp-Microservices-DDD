using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MicroservicoEstoque.Application.DTOs;
using MicroservicoEstoque.Application.Interfaces;
using MicroservicoEstoque.Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;

namespace MicroservicoEstoque.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class RelatorioController : ControllerBase
    {
        private readonly IRelatorioService _relatorioService;

        public RelatorioController(IRelatorioService relatorioService)
        {
            _relatorioService = relatorioService;
        }

        [HttpGet()]
        public async Task<IActionResult> Get()
        {
            try
            {
                var relatorios = await _relatorioService.ObterTodos();
                return Ok(relatorios);
            }
            catch (Exception ex)
            {
                var errorResponse = new
                {
                    Message = "Erro ao consultar relatórios",
                    Error = ex.Message
                };

                return BadRequest(errorResponse);
            }
        }

        [HttpPost()]
        public async Task<IActionResult> Post([FromBody] RelatorioDTO relatorioDto)
        {
            try
            {
                Relatorio MapearParaEntidade(RelatorioDTO dto)
                {
                    return new Relatorio
                    {
                        Id = dto.Id,
                        Titulo = dto.Titulo,
                        Descricao = dto.Descricao,
                        DataCriacao = dto.DataCriacao,
                        Tipo = Enum.Parse<TipoRelatorio>(dto.Tipo.ToString()),
                        Dados = new BsonDocument(dto.Dados)
                    };
                }

                var relatorio = MapearParaEntidade(relatorioDto);
                var novoRelatorio = await _relatorioService.Adicionar(relatorio);
                return Ok(novoRelatorio);
            }
            catch (Exception ex)
            {
                var errorResponse = new
                {
                    Message = "Erro ao adicionar relatório",
                    Error = ex.Message
                };

                return BadRequest(errorResponse);
            }
        }

        [HttpPut()]
        public async Task<IActionResult> Put([FromBody] RelatorioDTO relatorioDto)
        {
            try
            {
                Relatorio MapearParaEntidade(RelatorioDTO dto)
                {
                    return new Relatorio
                    {
                        Id = dto.Id,
                        Titulo = dto.Titulo,
                        Descricao = dto.Descricao,
                        DataCriacao = dto.DataCriacao,
                        Tipo = Enum.Parse<TipoRelatorio>(dto.Tipo.ToString()),
                        Dados = new BsonDocument(dto.Dados)
                    };
                }

                var relatorio = MapearParaEntidade(relatorioDto);
                var relatorioAtualizado = await _relatorioService.Atualizar(relatorio);
                return Ok(relatorioAtualizado);
            }
            catch (Exception ex)
            {
                var errorResponse = new
                {
                    Message = "Erro ao atualizar relatório",
                    Error = ex.Message
                };

                return BadRequest(errorResponse);
            }
        }

        [HttpDelete("{relatorioId}")]
        public IActionResult Delete(string relatorioId)
        {
            try
            {
                _relatorioService.Remover(relatorioId);
                return Ok($"Relatório {relatorioId} removido com sucesso");
            }
            catch (Exception ex)
            {
                var errorResponse = new
                {
                    Message = "Erro ao remover relatório",
                    Error = ex.Message
                };

                return BadRequest(errorResponse);
            }
        }
    }
}
