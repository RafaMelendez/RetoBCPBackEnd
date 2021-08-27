using CalCambApi.Aplication.Adapter;
using CalCambApi.Aplication.Adapter.DTORequest;
using CalCambApi.Aplication.Adapter.DTOResponse.TipoCambio;
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
    public class TipoCambioController : Controller
    {
        #region .::Constantes::.

        private readonly ITipoCambioService _services;

        #endregion

        #region .::Constructor::.

        public TipoCambioController(ApplicationDbContext dataContext)
        {
            _services = new TipoCambioService(dataContext);
        }

        #endregion

        // GET api/TipoCambio
        [HttpGet("GetList")]
        public async Task<ResponseModel<ListadoResponse>> Get()
        {
            try
            {
                return await _services.ObtenerListado();
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        // GET api/TipoCambio/Insert
        [HttpPost("Consultar")]
        public async Task<ResponseModel<ConsultaTCResponse>> Post([FromBody] TipoCambioRequest obj)
        {
            try
            {
                var res = await _services.ObtenerTipoCambio(obj);
                return res;
            }
            catch (Exception ex)
            {

                throw;
            }

        }

        [HttpPut("{id}")]
        public ResponseModel<TipoCambio> Put(int id, [FromBody] TipoCambio obj)
        {
            try
            {
                var responseModel = new ResponseModel<TipoCambio>();
                if (id == obj.Id)
                {
                    _services.ActualizarTipoCambio(obj);
                    responseModel.Entity = obj;
                }
                responseModel.IsValid = (obj.Id == id) ? true : false;
                return responseModel;


            }
            catch (Exception ex)
            {

                throw;
            }


        }


    }
}
