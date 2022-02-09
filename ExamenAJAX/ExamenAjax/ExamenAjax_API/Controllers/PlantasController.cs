using ExamenAjax_API.Entidades;
using ExamenAjax_API.Dal.Gestoras;
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
        // GET: api/<ValuesController>
        [HttpGet]
        public ObjectResult Get()
        {
            List<ClsPlanta> listadoPlantas = null;
            ObjectResult result = new ObjectResult(new { Value = listadoPlantas });
            try
            {
                result.Value = ListadosPlantaDAL.obtenerPlantas();

                if ((result.Value as List<ClsPlanta>) == null || (result.Value as List<ClsPlanta>).Count == 0)
                {
                    result.StatusCode = (int)HttpStatusCode.NotFound;
                }
                else {
                    result.StatusCode = (int)HttpStatusCode.OK;
                }
            }
            catch
            {
                result.StatusCode = (int)HttpStatusCode.InternalServerError;
            }
            return result;
        }

        // GET api/<ValuesController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<ValuesController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<ValuesController>/5
        [HttpPut]
        public ObjectResult Put([FromBody] ClsPlanta planta)
        {
            ObjectResult result = new ObjectResult(new { Value = 0 });
            try
            {
                result.Value = GestoraPlantasDAL.actualizarPrecioPlanta(planta.Id, planta.Precio);

                if (result.Value.ToString().Equals(0))
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

        // DELETE api/<ValuesController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
