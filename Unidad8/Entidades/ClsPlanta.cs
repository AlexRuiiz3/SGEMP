using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class ClsPlanta
    {

        private String nombre;
        private String detalles;

        public ClsPlanta() {
            nombre = "";
            detalles = "";
        }

        public ClsPlanta(String nombre, String detalles) {
            this.nombre = nombre;
            this.detalles = detalles;
        }


        public String Nombre{
            get { return nombre; }
            set { nombre = value; }
        }
        public String Detalles
        {
            get { return detalles; }
            set { detalles = value; }
        }
    }
}
