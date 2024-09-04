using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DesafioFundamentos.Models
{
    public class Veiculo
    {
        public DateTime Entrada { get; set; }
        public DateTime? Saida { get; set; }
        public string Placa { get; set; }
    }
}