using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;
using ExamenSistemaGestion_Dal.Gestora;

namespace ExamenSistemaGestion_BL.Gestora
{
    public class GestoraPlantasBL
    {
        /// <summary>
        /// Cabecera: public static int actualizarPrecioPlanta(int idPlanta,float precio)
        /// Comentario: Este metodo se encarga de llamar al metodo GestoraPlantasDAL.actualizarPrecioPlanta(idPlanta,precio)
        /// Entradas: int idPlanta,float precio
        /// Salidas: int actualizaciones
        /// Precondiciones: La persona recibida no debera de estar a null, sino se producira una excepcion.
        /// Postcondiciones: Se modificara el valor de las columna precio una planta en especifico de la tabla Planta y se devolvera el numero de modificaciones realizadas,
        ///                  si el id recibido no coincide con el de ninguna planta o el precio a actualizar es el que ya tiene la planta o se produce alguna excepcion no se 
        ///                  modificara el valor precio de la planta y el valor del numero entero devuelto sera 0.
        /// </summary>
        /// <param name="idPlanta"></param>
        /// <param name="precio"></param>
        /// <returns>int actualizaciones</returns>
        public static int actualizarPrecioPlanta(int idPlanta, float precio)
        {
            int actualizaciones = 0;
            try
            {
                actualizaciones = GestoraPlantasDAL.actualizarPrecioPlanta(idPlanta,precio);
            }
            catch (SqlException)
            {
                throw;
            }
            return actualizaciones;
        }

    }
}
