using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalCambApi.Aplication.Adapter.DTOResponse.TipoCambio
{
    public class ConsultaTCResponse
    {
        public double Monto { get; set; }
        public double MontoCambio { get; set; }
        public string MonedaOrigen { get; set; }
        public string MonedaDestino { get; set; }
        public double ValorTipoCambio { get; set; }
    }
}
