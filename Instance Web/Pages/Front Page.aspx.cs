using System;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web.UI;

namespace Instance_Web.Pages {
    public partial class FrontPage : Page {
        protected void Page_Load(object sender, EventArgs e) {
        }

        // Extracts fields and inserts to SQL table
        protected void create_account_Click(object sender, EventArgs e) {
            // Connection string for SQL connection
            var connectionString = @"Data Source=80.198.77.171,1337; Initial Catalog=Instance; User Id = InstanceLogin; Password = password";

            // If usernames exists, shows error
            if (DoesExist(username.Text)) {
                MessageBox("Username is taken.");
            }
            else {
                try {
                    // SQL Connection
                    using (var con = new SqlConnection(connectionString)) {
                        // SQL Command, inserts username, password, title and online status via connection named con
                        var command = new SqlCommand("INSERT INTO logins values(@username,@password,@title,default)", con);
                        command.Parameters.AddWithValue("@username", username.Text);
                        command.Parameters.AddWithValue("@password", HashThis(password.Text));
                        command.Parameters.AddWithValue("@title", title.Text);
                        con.Open();

                        // Executes SQL Command named command
                        command.ExecuteNonQuery();
                    }
                }
                    // If connection cannot be established, show error
                catch (Exception) {
                    MessageBox("Connection refused");
                }
            }

            // Empties all fields
            username.Text = null;
            title.Text = null;
            password.Text = null;

            // Informs user that account is created
            MessageBox("Account successfully created.");
        }


        // Hashes Password and returns hash value
        private static string HashThis(string pass) {
            // Generates SHA1
            using (var sha1 = new SHA1Managed()) {
                var hash = sha1.ComputeHash(Encoding.UTF8.GetBytes(pass));
                var sb = new StringBuilder(hash.Length*2);

                foreach (var b in hash) {
                    sb.Append(b.ToString("X2"));
                }

                // Returns hash value
                return sb.ToString();
            }
        }

        // Function for displaying message boxes in JS
        protected void MessageBox(string str) {
            Page.ClientScript.RegisterStartupScript(GetType(), "scriptkey", "<script>alert('" + str + "');</script>");
        }


        // Returns all usernames
        protected bool DoesExist(string str) {
            // Connection string for SQL connection
            var connectionString = @"Data Source=80.198.77.171,1337; Initial Catalog=Instance; User Id = InstanceLogin; Password = password";

            // Connection establishment
            using (var con = new SqlConnection(connectionString)) {
                // Creates datatable
                var dt = new DataTable();
                con.Open();

                // SQL statement
                var command = new SqlCommand("select * from logins", con);

                // Creates datareader from SQL command
                var dr = command.ExecuteReader();
                dt.Load(dr);

                // Functions as foreach using LINQ expression
                return dt.Rows.Cast<DataRow>().Any(row => row.Field<string>("usernames") == str);
            }
        }
    }
}