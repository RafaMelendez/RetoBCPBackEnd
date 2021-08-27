using CalCambApi.Domain.Entities;
using CalCambApi.Infraestructure.Connections.Context;
using CalCambApi.Infraestructure.UnitOfWork.Repository.Class;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalCambApi.Infraestructure.Repository.Class
{
    public class TipoMonedaRepository : GenericRepository<TipoMoneda>, ITipoMonedaRepository
    {
        #region .:: Constants ::.

        private readonly ApplicationDbContext _dataContext;

        #endregion
        #region .::Constructor::.

        public TipoMonedaRepository(ApplicationDbContext dataContext) : base(dataContext)
        {
            _dataContext = dataContext;
        }

        #endregion

        public List<TipoMoneda> ObtenerListadoTipoMoneda()
        {
            //var response = _dataContext.TipoMonedas.ToList();
            var response = _dataContext.TipoMonedas.Local.ToList();
            return response;
        }
        public string ObtenerMoneda(int id)
        {
            //var response = _dataContext.TipoMonedas.Where(x => x.Id == id).FirstOrDefault();
            var response = _dataContext.TipoMonedas.Local.Where(x => x.Id == id).FirstOrDefault();
            return response.Descripcion;
        }
    }
}
