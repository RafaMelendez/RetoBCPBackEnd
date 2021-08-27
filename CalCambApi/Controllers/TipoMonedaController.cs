using CalCambApi.Aplication.Adapter;
using CalCambApi.Aplication.Services;
using CalCambApi.Domain.Entities;
using CalCambApi.Infraestructure.Connections.Context;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CalCambApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TipoMonedaController : Controller
    {
        #region .::Constantes::.

        private readonly ITipoMonedaService _services;

        #endregion

        #region .::Constructor::.

        public TipoMonedaController(ApplicationDbContext dataContext)
        {
            _services = new TipoMonedaService(dataContext);
        }

        #endregion

        // GET api/Usuario
        [HttpGet("GetList")]
        public async Task<ResponseModel<TipoMoneda>> Get()
        {
            try
            {
                return await _services.ObtenerListadoTipoMoneda();
            }
            catch (Exception ex )
            {

                throw;
            }
        }

    }
}
