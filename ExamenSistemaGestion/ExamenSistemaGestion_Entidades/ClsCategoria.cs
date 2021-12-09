﻿using System;

namespace ExamenSistemaGestion_Entidades
{
    public class ClsCategoria
    {
        #region Constructores
        //Constructor por defecto
        public ClsCategoria()
        {
            Id = 0;
            Nombre = "";
        }
        //Constructor con parametros
        public ClsCategoria(int id,string nombre) {
            Id = id;
            Nombre = nombre;
        }
        #endregion

        #region Propiedades
        //ID
        public int Id{ get; set; }
        //Nombre
        public string Nombre { get; set; }
        #endregion
    }
}
