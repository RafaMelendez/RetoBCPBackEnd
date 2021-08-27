using CalCambApi.Aplication.Adapter;
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
    public class TipoMonedaService:ITipoMonedaService
    {
        #region .::Constantes::.
        private readonly ApplicationDbContext _dataContext;
        #endregion

        #region .::Constructor::.
        public TipoMonedaService(ApplicationDbContext dataContext)
        {
            _dataContext = dataContext;
        }
        #endregion

        public Task<ResponseModel<TipoMoneda>> ObtenerListadoTipoMoneda()
        {

            var service = new ResponseModel<TipoMoneda>();
            using (var uow = new UnitOfWork(_dataContext))
            {
                service.auditResponse = new AuditResponse();
                service.EntityList = new List<TipoMoneda>();
                service.EntityList = uow.TipoMonedaRepository.ObtenerListadoTipoMoneda();
                //uow.Save();
            }
            return Task.Run(() =>
            {
                return service;
            });
        }
    }
}
