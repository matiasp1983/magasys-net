using System;
using System.Web;
using System.Collections;
using System.Web.Services;
using System.Web.Services.Protocols;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;

[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
[System.Web.Script.Services.ScriptService]
public class AutoComplete : System.Web.Services.WebService
{
    #region [Atributos]

    private SqlConnection connection = null;
    private SqlCommand cmd = null;  
    private SqlDataReader dr = null;
    
    #endregion

    #region [Constructor]

    public AutoComplete()
    {      
        connection = new SqlConnection(ConfigurationManager.AppSettings.Get("keyconnection"));
    }
    
    #endregion

    #region [Métodos]

    [WebMethod]
    public String[] InformacionAutocompletarGeneros(string prefixText, int count)
    {
        List<String> Collection = new List<String>();
        CreateCommand("SELECT distinct nombre FROM Generos WHERE estado = 1 AND nombre LIKE '%'+ @nombre +'%'", false);
        AddCmdParameter("@nombre", prefixText, ParameterDirection.Input);
        OpenConnection();
        dr = cmd.ExecuteReader();
        while (dr.Read())
        {
            Collection.Add(dr["nombre"].ToString());
        }
        return Collection.ToArray();
    }
    
    #endregion

    #region [FactoryBase]

    /// <summary>
    /// Ejecucion de sentencia o procedimiento
    /// </summary>
    /// <param name="sql">Nombre del procedimiento o sentencia a ejecutar</param>
    /// <param name="use_store_proc">Si se invoca un procedimiento almacenado</param>
    public void CreateCommand(string sql, bool use_store_proc)
    {
        cmd = new SqlCommand(sql, connection);
        cmd.CommandType = CommandType.Text;
        if (use_store_proc)
            cmd.CommandType = CommandType.StoredProcedure;
    }

    /// <summary>
    /// Adiciona un parametro en la ejecucion de la sentencia o procedimiento
    /// </summary>
    /// <param name="name">Nombre del parametro</param>
    /// <param name="value">Valor del parametro</param>
    /// <param name="parameterDirection">Direccin del parametro (Entrada o Salida)</param>
    public void AddCmdParameter(string name, object value, ParameterDirection parameterDirection)
    {
        SqlParameter param = new SqlParameter(name, value);
        param.Direction = parameterDirection;
        cmd.Parameters.Add(param);
    }   

    /// <summary>
    /// Función que retorna la información en un DataReader
    /// </summary>
    /// <returns></returns>
    public SqlDataReader ExecuteReader()
    {
        try
        {
            OpenConnection();
            dr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
            return dr;
        }
        catch (Exception Ex)
        {
            CloseConnection();
            throw Ex;
        }
    }   

    /// <summary>
    /// Metodo que permite la apertura de la base de datos
    /// </summary>
    public void OpenConnection()
    {
        if (connection.State != ConnectionState.Open)
        {
            try
            {
                connection.Open();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }

    /// <summary>
    /// Método que permite el cierre de la conexión a la base de datos
    /// </summary>
    public void CloseConnection()
    {
        connection.Close();
    }
    
    #endregion
}

