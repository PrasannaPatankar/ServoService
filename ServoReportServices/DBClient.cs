using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace TrackingServices
{
    public class DBClient:IDisposable
    {

        //string ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
        //        string ConnectionString = "Data Source = CMSCS\\SQLEXPRESS;Initial Catalog = Kai.las; User ID = sa; Password=cms";
        string ConnectionString = "Data Source = IDTP362;Initial Catalog = ServoNew; User ID = sa; Password=synerzip";
        //string ConnectionString = "Data Source = ULTP_686\\CMS;Initial Catalog = Pavey; User ID = sa; Password=synerzip123";

        SqlConnection con;


        public void OpenConection()
        {
            con = new SqlConnection(ConnectionString);
            con.Open();
        }

        public DBClient()
        {
            con = new SqlConnection(ConnectionString);
            con.Open();
        }


        public void CloseConnection()
        {
            con.Close();
        }


        public void ExecuteQueries(string Query_)
        {
            SqlCommand cmd = new SqlCommand(Query_, con);
            cmd.ExecuteNonQuery();
        }


        public SqlDataReader DataReader(string Query_)
        {
            SqlCommand cmd = new SqlCommand(Query_, con);
            SqlDataReader dr = cmd.ExecuteReader();
            return dr;
        }


        public object ShowDataInGridView(string Query_)
        {
            SqlDataAdapter dr = new SqlDataAdapter(Query_, ConnectionString);
            DataSet ds = new DataSet();
            dr.Fill(ds);
            object dataum = ds.Tables[0];
            return dataum;
        }

        public DataSet GetDataSet(string Query_)
        {
            SqlDataAdapter dr = new SqlDataAdapter(Query_, ConnectionString);
            DataSet ds = new DataSet();
            return ds;
        }


        public DataTable GetDataTable(string Query_)
        {
            SqlDataAdapter dr = new SqlDataAdapter(Query_, ConnectionString);
            DataSet ds = new DataSet();
            dr.Fill(ds);
            DataTable dataum = ds.Tables[0];
            dataum.TableName = "ResultTable";
            return dataum;
        }

        public void Dispose()
        {
            try
            {
                if (con != null)
                {
                    con.Close();
                }

            }
            catch (Exception)
            {

                throw;
            }
           

        }
    }
}