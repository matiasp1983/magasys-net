using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace Dyn.Database.logic 
{
    public class Suplemento : FactoryBase 
    {
        public Suplemento() { }

        public Dyn.Database.entities.Suplemento Load(int idSuplemento)
        {
            Dyn.Database.entities.Suplemento objSuplemento = new Dyn.Database.entities.Suplemento();
            CreateCommand("usp_Suplemento", true);
            AddCmdParameter("@idSuplemento", idSuplemento, ParameterDirection.Input);
            AddCmdParameter("@Action", 0, ParameterDirection.Input);
            ExecuteReader();
            while (Read())
            {
                objSuplemento = new Dyn.Database.entities.Suplemento(GetDataReader());
            }
            return objSuplemento;
        }

        private void AddParameters(Dyn.Database.entities.Suplemento objusuario)
        {
            CreateCommand("usp_Suplemento", true);
            AddCmdParameter("@idSuplemento", objusuario.IdSuplemento, ParameterDirection.Input);
            AddCmdParameter("@idDiario", objusuario.IdDiario, ParameterDirection.Input);
            AddCmdParameter("@diaSemana", objusuario.DiaSemana, ParameterDirection.Input);
            AddCmdParameter("@precio", objusuario.Precio, ParameterDirection.Input);
            AddCmdParameter("@idGenero", objusuario.IdGenero, ParameterDirection.Input);
            AddCmdParameter("@idPeriodicidad", objusuario.IdPeriodicidad, ParameterDirection.Input);
        }

        public object Insert(Dyn.Database.entities.Suplemento objSuplemento)
        {
            object IdSuplemento = null;
            objSuplemento.Estado = 1;
            AddParameters(objSuplemento);
            AddCmdParameter("@Action", 2, ParameterDirection.Input);
            ExecuteReader();
            while (Read())
            {
                IdSuplemento = GetValue(0);
            }
            return IdSuplemento;
        }

        public void Update(Dyn.Database.entities.Suplemento objSuplemento)
        {
            objSuplemento.Estado = 1;
            AddParameters(objSuplemento);
            AddCmdParameter("@Action", 1, ParameterDirection.Input);
            ExecuteNonQuery();
        }

        public void Delete(int idSuplemento)
        {
            CreateCommand("usp_Suplemento", true);
            AddCmdParameter("@idSuplemento", idSuplemento, ParameterDirection.Input);
            AddCmdParameter("@estado", 0, ParameterDirection.Input);
            AddCmdParameter("@Action", 3, ParameterDirection.Input);

            ExecuteNonQuery();
        }
        public bool validarVentas(int idEntity)
        {
            // FALTA REALIZAR FUNCIONAMIENTO, por ahora no valida nada 

            return true;
        }

    }
}
