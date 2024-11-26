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
    public partial class Studentreg : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection(@"server=LAPTOP-APGQFLB4\SQLEXPRESS;database=estrrado;integrated security=true");
        Class1 obj = new Class1();
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void Button2_Click(object sender, EventArgs e)
        {

            string ins = "insert into Student_reg values('" + TextBox1.Text + "','" + TextBox2.Text + "'," + TextBox3.Text + ",'" + TextBox4.Text + "','" + TextBox5.Text + "','" + TextBox6.Text + "','" + TextBox7.Text + "','" + TextBox8.Text + "','" + TextBox9.Text + "')";
            SqlCommand cmd = new SqlCommand(ins, con);
            con.Open();
            int i = cmd.ExecuteNonQuery();
            con.Close();
            if (i == 1)
            {
                Label16.Text = "Registered Successfully";
            }

            string ine = "insert into Qual values('" + Session["Student_id"] + "','" + TextBox10.Text + "','" + TextBox11.Text + "'," + TextBox12.Text + "," + TextBox13.Text + ")";
            con.Open();
            int n = obj.Fun_exenonquery(ine);
            con.Close();
            Response.Redirect("Profile.aspx");
        }
        protected void Button1_Click(object sender, EventArgs e)
        {
            //string course = TextBox10.Text.Replace("'", "''");
            //string university = TextBox11.Text.Replace("'", "''");
            //int year = Convert.ToInt32(TextBox12.Text);
            //decimal percentage = Convert.ToDecimal(TextBox13.Text);
            //int studentId = Convert.ToInt32(Session["StudentId"]);

            //string ine1 = "insert into Qual values(" + studentId + ",'" + course + "','" + university + "'," + year + "," + percentage + ")";
            //con.Open();
            //int m = obj.Fun_exenonquery(ine1);
            //con.Close();
            TextBox10.Text = "";
            TextBox11.Text = "";
            TextBox12.Text = "";
            TextBox13.Text = "";

        }
    }
}