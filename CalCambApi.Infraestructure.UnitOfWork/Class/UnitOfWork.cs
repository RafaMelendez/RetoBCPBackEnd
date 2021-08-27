using CalCambApi.Infraestructure.Connections.Context;
using CalCambApi.Infraestructure.Repository.Class;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalCambApi.Infraestructure.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        #region .:: Constants ::.

        private readonly ApplicationDbContext _dataContext;

        #endregion

        #region .:: Interface Repositories::.

        public ITipoMonedaRepository _tipomonedaRepository;
        public ITipoCambioRepository _tipocambioRepository;

        #endregion

        public UnitOfWork(ApplicationDbContext dataContext) //, IConfiguration icon
        {
            _dataContext = dataContext;
        }
        public void Save()
        {
            _dataContext.SaveChanges();
            resetRepositories();
        }

        #region .:: TipoMoneda  ::.
        public ITipoMonedaRepository TipoMonedaRepository
        {
            get { return _tipomonedaRepository ?? (_tipomonedaRepository = new TipoMonedaRepository(_dataContext)); }
        }
        #endregion
        #region .:: TipoCambio  ::.
        public ITipoCambioRepository TipoCambioRepository
        {
            get { return _tipocambioRepository ?? (_tipocambioRepository = new TipoCambioRepository(_dataContext)); }
        }
        #endregion
        private void resetRepositories()
        {
            //Agregar Repositorios
            _tipomonedaRepository = null;
            _tipocambioRepository = null;
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}
