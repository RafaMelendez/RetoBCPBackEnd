using CalCambApi.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalCambApi.Infraestructure.Repository.Class
{
    public interface ITipoCambioRepository
    {
        double ObtenerTipoCambio(double Origen, double Destino);
        List<TipoCambio> ObtenerListado();

        void ActualizarTipoCambio(TipoCambio tipoCambio);
    }
}
