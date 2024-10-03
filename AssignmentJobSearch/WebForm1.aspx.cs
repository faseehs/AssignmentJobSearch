using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

namespace AssignmentJobSearch
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection(@"server=DESKTOP-BV868UE\SQLEXPRESS01;database=Luminar;Integrated Security=True");
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string str = "";
            if(!string.IsNullOrWhiteSpace(TextBox1.Text))
            {
                str += "where Company_Name like '%" + TextBox1.Text + "%'";
                if(!string.IsNullOrWhiteSpace(TextBox2.Text))
                {
                    str += " and Skills like '%" + TextBox2.Text + "%'";
                    if(!string.IsNullOrWhiteSpace(TextBox3.Text))
                    {
                        str += " and Experience like '%" + TextBox3.Text + "%'";
                    }
                }
                else if(!string.IsNullOrWhiteSpace(TextBox3.Text))
                {
                    str += " and Experience like '%" + TextBox3.Text + "%'";
                }
            }
            else if (!string.IsNullOrWhiteSpace(TextBox2.Text))
            {
                str += " where Skills like '%" + TextBox2.Text + "%'";
                if (!string.IsNullOrWhiteSpace(TextBox3.Text))
                {
                    str += " and Experience like '%" + TextBox3.Text + "%'";
                }
            }
            else if (!string.IsNullOrWhiteSpace(TextBox3.Text))
            {
                str += " where Experience like '%" + TextBox3.Text + "%'";
            }
            string s = "select * from JobSearch " + str;
            SqlDataAdapter da = new SqlDataAdapter(s, con);
            DataSet ds = new DataSet();
            da.Fill(ds);
            GridView1.DataSource = ds;
            GridView1.DataBind();
        }
    }
}