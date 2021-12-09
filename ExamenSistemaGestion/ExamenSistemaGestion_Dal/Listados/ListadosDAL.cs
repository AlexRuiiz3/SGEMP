using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using ExamenSistemaGestion_Entidades;
using ExamenSistemaGestion_Dal.Conexion;

namespace ExamenSistemaGestion_Dal.Listados
{
    public class ListadosDAL
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
            try
            {
                SqlConnection conexion = clsMyConnection.establecerConexion();
                SqlCommand sqlCommand;
                SqlDataReader sqlDataReader;
                ClsCategoria categoria;

                sqlCommand = new SqlCommand("SELECT * FROM Categorias", conexion);
                sqlDataReader = sqlCommand.ExecuteReader();

                if (sqlDataReader.HasRows) //Si hay filas 
                {
                    while (sqlDataReader.Read())
                    {
                        categoria = new ClsCategoria();
                        categoria.Id = sqlDataReader.GetInt32(0);
                        categoria.Nombre = sqlDataReader[1].ToString();


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
            return listaCategorias;
        }

        /// <summary>
        /// Cabecera: public static List<ClsPlanta> obtenerPlantasDeCategoria(int idCategoria)
        /// Comentario: Este metodo se encarga de obtener todas las plantas que estan asociadas a un categoria en concreto(Segun el id recibido) que hay en la tabla PLanta de una base de datos.
        /// Entradas: int idCategoria
        /// Salidas: List<ClsPlanta> listaPlantas
        /// Precondiciones: Ninguna
        /// Postcondiciones: Se obtendra una lista con las plantas que estan asociadas a una categoria en concreto que hay en una base de datos, si el id recibido no coincide con ninguna categoria o
        ///                  se produce alguna excepcion, la lista devuleta tendra 0 elementos.
        /// 
        /// </summary>
        /// <paramref name="idCategoria"/>
        /// <returns>List<ClsPlanta> listaPlantas</returns>
        public static List<ClsPlanta> obtenerPlantasDeCategoria(int idCategoria)
        {
            List<ClsPlanta> listaPlantas = new List<ClsPlanta>();
            try
            {
                SqlConnection conexion = clsMyConnection.establecerConexion();
                SqlCommand sqlCommand;
                SqlDataReader sqlDataReader;
                ClsPlanta planta;

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
                        planta.Descripcion = sqlDataReader[2].ToString();
                        planta.IdCategoria = sqlDataReader.GetInt32(3);
                        /* Me da un error de que no se puede castear de system.double a system.single. Por eso cuando se modifique el precio de la planta y mas tarde se quiera modificar no va a salir el precio actual sino 0
                        if (sqlDataReader.GetValue(4) != System.DBNull.Value)
                        {
                            planta.Precio = sqlDataReader.GetFloat(4) ; //El problema esta en esta linea pero no entiendo el fallo, si en la base de datos hay un tipo de datos Float, se tendra que leer con el getFloat
                        }*/

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
            try
            {
                SqlConnection conexion = clsMyConnection.establecerConexion();
                SqlCommand sqlCommand;
                SqlDataReader sqlDataReader;


                sqlCommand = new SqlCommand("SELECT * FROM Plantas WHERE idPlanta = @ID", conexion);
                sqlCommand.Parameters.Add("@ID", System.Data.SqlDbType.Int).Value = idPlanta;
                sqlDataReader = sqlCommand.ExecuteReader();

                if (sqlDataReader.HasRows) //Si hay filas 
                {
                    sqlDataReader.Read();

                    planta = new ClsPlanta();
                    planta.Id = sqlDataReader.GetInt32(0);
                    planta.Nombre = sqlDataReader[1].ToString();
                    planta.Descripcion = sqlDataReader[2].ToString();
                    planta.IdCategoria = sqlDataReader.GetInt32(3);
                    /* Me da un error de que no se puede castear de system.double a system.single 
                    if (sqlDataReader.GetValue(4) != System.DBNull.Value)
                    {
                        planta.Precio = sqlDataReader.GetFloat(4) ; //El problema esta en esta linea pero no entiendo el fallo, si en la base de datos hay un tipo de datos Float, se tendra que leer con el getFloat
                    }*/
                }
                sqlDataReader.Close();
                clsMyConnection.cerrarConexion(conexion);
            }
            catch (SqlException)
            {
                throw;
            }
            return planta;
        }
    }
}