using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using ServoReportServices.Common;
using System.Data;
using TrackingServices;
using System.Data.SqlClient;

namespace ServoReportServices
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    public class Service1 : IService1
    {
        public string GetData(int value)
        {
            return string.Format("You entered: {0}", value);
        }

        public CompositeType GetDataUsingDataContract(CompositeType composite)
        {
            if (composite == null)
            {
                throw new ArgumentNullException("composite");
            }
            if (composite.BoolValue)
            {
                composite.StringValue += "Suffix";
            }
            return composite;
        }

        SqlConnection con;
        SqlCommand cmd;
        SqlDataAdapter adapt;

        public List<PrimarySecReport> Get_PrimarySecReport(string Year)
        {
            try
            {
                DataSet ds = new DataSet();
                con = new SqlConnection("Data Source = IDTP362;Initial Catalog = ServoNew; User ID = sa; Password=synerzip");
                cmd = new SqlCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "ProGetPrimarySecSalesReportGP";
                cmd.Connection = con;

                cmd.Parameters.Add(new SqlParameter("@Year", SqlDbType.VarChar, 20)).Value = Year + "-04-01";
                adapt = new SqlDataAdapter();
                adapt.SelectCommand = cmd;
                adapt.Fill(ds);

                List<PrimarySecReport> Get_PrimarySecReport = new List<PrimarySecReport>();

                DataTable table1 = ds.Tables[0];

                Get_PrimarySecReport = (from DataRow dr in table1.Rows
                                        select new PrimarySecReport()
                                        {
                                            MainCategory = Convert.ToString(dr["MainCategory"]),
                                            SubCategory = Convert.ToString(dr["SubCategory"]),
                                            April = Convert.ToString(dr["April"]),
                                            August = Convert.ToString(dr["August"]),
                                            December = Convert.ToString(dr["December"]),
                                            February = Convert.ToString(dr["February"]),
                                            January = Convert.ToString(dr["January"]),
                                            July = Convert.ToString(dr["July"]),
                                            June = Convert.ToString(dr["June"]),
                                            March = Convert.ToString(dr["March"]),
                                            May = Convert.ToString(dr["May"]),
                                            November = Convert.ToString(dr["November"]),
                                            October = Convert.ToString(dr["October"]),
                                            September = Convert.ToString(dr["September"]),
                                            Total = Convert.ToString(dr["Total"]),
                                        }).ToList();
                return Get_PrimarySecReport;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return null;
            }
            finally
            {
                con.Close();
            }
        }

        public List<SSRIncentiveGroup> Get_SSRIncentiveReport(string FrDt, string ToDt)
        {
            try
            {
                DataSet ds = new DataSet();
                con = new SqlConnection("Data Source = IDTP362;Initial Catalog = ServoNew; User ID = sa; Password=synerzip");
                cmd = new SqlCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "ProSSRIncentiveReportGP";
                cmd.Connection = con;

                cmd.Parameters.Add(new SqlParameter("@FrDt", SqlDbType.VarChar, 20)).Value = FrDt;
                cmd.Parameters.Add(new SqlParameter("@ToDt", SqlDbType.VarChar, 20)).Value = ToDt;
                adapt = new SqlDataAdapter();
                adapt.SelectCommand = cmd;
                adapt.Fill(ds);

                List<SSRIncentiveGroup> Get_SSRIncentiveReport = new List<SSRIncentiveGroup>();

                for (int K = 0; K < ds.Tables.Count; K++)
                {
                    DataTable dt2 = new DataTable();
                    for (int i = 0; i <= ds.Tables[K].Rows.Count; i++)
                    {
                        dt2.Columns.Add();
                    }
                    for (int i = 0; i < ds.Tables[K].Columns.Count; i++)
                    {
                        dt2.Rows.Add();
                        dt2.Rows[i][0] = ds.Tables[K].Columns[i].ColumnName;
                    }
                    for (int i = 0; i < ds.Tables[K].Columns.Count; i++)
                    {
                        for (int j = 0; j < ds.Tables[K].Rows.Count; j++)
                        {
                            dt2.Rows[i][j + 1] = ds.Tables[K].Rows[j][i];
                        }
                    }


                    Get_SSRIncentiveReport.Add(new SSRIncentiveGroup
                    {
                        Receipt = Convert.ToString(dt2.Rows[1][1].ToString()),
                        Cash_Discount = Convert.ToString(dt2.Rows[1][2].ToString()),
                        Spacial_Discount = Convert.ToString(dt2.Rows[1][3].ToString()),
                        Credit_Note = Convert.ToString(dt2.Rows[1][4].ToString()),
                        Cheque_Bounce = Convert.ToString(dt2.Rows[1][5].ToString()),
                        Total_Receipts = Convert.ToString(dt2.Rows[1][6].ToString()),
                        Total_Incentive = Convert.ToString(dt2.Rows[1][7].ToString()),
                        Basic_Salary = Convert.ToString(dt2.Rows[1][8].ToString()),
                        Salary_Incentive = Convert.ToString(dt2.Rows[1][9].ToString()),

                        EmpCode = Convert.ToString(dt2.Rows[2][1].ToString()),
                        EmpName = Convert.ToString(dt2.Rows[3][1].ToString()),
                        FromDate = Convert.ToString(dt2.Rows[4][1].ToString()),
                        ToDate = Convert.ToString(dt2.Rows[5][1].ToString()),
                    });

                }

                return Get_SSRIncentiveReport;

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return null;
            }
            finally
            {
                con.Close();
            }
        }

        public string Get_UserID(string Username, string Password, string Role)
        {
            string Query = "Select UserID from User_Master um, Roles r Where um.role_ID = r.role_ID And LoginName = '" + Username + "' And Password = '" + Password + "' And r.Role_ID = (Select Role_ID From Roles Where Role_Name = '" + Role + "')";
            DBClient db = new DBClient();
            object obj = db.ExecuteScalar(Query);
            if (obj == null)
                return "0";
            else
                return db.ExecuteScalar(Query).ToString();
        }

        public string Get_UserID(string Username, string Password, string Role, string type)
        {
            throw new NotImplementedException();
        }
    }
}
