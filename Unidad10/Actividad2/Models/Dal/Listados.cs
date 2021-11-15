using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using Actividad2.Models.Entidades;

namespace Actividad2.Models.Dal
{
    public class Listados
    {
      
        public static List<ClsPersona> obtenerPersonas()
        {
            SqlConnection conexion = new SqlConnection();
            SqlCommand sqlCommand;
            SqlDataReader sqlDataReader;
            List<ClsPersona> listaPersonas = new List<ClsPersona>();

            try
            {
                conexion.ConnectionString = "server=servidoralexbasedatos.database.windows.net;" +
                                            "database=SistemaGestion;uid=saboresdelatierra;pwd=#Mitesoro;";
                conexion.Open();

                sqlCommand = new SqlCommand("SELECT * FROM Personas", conexion);
                sqlDataReader = sqlCommand.ExecuteReader();

                while (sqlDataReader.Read())
                {
                    listaPersonas.Add(new ClsPersona(sqlDataReader.GetInt16(0),
                                                        sqlDataReader[1].ToString(),
                                                        sqlDataReader[2].ToString(),
                                                        sqlDataReader[3].ToString(),
                                                        sqlDataReader[4].ToString(),
                                                        0,
                                                        sqlDataReader[6].ToString(),
                                                        sqlDataReader.GetInt16(7)));

                }
                conexion.Close();
            }
            catch (SqlException e)
            {

            }
            return listaPersonas;
        }
    }
}