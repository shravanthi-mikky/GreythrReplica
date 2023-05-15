using CommonLayer.Model;
using Microsoft.Extensions.Configuration;
using RepositoryLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace RepositoryLayer.Services
{
    public class UserRL : IUserRL
    {
        SqlConnection sqlConnection;

        SqlDataReader reader;



        public UserRL(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public ProfileModel UserLogin(LoginModel loginModel)
        {
            sqlConnection = new SqlConnection(this.Configuration.GetConnectionString("greythrDb"));
            using (sqlConnection)
            {
                try
                {
                    SqlCommand command = new SqlCommand("SP_Login", sqlConnection);
                    command.CommandType = System.Data.CommandType.StoredProcedure;


                    sqlConnection.Open();
                    command.Parameters.AddWithValue("@EmployeeID", loginModel.EmployeeID);
                    command.Parameters.AddWithValue("@Password", loginModel.Password);

                    var result = command.ExecuteScalar();
                    if (result != null)
                    {
                        string query = "SELECT * FROM Profile WHERE EmployeeID = '" + loginModel.EmployeeID + "'";
                        SqlCommand cmd = new SqlCommand(query, sqlConnection);
                        reader = cmd.ExecuteReader();
                        ProfileModel employeeemodel = new ProfileModel();
                        while (reader.Read())
                        {
                            employeeemodel.EmployeeID = Convert.ToInt32(reader["EmployeeID"]);
                            employeeemodel.Name = reader["Name"].ToString();
                            employeeemodel.Location = reader["Location"].ToString();
                            employeeemodel.PrimaryContact = Convert.ToInt32(reader["PrimaryContact"]);
                            employeeemodel.CompanyEmail = reader["CompanyEmail"].ToString();
                            employeeemodel.Password = reader["Password"].ToString();
                           

                        }
                        return employeeemodel;
                    }
                    else
                    {
                        return null;
                    }
                }
                catch (Exception e)
                {
                    throw new Exception(e.Message);
                }
                finally
                {
                    sqlConnection.Close();
                }

            }
        }

    }
}
