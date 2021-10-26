using System;

namespace Actividad1.Gestion
{
    public class Utilidad
    {

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public static String obtenerMensaje()
        {
            String mensaje = "Buenas noches";

            DateTime fechaActual = DateTime.Now;

            if (fechaActual.Hour >= 6 && fechaActual.Hour < 12) {
                mensaje = "Buenos Dias";
            } else if (fechaActual.Hour >= 12 && fechaActual.Hour < 22)
            {
                mensaje = "Buenas tardes";
            }

            return mensaje;
        }

    }
}
