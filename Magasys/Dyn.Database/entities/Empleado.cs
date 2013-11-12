using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using Dyn.Database.logic;

namespace Dyn.Database.entities
{
   public class Empleado
    {
        #region constructores
        
        public Empleado () {}

        public Empleado(Int32? nroEmp, TipoDocumento tipoDoc, Int32? nroDoc, string ape, string nom, string tel, string cel, string emai,
            string barrio, string calle, Int32? nro, string dpto, string piso, string codPostal, Int32? idLocal, Estado est, 
            DateTime fecha)
        {
            nroEmpleado = nroEmp;
            tipoDocumento = tipoDoc;
            nroDocumento = nroDoc;
            apellido = ape;
            nombre = nom;
            telefono = tel;
            celular = cel;
            email = emai;
            domBarrio = barrio;
            domCalle = calle;
            domNro = nro;
            domicilioDpto = dpto;
            domicilioPiso = piso;
            domicilioCodPostal = codPostal;
            idLocalidad = idLocal;
            estado = est;
            fechaAlta = fecha;
        }

        #endregion

        #region Propiedades

        private Int32? nroEmpleado;
        public Int32? NroEmpleado
        { 
            get { return nroEmpleado; }
            set { nroEmpleado = value; }
        }

       private TipoDocumento tipoDocumento = new TipoDocumento();
       public TipoDocumento TipoDocumento
       {
           get { return tipoDocumento; }
           set { tipoDocumento = value; }

       }

       private Int32? nroDocumento;
       public Int32? NroDocumento
       {
           get { return nroDocumento; }
           set { nroDocumento = value; }
       }

       private string apellido;
       public string Apellido
       {
           get { return apellido; }
           set { apellido = value; }
       }

       private string nombre;
       public string Nombre
       {
           get { return nombre; }
           set { nombre = value; }
       }

       private string telefono;
       public string Telefono
       {
           get { return telefono; }
           set { telefono = value; }
       }
       private string celular;
       public string Celular
       {
           get { return celular; }
           set { celular = value; }
       }

       private string email;
       public string Email
       {
           get { return email; }
           set { email = value; }
       }

       private string domBarrio;
       public string DomBarrio
       {
           get { return domBarrio; }
           set { domBarrio = value; }
       }

       private string domCalle;
       public string DomCalle
       {
           get { return domCalle; }
           set { domCalle = value; }
       }

       private Int32? domNro;
       public Int32? DomNro
       {
           get { return domNro; }
           set { domNro = value; }
       }

       private string domicilioDpto;
       public string DomicilioDpto
       {
           get { return domicilioDpto; }
           set { domicilioDpto = value; }
       }

       private string domicilioPiso;
       public string DomicilioPiso
       {
           get { return domicilioPiso; }
           set { domicilioPiso = value; }
       }

       private string domicilioCodPostal;
       public string DomicilioCodPostal
       {
           get { return domicilioCodPostal; }
           set { domicilioCodPostal = value; }
       }

       private Int32? idLocalidad;
       public Int32? IdLocalidad
       {
           get { return idLocalidad; }
           set { idLocalidad = value; }
       }

       private DateTime fechaAlta;
       public DateTime FechaAlta
       {
           get { return fechaAlta; }
           set { fechaAlta = value; }
       }

       private Estado estado = new Estado();
       public Estado Estado
       {
           get { return estado; }
           set { estado = value; }
       }

       private string motivoBaja;
       public string MotivoBaja
       {
           get { return motivoBaja; }
           set { motivoBaja = value; }
       }

        #endregion
    }
}
