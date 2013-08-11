using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace Dyn.Database.logic
{
    public class DiarioPorDia : FactoryBase 
    {
        public DiarioPorDia() { }

        public Dyn.Database.entities.DiarioPorDia Load(int idDiario)
        {
            Dyn.Database.entities.DiarioPorDia objDiarioPorDia = new Dyn.Database.entities.DiarioPorDia();
            CreateCommand("usp_DiarioPorDia", true);
            AddCmdParameter("@idDiario", idDiario, ParameterDirection.Input);
            AddCmdParameter("@Action", 0, ParameterDirection.Input);
            ExecuteReader();
            while (Read())
            {
                objDiarioPorDia = new Dyn.Database.entities.DiarioPorDia(GetDataReader());
            }
            return objDiarioPorDia;
        }

        private void AddParameters(Dyn.Database.entities.DiarioPorDia objusuario)
        {
            CreateCommand("usp_DiarioPorDia", true);
            AddCmdParameter("@idDiario", objusuario.IdDiario, ParameterDirection.Input);
            AddCmdParameter("@diaSemana", objusuario.DiaSemana, ParameterDirection.Input);
            AddCmdParameter("@precio", objusuario.Precio, ParameterDirection.Input);
        }

        public object Insert(Dyn.Database.entities.DiarioPorDia objDiarioPorDia)
        {
            object IdDiario = null;
            AddParameters(objDiarioPorDia);
            AddCmdParameter("@Action", 2, ParameterDirection.Input);
            ExecuteReader();
            while (Read())
            {
                IdDiario = GetValue(0);
            }
            return IdDiario;
        }

        public void Update(Dyn.Database.entities.DiarioPorDia objDiarioPorDia)
        {
            AddParameters(objDiarioPorDia);
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
        public List<Dyn.Database.entities.DiarioPorDia> SeleccionarTodosLosDias(Dyn.Database.entities.Diario objDiario)
        {
            List<Dyn.Database.entities.DiarioPorDia> Collection = new List<Dyn.Database.entities.DiarioPorDia>();
            CreateCommand("usp_DiarioPorDia", true);
            AddCmdParameter("@idDiario", objDiario.IdDiario, ParameterDirection.Input);
            AddCmdParameter("@Action", 0, ParameterDirection.Input);
            ExecuteReader();
            while (Read())
            {
                Collection.Add(new Dyn.Database.entities.DiarioPorDia(GetDataReader()));
            }
            return Collection;
        }

    


    }
}
