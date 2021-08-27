using CalCambApi.Domain.Entities;
using CalCambApi.Infraestructure.Connections.Context;
using CalCambApi.Infraestructure.UnitOfWork.Repository.Class;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalCambApi.Infraestructure.Repository.Class
{
    public class TipoCambioRepository: GenericRepository<TipoCambio>, ITipoCambioRepository
    {
        #region .:: Constants ::.

        private readonly ApplicationDbContext _dataContext;

        #endregion
        #region .::Constructor::.

        public TipoCambioRepository(ApplicationDbContext dataContext) : base(dataContext)
        {
            _dataContext = dataContext;
        }

        #endregion

        public double ObtenerTipoCambio(double Origen, double Destino)
        {

            //var response = _dataContext.TipoCambio.Where(x => x.MonedaOrigen == Origen && x.MonedaDestino == Destino).FirstOrDefault();
            var response = _dataContext.TipoCambio.Local.Where(x => x.MonedaOrigen == Origen && x.MonedaDestino == Destino).FirstOrDefault();
            return response.Valor;
        }
        public List<TipoCambio> ObtenerListado()
        {

            //var response = _dataContext.TipoCambio.Where(x => x.MonedaOrigen == Origen && x.MonedaDestino == Destino).FirstOrDefault();
            var response = _dataContext.TipoCambio.Local.ToList();
            return response;
        }
        
        public void ActualizarTipoCambio(TipoCambio tipoCambio)
        {
            _dataContext.Entry(tipoCambio).State = EntityState.Modified;
        }
    }
}
