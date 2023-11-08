using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace MicroservicoCompras.Application.DTOs
{
    public class VendasDTO
    {
        public string Id { get; set; }

        [JsonConverter(typeof(StringEnumConverter))]
        public string Produto { get; set; }

        [JsonConverter(typeof(StringEnumConverter))]
        public string Status { get; set; }

        public decimal ValorTotal { get; set; }

        public DateTime DataVenda { get; set; }
    }
}
