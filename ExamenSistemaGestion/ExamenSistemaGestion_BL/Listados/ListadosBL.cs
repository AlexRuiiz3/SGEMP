using System;
using System.Collections.Generic;
using System.Text;
using ExamenSistemaGestion_Entidades;
using ExamenSistemaGestion_Dal.Listados;
using System.Data.SqlClient;

namespace ExamenSistemaGestion_BL.Listados
{
    public class ListadosBL
    {

        /// <summary>
        /// Cabecera: public static List<ClsCategoria> obtenerCategorias()
        /// Comentario: Este metodo se encarga de llamar al metodo ListadosDAL.obtenerCategorias()
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
                listaCategorias = ListadosDAL.obtenerCategorias();
            }
            catch (SqlException)
            {
                throw;
            }
            return listaCategorias;
        }
        /// <summary>
        /// Cabecera: public static List<ClsPlanta> obtenerPlantasDeCategoria(int idCategoria)
        /// Comentario: Este metodo se encarga de llamar al metodo ListadosDAL.obtenerPlantasDeCategoria(idCategoria)
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
                listaPlantas = ListadosDAL.obtenerPlantasDeCategoria(idCategoria);
            }
            catch (SqlException)
            {
                throw;
            }
            return listaPlantas;
        }
        /// <summary>
        /// Cabecera: public static ClsPlanta obtenerPlanta(int idPlanta)
        /// Comentario: Este metodo se encarga de llamar al metodo ListadosDAL.obtenerPlanta(idPlanta)
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
                planta = ListadosDAL.obtenerPlanta(idPlanta);
            }
            catch (SqlException)
            {
                throw;
            }
            return planta;
        }
    }
}
