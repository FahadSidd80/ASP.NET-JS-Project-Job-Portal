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
    public partial class ManageCity : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["job_portal"].ConnectionString);
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                GetCountry();
                ddlstate.Enabled = false;
                ddlstate.Items.Insert(0, new ListItem("--Select--", "0"));
            }
        }
        public void GetCountry()
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("sp_tblCountry", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@action", "GETCOUNTRY");
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            con.Close();
            ddlcountry.DataValueField = "countryid";
            ddlcountry.DataTextField = "countryname";
            ddlcountry.DataSource = dt;
            ddlcountry.DataBind();
            ddlcountry.Items.Insert(0, new ListItem("--Select--", "0"));
        }
        public void GetState()
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("sp_tblState", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@action", "GETSTATE");
            cmd.Parameters.AddWithValue("@countryid", ddlcountry.SelectedValue);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            con.Close();
            ddlstate.Enabled = true;
            ddlstate.DataValueField = "stateid";
            ddlstate.DataTextField = "statename";
            ddlstate.DataSource = dt;
            ddlstate.DataBind();
            ddlstate.Items.Insert(0, new ListItem("--Select--", "0"));
        }

        protected void btnsave_City_Click(object sender, EventArgs e)
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("sp_tblCity", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@action", "INSERT");
            cmd.Parameters.AddWithValue("@countryid", ddlcountry.SelectedValue);
            cmd.Parameters.AddWithValue("@stateid", ddlstate.SelectedValue);
            cmd.Parameters.AddWithValue("@cityname", txtcity.Text);
            cmd.ExecuteNonQuery();
            con.Close();
        }

        protected void ddlcountry_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlcountry.SelectedValue=="0")
            {
                ddlstate.Enabled = false;
                ddlstate.SelectedValue = "0";
            }
            else
            {
                GetState(); 
            }
        }
    }
}