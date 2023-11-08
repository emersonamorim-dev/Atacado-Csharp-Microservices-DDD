using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MicroservicoCompras.Application.DTOs
{
    public class ClienteDTO
    {

        public ObjectId Id { get; set; }

        public string Nome { get; set; }

        public string Email { get; set; }
        public string Telefone { get; set; }

        public string Endereco { get; set; }
    }
}