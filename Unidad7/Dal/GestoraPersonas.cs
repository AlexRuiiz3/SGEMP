using System;
using Entidades;
using System.Collections.Generic;

namespace Dal
{
    public class GestoraPersonas
    {
        public static List<ClsPersona> obtenerPersonas() {
            List <ClsPersona> listaPersonas = new List<ClsPersona>();

            listaPersonas.Add(new ClsPersona("Persona1","Apellido1"));
            listaPersonas.Add(new ClsPersona("Persona2", "Apellido2"));
            listaPersonas.Add(new ClsPersona("Persona3", "Apellido3"));
            listaPersonas.Add(new ClsPersona("Persona4", "Apellido4"));

            return listaPersonas;
        }

    }
}
