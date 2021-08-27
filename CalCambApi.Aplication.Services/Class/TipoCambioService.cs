    using CalCambApi.Aplication.Adapter;
using CalCambApi.Aplication.Adapter.DTORequest;
using CalCambApi.Aplication.Adapter.DTOResponse.TipoCambio;
using CalCambApi.Domain.Entities;
using CalCambApi.Infraestructure.Connections.Context;
using CalCambApi.Infraestructure.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalCambApi.Aplication.Services
{
    public class TipoCambioService : ITipoCambioService
    {
        #region .::Constantes::.
        private readonly ApplicationDbContext _dataContext;
        #endregion

        #region .::Constructor::.
        public TipoCambioService(ApplicationDbContext dataContext)
        {
            _dataContext = dataContext;
        }
        #endregion

        public Task<ResponseModel<ConsultaTCResponse>> ObtenerTipoCambio(TipoCambioRequest obj)
        {

            var service = new ResponseModel<ConsultaTCResponse>();
            
            using (var aa = new UnitOfWork(_dataContext))
            {
                var tipoCambio = aa.TipoCambioRepository.ObtenerTipoCambio(obj.MonedaOrigen, obj.MonedaDestino);
                service.auditResponse = new AuditResponse();
                service.Entity = new ConsultaTCResponse() { 
                 MonedaOrigen = aa.TipoMonedaRepository.ObtenerMoneda(obj.MonedaOrigen),
                 MonedaDestino = aa.TipoMonedaRepository.ObtenerMoneda(obj.MonedaDestino),
                 Monto = obj.Monto,
                 ValorTipoCambio = tipoCambio,
                 MontoCambio = obj.Monto * tipoCambio
                };
                //service.Entity = aa.TipoCambioRepository.ObtenerTipoCambio(tipoCambio);
                //aa.Save();
            }
            return Task.Run(() =>
            {
                return service;
            });
        }
        public Task<ResponseModel<ListadoResponse>> ObtenerListado()
        {
            IDictionary<int, string> dic = new Dictionary<int, string>();
            dic.Add(1, "SOLES");
            dic.Add(2, "DOLARES");
            dic.Add(3, "EUROS");
            var service = new ResponseModel<ListadoResponse>();

            using (var aa = new UnitOfWork(_dataContext))
            {
                var listadoTipoCambio = aa.TipoCambioRepository.ObtenerListado();
                var listadoMonedas = aa.TipoMonedaRepository.ObtenerListadoTipoMoneda();
                service.auditResponse = new AuditResponse();
                service.EntityList = listadoTipoCambio.Select(x => new ListadoResponse
                {
                    Id = x.Id,
                    IdMonedaOrigen = x.MonedaOrigen,
                    MonedaOrigen = dic.Where(y => y.Key == x.MonedaOrigen ).FirstOrDefault().Value,
                    IdMonedaDestino = x.MonedaDestino,
                    MonedaDestino = dic.Where(y => y.Key == x.MonedaDestino).FirstOrDefault().Value,
                    Valor = x.Valor
                }).ToList();
            }
            return Task.Run(() =>
            {
                return service;
            });
        }

        public void ActualizarTipoCambio(TipoCambio tipoCambio)
        {
            using (var uow = new UnitOfWork(_dataContext))
            {
                uow.TipoCambioRepository.ActualizarTipoCambio(tipoCambio);
                uow.Save();
            }
        }
        
    }
}
