using ExamenAjax_API.Entidades;
using ExamenAjax_API.Dal.Conexion;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace ExamenAjax_API.Dal.Listados
{
    public class ListadosPlantaDAL
    {
        /// <summary>
        /// Cabecera: public static List(ClsPlanta) obtenerPlantasDeCategoria(int idCategoria)
        /// Comentario: Este metodo se encarga de obtener todas las plantas que estan asociadas a un categoria en concreto(Segun el id recibido) que hay en la tabla PLanta de una base de datos.
        /// Entradas: int idCategoria
        /// Salidas: List(ClsPlanta) listaPlantas
        /// Precondiciones: Ninguna
        /// Postcondiciones: Se obtendra una lista con las plantas que estan asociadas a una categoria en concreto que hay en una base de datos, si el id recibido no coincide con ninguna categoria o
        ///                  se produce alguna excepcion, la lista devuelta tendra 0 elementos.
        /// 
        /// </summary>
        /// <paramref name="idCategoria"/>
        /// <returns>List(ClsPlanta) listaPlantas</returns>
        public static List<ClsPlanta> obtenerPlantasDeCategoria(int idCategoria)
        {
            List<ClsPlanta> listaPlantas = new List<ClsPlanta>();
            ClsPlanta planta;

            SqlConnection conexion = null;
            SqlCommand sqlCommand;
            SqlDataReader sqlDataReader = null;
            try
            {
                conexion = clsMyConnection.establecerConexion();
                sqlCommand = new SqlCommand("SELECT * FROM Plantas WHERE idCategoria = @ID", conexion);
                sqlCommand.Parameters.Add("@ID", System.Data.SqlDbType.Int).Value = idCategoria;
                sqlDataReader = sqlCommand.ExecuteReader();

                if (sqlDataReader.HasRows) //Si hay filas 
                {
                    while (sqlDataReader.Read())
                    {
                        planta = new ClsPlanta();
                        planta.Id = sqlDataReader.GetInt32(0);
                        planta.Nombre = sqlDataReader[1].ToString();
                        planta.Descripcion = sqlDataReader.GetValue(2) != DBNull.Value ? sqlDataReader[2].ToString() : "";
                        planta.IdCategoria = sqlDataReader.GetInt32(3);
                        planta.Precio = 1;//sqlDataReader.GetValue(4) != DBNull.Value ? sqlDataReader.GetFloat(4) : 0; //No se porque pero esta petando al leer el precio, antes de hacer el examen estaba probando y funcionaba bien.
                        listaPlantas.Add(planta);
                    }
                }
                sqlDataReader.Close();
                clsMyConnection.cerrarConexion(conexion);
            }
            catch (SqlException)
            {
                throw;
            }
            finally
            {
                if (sqlDataReader != null)
                {
                    sqlDataReader.Close();
                }
                clsMyConnection.cerrarConexion(conexion);
            }
            return listaPlantas;
        }
    }
}
