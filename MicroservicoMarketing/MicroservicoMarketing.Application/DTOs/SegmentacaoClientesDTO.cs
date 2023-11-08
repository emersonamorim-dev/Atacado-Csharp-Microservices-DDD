using System;
using System.Collections.Generic;

namespace MicroservicoMarketing.Application.DTOs
{
    public class SegmentacaoClientesDTO
    {
        public string Id { get; set; }
        public string NomeSegmento { get; set; }
        public string Critérios { get; set; }
        public DateTime DataCriacao { get; set; }
        public List<string> ClientesIds { get; set; }
        public bool Ativo { get; set; }

        public SegmentacaoClientesDTO()
        {
            ClientesIds = new List<string>();
        }
    }
}
