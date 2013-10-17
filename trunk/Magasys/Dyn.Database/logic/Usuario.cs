using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace Dyn.Database.logic
{
    public class Usuario : FactoryBase
    {
        public Usuario() {}

        public List<Dyn.Database.entities.Usuario> BuscarUsuarios(string nombre, string apellido, int tipoDoc, int nroDoc)
        {
            List<Dyn.Database.entities.Usuario> Collection = new List<Dyn.Database.entities.Usuario>();
            CreateCommand("usp_Usuario", true);
            AddCmdParameter("@nombre", nombre, ParameterDirection.Input);
            AddCmdParameter("@apellido", apellido, ParameterDirection.Input);
            AddCmdParameter("@tipoDocumento", tipoDoc, ParameterDirection.Input);
            if (nroDoc != 0)
            {
                AddCmdParameter("@nroDocumento", nroDoc, ParameterDirection.Input);
            }
            AddCmdParameter("@Action", 0, ParameterDirection.Input);
            ExecuteReader();
            while (Read())
            {
                Collection.Add(new Dyn.Database.entities.Usuario(GetDataReader()));
            }
            return Collection;
        }
    }
}
