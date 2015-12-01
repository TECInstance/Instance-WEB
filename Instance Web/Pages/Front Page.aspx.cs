using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Instance_Web.Pages {
    public partial class Front_Page : System.Web.UI.Page {
        protected void Page_Load(object sender, EventArgs e) {

        }

        protected void create_account_Click(object sender, EventArgs e) {
            string connectionString = @"Data Source=80.198.77.171,1337; Initial Catalog=INSTANCESQL; Network Library = dbnmpntw; User Id = InstanceLogin; Password = password";

            using (SqlConnection con = new SqlConnection(connectionString)) {

                SqlCommand command = new SqlCommand("INSERT INTO logins(usernames,passwords) values(@username,@password)", con);
                command.Parameters.AddWithValue("@username", username.Text);
                command.Parameters.AddWithValue("@password", HashThis(password.Text));
                con.Open();

                command.ExecuteNonQuery();
            }
        }

        private string HashThis(string password) {
                using (SHA1Managed sha1 = new SHA1Managed())
                {
                    var hash = sha1.ComputeHash(Encoding.UTF8.GetBytes(password));
                    var sb = new StringBuilder(hash.Length * 2);

                    foreach (byte b in hash)
                    {
                        // can be "x2" if you want lowercase
                        sb.Append(b.ToString("X2"));
                    }

                    return sb.ToString();
            }
        }
    }
}