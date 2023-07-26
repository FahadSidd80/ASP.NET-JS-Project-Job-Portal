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

namespace JobPortal
{
    public partial class Recruiter_ManageJobPost : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["job_portal"].ConnectionString);

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                GetJobProfile();
                GetGridJobPost();
                
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
        public void GetGridJobPost()
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("sp_tblJobPostRecruiter", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@action", "GETJOB");
            cmd.Parameters.AddWithValue("@recruiterid", Session["recruiterid"]);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            con.Close();
            grdjobpostget.DataSource = dt;
            grdjobpostget.DataBind();
        }

        protected void btnsearch_Click(object sender, EventArgs e)
        {
            if (ddljobprofile.SelectedValue == "0")
            {
                lblmsg.Text = "please select job title...";
                lblmsg.ForeColor = Color.Red;
                GetGridJobPost();
            }
            else
            {
                GetSearchSkill();
            }
          
        }
        public void GetSearchSkill()
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("sp_tblJobPostRecruiter", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@action", "SEARCHJOB");
            cmd.Parameters.AddWithValue("@jobprofileid", ddljobprofile.SelectedValue);
            cmd.Parameters.AddWithValue("@recruiterid", Session["recruiterid"]);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            con.Close();
            grdjobpostget.DataSource = dt;
            grdjobpostget.DataBind();
            if (dt.Rows.Count > 0)
            {
                lblmsg.Text = "";
                //lblmsg.Visible = false;

            }
            if (dt.Rows.Count == 0)
            {
                lblmsg.Text = "No record found...!!";
                lblmsg.ForeColor = Color.Red;
            }

        }

        protected void btnrefresh_Click(object sender, EventArgs e)
        {
            //Response.Redirect("Recruiter_ManageJobPost.aspx");
            GetGridJobPost();
            lblmsg.Text = "";
            ddljobprofile.SelectedValue = "0";
        }

        protected void grdjobpostget_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName=="Del")
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("sp_tblJobPostRecruiter", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@action", "DELETEJOB");
                cmd.Parameters.AddWithValue("@jobid", e.CommandArgument);
                cmd.ExecuteNonQuery();
                con.Close();
                GetGridJobPost();
            }
            else if (e.CommandName == "Edt")
            {
                //Response.Redirect("Recruiter_AddJobPost.aspx?Qs='"+e.CommandArgument+"'");
                Response.Redirect("Recruiter_AddJobPost.aspx?Qs=" + e.CommandArgument ); 
            }
            
        }
    }
}