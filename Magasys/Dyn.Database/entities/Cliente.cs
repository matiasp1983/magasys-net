using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace Dyn.Database.entities
{
    public class Cliente
    {
        #region Constructores

        public Cliente() { }

        public Cliente(Int32? idProv, string cui, string nom, string det, string domCalle, Int32? domNro, string domDpto, string domPiso, Int32? idLocal,
            string emai, Int16? est, string razonSoc, string responApellido, string responNombre, string responEmail, string tel)
        {
            idCliente = idProv;
            cuit = cui;
            nombre = nom;
            alias = det;
            domicilioCalle = domCalle;
            domicilioNro = domNro;
            domicilioDpto = domDpto;
            domicilioPiso = domPiso;
            idLocalidad = idLocal;
            email = emai;
            estado = est;
            razonSocial = razonSoc;
            responsableApellido = responApellido;
            responsableNombre = responNombre;
            responsableEmail = responEmail;
            telefono = tel;
        }

        public Cliente(IDataRecord obj)
		{            
            idCliente = Convert.ToInt32(obj["idProveedor"]);
            nombre = Convert.ToString(obj["nombre"]);
            estado = Convert.ToInt16(obj["estado"]);
            cuit = Convert.ToString(obj["cuit"]);
            alias = Convert.ToString(obj["detalle"]);
            domicilioCalle = Convert.ToString(obj["domicilioCalle"]);
            if (obj["domicilioNro"]!= DBNull.Value)
            {
                domicilioNro = Convert.ToInt32(obj["domicilioNro"]);
            }
            else
            {
                domicilioNro = null;
            }          
            //domicilioNro = Convert.ToInt32(obj["domicilioNro"]);
            domicilioDpto = Convert.ToString(obj["domicilioDpto"]);
            // domicilioPiso = Convert.ToString(obj["domicilioPiso"]);
            if (obj["domicilioPiso"] != DBNull.Value)
            {
                domicilioPiso = Convert.ToString(obj["domicilioPiso"]);
            }
            else
            {
                domicilioPiso = null;
            }
            if (obj["idLocalidad"] != DBNull.Value)
            {
                idLocalidad = Convert.ToInt32(obj["idLocalidad"]);
            }
            else
            {
                idLocalidad = null;
            }
            // idLocalidad = Convert.ToInt32(obj["idLocalidad"]);
            email = Convert.ToString(obj["email"]);
            razonSocial = Convert.ToString(obj["razonSocial"]);
            responsableApellido = Convert.ToString(obj["reponsableApellido"]);
            responsableNombre = Convert.ToString(obj["reponsableNombre"]);
            responsableEmail = Convert.ToString(obj["reponsableEmail"]);
            telefono = Convert.ToString(obj["telefono"]);   
		}

        #endregion

        #region Propiedades

        private Int32? idCliente;
        public Int32? IdCliente
        {
            get { return idCliente; }
            set { idCliente = value; }
        }

        private TipoDocumento tipoDocumento;
        public TipoDocumento NroDocumento
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

        private Int16? estado;
        public Int16? Estado
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
