using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Instance_Web.Pages {
    public partial class FrontPage : Page {
        protected void Page_Load(object sender, EventArgs e) {

        }

        protected void create_account_Click(object sender, EventArgs e) {
            string connectionString = @"Data Source=80.198.77.171,1337; Initial Catalog=Instance; User Id = InstanceLogin; Password = password";

            if (DoesExist(username.Text)) {
                MessageBox("Username is taken.");
            }
            else {
                try {
                    using (SqlConnection con = new SqlConnection(connectionString))
                    {
                        SqlCommand command = new SqlCommand("INSERT INTO logins(usernames,passwords) values(@username,@password)", con);
                        command.Parameters.AddWithValue("@username", username.Text);
                        command.Parameters.AddWithValue("@password", HashThis(password.Text));
                        con.Open();

                        command.ExecuteNonQuery();
                    }
                }
                catch (Exception) {
                    MessageBox("Connection refused");
                }
            }

            username.Text = null;
            password.Text = null;
            MessageBox("Account successfully created.");
        }

        private string HashThis(string pass) {
            using (SHA1Managed sha1 = new SHA1Managed()) {
                var hash = sha1.ComputeHash(Encoding.UTF8.GetBytes(pass));
                var sb = new StringBuilder(hash.Length*2);

                foreach (byte b in hash) {
                    sb.Append(b.ToString("X2"));
                }

                return sb.ToString();
            }
        }

        protected void MessageBox(string str) {
            Page.ClientScript.RegisterStartupScript(GetType(), "scriptkey", "<script>alert('"+ str +"');</script>");
        }

        protected bool DoesExist (string str) {

            string connectionString = @"Data Source=80.198.77.171,1337; Initial Catalog=Instance; User Id = InstanceLogin; Password = password";

            using (SqlConnection con = new SqlConnection(connectionString)) {
                DataTable dt = new DataTable();
                con.Open();

                var command = new SqlCommand("select * from logins", con);
                SqlDataReader dr = command.ExecuteReader();
                dt.Load(dr);

                return dt.Rows.Cast<DataRow>().Any(row => row.Field<string>("usernames") == str);
            }
        }
    }
}