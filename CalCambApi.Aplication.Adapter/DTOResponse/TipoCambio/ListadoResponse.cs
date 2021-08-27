using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalCambApi.Aplication.Adapter.DTOResponse.TipoCambio
{
    public class ListadoResponse
    {
        public int Id { get; set; }
        public int IdMonedaOrigen{ get; set; }
        public string MonedaOrigen { get; set; }
        public int IdMonedaDestino { get; set; }
        public string MonedaDestino { get; set; }

        public double Valor { get; set; }
    }
}
