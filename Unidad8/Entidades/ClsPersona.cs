using System;

namespace Entidades

{
    public class ClsPersona
    {
        private String nombre;
        private String apellidos;
        private int edad;

        #region Constructor con parametros
        public ClsPersona(String nombre, String apellidos, int edad)
        {
            this.nombre = nombre;
            this.apellidos = apellidos;
            this.edad = edad;
        }
        #endregion


        public String Nombre { get { return nombre; } set { nombre = value; } }

        public String Apellidos { get { return apellidos; } set { apellidos = value; } }

        public int Edad { get { return edad; } set { edad = value; } }
    }
}
