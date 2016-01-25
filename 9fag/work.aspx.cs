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
using System.IO;

namespace _9fag
{
    public partial class work : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string pic_id = Request.QueryString["id"];

            if(pic_id == null)
            {
                Response.Redirect("favourite.aspx");
            }


            string constr = ConfigurationManager.ConnectionStrings["baza"].ConnectionString;

            using (MySqlConnection con = new MySqlConnection(constr))
            {
                using (MySqlCommand cmd = new MySqlCommand("DELETE FROM uploads WHERE upload_pic_id=@id"))
                {
                    using (MySqlDataAdapter sda = new MySqlDataAdapter())
                    {
                        cmd.Parameters.AddWithValue("@id", pic_id);
                        cmd.Connection = con;
                        con.Open();
                        cmd.ExecuteNonQuery();
                        con.Close();
                        File.Delete(Server.MapPath("upload" + "//" + pic_id + ".png"));
                        Response.Redirect("favourite.aspx");
                    }
                }
            }
        }
    }
}