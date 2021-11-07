using System;
using System.Collections.Generic;

namespace Dal
{
    public class GestoraPlantas
    {

        /// <summary>
        /// Cabecera: public static List<String> obtenerNombresPlantas()
        /// Comentarios: Este metodo se encarga de obtener un listado con todos los nombres de plantas que hay.
        /// Entradas: Ninguna
        /// Salidas: List<String> nombresPlantas
        /// Precondiciones: Ninguna
        /// Postcondiciones: Se devolvera una lista de String con todos los nombres de plantas.
        /// </summary>
        /// <returns>List<String> nombresPlantas</returns>
        public static List<String> obtenerNombresPlantas()
        {
            List<String> nombresPlantas = new List<String>();

            nombresPlantas.Add("Aloe Vera");
            nombresPlantas.Add("Valeriana");
            nombresPlantas.Add("Amapola");
            nombresPlantas.Add("Eucalipto");
            nombresPlantas.Add("Salvia");
            nombresPlantas.Add("Arandanos");

            return nombresPlantas;
        }

        /// <summary>
        /// Cabecera: public static String obtenerDetallesPlanta(String nombre)
        /// Comentarios: Este metodo se encarga de obtener los detalles de una Planta apartir del nombre.
        /// Entradas: String nombre
        /// Salidas: String detalles
        /// Precondiciones: Niguna
        /// Postcondiciones: Se devolvera un valor de tipo String cuyo valor sera los detalles que tiene asociado una planta.
        ///                  Si el nombre no esta asociado a ninguna planta el valor del String devuelto sera ""(Vacio)
        /// </summary>
        /// <param name="nombre"></param>
        /// <returns>String detalles</returns>
        public static String obtenerDetallesPlanta(String nombre)
        {

            String detalles = "";

            switch (nombre)
            {

                case "Aloe Vera":
                    detalles = "De la familia de las Asphodelaceae, pertenece al género Aloe, que cuenta con más de 350 especies " +
                        "vegetales. Esta especie, muy habitual entre las plantas de interior, tiene infinidad de aplicaciones en " +
                        "diversos remedios naturales, especialmente para los de la piel. Entre ellas, la de aliviar las quemaduras," +
                        " rozaduras e, incluso, psoriasis y picaduras de insectos.";
                    break;

                case "Valeriana":
                    detalles = "La valeriana o Valeriana officinalis es una de las plantas medicinales más empleadas en " +
                        "la fitoterapia. Y es normal, ya que tiene infinidad de beneficios pero quizás el más conocido sea el " +
                        "ayudar a relajarnos. La valeriana es una planta que disminuye la ansiedad y ayuda a dormir. ";
                    break;

                case "Amapola":
                    detalles = "La amapola o Papaver rhoeas L., es una planta curativa de la que se usan las semillas." +
                        " Con estas semillas se consigue prevenir enfermedades cardiovasculares, anemias o afecciones de la piel.";
                    break;

                case "Eucalipto":
                    detalles = "El eucalipto o eucaliptas es una de las plantas que más usamos para decorar la casa." +
                        " Son plantas muy resistentes y perfectas para añadir a cualquier centro de mesa. Pero además de " +
                        "decorar el interior de nuestra casa, los eucaliptos son plantas medicinales muy beneficiosas para " +
                        "la salud. Entre sus propiedades más conocidas está la de aliviar los síntomas de los resfriados, en" +
                        " concreto afecciones respiratorias (tos, bronquitis, neumonía, asma...).";
                    break;

                case "Salvia":
                    detalles = "La salvia o Salvia officinalis es una de las plantas más conocidas por utilizarse en cosméticos, " +
                        "pero también tiene otras funciones. Entre las más conocidas está su utilización para aliviar los síntomas" +
                        " de la menopausia.";
                    break;

                case "Arandanos":
                    detalles = "Los arándanos o también llamado como cranberry (o Vaccinium macrocarpon) junto con las" +
                        " frambuesas son algunos de los ingredientes principales de los boles que más verás en un desayuno" +
                        " saludable. Pues bien, los arándanos, muy populares en la fitoterapia, a pesar de ser muy pequeños," +
                        " cuentan con muchas propiedades, entre las que destaca su capacidad antibacteriana, ya que ayuda a " +
                        "combatir infecciones. ";
                    break;
            }
            return detalles;
        }
    }
}
