using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Sale : Generic
    {
        public int Id { get; set; }
        public DateTime DataVenda { get; set; }
        public string Cliente { get; set; }
        public Dictionary<string, int> Produtos { get; set; } //dicionario de produtos e quantidade

        public decimal ValorTotal { get; set; }
        public string Status { get; set; }
    }
}
