using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BonusTrack.Models
{
    public class ClsPlantasVM
    {

        private List<String> nombresPlantas;
        private String detalles;

        public ClsPlantasVM() {
            nombresPlantas = new List<string>();
            detalles = "";
        }

        public ClsPlantasVM(List<String> nombresPlantas, String detalles) {
            this.nombresPlantas = nombresPlantas;
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