using CalCambApi.Aplication.Adapter;
using CalCambApi.Aplication.Adapter.DTORequest;
using CalCambApi.Aplication.Adapter.DTOResponse.TipoCambio;
using CalCambApi.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalCambApi.Aplication.Services
{
    public interface ITipoCambioService
    {
        Task<ResponseModel<ConsultaTCResponse>> ObtenerTipoCambio(TipoCambioRequest obj);
        Task<ResponseModel<ListadoResponse>> ObtenerListado();
        void ActualizarTipoCambio(TipoCambio tipoCambio);
    }
}
