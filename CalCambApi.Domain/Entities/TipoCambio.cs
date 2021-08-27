using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalCambApi.Domain.Entities
{
    public class TipoCambio
    {
        public int Id { get; set; }
        public int MonedaOrigen { get; set; } //soles
        public int MonedaDestino { get; set; } // dolares
        public double Valor { get; set; } // 2.20
    }
}
