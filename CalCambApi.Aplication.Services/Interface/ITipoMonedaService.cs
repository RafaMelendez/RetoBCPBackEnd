using CalCambApi.Aplication.Adapter;
using CalCambApi.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalCambApi.Aplication.Services
{
    public interface ITipoMonedaService
    {
        Task<ResponseModel<TipoMoneda>> ObtenerListadoTipoMoneda();
    }
}
