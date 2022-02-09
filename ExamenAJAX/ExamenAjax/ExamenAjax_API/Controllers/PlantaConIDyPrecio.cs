namespace ExamenAjax_API.Controllers
{
    public class PlantaConIDyPrecio
    {
        #region Constructores
        //Constructor por defecto
        public PlantaConIDyPrecio()
        {
            Id = 0;
            Precio = 0;

        }
        //Constructor con parametros
        public PlantaConIDyPrecio(int id, double precio)
        {
            Id = id;
            Precio = precio;
        }
        #endregion

        #region Propiedades
        //ID
        public int Id { get; }
        //Precio
        public double Precio { get; set; }
        #endregion

    }
}
