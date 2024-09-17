using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Data.SqlClient;
using System.Data.OleDb;
using System.Data;
using System.Web;
using System.Configuration;
using System.Reflection;

namespace DataLayer
{
  public class DataAccess
  {
    private string strCon = "";
    public string cbStringDB = "";
    private SqlConnection cnn = new SqlConnection();
    private SqlDataAdapter DbAdapter = new SqlDataAdapter();
    private SqlCommand DbCommand = new SqlCommand();
    private SqlTransaction DbTran;
    private bool bDebug = true;
    public DataAccess()
    {
    }

    public void Open(string StringDB)
    {
      cbStringDB = StringDB;
      if (cnn.State.ToString() == "Open")
        cnn.Close();
      strCon = System.Configuration.ConfigurationManager.ConnectionStrings[StringDB].ToString();
      cnn.ConnectionString = strCon;
      cnn.Open();

    }

    public DataSet getData(string StoreProcedure, SqlParameter[] pParameters)
    {
      Open(cbStringDB);
      SqlDataAdapter daConsulta = new SqlDataAdapter(StoreProcedure, strCon);
      daConsulta.SelectCommand.CommandType = CommandType.StoredProcedure;
      daConsulta.SelectCommand.CommandTimeout = 120;
      for (int i = 0; i < pParameters.Length; i++)
        daConsulta.SelectCommand.Parameters.Add(pParameters[i]);

      DateTime dtInicio = DateTime.Now;

      DataSet dsResultado = new DataSet();
      daConsulta.Fill(dsResultado);
      Close();
      DebugProcedure(cbStringDB + ".." + StoreProcedure, pParameters, dtInicio);
      return dsResultado;
    }


    public DataSet getData(string StoreProcedure)
    {
      Open(cbStringDB);
      SqlDataAdapter daConsulta = new SqlDataAdapter(StoreProcedure, cnn);
      daConsulta.SelectCommand.CommandType = CommandType.StoredProcedure;
      daConsulta.SelectCommand.CommandTimeout = 120;

      DataSet dsResultado = new DataSet();
      DateTime dtInicio = DateTime.Now;
      daConsulta.Fill(dsResultado);
      Close();
      DebugProcedure(cbStringDB + ".." + StoreProcedure, null, dtInicio);
      return dsResultado;
    }

    public DataTable ExecProdIns(string StoreProcedure, SqlParameter[] pParameters)
    {
      DateTime dtInicio = DateTime.Now;
      try
      {
        Open(cbStringDB);
        SqlDataAdapter daConsulta = new SqlDataAdapter(StoreProcedure, cnn);
        daConsulta.SelectCommand.CommandType = CommandType.StoredProcedure;
        daConsulta.SelectCommand.CommandTimeout = 120;
        for (int i = 0; i < pParameters.Length; i++)
          daConsulta.SelectCommand.Parameters.Add(pParameters[i]);

				DataSet dsResultado = new DataSet();
				daConsulta.SelectCommand.ExecuteReader(CommandBehavior.Default);
				//SqlDataReader dr = daConsulta.SelectCommand.ExecuteReader(CommandBehavior.CloseConnection);
				daConsulta.SelectCommand.ExecuteNonQuery();
				//dsResultado.Tables[0].Load(dr);
				Close();
        DebugProcedure(cbStringDB + ".." + StoreProcedure, pParameters, dtInicio);
        return dsResultado.Tables[0];
      }
      catch
      {
        DebugProcedure(cbStringDB + ".." + StoreProcedure, pParameters, dtInicio);
        throw;
      }

    }

    public Boolean ExecProdInsBool(string StoreProcedure, SqlParameter[] pParameters)
    {
      DateTime dtInicio = DateTime.Now;
      try
      {
        Open(cbStringDB);
        SqlDataAdapter daConsulta = new SqlDataAdapter(StoreProcedure, cnn);
        daConsulta.SelectCommand.CommandType = CommandType.StoredProcedure;
        daConsulta.SelectCommand.CommandTimeout = 120;
        for (int i = 0; i < pParameters.Length; i++)
          daConsulta.SelectCommand.Parameters.Add(pParameters[i]);

        daConsulta.SelectCommand.ExecuteNonQuery();
        Close();
        DebugProcedure(cbStringDB + ".." + StoreProcedure, pParameters, dtInicio);
        return (bool)daConsulta.SelectCommand.Parameters[pParameters.Length - 1].Value;
      }
      catch
      {
        DebugProcedure(cbStringDB + ".." + StoreProcedure, pParameters, dtInicio);
        throw;
      }


    }


    public string ExecProdInsSTR(string StoreProcedure, SqlParameter[] pParameters)
    {
      DateTime dtInicio = DateTime.Now;
      try
      {

        Open(cbStringDB);
        SqlDataAdapter daConsulta = new SqlDataAdapter(StoreProcedure, cnn);
        daConsulta.SelectCommand.CommandType = CommandType.StoredProcedure;
        daConsulta.SelectCommand.CommandTimeout = 120;
        for (int i = 0; i < pParameters.Length; i++)
          daConsulta.SelectCommand.Parameters.Add(pParameters[i]);

        daConsulta.SelectCommand.ExecuteNonQuery();
        Close();
        DebugProcedure(cbStringDB + ".." + StoreProcedure, pParameters, dtInicio);
        return daConsulta.SelectCommand.Parameters[pParameters.Length - 1].Value.ToString();
      }
      catch
      {
        DebugProcedure(cbStringDB + ".." + StoreProcedure, pParameters, dtInicio);
        throw;
      }

    }




