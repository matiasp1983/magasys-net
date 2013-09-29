using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace Dyn.Database.entities
{
    public class ReservaEdicion
    {
        #region Constructores

        public ReservaEdicion() { }

        public ReservaEdicion(Int32? codResEdi, Int32? codRes, Int32? nroCli, DateTime fechReservEdi, DateTime fechIni, DateTime fechFin, string tipoRes,
            Int32? idProdEdi, Int16? cant, Int32? idEst)
        {
            codReservaEdicion = codResEdi;
            codReserva = codRes;
            idProductoEdicion = idProdEdi;
            nroCliente = nroCli;
            fechaReservaEdicion = fechReservEdi;
            fechaInicio = fechIni;
            fechaFin = fechFin;
            tipoReserva = tipoRes;
            cantidad = cant;
            idEstado = idEst;
        }

        public ReservaEdicion(IDataRecord obj)
        {
            codReservaEdicion = Convert.ToInt32(obj["codReservaEdicion"]);
            if (obj["codReserva"].ToString() == "")
            {
                codReserva = null; 
            }
            else
            { codReserva = Convert.ToInt32(obj["codReserva"]); }
            
            idProductoEdicion = Convert.ToInt32(obj["idProductoEdicion"]);
            nroCliente = Convert.ToInt32(obj["nroCliente"]);
            fechaReservaEdicion = Convert.ToDateTime(obj["fechaReservaEdicion"]);
            fechaInicio = Convert.ToDateTime(obj["fechaInicio"]);
            fechaFin = Convert.ToDateTime(obj["fechaFin"]);
            tipoReserva = Convert.ToString(obj["tipoReserva"]);
            cantidad = Convert.ToInt16(obj["cantidad"]);
            idEstado = Convert.ToInt32(obj["idEstado"]);
        }

        #endregion

        #region Propiedades

        private Int32? codReservaEdicion;
        public Int32? CodReservaEdicion
        {
            get { return codReservaEdicion; }
            set { codReservaEdicion = value; }
        }

        private Int32? codReserva;
        public Int32? CodReserva
        {
            get { return codReserva; }
            set { codReserva = value; }
        }
        
        private Reserva reserva = new Dyn.Database.entities.Reserva();
        public Reserva Reserva
        {
            get { return reserva; }
            set { reserva = value; }
        }

        private Int32? idProductoEdicion;
        public Int32? IdProductoEdicion
        {
            get { return idProductoEdicion; }
            set { idProductoEdicion = value; }
        }

        private ProductoEdicion productoEdicion = new Dyn.Database.entities.ProductoEdicion();
        public ProductoEdicion ProductoEdicion
        {
            get { return productoEdicion; }
            set { productoEdicion = value; }
        }

        private Int32? nroCliente;
        public Int32? NroCliente
        {
            get { return nroCliente; }
            set { nroCliente = value; }
        }

        private Cliente cliente = new Cliente();
        public Cliente Cliente
        {
            get { return cliente; }
            set { cliente = value; }
        }

        private DateTime fechaReservaEdicion;
        public DateTime FechaReservaEdicion
        {
            get { return fechaReservaEdicion; }
            set { fechaReservaEdicion = value; }
        }

        private DateTime fechaInicio;
        public DateTime FechaInicio
        {
            get { return fechaInicio; }
            set { fechaInicio = value; }
        }

        private DateTime fechaFin;
        public DateTime FechaFin
        {
            get { return fechaFin; }
            set { fechaFin = value; }
        }

        private string tipoReserva;
        public string TipoReserva
        {
            get { return tipoReserva; }
            set { tipoReserva = value; }
        }

        private Int16? cantidad;
        public Int16? Cantidad
        {
            get { return cantidad; }
            set { cantidad = value; }
        }

        private Int32? idEstado;
        public Int32? IdEstado
        {
            get { return idEstado; }
            set { idEstado = value; }
        }
        
        private Estado estado = new Estado();
        public Estado Estado
        {
            get { return estado; }
            set { estado = value; }
        }

        #endregion

        #region Operaciones

        public void CargarPropiedades()
        {
            Dyn.Database.logic.Cliente lCliente = new Dyn.Database.logic.Cliente();
            Dyn.Database.logic.ProductoEdicion2 lProducto = new Dyn.Database.logic.ProductoEdicion2();
            Dyn.Database.logic.Estado lEstado = new Dyn.Database.logic.Estado();
            Dyn.Database.logic.Reserva lReserva = new Dyn.Database.logic.Reserva();
            Cliente = lCliente.Load(Convert.ToInt16(nroCliente));
            ProductoEdicion = lProducto.CargarProductoEdicion(Convert.ToInt32(IdProductoEdicion));
            Estado = lEstado.Load(Convert.ToInt32(IdEstado));
            Reserva = lReserva.Load(Convert.ToInt32(IdEstado));

        }
        public void CargarDatosDeReserva()
        { 
            CodReserva = Reserva.CodReserva;
            Cantidad = Reserva.Cantidad;
            Cliente = Reserva.Cliente;
            TipoReserva = "Única";
            FechaInicio = DateTime.Now;
            FechaReservaEdicion = DateTime.Now;
            idProductoEdicion = ProductoEdicion.IdProductoEdicion;
            CodReserva = Reserva.CodReserva;
            NroCliente = Reserva.NroCliente;
        }

        #endregion
    }
}
