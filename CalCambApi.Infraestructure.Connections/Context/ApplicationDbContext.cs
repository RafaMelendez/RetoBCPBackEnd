using CalCambApi.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalCambApi.Infraestructure.Connections.Context
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) //ctor
        : base(options)
        {
            LoadDataInMemory();
        }

        public DbSet<TipoMoneda> TipoMonedas { get; set; }

        public DbSet<TipoCambio> TipoCambio { get; set; }

        private IDbContextTransaction _transaction;

        public void LoadDataInMemory() {


            #region BD FAKE Moneda
                TipoMoneda Moneda = new TipoMoneda() {Id = 1, Descripcion = "SOLES", Estado = 1 };
                TipoMonedas.Add(Moneda);
                Moneda = new TipoMoneda() { Id = 2,Descripcion = "DOLARES", Estado = 1 };
                TipoMonedas.Add(Moneda);
                Moneda = new TipoMoneda() { Id = 3,Descripcion = "EUROS", Estado = 1 };
                TipoMonedas.Add(Moneda);
            #endregion

            #region BD Fake ConsultaTipoCambio
            // SOLES -> DOLARES
            TipoCambio tipoCambio = new TipoCambio() { MonedaOrigen = 1, MonedaDestino = 2, Valor = 4.2 };
            TipoCambio.Add(tipoCambio);
            // SOLES -> EUROS
            tipoCambio = new TipoCambio() { MonedaOrigen = 1, MonedaDestino = 3, Valor = 5.2 };
            TipoCambio.Add(tipoCambio);
            // DOLARES -> SOLES
            tipoCambio = new TipoCambio() { MonedaOrigen = 2, MonedaDestino = 1, Valor = 2.1 };
            TipoCambio.Add(tipoCambio);
            // DOLARES -> EUROS
            tipoCambio = new TipoCambio() { MonedaOrigen = 2, MonedaDestino = 3, Valor = 2.1 };
            TipoCambio.Add(tipoCambio);
            // EUROS -> SOLES
            tipoCambio = new TipoCambio() { MonedaOrigen = 3, MonedaDestino = 1, Valor = 1.2 };
            TipoCambio.Add(tipoCambio);
            // EUROS -> DOLARES
            tipoCambio = new TipoCambio() { MonedaOrigen = 3, MonedaDestino = 2, Valor = 1.5 };
            TipoCambio.Add(tipoCambio);

            #endregion

        }
        public void BeginTransaction()
        {
            _transaction = Database.BeginTransaction();
        }

        public void Commit()
        {
            try
            {
                SaveChanges();
                _transaction.Commit();
            }
            finally
            {
                _transaction.Dispose();
            }
        }

        public void Rollback()
        {
            _transaction.Rollback();
            _transaction.Dispose();
        }
    }
}
