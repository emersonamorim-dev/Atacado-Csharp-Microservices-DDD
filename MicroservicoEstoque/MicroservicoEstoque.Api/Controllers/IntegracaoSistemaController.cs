using System;
using System.Linq;
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
    public class IntegracaoSistemaController : ControllerBase
    {
        private readonly IIntegracaoSistemaService _integracaoSistemaService;

        public IntegracaoSistemaController(IIntegracaoSistemaService integracaoSistemaService)
        {
            _integracaoSistemaService = integracaoSistemaService;
        }

        [HttpGet()]
        public async Task<IActionResult> Get()
        {
            try
            {
                var integracoes = await _integracaoSistemaService.ObterTodos();
                return Ok(integracoes);
            }
            catch (Exception ex)
            {
                var errorResponse = new
                {
                    Message = "Erro ao consultar integrações de sistemas",
                    Error = ex.Message
                };

                return BadRequest(errorResponse);
            }
        }

        [HttpPost()]
        public async Task<IActionResult> Post([FromBody] IntegracaoSistemaDTO integracaoDto)
        {
            try
            {
                IntegracaoSistema MapearParaEntidade(IntegracaoSistemaDTO dto)
                {
                    return new IntegracaoSistema
                    {
                        Id = dto.Id,
                        NomeSistema = dto.NomeSistema,
                        Tipo = Enum.Parse<TipoIntegracao>(dto.TipoIntegracao, true),
                        DataUltimaIntegracao = dto.DataUltimaIntegracao,
                        Status = Enum.Parse<StatusIntegracao>(dto.StatusIntegracao, true),
                        Configuracao = new ConfiguracaoIntegracao
                        {
                            URLAPI = dto.Configuracao.URLAPI,
                            ChaveAPI = dto.Configuracao.ChaveAPI,
                            Parametros = new BsonDocument(dto.Configuracao.Parametros)
                        }
                    };
                }

                var integracao = MapearParaEntidade(integracaoDto);
                var novaIntegracao = await _integracaoSistemaService.Adicionar(integracao);
                return Ok(novaIntegracao);
            }
            catch (Exception ex)
            {
                var errorResponse = new
                {
                    Message = "Erro ao adicionar integração de sistema",
                    Error = ex.Message
                };

                return BadRequest(errorResponse);
            }
        }

        [HttpPut()]
        public async Task<IActionResult> Put([FromBody] IntegracaoSistemaDTO integracaoDto)
        {
            try
            {
                IntegracaoSistema MapearParaEntidade(IntegracaoSistemaDTO dto)
                {
                    return new IntegracaoSistema
                    {
                        Id = dto.Id,
                        NomeSistema = dto.NomeSistema,
                        Tipo = Enum.Parse<TipoIntegracao>(dto.TipoIntegracao, true),
                        DataUltimaIntegracao = dto.DataUltimaIntegracao,
                        Status = Enum.Parse<StatusIntegracao>(dto.StatusIntegracao, true),
                        Configuracao = new ConfiguracaoIntegracao
                        {
                            URLAPI = dto.Configuracao.URLAPI,
                            ChaveAPI = dto.Configuracao.ChaveAPI,
                            Parametros = new BsonDocument(dto.Configuracao.Parametros)
                        }
                    };
                }

                var integracao = MapearParaEntidade(integracaoDto);
                var integracaoAtualizada = await _integracaoSistemaService.Atualizar(integracao);
                return Ok(integracaoAtualizada);
            }
            catch (Exception ex)
            {
                var errorResponse = new
                {
                    Message = "Erro ao atualizar integração de sistema",
                    Error = ex.Message
                };

                return BadRequest(errorResponse);
            }
        }

        [HttpDelete("{integracaoId}")]
        public IActionResult Delete(string integracaoId)
        {
            try
            {
                _integracaoSistemaService.Remover(integracaoId);
                return Ok($"Integração de sistema {integracaoId} removida com sucesso");
            }
            catch (Exception ex)
            {
                var errorResponse = new
                {
                    Message = "Erro ao remover integração de sistema",
                    Error = ex.Message
                };

                return BadRequest(errorResponse);
            }
        }
    }
}
