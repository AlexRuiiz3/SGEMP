/*
 * Nombre: ClsPersona
 * 
 * Comentario: Esta clase representa a una persona de la tabla Persona de una BBDD, siendo cada atributo una columna que esta definida en la tabla Persona
 * 
 * Atributos:   Basicos: Definido por propiedades autoimplementadas.
 *              Derivados: Ninguno.
 *              Compartidos: Ninguno.
 * 
 * Metodos Fundamentales:
 *                Propiedades: -public int ID
 *                             -public string Nombre
 *                             -public string Apellidos
 *                             -public string Telefono
 *                             -public string Direccion
 *                             -public byte[] Foto
 *                             -public DateTime FechaNacimiento
 *                             -public int IdDepartamento
 *                          
 * 
 * Metodos heredados: Ninguno.
 * Metodos añadidos: Ninguno.
 */
using System;

namespace ExamenSistemaGestion_Entidades
{
    public class Class1
    {
        #region Constructores
        //Constructor por defecto
        public Class1()
        {

        }
        //Constructor con parametros
        public Class1(string a) { 
        }
        #endregion

        #region Propiedades
        //
        public string a { get; set; }
        #endregion
    }
}
