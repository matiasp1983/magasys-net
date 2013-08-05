using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace Dyn.Database.logic
{
    public class MenuCategoria : FactoryBase
    {
        public MenuCategoria() { }
        
        public Dyn.Database.entities.MenuCategoria Load(Dyn.Database.entities.MenuCategoria objcategoria)
        {
            AddParameters(objcategoria);
            AddCmdParameter("@Action", 0, ParameterDirection.Input);
            ExecuteReader();
            while (Read())
            {
                objcategoria = new Dyn.Database.entities.MenuCategoria(GetDataReader());
            }
            return objcategoria;
        }

        public Dyn.Database.entities.MenuCategoria Load(int idcategoria)
        {
            Dyn.Database.entities.MenuCategoria objcategoria = new Dyn.Database.entities.MenuCategoria();
            CreateCommand("usp_MenuCategoria", true);
            AddCmdParameter("@IdMenuCategoria", idcategoria, ParameterDirection.Input);
            AddCmdParameter("@Action", 0, ParameterDirection.Input);
            ExecuteReader();
            while (Read())
            {
                objcategoria = new Dyn.Database.entities.MenuCategoria(GetDataReader());
            }
            return objcategoria;
        }

        /// <summary>
        /// Selecciona las categorias padre
        /// </summary>
        /// <returns></returns>
        /// 
        public List<Dyn.Database.entities.MenuCategoria> SeleccionarCategoriasPadre(int estado)
        {
            List<Dyn.Database.entities.MenuCategoria> Collection = new List<Dyn.Database.entities.MenuCategoria>();
            CreateCommand("usp_SeleccionarMenuCategoriasPadre", true);
            AddCmdParameter("@estado", estado, ParameterDirection.Input);
            ExecuteReader();
            while (Read())
            {
                Collection.Add(new Dyn.Database.entities.MenuCategoria(GetDataReader()));
            }
            return Collection;
        }

        /// <summary>
        /// selecciona las categorias hijas
        /// </summary>
        /// <param name="categoriaid">id de la categoria padre</param>
        /// <returns></returns>
        public List<Dyn.Database.entities.MenuCategoria> SeleccionarSubCategoriaDeCategoria(int categoriaid, int estado)
        {
            List<Dyn.Database.entities.MenuCategoria> Collection = new List<Dyn.Database.entities.MenuCategoria>();
            CreateCommand("usp_SeleccionarSubCategoriaDeMenuCategoria", true);
            AddCmdParameter("@idcategoria", categoriaid, ParameterDirection.Input);
            AddCmdParameter("@estado", estado, ParameterDirection.Input);
            ExecuteReader();
            while (Read())
            {
                Collection.Add(new Dyn.Database.entities.MenuCategoria(GetDataReader()));
            }
            return Collection;
        }

        private void AddParameters(Dyn.Database.entities.MenuCategoria objcategoria)
		{
			CreateCommand("usp_MenuCategoria", true);
            AddCmdParameter("@IdMenuCategoria", objcategoria.IdMenuCategoria, ParameterDirection.Input);
            AddCmdParameter("@RelacionadaIdMenuCategoria", objcategoria.RelacionadaIdMenuCategoria, ParameterDirection.Input);
			AddCmdParameter("@Nombre", objcategoria.Nombre, ParameterDirection.Input);
			AddCmdParameter("@Estado", objcategoria.Estado, ParameterDirection.Input);			
		}
    }
}
