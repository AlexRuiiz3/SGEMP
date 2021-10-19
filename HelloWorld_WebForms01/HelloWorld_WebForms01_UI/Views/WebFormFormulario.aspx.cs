﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using HelloWorld_WebForms01_Entidades;

namespace HelloWorld_WebForms01_UI.Views
{
    public partial class WebFormFormulario : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnEnviar_Click(object sender, EventArgs e)
        {
            ClsPersona persona;

            if (String.IsNullOrEmpty(txtNombre.Text))
            {
                persona = new ClsPersona(txtNombre.Text);
                lblError.Text = "Nombre no valido";
                lblMensaje.Text = "";
            }
            else {
                lblMensaje.Text = $"Hola {txtNombre.Text}";
                lblError.Text = "";
            }

        }
    }
}