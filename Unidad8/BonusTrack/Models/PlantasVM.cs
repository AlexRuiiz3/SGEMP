using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Dal;

namespace BonusTrack.Models
{
    public class PlantasVM
    {

        private List<String> nombresPlantas;
        private String detalles;

        public PlantasVM() {
            GestoraPlantas gestoraPlantas = new GestoraPlantas();
            nombresPlantas = gestoraPlantas.obtenerNombresPlantas();
            detalles = "";
        }

        public PlantasVM(String detalles) {
            GestoraPlantas gestoraPlantas = new GestoraPlantas();
            nombresPlantas = gestoraPlantas.obtenerNombresPlantas();
            this.detalles = detalles;
        }

        public List<String> NombresPlantas {
            get { return nombresPlantas; }
            set { nombresPlantas = value; }
        }

        public String Detalles
        {
            get { return detalles; }
            set { detalles = value; }
        }
    }
}