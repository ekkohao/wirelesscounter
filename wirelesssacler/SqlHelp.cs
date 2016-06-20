using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.Common;
using System.Text;

namespace MySqlCon
{
   public  class SqlHelp
    {
        
        private string Constr = ConfigurationManager.AppSettings["DbConnectionString"];//连接字符串
        private string path = ConfigurationManager.AppSettings["DBpath"];//连接数据库路径
       /// <summary>
       /// z直接执行sql语句
       /// </summary>
       /// <param name="sql">sql语句</param>
        public  void Insert(string sql)
        {
            if (Connectstring() == null)
            {
                Console.Write("本地没有数据库!");
            }
            else
            {
                try
                {
                    DbHelper db = new DbHelper(Connectstring());
                    DbCommand cmd = db.GetSqlStringCommand(sql);
                    db.ExecuteNonQuery(cmd);
                }
                catch
                {
                    throw;
                }
            }
        }
       /// <summary>
       /// 插入数据，并返回
       /// </summary>
       /// <param name="sql"></param>
       /// <returns></returns>
        public int Insert2(string sql)
        {
            int count = 0;
            if (Connectstring() == null)
            {
                Console.Write("本地没有数据库!");
            }
            else
            {
                try
                {
                    DbHelper db = new DbHelper(Connectstring());
                    DbCommand cmd = db.GetSqlStringCommand(sql);
                    count= db.ExecuteNonQuery(cmd);
                }
                catch
                {
                    throw;
                }
            }
            return count;
        }
       /// <summary>
       /// 直接执行sql
       /// </summary>
       /// <param name="sql"></param>
       /// <param name="path">数据库路径</param>
        public  void Insert(string sql, string path)
        {
            try
            {
                DbHelper db = new DbHelper(Constr + path);
                DbCommand cmd = db.GetSqlStringCommand(sql);
                db.ExecuteNonQuery(cmd);
            }
            catch
            {
                throw;
            }
        }
        private  string Connectstring()
        {
            if (path == "")
            {
                return null;
            }
            return Constr;//+ path;
        }
       /// <summary>
       /// 存储过程
       /// </summary>
       /// <param name="insert"></param>
       /// <param name="id"></param>
       /// <param name="type"></param>
       /// <param name="value"></param>
       public void RunProc(string insert,string @id,DbType type,Object value)
        {
            DbHelper db = new DbHelper();
            DbCommand cmd =db.GetStoredProcCommand(insert);
            db.AddInParameter(cmd,@id,type,value);
            db.ExecuteNonQuery(cmd);
        }
       /// <summary>
       /// 返回DataSet
       /// </summary>
       /// <returns></returns>
      public DataSet ReturnDataset(string sql)
       {
           DbHelper db = new DbHelper();
           DbCommand cmd = db.GetSqlStringCommand(sql);
           DataSet ds = db.ExecuteDataSet(cmd);
           return ds;
       }
       /// <summary>
       /// 返回datatable
       /// </summary>
       /// <returns></returns>
       public DataTable ReturnTable(string sql)
      {

          DbHelper db = new DbHelper();
          DbCommand cmd = db.GetSqlStringCommand(sql);
          DataTable dt = db.ExecuteDataTable(cmd);
          return dt;
      }
    }
}
