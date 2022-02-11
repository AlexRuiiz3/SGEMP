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
        /// Comentario: Este metodo se encarga de obtener de la tabla Categorias de una base datos SQL, todas las categorias que contenga dicha tabla.
        /// Entradas: Ninguna
        /// Salidas: List(ClsCategoria) listaCategorias
        /// Precondiciones: Ninguna
        /// Postcondiciones: Se obtendra un listado con los registros(Categorias) que haya en la tabla Categorias.
        ///                  Si se produce algun tipo de excepcion se devolvera una lista vacia.
        /// </summary>
        /// <returns>List(ClsCategoria) listaCategorias</returns>
        public static List<ClsCategoria> obtenerCategorias()
        {
            List<ClsCategoria> listaCategorias = new List<ClsCategoria>();
            ClsCategoria categoria;

            SqlConnection conexion = null;
            SqlCommand sqlCommand;
            SqlDataReader sqlDataReader = null;
            try
            {
                conexion = clsMyConnection.establecerConexion();
                sqlCommand = new SqlCommand("SELECT * FROM Categorias", conexion);
                sqlDataReader = sqlCommand.ExecuteReader();

                if (sqlDataReader.HasRows)
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