    public Int64 ExecProdDel(string StoreProcedure, SqlParameter[] pParameters)
    {
      DateTime dtInicio = DateTime.Now;
      try
      {
        Open(cbStringDB);
        SqlDataAdapter daConsulta = new SqlDataAdapter(StoreProcedure, cnn);
        daConsulta.SelectCommand.CommandType = CommandType.StoredProcedure;
        daConsulta.SelectCommand.CommandTimeout = 120;
        for (int i = 0; i < pParameters.Length; i++)
          daConsulta.SelectCommand.Parameters.Add(pParameters[i]);

        daConsulta.SelectCommand.ExecuteNonQuery();
        Close();
        DebugProcedure(cbStringDB + ".." + StoreProcedure, pParameters, dtInicio);
        return (Int64)daConsulta.SelectCommand.Parameters[pParameters.Length - 1].Value;
      }
      catch
      {
        DebugProcedure(cbStringDB + ".." + StoreProcedure, pParameters, dtInicio);
        throw;
      }


    }
    public void Close()
    {
      cnn.Close();

    }

    public void beginTrans()
    {
      try
      {
        if (DbTran == null)
        {
          if (cnn.State == 0)
          {
            Open(cbStringDB);
          }


          DbTran = cnn.BeginTransaction();
          DbCommand.Transaction = DbTran;
          DbAdapter.SelectCommand.Transaction = DbTran;
          DbAdapter.InsertCommand.Transaction = DbTran;
          DbAdapter.UpdateCommand.Transaction = DbTran;
          DbAdapter.DeleteCommand.Transaction = DbTran;


        }


      }
      catch (Exception exp)
      {
        throw exp;
      }
    }

    public void commitTrans()
    {
      try
      {
        if (DbTran != null)
        {
          DbTran.Commit();
          DbTran = null;
        }


      }
      catch (Exception exp)
      {
        throw exp;
      }
    }


    public void rollbackTrans()
    {
      try
      {
        if (DbTran != null)
        {
          DbTran.Rollback();
          DbTran = null;
        }


      }
      catch (Exception exp)
      {
        throw exp;
      }
    }



    public void ExecProc(string StoreProcedure, SqlParameter[] pParameters)
    {
      DateTime dtInicio = DateTime.Now;
      try
      {
        Open(cbStringDB);
        SqlDataAdapter daConsulta = new SqlDataAdapter(StoreProcedure, cnn);
        daConsulta.SelectCommand.CommandType = CommandType.StoredProcedure;
        daConsulta.SelectCommand.CommandTimeout = 120;
        for (int i = 0; i < pParameters.Length; i++)
          daConsulta.SelectCommand.Parameters.Add(pParameters[i]);

        daConsulta.SelectCommand.ExecuteNonQuery();
        Close();
        DebugProcedure(cbStringDB + ".." + StoreProcedure, pParameters, dtInicio);
      }
      catch
      {
        DebugProcedure(cbStringDB + ".." + StoreProcedure, pParameters, dtInicio);
        throw;
      }

    }


    /// <summary>
    /// Agrega parametros
    /// </summary>
    /// <param name="pPos"></param>
    /// <param name="Nombre"></param>
    /// <param name="Tipo"></param>
    /// <param name="Size"></param>
    /// <param name="Precision"></param>
    /// <param name="Valor"></param>
    /// <param name="Direccion"></param>
    /// <param name="Param"></param>
    /// <returns></returns>
    public void AddParameter(ref int pPos, string Nombre, object Valor, SqlDbType Tipo, int Size, byte Precision, ParameterDirection Direccion, ref SqlParameter[] Param)
    {
      Param[pPos] = new SqlParameter();
      Param[pPos].ParameterName = Nombre;
      Param[pPos].SqlDbType = Tipo;
      Param[pPos].Direction = Direccion;
      Param[pPos].Size = Size;
      Param[pPos].Precision = Precision;
      Param[pPos].Value = Valor;
      pPos++;
      return;
    }

    private void DebugProcedure(string StoreProcedure, SqlParameter[] pParameters, DateTime dtInicio)
    {
      if (bDebug)
      {
        string sSQL = "Exec ";

        sSQL = StoreProcedure + " ";
        if (pParameters != null)
        {
          for (int i = 0; i < pParameters.Length; i++)
          {
            if (pParameters[i].DbType == DbType.String || pParameters[i].DbType == DbType.AnsiString || pParameters[i].DbType == DbType.AnsiStringFixedLength || pParameters[i].DbType == DbType.Xml || pParameters[i].DbType == DbType.StringFixedLength)
              sSQL = sSQL + "'";
            sSQL = sSQL + pParameters[i].Value;
            if (pParameters[i].DbType == DbType.String || pParameters[i].DbType == DbType.AnsiString || pParameters[i].DbType == DbType.AnsiStringFixedLength || pParameters[i].DbType == DbType.Xml || pParameters[i].DbType == DbType.StringFixedLength)
              sSQL = sSQL + "'";
            if (i < pParameters.Length - 1)
              sSQL = sSQL + ",";

          }
        }
        dtInicio = DateTime.Now;

        string path = System.AppDomain.CurrentDomain.BaseDirectory;
        if (Directory.Exists(path + @"\logs"))
        {
          StreamWriter file = new StreamWriter(path + @"\logs\logSQL.txt", true);
          file.WriteLine(sSQL);
          file.WriteLine("GO");
          file.WriteLine("-- Hora Ejecucion   :" + dtInicio);
          file.WriteLine("-- Tiempo Ejecucion :" + (DateTime.Now - dtInicio).ToString());
          file.WriteLine("");
          file.WriteLine("-----------------------------------------------------------------------");
          file.WriteLine("");
          file.WriteLine("");
          file.Close();
        }
      }

    }



  }
}
