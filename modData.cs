using System;
using System.Collections.Generic;
using System.Text;
using System.Data;


public static class ModData
{
    //public static Boolean _DEBUG = false;

    public static string ConnectionString { get; set; }
    //dataset containing entire database in memory
    public static DataSet gvarModDataset = new DataSet();
    public static IDbConnection m_conn;
    private static IDbCommand m_cmd;

    public static void Init(IDbConnection pDBConnection)
    {
        m_conn = pDBConnection;
        ConnectionString = m_conn.ConnectionString;
        //m_conn.ConnectionString = ConnectionString;
        m_conn.Open();
        m_cmd = m_conn.CreateCommand();
    }
    public static void DeInit()
    {
        if ((m_conn != null) && m_conn.State == ConnectionState.Open)
        {
            m_conn.Close();
            m_conn = null;

        }
    }
    public static DataTable ExecuteSQL(string pQuery, string p_TableName = "")
    {
        if (m_conn.State != ConnectionState.Open)
            m_conn.Open();

        var m_cmd = m_conn.CreateCommand();

        DataTable dtTemp = new DataTable(p_TableName);
        m_cmd.CommandText = pQuery;

        //#TODO:For Desktop
        var reader = m_cmd.ExecuteReader();

        dtTemp.Load(reader);
        reader.Close();
        m_cmd.Dispose();

        return dtTemp;
    }
    public static object ExecuteSQLScaler(string pQuery)
    {
        m_cmd.CommandText = pQuery;
        return m_cmd.ExecuteScalar();

    }


    public static DataTable ToTable(this Tables en)
    {
        return gvarModDataset.Tables[en.ToString()];
    }
    //Refresh a table
    public static void RefreshTable(this Tables p_Table)
    {
        string query = string.Format("select * from {0}", p_Table.ToString());
        DataTable dtTemp = ExecuteSQL(query, p_Table.ToString());
        DataTable dtRemove = p_Table.ToTable();
        gvarModDataset.Tables.Remove(p_Table.ToString());
        gvarModDataset.Tables.Add(dtTemp);
        dtRemove.Rows.Clear();
        dtRemove.Dispose();
    }

    public static DataTable ToTable(this DataRow row)
    {
        DataTable dt = row.Table.Clone();
        dt.Rows.Add(row.ItemArray);
        return dt;
    }

    public static DataTable ToTable(this DataRow[] rows)
    {
        if (rows.Length == 0)
            return null;
        DataTable dt = rows[0].Table.Clone();
        foreach (DataRow row in rows)
            dt.Rows.Add(row.ItemArray);
        return dt;
    }
    public static DataTable ToTable(this DataRowCollection rows)
    {
        if (rows.Count == 0)
            return null;

        DataTable dt = rows[0].Table.Clone();
        foreach (DataRow row in rows)
            dt.Rows.Add(row.ItemArray);
        return dt;
    }
    public static void ExecuteSQLQuery(string pSQL)
    {
        m_cmd.CommandText = pSQL;
        m_cmd.ExecuteNonQuery();
    }
    //load entire database
    public static void LoadEntireDatabase()
    {
        gvarModDataset.Clear();

        if (gvarModDataset.Tables.Count > 0)
        {
            while (gvarModDataset.Tables.Count > 0)
            {
                gvarModDataset.Tables.Remove(gvarModDataset.Tables[0]);

            }
        }
        foreach (Tables enTable in Enum.GetValues(typeof(Tables)))
        {
            LoadATable(enTable);

        }
        foreach (DataTable tbTemp in gvarModDataset.Tables)
            tbTemp.CaseSensitive = false;
    }
    //Load a table in the dataset
    public static void LoadATable(Tables p_Table, string pWhereClause = "")
    {
        //m_cmd.CommandType = CommandType.TableDirect
        gvarModDataset.Tables.Add(ExecuteSQL("select * from " + p_Table.ToString() + (string.IsNullOrEmpty(pWhereClause) ? "" : " Where " + pWhereClause), p_Table.ToString()));

    }
    public static void Remove(this DataRow[] rows)
    {
        foreach (DataRow row in rows)
            row.Table.Rows.Remove(row);
    }
}


