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
    public partial class Login : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection(@"server=LAPTOP-APGQFLB4\SQLEXPRESS;database=estrrado;integrated security=true");
        Class1 obj = new Class1();

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            try
            {
                
                string s = "SELECT COUNT(Student_id) FROM Student_reg WHERE Username ='" + TextBox1.Text + "' AND Password='" + TextBox2.Text + "'";
                SqlCommand cmd = new SqlCommand(s, con);
                con.Open();
                int count = Convert.ToInt32(cmd.ExecuteScalar());
                con.Close();

                if (count == 1) 
                {
                    string se = "SELECT Student_id FROM Student_reg WHERE Username ='" + TextBox1.Text + "' AND Password='" + TextBox2.Text + "'";
                    SqlCommand cmd1 = new SqlCommand(se, con);
                    con.Open();
                    string id = cmd1.ExecuteScalar().ToString();
                    con.Close();
                    Session["Student_id"] = id; 
                    Response.Redirect("Profile.aspx");
                }
                else 
                {
                    Label4.Text = "Invalid Username and Password";
                }
            }
            catch (Exception ex)
            {
                Label4.Text = "An error occurred: " + ex.Message;
            }
            finally
            {
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }
            }
        }
    }
    }

    
