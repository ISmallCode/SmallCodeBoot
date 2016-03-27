using SmallCodeBoot.Extendsions;
using SmallCodeBoot.Helpers;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace SmallCodeBoot.Models
{
    public class SmallCodeContext : DbContext
    {
        public readonly string connStr = ConfigurationHelper.GetConnectionValue("sqlserverdb");

        public SmallCodeContext() : base("name=sqlserverdb")
        {
        }

        public DbSet<User> Users { set; get; }

        public DbSet<Log> Logs { set; get; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }

        /// <summary>
        /// 执行SQL
        /// </summary>
        /// <param name="contxt"></param>
        /// <param name="cmdText"></param>
        /// <param name="Paramers"></param>
        /// <returns></returns>
        public DataSet ExecuteDataSet(string cmdText, params object[] Paramers)
        {
            using (SqlConnection con = new SqlConnection(connStr))
            {
                DateTime beginTime = DateTime.Now;
                SqlCommand cmd = new SqlCommand(cmdText, con);

                for (int i = 0; Paramers != null && i < Paramers.Length; i++)
                {
                    cmd.Parameters.Add(new SqlParameter(string.Format("@P{0}", i.ToString()), Paramers[i] == null ? DBNull.Value : Paramers[i]));
                }

                SqlDataAdapter adapter = new SqlDataAdapter(cmd);

                DataSet result = new DataSet();

                adapter.Fill(result);
                DateTime endTime = DateTime.Now;

                return result;

            }
        }

        /// <summary>
        /// 执行SQL
        /// </summary>
        /// <param name="contxt"></param>
        /// <param name="cmdText"></param>
        /// <param name="tableIndex"></param>
        /// <param name="Paramers"></param>
        /// <returns></returns>
        public DataTable ExecuteDataTable(string cmdText, int tableIndex = 0, params object[] Paramers)
        {
            using (SqlConnection con = new SqlConnection(connStr))
            {
                DateTime beginTime = DateTime.Now;
                SqlCommand cmd = new SqlCommand(cmdText, con);

                for (int i = 0; Paramers != null && i < Paramers.Length; i++)
                {
                    cmd.Parameters.Add(new SqlParameter(string.Format("@P{0}", i.ToString()), Paramers[i] == null ? DBNull.Value : Paramers[i]));
                }
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);

                DataSet result = new DataSet();

                adapter.Fill(result);

                if (result != null && result.Tables.Count > tableIndex)
                {
                    return result.Tables[tableIndex];
                }
                DateTime endTime = DateTime.Now;

                return null;
            }
        }

        /// <summary>
        /// 执行SQL
        /// </summary>
        /// <param name="contxt"></param>
        /// <param name="cmdText"></param>
        /// <param name="tableIndex"></param>
        /// <param name="Paramers"></param>
        /// <returns></returns>
        public DataTable ExecuteDataTable(string cmdText, params object[] Paramers)
        {
            using (SqlConnection con = new SqlConnection(connStr))
            {
                DateTime beginTime = DateTime.Now;
                SqlCommand cmd = new SqlCommand(cmdText, con);

                for (int i = 0; Paramers != null && i < Paramers.Length; i++)
                {
                    cmd.Parameters.Add(new SqlParameter(string.Format("@P{0}", i.ToString()), Paramers[i] == null ? DBNull.Value : Paramers[i]));
                }

                SqlDataAdapter adapter = new SqlDataAdapter(cmd);

                DataTable result = new DataTable();

                adapter.Fill(result);
                DateTime endTime = DateTime.Now;

                return result;
            }
        }

        /// <summary>
        /// 执行SQL
        /// </summary>
        /// <param name="contxt"></param>
        /// <param name="cmdText"></param>
        /// <param name="tableIndex"></param>
        /// <param name="Paramers"></param>
        /// <returns></returns>
        public DataTable ExecuteDataTableForPager(string cmdText, ref int totalRecords, params object[] Paramers)
        {
            using (SqlConnection con = new SqlConnection(connStr))
            {
                DateTime beginTime = DateTime.Now;
                SqlCommand cmd = new SqlCommand(cmdText, con);

                for (int i = 0; Paramers != null && i < Paramers.Length; i++)
                {
                    cmd.Parameters.Add(new SqlParameter(string.Format("@P{0}", i.ToString()), Paramers[i] == null ? DBNull.Value : Paramers[i]));
                }

                SqlDataAdapter adapter = new SqlDataAdapter(cmd);

                DataSet result = new DataSet();

                adapter.Fill(result);

                if (result == null || result.Tables.Count != 2)
                {
                    return new DataTable();
                }

                totalRecords = result.Tables[0].Rows[0][0].ToString().ToInt32();
                DateTime endTime = DateTime.Now;

                return result.Tables[1];
            }
        }

        /// <summary>
        /// 执行SQL 重载ExecuteDataTableForPager  
        /// </summary>
        /// <param name="contxt"></param>
        /// <param name="cmdText"></param>
        /// <param name="tableIndex"></param>
        /// <param name="Paramers"></param>
        /// <returns></returns>
        public DataTable ExecuteDataTableForPager(string cmdText, ref int totalRecords)
        {
            using (SqlConnection con = new SqlConnection(connStr))
            {
                DateTime beginTime = DateTime.Now;
                SqlCommand cmd = new SqlCommand(cmdText, con);

                SqlDataAdapter adapter = new SqlDataAdapter(cmd);

                DataSet result = new DataSet();

                adapter.Fill(result);

                if (result == null || result.Tables.Count != 2)
                {
                    return new DataTable();
                }

                totalRecords = result.Tables[0].Rows[0][0].ToString().ToInt32();
                DateTime endTime = DateTime.Now;

                return result.Tables[1];
            }
        }

        /// <summary>
        /// 执行SQL 删除数据
        /// </summary>
        /// <param name="contxt"></param>
        /// <param name="cmdText"></param>
        /// <param name="tableIndex"></param>
        /// <param name="Paramers"></param>
        /// <returns></returns>
        public int ExecuteDeleteSQl(string cmdText, string connstr, params object[] Paramers)
        {
            // string str = base.Database.Connection.ConnectionString;
            using (SqlConnection con = new SqlConnection(connstr))
            {
                DateTime beginTime = DateTime.Now;

                SqlCommand cmd = new SqlCommand(cmdText, con);

                for (int i = 0; Paramers != null && i < Paramers.Length; i++)
                {
                    cmd.Parameters.Add(new SqlParameter(string.Format("@P{0}", i.ToString()), Paramers[i] == null ? DBNull.Value : Paramers[i]));
                }

                con.Open();
                object o = cmd.ExecuteScalar();
                DateTime endTime = DateTime.Now;
                con.Close();
                return o == null ? 0 : (int)o;
            }
        }
    }
}