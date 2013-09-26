﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace Dyn.Database.entities
{
    public class Reserva
    {
        #region Constructores

        public Reserva() { }

        public Reserva(Int32? codRes,Int32? nroCli, DateTime fechReserv, DateTime fechIni, DateTime fechFin, string tipoRes, Int32? idProd,
            Int16? cant, Int32? idEst)
        {
            codReserva = codRes;
            nroCliente = nroCli;
            fechaReserva = fechReserv;
            fechaInicio = fechIni;
            fechaFin = fechFin;
            tipoReserva = tipoRes;
            idProducto = idProd;
            cantidad = cant;
            idEstado = idEst;
        }

        public Reserva(IDataRecord obj)
        {
            codReserva = Convert.ToInt32(obj["codReserva"]);
            nroCliente = Convert.ToInt32(obj["nroCliente"]);
            fechaReserva = Convert.ToDateTime(obj["fechaReserva"]);
            fechaInicio = Convert.ToDateTime(obj["fechaReserva"]);
            fechaFin = Convert.ToDateTime(obj["fechaReserva"]);
            tipoReserva = Convert.ToString(obj["tipoReserva"]);
            idProducto = Convert.ToInt32(obj["idProducto"]);
            cantidad = Convert.ToInt16(obj["cantidad"]);
            idEstado = Convert.ToInt32(obj["idEstado"]);
        }

        #endregion

        #region Propiedades

        private Int32? codReserva;

	    public Int32? CodReserva
	    {
            get { return codReserva; }
            set { codReserva = value; }
	    }

        private Int32? nroCliente;

	    public Int32? NroCliente
	{
		get { return nroCliente;}
		set { nroCliente = value;}
	}

        private DateTime fechaReserva;

        public DateTime FechaReserva
        {
            get { return fechaReserva; }
            set { fechaReserva = value; }
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

        private Int32? idProducto;

        public Int32? IdProducto
        {
            get { return idProducto; }
            set { idProducto = value; }
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
        
        #endregion
    }
}
