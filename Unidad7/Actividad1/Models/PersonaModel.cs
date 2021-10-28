using System;

namespace Actividad1.Models

{
    public class PersonaModel
    {
        public String nombre;
        public String apellidos;

       #region Constructor con parametros
        public PersonaModel(String nombre, String apellidos)
        {
            this.nombre = nombre;
            this.apellidos = apellidos;

        }
        #endregion


        public String Nombre{ get { return nombre; } set { nombre = value; } }

        public String Apellidos { get { return apellidos; } set { apellidos = value; } }
    }
}
