using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MicroservicoMarketing.Infra.Data
{
    public class DatabaseSettings
    {
        public string ConnectionString { get; set; } = string.Empty;
        public string DatabaseName { get; set; } = string.Empty;
        public string CollectionName { get; set; } = string.Empty;

        public enum DatabaseStatus
        {
            Edicao,
            Insercao
        }
    }
}
