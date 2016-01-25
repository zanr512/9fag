using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Xml;
using System.Text;
using MySql.Data.MySqlClient;
using System.Windows;
using System.Configuration;

namespace _9fag
{
    public partial class favourite : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["username"] == null)
            {
                Response.Redirect("index.aspx");
            }
            string email = Convert.ToString(Session["username"]);

            label_user.Text = email;


            string constr = ConfigurationManager.ConnectionStrings["baza"].ConnectionString;

            using (MySqlConnection con = new MySqlConnection(constr))
            {
                using (MySqlCommand cmd = new MySqlCommand("SELECT * FROM uploads WHERE upload_user_id=@id"))
                {
                    using (MySqlDataAdapter sda = new MySqlDataAdapter())
                    {
                        cmd.Parameters.AddWithValue("@id", Session["user_id"]);
                        cmd.Connection = con;
                        con.Open();
                        DataTable dt = new DataTable();
                        sda.SelectCommand = cmd;
                        sda.Fill(dt);
                        DataList1.DataSource = dt;
                        DataList1.DataBind();
                        con.Close();

                    }
                }
            }

        }
    }
}