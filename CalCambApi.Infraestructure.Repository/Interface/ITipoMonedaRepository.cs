using CalCambApi.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalCambApi.Infraestructure.Repository.Class
{
    public interface ITipoMonedaRepository
    {
        List<TipoMoneda> ObtenerListadoTipoMoneda();
        string ObtenerMoneda(int id);
    }
}
