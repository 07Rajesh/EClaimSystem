using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace EClaimSystem.Models
{
    public class AccountDataAccess
    {
        DbConnection db = new DbConnection();
        
        public string SignUpEmployee(SignUpModel signup)
        {
            string msg = string.Empty;
            SqlCommand cmd = new SqlCommand("sp_insert_Employees",db.connection);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@FName",signup.FName);
            cmd.Parameters.AddWithValue("@LName",signup.LName);
            cmd.Parameters.AddWithValue("@Email",signup.Email);
            cmd.Parameters.AddWithValue("@Password",signup.Password);
            cmd.Parameters.AddWithValue("@Mobile",signup.Mobile);
            cmd.Parameters.AddWithValue("@EmployeeId",signup.EmployeeId);
            cmd.Parameters.AddWithValue("@Is_Active",signup.Is_Active);
            cmd.Parameters.AddWithValue("@ManagerId",signup.ManagerId);
            cmd.Parameters.AddWithValue("@ManagerId",signup.ManagerId);
            cmd.Parameters.AddWithValue("@ProfileImage",signup.ProfileImage);

            if (db.connection.State == System.Data.ConnectionState.Closed)
            {
                db.connection.Open();
            }
            cmd.ExecuteNonQuery();
            db.connection.Close();
            msg = "Record Save Successfully";
            return msg;
        }
        public int SignInEmployee(LoginModel login)
        {
            string msg = string.Empty;
            SqlCommand cmd = new SqlCommand("sp_login_empmloyee",db.connection);
            cmd.CommandType =  System.Data.CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Email",login.Email);
            cmd.Parameters.AddWithValue("@Password",login.Password);
            if (db.connection.State == System.Data.ConnectionState.Closed)
            {
                db.connection.Open();
            }
            int result = (int)cmd.ExecuteScalar();
            db.connection.Close();
            return result;
        }
        
    }
}
