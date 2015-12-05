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
            string _connectionString = @"Data Source=80.198.77.171,1337; Initial Catalog=Instance; User Id = InstanceLogin; Password = password";

            if (DoesExist(username.Text)) {
                MessageBox("Username is taken.");
            }
            else {
                try {
                    using (SqlConnection _con = new SqlConnection(_connectionString))
                    {
                        SqlCommand _command = new SqlCommand("INSERT INTO logins(usernames,passwords) values(@username,@password)", _con);
                        _command.Parameters.AddWithValue("@username", username.Text);
                        _command.Parameters.AddWithValue("@password", HashThis(password.Text));
                        _con.Open();

                        _command.ExecuteNonQuery();
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

        private string HashThis(string _pass) {
            using (SHA1Managed sha1 = new SHA1Managed()) {
                var _hash = sha1.ComputeHash(Encoding.UTF8.GetBytes(_pass));
                var _sb = new StringBuilder(_hash.Length*2);

                foreach (byte b in _hash) {
                    _sb.Append(b.ToString("X2"));
                }

                return _sb.ToString();
            }
        }

        protected void MessageBox(string _str) {
            Page.ClientScript.RegisterStartupScript(GetType(), "scriptkey", "<script>alert('"+ _str +"');</script>");
        }

        protected bool DoesExist (string _str) {

            string _connectionString = @"Data Source=80.198.77.171,1337; Initial Catalog=Instance; User Id = InstanceLogin; Password = password";

            using (SqlConnection _con = new SqlConnection(_connectionString)) {
                DataTable _dt = new DataTable();
                _con.Open();

                var _command = new SqlCommand("select * from logins", _con);
                SqlDataReader _dr = _command.ExecuteReader();
                _dt.Load(_dr);

                return _dt.Rows.Cast<DataRow>().Any(row => row.Field<string>("usernames") == _str);
            }
        }
    }
}