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
        /// Cabecera: public static List(ClsPlanta) obtenerPlantas()
        /// Comentario: Este metodo se encarga de obtener de la tabla Plantas de una base datos SQL, todas las plantas que contenga dicha tabla.
        /// Entradas: Ninguna
        /// Salidas: List(ClsPlanta) listaPlantas
        /// Precondiciones: Ninguna
        /// Postcondiciones: Se obtendra un listado con los registros(Plantas) que haya en la tabla Plantas.
        ///                  Si se produce algun tipo de excepcion se devolvera una lista vacia.
        /// </summary>
        /// <returns>List(ClsPlanta) listaPlantas</returns>
        public static List<ClsPlanta> obtenerPlantas()
        {
            List<ClsPlanta> listaPlantas = new List<ClsPlanta>();
            ClsPlanta planta;

            SqlConnection conexion = null;
            SqlCommand sqlCommand;
            SqlDataReader sqlDataReader = null;
            try
            {
                conexion = clsMyConnection.establecerConexion();
                sqlCommand = new SqlCommand("SELECT * FROM Plantas", conexion);
                sqlDataReader = sqlCommand.ExecuteReader();

                if (sqlDataReader.HasRows)
                {
                    while (sqlDataReader.Read())
                    {
                        /* Lo hago de esta manera ya que clsPlanta.ID no tiene set, y no se puede hacer planta.ID = 1.
                         * Tambien se podrian crear varaibles y guardar hay el valor reader.get, pero de esta forma lo 
                         * veo mas comodo
                         */
                        planta = new ClsPlanta(
                            sqlDataReader.GetInt32(0),
                            sqlDataReader[1].ToString(),
                            sqlDataReader.GetValue(2) != DBNull.Value ? sqlDataReader[2].ToString() : "",
                            sqlDataReader.GetInt32(3),
                            sqlDataReader.GetValue(4) != DBNull.Value ? sqlDataReader.GetFloat(4) : 0
                            );
                        listaPlantas.Add(planta);
                    }
                }
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
                        planta = new ClsPlanta(
                            sqlDataReader.GetInt32(0),
                            sqlDataReader[1].ToString(),
                            sqlDataReader.GetValue(2) != DBNull.Value ? sqlDataReader[2].ToString() : "",
                            sqlDataReader.GetInt32(3),
                            sqlDataReader.GetValue(4) != DBNull.Value ? sqlDataReader.GetFloat(4) : 0
                            );
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

        /// <summary>
        /// Cabecera: public static ClsPlanta obtenerPlanta(int idPlanta)
        /// Comentario: Este metodo se encarga de obtener una planta en concreto que se ecuentra en la tabla Planta de una base de datos.
        /// Entradas: int idPlanta
        /// Salidas: ClsPlanta planta
        /// Precondiciones: Ninguna
        /// Postcondiciones: Se obtendra una planta en concreto que hay en una base de datos, si el id recibido no coincide con el de ninguna planta o se produce alguna excepcion, 
        ///                  el valor de la planta devuelta sea null.
        /// </summary>
        /// <paramref name="idPlanta"/>
        /// <returns>ClsPlanta planta</returns>
        public static ClsPlanta obtenerPlanta(int idPlanta)
        {
            ClsPlanta planta = null;

            SqlConnection conexion = null;
            SqlCommand sqlCommand;
            SqlDataReader sqlDataReader = null;
            try
            {
                conexion = clsMyConnection.establecerConexion();
                sqlCommand = new SqlCommand("SELECT * FROM Plantas WHERE idPlanta = @ID", conexion);
                sqlCommand.Parameters.Add("@ID", System.Data.SqlDbType.Int).Value = idPlanta;
                sqlDataReader = sqlCommand.ExecuteReader();

                if (sqlDataReader.HasRows) //Si hay filas 
                {
                    sqlDataReader.Read();

                    planta = new ClsPlanta(
                        sqlDataReader.GetInt32(0),
                        sqlDataReader[1].ToString(),
                        sqlDataReader.GetValue(2) != DBNull.Value ? sqlDataReader[2].ToString() : "",
                        sqlDataReader.GetInt32(3),
                        sqlDataReader.GetValue(4) != DBNull.Value ? sqlDataReader.GetFloat(4) : 0
                        );
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
            return planta;
        }
    }
}
