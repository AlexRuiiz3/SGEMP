using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Ejercicio1.Models
{
    public class ClsEditarVM
    {
        private int idPersona;
        private String nombre;
        private String apellidos;
        private DateTime fechaNac;
        private String direccion;
        private String telefono;

        public ClsEditarVM() {
            idPersona = 0;
            nombre = "";
            apellidos = "";
            fechaNac = new DateTime();
            direccion = "";
            telefono = "";
        }

        public ClsEditarVM(int idPersona, String nombre, String apellidos, DateTime fechaNac, String direccion, String telefono) {
            this.idPersona = idPersona;
            this.nombre = nombre;
            this.apellidos = apellidos;
            this.fechaNac = fechaNac;
            this.direccion = direccion;
            this.telefono = telefono;

        }

        [HiddenInput(DisplayValue = false)]
        public int IdPersona { get { return idPersona; } set { idPersona = value; } }

        [Required(ErrorMessage = "Campo obligatorio")]
        public String Nombre { get { return nombre; } set { nombre = value; } }

        [Required(ErrorMessage = "Campo obligatorio"), MaxLength(40, ErrorMessage = "Longitud maxima 40 caracteres")]
        public String Apellidos { get { return apellidos; } set { apellidos = value; } }

        [DisplayFormat(DataFormatString = "{dd:MM:yyyy}")]
        public DateTime FechaNac { get { return fechaNac; } set { fechaNac = value; } }

        [MaxLength(200, ErrorMessage = "Longitud maxima 200 caracteres")]
        public String Direccion { get { return direccion; } set { direccion = value; } }

        [RegularExpression(@"(\+34|0034|34)?[ -]*(6|7)[ -]*([0-9][ -]*){8}", ErrorMessage = "Formato de telefono no español")]
        public String Telefono { get { return telefono; } set { telefono = value; } }

    }
}