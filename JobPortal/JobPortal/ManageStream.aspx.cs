using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;

namespace JobPortal
{
    public partial class ManageStream : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["job_portal"].ConnectionString);
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                GetQualification();
            }
        }

        public void GetQualification()
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("sp_tblQualification", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@action", "GETQUALIFICATION");
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            con.Close();
            ddlqualification.DataValueField = "qualificationid";
            ddlqualification.DataTextField = "qualificationname";
            ddlqualification.DataSource = dt;
            ddlqualification.DataBind();
            ddlqualification.Items.Insert(0, new ListItem("--Select--", "0"));
        }
        protected void btnsave_stream_Click(object sender, EventArgs e)
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("sp_tblStream", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@action", "INSERTSTREAM");
            cmd.Parameters.AddWithValue("@qualificationid", ddlqualification.SelectedValue);
            cmd.Parameters.AddWithValue("@streamname", txtstream.Text);
            cmd.ExecuteNonQuery();
            con.Close();
        }
    }
}