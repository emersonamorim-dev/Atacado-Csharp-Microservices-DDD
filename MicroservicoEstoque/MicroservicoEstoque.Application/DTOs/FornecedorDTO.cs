using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MicroservicoEstoque.Application.DTOs
{
    public class FornecedorDTO
    {
        public string Id { get; set; }
        public string NomeFornecedor { get; set; }
        public ContatoFornecedorDTO Contato { get; set; }
        public string Endereco { get; set; }
        public DateTime DataCadastro { get; set; }
        public string StatusFornecedor { get; set; }
    }

    public class ContatoFornecedorDTO
    {
        public string Email { get; set; }
        public string Telefone { get; set; }
    }
}