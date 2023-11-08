using System;
using System.Linq;
using System.Threading.Tasks;
using MicroservicoEstoque.Application.DTOs;
using MicroservicoEstoque.Application.Interfaces;
using MicroservicoEstoque.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace MicroservicoEstoque.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class FornecedorController : ControllerBase
    {
        private readonly IFornecedorService _fornecedorService;

        public FornecedorController(IFornecedorService fornecedorService)
        {
            _fornecedorService = fornecedorService;
        }

        [HttpGet()]
        public async Task<IActionResult> Get()
        {
            try
            {
                var fornecedores = await _fornecedorService.ObterTodos();
                return Ok(fornecedores);
            }
            catch (Exception ex)
            {
                var errorResponse = new
                {
                    Message = "Erro ao consultar fornecedores",
                    Error = ex.Message
                };

                return BadRequest(errorResponse);
            }
        }

        [HttpPost()]
        public async Task<IActionResult> Post([FromBody] FornecedorDTO fornecedorDto)
        {
            try
            {
                Fornecedor MapearParaEntidade(FornecedorDTO dto)
                {
                    return new Fornecedor
                    {
                        Id = dto.Id,
                        NomeFornecedor = dto.NomeFornecedor,
                        Endereco = dto.Endereco,
                        DataCadastro = dto.DataCadastro,
                        Status = Enum.Parse<StatusFornecedor>(dto.StatusFornecedor, true),
                        Contato = new ContatoFornecedor
                        {
                            Email = dto.Contato.Email,
                            Telefone = dto.Contato.Telefone
                        }
                    };
                }

                var fornecedor = MapearParaEntidade(fornecedorDto);
                var novoFornecedor = await _fornecedorService.Adicionar(fornecedor);
                return Ok(novoFornecedor);
            }
            catch (Exception ex)
            {
                var errorResponse = new
                {
                    Message = "Erro ao adicionar fornecedor",
                    Error = ex.Message
                };

                return BadRequest(errorResponse);
            }
        }

        [HttpPut()]
        public async Task<IActionResult> Put([FromBody] FornecedorDTO fornecedorDto)
        {
            try
            {
                Fornecedor MapearParaEntidade(FornecedorDTO dto)
                {
                    return new Fornecedor
                    {
                        Id = dto.Id,
                        NomeFornecedor = dto.NomeFornecedor,
                        Endereco = dto.Endereco,
                        DataCadastro = dto.DataCadastro,
                        Status = Enum.Parse<StatusFornecedor>(dto.StatusFornecedor, true),
                        Contato = new ContatoFornecedor
                        {
                            Email = dto.Contato.Email,
                            Telefone = dto.Contato.Telefone
                        }
                    };
                }

                var fornecedor = MapearParaEntidade(fornecedorDto);
                var fornecedorAtualizado = await _fornecedorService.Atualizar(fornecedor);
                return Ok(fornecedorAtualizado);
            }
            catch (Exception ex)
            {
                var errorResponse = new
                {
                    Message = "Erro ao atualizar fornecedor",
                    Error = ex.Message
                };

                return BadRequest(errorResponse);
            }
        }

        [HttpDelete("{fornecedorId}")]
        public IActionResult Delete(string fornecedorId)
        {
            try
            {
                _fornecedorService.Remover(fornecedorId);
                return Ok($"Fornecedor {fornecedorId} removido com sucesso");
            }
            catch (Exception ex)
            {
                var errorResponse = new
                {
                    Message = "Erro ao remover fornecedor",
                    Error = ex.Message
                };

                return BadRequest(errorResponse);
            }
        }
    }
}
