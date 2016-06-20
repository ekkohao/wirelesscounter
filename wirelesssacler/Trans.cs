using System;
using System.Data.Common;


public class Trans : IDisposable
{
    private DbConnection conn=null;
    private DbTransaction dbTrans=null;
    public DbConnection DbConnection
    {
        get { return this.conn; }
    }
    public DbTransaction DbTrans
    {
        get { return this.dbTrans; }
    }


    public void Dispose()
    {
        
        
        this.Colse();
    }

    public void Colse()
    {
        if (conn.State == System.Data.ConnectionState.Open)
        {
            conn.Close();
        }
    }

}
