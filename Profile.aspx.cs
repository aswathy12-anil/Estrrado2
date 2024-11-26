using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

namespace Estrrado
{
    public partial class Profile : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection(@"server=LAPTOP-APGQFLB4\SQLEXPRESS;database=estrrado;integrated security=true");
        Class1 obj = new Class1();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string query = @"
            SELECT 
               
                q.Course, 
                q.University, 
                q.Year, 
                q.Percentage
            FROM 
                Qual q";
                SqlDataAdapter da = new SqlDataAdapter(query, con);
                DataTable dt = new DataTable();
                da.Fill(dt);
                GridView1.DataSource = dt;
                GridView1.DataBind();
                con.Close();
            }
        }

       
        }
    }
