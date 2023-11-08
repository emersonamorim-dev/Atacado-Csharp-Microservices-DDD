using System;
using System.Collections.Generic;

namespace MicroservicoEstoque.Application.DTOs
{
    public class ArmazemDTO
    {
        public string Id { get; set; }
        public string NomeArmazem { get; set; }
        public string Localizacao { get; set; }
        public int CapacidadeTotal { get; set; }
        public int EspacoOcupado { get; set; }
        public int EspacoDisponivel
        {
            get
            {
                return CapacidadeTotal - EspacoOcupado;
            }
        }
        public List<ItemArmazenadoDTO> ItensArmazenados { get; set; } = new List<ItemArmazenadoDTO>();
        public DateTime DataUltimaAtualizacao { get; set; }
        public string StatusArmazem { get; set; }
    }

    public class ItemArmazenadoDTO
    {
        public string ProdutoId { get; set; }
        public string NomeProduto { get; set; }
        public int Quantidade { get; set; }
        public string LocalizacaoNoArmazem { get; set; }
    }
}
