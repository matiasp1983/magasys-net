using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using Dyn.Database.logic;

namespace Dyn.Database.entities
{
    public class Cliente
    {
        #region Constructores

        public Cliente() { }

        public Cliente(Int32? nroCli, TipoDocumento tipoDoc, Int32? nroDoc, string nom, string ape, string ali, string tel, string cel, string emai,
            string barrio, string domCalle, Int32? domNro, string domDpto, string domPiso, string codPostal, Int32? idLocal,
            Estado est, DateTime fecha)
        {
            nroCliente = nroCli;

            tipoDocumento = tipoDoc;
            nroDocumento = nroDoc;

            apellido = ape;
            nombre = nom;
            alias = ali;

            telefono = tel;
            celular = cel;
            email = emai;

            domicilioBarrio = barrio;
            domicilioCalle = domCalle;
            domicilioNro = domNro;
            domicilioDpto = domDpto;
            domicilioPiso = domPiso;
            domicilioCodPostal = codPostal;
            idLocalidad = idLocal;
            
            estado = est;
            fechaAlta = fecha;            
        }

        public Cliente(IDataRecord obj)
		{            
            nroCliente = Convert.ToInt32(obj["nroCliente"]);

            tipoDocumento.IdTipoDocumento = Convert.ToInt32(obj["tipoDocumento"]);
            try
            {
                nroDocumento = Convert.ToInt32(obj["nroDocumento"]);
            }
            catch (Exception)
            {
                nroDocumento = null;
            }
            
            nombre = Convert.ToString(obj["nombre"]);
            apellido = Convert.ToString(obj["apellido"]);
            alias = Convert.ToString(obj["alias"]);

            try
            {
                telefono = Convert.ToString(obj["telefono"]);
            }
            catch (Exception)
            {
                telefono = null;
            }

            try
            {
                celular = Convert.ToString(obj["celular"]);
            }
            catch (Exception)
            {
                celular = null;
            }

            email = Convert.ToString(obj["email"]);

            try
            {
                domicilioBarrio = Convert.ToString(obj["domBarrio"]);
            }
            catch (Exception)
            {
                domicilioBarrio = null;
            }

            domicilioCalle = Convert.ToString(obj["domCalle"]);

            try
            {
                domicilioNro = Convert.ToInt32(obj["domNro"]);
            }
            catch (Exception)
            {
                domicilioNro = null;
            }
      
            domicilioDpto = Convert.ToString(obj["domDpto"]);

            try
            {
                domicilioPiso = Convert.ToString(obj["domPiso"]);
            }
            catch (Exception)
            {
                domicilioPiso = null;
            }

            try
            {
                domicilioPiso = Convert.ToString(obj["domPiso"]);
            }
            catch (Exception)
            {
                domicilioPiso = null;
            }

            try
            {
                domicilioCodPostal = Convert.ToString(obj["domCodigoPostal"]);
            }
            catch (Exception)
            {
                domicilioCodPostal = null;
            }

            try
            {
                idLocalidad = Convert.ToInt32(obj["domIdLocalidad"]);
            }
            catch (Exception)
            {
                idLocalidad = null;
            }

            fechaAlta = Convert.ToDateTime(obj["fechaAlta"]);
            estado.IdEstado = Convert.ToInt32(obj["idEstado"]);
            try
            {
                motivoBaja = Convert.ToString(obj["motivoBaja"]);
            }
            catch (Exception)
            {
                motivoBaja = null;
            }
		}

        #endregion

        #region Propiedades

        private Int32? nroCliente;
        public Int32? NroCliente
        {
            get { return nroCliente; }
            set { nroCliente = value; }
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

        private string nombre;
        public string Nombre
        {
            get { return nombre; }
            set { nombre = value; }
        }

        private string apellido;
        public string Apellido
        {
            get { return apellido; }
            set { apellido = value; }
        }

        private string alias;
        public string Alias
        {
            get { return alias; }
            set { alias = value; }
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

        private string domicilioBarrio;
        public string DomicilioBarrio
        {
            get { return domicilioBarrio; }
            set { domicilioBarrio = value; }
        }

        private string domicilioCalle;
        public string DomicilioCalle
        {
            get { return domicilioCalle; }
            set { domicilioCalle = value; }
        }

        private Int32? domicilioNro;
        public Int32? DomicilioNro
        {
            get { return domicilioNro; }
            set { domicilioNro = value; }
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

        #region Operaciones

        public bool validarBaja()

        {
            //Dyn.Database.logic.Venta lVenta = Dyn.Database.logic.Venta();
            //Dyn.Database.logic.Reserva lReserva = Dyn.Database.logic.Reserva();

            // Crear una funcion en Ventas y Reservas y validar si el cliente posee alguna de ellas

            return true;
        
        }

        #endregion
    }
}
