using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalCambApi.Aplication.Adapter.DTORequest
{
    public class TipoCambioRequest
    {
        public int MonedaOrigen { get; set; }
        public int MonedaDestino { get; set; }
        public double Monto { get; set; }
    }
}
