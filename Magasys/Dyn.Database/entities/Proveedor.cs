using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace Dyn.Database.entities
{
    public class Proveedor
    {
        #region Constructores

        public Proveedor() { }

        public Proveedor(Int32? idProv, string cui, string nom, string det, string domCalle, Int32? domNro, string domDpto, string domPiso, Int32? idLocal,
            string emai, Int16? est, string razonSoc, string responApellido, string responNombre, string responEmail, string tel)
        {
            idProveedor = idProv;
            cuit = cui;
            nombre = nom;
            detalle = det;
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

        public Proveedor(IDataRecord obj)
		{            
            idProveedor = Convert.ToInt32(obj["idProveedor"]);
            nombre = Convert.ToString(obj["nombre"]);
            estado = Convert.ToInt16(obj["estado"]);
            cuit = Convert.ToString(obj["cuit"]);
            detalle = Convert.ToString(obj["detalle"]);
            domicilioCalle = Convert.ToString(obj["domicilioCalle"]);
            if (obj["domicilioNro"]!= DBNull.Value)
            {
                domicilioNro = Convert.ToInt32(obj["domicilioNro"]);
            }
            else
            {
                domicilioNro = null;
            }          
            domicilioNro = Convert.ToInt32(obj["domicilioNro"]);
            domicilioDpto = Convert.ToString(obj["domicilioDpto"]);
            domicilioPiso = Convert.ToString(obj["domicilioPiso"]);
            //if (obj["idLocalidad"] != DBNull.Value)
            //{
            //    domicilioNro = Convert.ToInt32(obj["idLocalidad"]);
            //}
            //else
            //{
            //    domicilioNro = null;
            //} 
            idLocalidad = Convert.ToInt32(obj["idLocalidad"]);
            email = Convert.ToString(obj["email"]);
            razonSocial = Convert.ToString(obj["razonSocial"]);
            responsableApellido = Convert.ToString(obj["reponsableApellido"]);
            responsableNombre = Convert.ToString(obj["reponsableNombre"]);
            responsableEmail = Convert.ToString(obj["reponsableEmail"]);
            telefono = Convert.ToString(obj["telefono"]);   
		}

        #endregion

        #region Propiedades

        private Int32? idProveedor;
        public Int32? IdProveedor
        {
            get { return idProveedor; }
            set { idProveedor = value; }
        }

        private string cuit;
        public string Cuit
        {
            get { return cuit; }
            set { cuit = value; }
        }

        private string nombre;
        public string Nombre
        {
            get { return nombre; }
            set { nombre = value; }
        }

        private string detalle;
        public string Detalle
        {
            get { return detalle; }
            set { detalle = value; }
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

        private Int32? idLocalidad;
        public Int32? IdLocalidad
        {
            get { return idLocalidad; }
            set { idLocalidad = value; }
        }

        private string email;
        public string Email
        {
            get { return email; }
            set { email = value; }
        }

        private Int16? estado;
        public Int16? Estado
        {
            get { return estado; }
            set { estado = value; }
        }

        private string razonSocial;
        public string RazonSocial
        {
            get { return razonSocial; }
            set { razonSocial = value; }
        }

        private string responsableApellido;
        public string ResponsableApellido
        {
            get { return responsableApellido; }
            set { responsableApellido = value; }
        }

        private string responsableNombre;
        public string ResponsableNombre
        {
            get { return responsableNombre; }
            set { responsableNombre = value; }
        }

        private string responsableEmail;
        public string ResponsableEmail
        {
            get { return responsableEmail; }
            set { responsableEmail = value; }
        }

        private string telefono;
       // private System.Data.SqlClient.SqlDataReader sqlDataReader;

        public string Telefono
        {
            get { return telefono; }
            set { telefono = value; }
        }

        #endregion
    }
}
