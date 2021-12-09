using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ExamenSistemaGestion_Entidades;
using ExamenSistemaGestion_BL.Listados;
using ExamenSistemaGestion_UI.Models.ViewModels;

namespace ExamenSistemaGestion_UI.Controllers
{
    public class CategoriasController : Controller
    {
        /// <summary>
        /// Action que prepara un view model para la view Index del controller Categorias
        /// </summary>
        /// <returns></returns>
        public IActionResult Index()
        {
            IActionResult action;
            try
            {
                CategoriasControllerVM categoriasControllerVM = new CategoriasControllerVM();
                categoriasControllerVM.ListaCategorias = ListadosBL.obtenerCategorias();

                action = View(categoriasControllerVM);
            }
            catch (Exception)
            {
                action = View("ViewNotFoundCategorias");
            }
            return action;
        }
        /// <summary>
        /// Action que se prepara cuando se pulsa un boton de tipo sumit
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPost, ActionName("Index")]
        public IActionResult IndexPost(int id)
        {
            IActionResult action;
            try {
                CategoriasControllerVM categoriasControllerVM = new CategoriasControllerVM(ListadosBL.obtenerCategorias(), ListadosBL.obtenerPlantasDeCategoria(id));
                action = View(categoriasControllerVM);
            }
            catch (Exception) {
                action = View("ViewNotFoundCategorias");
            }
            return action;
        }
    }
}
