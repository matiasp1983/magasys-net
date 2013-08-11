using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace Dyn.Database.logic
{
    public class Diario : FactoryBase
    {
        public Diario() { }

        public Dyn.Database.entities.Diario Load(int idDiario)
        {
            Dyn.Database.entities.Diario objDiario = new Dyn.Database.entities.Diario();
            CreateCommand("usp_Coleccion", true);
            AddCmdParameter("@idColeccion", idDiario, ParameterDirection.Input);
            AddCmdParameter("@Action", 0, ParameterDirection.Input);
            ExecuteReader();
            while (Read())
            {
                objDiario = new Dyn.Database.entities.Diario(GetDataReader());
            }
            return objDiario;
        }

        private void AddParameters(Dyn.Database.entities.Diario objusuario)
        {
            CreateCommand("usp_Diario", true);
            AddCmdParameter("@idDiario", objusuario.IdDiario, ParameterDirection.Input);
        }

        public object Insert(Dyn.Database.entities.Diario objDiario)
        {
            object IdDiario = null;
            AddParameters(objDiario);
            AddCmdParameter("@Action", 2, ParameterDirection.Input);
            ExecuteReader();
            while (Read())
            {
                IdDiario = GetValue(0);
            }
            return IdDiario;
        }

        public void Update(Dyn.Database.entities.Diario objDiario)
        {
            objDiario.Estado = 1;
            AddParameters(objDiario);
            AddCmdParameter("@Action", 1, ParameterDirection.Input);
            ExecuteNonQuery();
        }

        public void Delete(int idColeccion)
        {
        //    CreateCommand("usp_Coleccion", true);
        //    AddCmdParameter("@idColeccion", idColeccion, ParameterDirection.Input);
        //    AddCmdParameter("@idGenero", 0, ParameterDirection.Input);
        //    AddCmdParameter("@idPeriodicidad", 3, ParameterDirection.Input);

        //    ExecuteNonQuery();
        }

    

    }
}
