using ExamenAjax_API.Entidades;
using ExamenAjax_API.Dal.Listados;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Net;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ExamenAjax_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriasController : ControllerBase
    {
        // GET api/<ValuesController>/5
        /*
         * Descripcion: Esta llamada a la API devuelve un ObjectResult cuyo Value sera un listado de ClsCategoria de la base de datos. 
         *              El estado del ObjectResult sera OK si se obtuvo una lista con ClsCategoria.
         *              En caso de que la llamada falle, el estado del ObjectResult sera:
         *                                                                                 -InternalServerError: Cuando se produzca cualquier tipo de excepcion.
         *                                                                                 -NotFound: Cuando no haya ClsCategoria en la lista.
         */
        [HttpGet]
        public ObjectResult Get()
        {
            ObjectResult result = new ObjectResult(new { });
            result.Value = new List<ClsCategoria>();
            try
            {
                result.Value = ListadosCategoriasDAL.obtenerCategorias();

                if ((result.Value as List<ClsCategoria>) == null || (result.Value as List<ClsCategoria>).Count == 0)
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
