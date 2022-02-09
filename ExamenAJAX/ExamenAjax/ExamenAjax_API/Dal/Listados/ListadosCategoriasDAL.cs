using ExamenAjax_API.Dal.Conexion;
using ExamenAjax_API.Entidades;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace ExamenAjax_API.Dal.Listados
{
    public class ListadosCategoriasDAL
    {
        /// <summary>
        /// Cabecera: public static List<ClsCategoria> obtenerCategorias()
        /// Comentario: Este metodo se encarga de obtener todas las categorias que hay en la tabla Categoria de una base de datos.
        /// Entradas: Ninguna
        /// Salidas: List<ClsCategoria> listaCategorias
        /// Precondiciones: Ninguna
        /// Postcondiciones: Se obtendra una lista con las categorias que hay en una base de datos, si no hay ninguna categoria o se produce 
        ///                  alguna excepcion, se devolvera una lista con 0 elementos.
        /// </summary>
        /// <returns>List<ClsCategoria> listaCategorias</returns>
        public static List<ClsCategoria> obtenerCategorias()
        {
            List<ClsCategoria> listaCategorias = new List<ClsCategoria>();
            ClsCategoria categoria;

            SqlCommand sqlCommand;
            SqlDataReader sqlDataReader = null;
            SqlConnection conexion = null;
            try
            {
                conexion = clsMyConnection.establecerConexion();

                sqlCommand = new SqlCommand("SELECT * FROM Categorias", conexion);
                sqlDataReader = sqlCommand.ExecuteReader();

                if (sqlDataReader.HasRows) //Si hay filas 
                {
                    while (sqlDataReader.Read())
                    {
                        categoria = new ClsCategoria(
                             sqlDataReader.GetInt32(0),
                             sqlDataReader[1].ToString()
                            );
                        listaCategorias.Add(categoria);
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
            return listaCategorias;
        }

    }
}
