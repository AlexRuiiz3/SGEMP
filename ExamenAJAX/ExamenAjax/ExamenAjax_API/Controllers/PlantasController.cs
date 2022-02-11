﻿using ExamenAjax_API.Entidades;
using ExamenAjax_API.Dal.Listados;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Net;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ExamenAjax_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlantasController : ControllerBase
    {
        // GET api/<ValuesController>/5
        [HttpGet("{id}")]//Lo idual seria poner idCategoria, ya que el id parece que hace referencia al id de la Planta
        /*
         * Descripcion: Esta llamada a la API devuelve un ObjectResult cuyo Value sera un listado de ClsPlanta de una categoria en concreto de la base de datos. 
         *              El estado del ObjectResult sera OK si se obtuvo una lista con ClsPlanta.
         *              En caso de que la llamada falle, el estado del ObjectResult sera:
         *                                                                                 -InternalServerError: Cuando se produzca cualquier tipo de excepcion.
         *                                                                                 -NotFound: Cuando no haya productos en la ClsPlanta.
         */
        public ObjectResult Get(int id)
        {
            ObjectResult result = new ObjectResult(new { });
            result.Value = new List<ClsPlanta>();
            try
            {
                result.Value = ListadosPlantaDAL.obtenerPlantasDeCategoria(id); 

                if ((result.Value as List<ClsPlanta>) == null || (result.Value as List<ClsPlanta>).Count == 0)
                {
                    result.StatusCode = (int)HttpStatusCode.NotFound;
                }
                else
                {
                    result.StatusCode = (int)HttpStatusCode.OK;
                }
            }
            catch
            {
                result.StatusCode = (int)HttpStatusCode.InternalServerError;
            }
            return result;
        }
    }
}
