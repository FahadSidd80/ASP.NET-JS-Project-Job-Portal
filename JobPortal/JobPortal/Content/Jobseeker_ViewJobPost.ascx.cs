using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Drawing;
using System.IO;

namespace JobPortal.Content
{
    public partial class Jobseeker_ViewJobPost : System.Web.UI.UserControl
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["job_portal"].ConnectionString);

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                GetJobProfile();
                GetGridJobPost();
                GetCompanyName();
            }
        }

        public void GetJobProfile()
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("sp_tblJobprofile", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@action", "GETJOBPROFILE");
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            con.Close();
            ddljobprofile.DataValueField = "jobprofileid";
            ddljobprofile.DataTextField = "jobprofilename";
            ddljobprofile.DataSource = dt;
            ddljobprofile.DataBind();
            ddljobprofile.Items.Insert(0, new ListItem("--Select--", "0"));
        }

        public void GetCompanyName()
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("sp_tblRecruiter", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@action", "GETFILTERCOMPANY");
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            con.Close();
            ddlcompanyname.DataValueField = "recruiterid";
            ddlcompanyname.DataTextField = "recruitername";
            ddlcompanyname.DataSource = dt;
            ddlcompanyname.DataBind();
            ddlcompanyname.Items.Insert(0, new ListItem("--Select--", "0"));
        }

        public void GetGridJobPost()
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("sp_tblJobPostRecruiter", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@action", "GETALLJOBPOSTBYRECRUITER");
            //cmd.Parameters.AddWithValue("@recruiterid", Session["recruiterid"]);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            con.Close();
            grdjobpostget.DataSource = dt;
            grdjobpostget.DataBind();
        }

        protected void grdjobpostget_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Aply")
            {
                Response.Redirect("EmailToRecruiter.aspx");
            }
        }

        protected void btnsearch_Click(object sender, EventArgs e)
        { 
            GetSearchSkill();
        }

        public void GetSearchSkill()
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("sp_tblJobPostRecruiter", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@action", "SEARCHFILTERJOB");
            cmd.Parameters.AddWithValue("@jobprofileid", ddljobprofile.SelectedValue);
            cmd.Parameters.AddWithValue("@recruiterid", ddlcompanyname.SelectedValue);
            cmd.Parameters.AddWithValue("@usersalary", txtusersalary.Text);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            con.Close();
            grdjobpostget.DataSource = dt;
            grdjobpostget.DataBind();
            if (dt.Rows.Count > 0)
            {
                lblrecruitermsg.Text = "";
                //lblmsg.Visible = false;

            }
            if (dt.Rows.Count == 0)
            {
                lblrecruitermsg.Text = "No record found...!!";
                lblrecruitermsg.ForeColor = Color.Red;
            }
        }
        protected void btnrefresh_Click(object sender, EventArgs e)
        {
            GetGridJobPost();
            lblrecruitermsg.Text = "";
            ddljobprofile.SelectedValue = "0";
            ddlcompanyname.SelectedValue = "0";
            txtusersalary.Text = "";
           
        }
    }
}