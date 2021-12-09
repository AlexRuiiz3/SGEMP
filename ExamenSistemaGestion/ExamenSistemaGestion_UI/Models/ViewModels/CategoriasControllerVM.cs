using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ExamenSistemaGestion_Entidades;



namespace ExamenSistemaGestion_UI.Models.ViewModels
{
    public class CategoriasControllerVM
    {
        public CategoriasControllerVM() {
            ListaCategorias = new List<ClsCategoria>();
            ListaPlantasCategoria = new List<ClsPlanta>();
        }

        public CategoriasControllerVM(List<ClsCategoria> listaCategorias, List<ClsPlanta> listaPlantasCategoria) {
            ListaCategorias = listaCategorias;
            ListaPlantasCategoria = listaPlantasCategoria;
        }

        public List<ClsCategoria> ListaCategorias { get; set; }
        public List<ClsPlanta> ListaPlantasCategoria { get; set; }
    }
}
