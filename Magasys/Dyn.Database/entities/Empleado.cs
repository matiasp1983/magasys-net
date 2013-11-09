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

        public Empleado(Int32? nroEmp, TipoDocumento tipoDoc, Int32? nroDoc, string nom, string ape, string tel, string cel, string email,
            string barrio, string domCalle, Int32? donNro, string domDpto, string domPiso, string codPostal, Int32? idLocal, Estado est, 
            DataTime fecha)
        {
           // nroEmpleado = nroEmp;
           // tipoDocumento = nroDoc;

        
        }


    }
}
