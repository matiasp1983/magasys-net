using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace Dyn.Database.entities
{
    public class IngresoProducto
    {
        #region Constructores

        public IngresoProducto() { }

        public IngresoProducto(Int32? idIngresoProd, DateTime fech, Int16? est, Int32? idProv)
        {
            idIngresoProducto = idIngresoProd;
            fecha = fech;
            estado = est;
            idProveedor = idProv;
        }

        public IngresoProducto(IDataRecord obj)
		{
            idIngresoProducto = Convert.ToInt32(obj["idIngresoProductos"]);
            fecha = Convert.ToDateTime(obj["fecha"]);
            estado = Convert.ToInt16(obj["estado"]);
            idProveedor = Convert.ToInt32(obj["idProveedor"]);

		}

        #endregion

        #region Propiedades

        private Int32? idIngresoProducto;

        public Int32? IdIngresoProducto
        {
            get { return idIngresoProducto; }
            set { idIngresoProducto = value; }
        }

        private DateTime fecha;

        public DateTime Fecha
        {
            get { return fecha; }
            set { fecha = value; }
        }

        private Int16? estado;

        public Int16? Estado
        {
            get { return estado; }
            set { estado = value; }
        }

        private Int32? idProveedor;

        public Int32? IdProveedor
        {
            get { return idProveedor; }
            set { idProveedor = value; }
        }

        private List<DetalleIngresoProducto> detalleIngreso = new List<DetalleIngresoProducto>();

        #endregion

        #region Operaciones

        public void CargarDetalles()
        {
            Dyn.Database.logic.DetalleIngreso lDetalleIngreso = new Dyn.Database.logic.DetalleIngreso();
            detalleIngreso = lDetalleIngreso.SeleccionarDetallesPorIngreso(idIngresoProducto);
        }
        public List<DetalleIngresoProducto> ObtenerDetalles()
        {
            return detalleIngreso;
        }
        public void AgregarDetalle(Dyn.Database.entities.DetalleIngresoProducto objDetalle)
        {
            detalleIngreso.Add(objDetalle);
        }
        

    }


}
