using CalCambApi.Infraestructure.Repository.Class;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalCambApi.Infraestructure.UnitOfWork
{
    public interface IUnitOfWork : IDisposable
    {
        
        //ITipoMonedaRepository TipoMonedaRepository { get; }
        ITipoCambioRepository TipoCambioRepository { get; }
        void Save();
    }
}
