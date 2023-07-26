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
    public partial class Recruiter_AddJobPost : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["job_portal"].ConnectionString);

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                GetJobProfile();
                if (Request.QueryString["Qs"] != null & Request.QueryString["Qs"] != "")
                {
                    JobPostEdit();
                }
                
            }
        }

        public void JobPostEdit()
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("sp_tblJobPostRecruiter", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@action", "EDITJOB");
            cmd.Parameters.AddWithValue("@jobid", Request.QueryString["Qs"]);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            con.Close();
            ddljobprofile.SelectedValue = dt.Rows[0]["jobprofileid"].ToString();
            txtminexperience.Text = dt.Rows[0]["minexperience"].ToString();
            txtmaxexperience.Text = dt.Rows[0]["maxexperience"].ToString();
            txtminsalary.Text = dt.Rows[0]["minsalary"].ToString();
            txtmaxsalary.Text = dt.Rows[0]["maxsalary"].ToString();
            txtvacancies.Text = dt.Rows[0]["vacancies"].ToString();
            txtrecuitercomment.Text = dt.Rows[0]["comment"].ToString();
            btnsave_recruiterpost.Text = "Update";
            
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

        protected void btnsave_recruiterpost_Click(object sender, EventArgs e)
        {
            if (btnsave_recruiterpost.Text == "Save")
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("sp_tblJobPostRecruiter", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@action", "INSERTJOB");
                cmd.Parameters.AddWithValue("@recruiterid", Session["recruiterid"]);
                cmd.Parameters.AddWithValue("@jobprofileid", ddljobprofile.SelectedValue);
                cmd.Parameters.AddWithValue("@minexperience", txtminexperience.Text);
                cmd.Parameters.AddWithValue("@maxexperience", txtmaxexperience.Text);
                cmd.Parameters.AddWithValue("@minsalary", txtminsalary.Text);
                cmd.Parameters.AddWithValue("@maxsalary", txtmaxsalary.Text);
                cmd.Parameters.AddWithValue("@vacancies", txtvacancies.Text);
                cmd.Parameters.AddWithValue("@comment", txtrecuitercomment.Text);
                cmd.ExecuteNonQuery();
                con.Close();
            }
            else if (btnsave_recruiterpost.Text == "Update")
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("sp_tblJobPostRecruiter", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@action", "UPDATEJOB");
                cmd.Parameters.AddWithValue("@jobid", Request.QueryString["Qs"]);
                cmd.Parameters.AddWithValue("@jobprofileid",ddljobprofile.SelectedValue);
                cmd.Parameters.AddWithValue("@minexperience", txtminexperience.Text);
                cmd.Parameters.AddWithValue("@maxexperience", txtmaxexperience.Text);
                cmd.Parameters.AddWithValue("@minsalary", txtminsalary.Text);
                cmd.Parameters.AddWithValue("@maxsalary", txtmaxsalary.Text);
                cmd.Parameters.AddWithValue("@vacancies", txtvacancies.Text);
                cmd.Parameters.AddWithValue("@comment", txtrecuitercomment.Text);
                cmd.ExecuteNonQuery();
                con.Close();
            }
            Response.Redirect("Recruiter_ManageJobPost.aspx");

        }
    }
}