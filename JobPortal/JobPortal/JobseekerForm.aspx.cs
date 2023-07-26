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
    public partial class JobseekerForm : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["job_portal"].ConnectionString);
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                GetCountry();
                GetQualification();
                GetJobProfile();
                ddlstate.Enabled = false;
                ddlcity.Enabled = false;
                ddlstream.Enabled = false;
                cblskills.Enabled = false;
                ddlstate.Items.Insert(0, new ListItem("--Select--", "0"));
                ddlcity.Items.Insert(0, new ListItem("--Select--", "0"));
                ddlstream.Items.Insert(0, new ListItem("--Select--", "0"));
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
            ddlcountry.DataValueField ="countryid";
            ddlcountry.DataTextField ="countryname";
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
            ddlstate.Items.Insert(0, new ListItem("--Select--","0"));  
        }

        public void GetCity()
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("sp_tblCity", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@action", "GETCITY");
            cmd.Parameters.AddWithValue("@countryid", ddlcountry.SelectedValue);
            cmd.Parameters.AddWithValue("@stateid", ddlstate.SelectedValue);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            con.Close();
            ddlcity.Enabled = true;
            ddlcity.DataValueField = "cityid";
            ddlcity.DataTextField = "cityname";
            ddlcity.DataSource = dt;
            ddlcity.DataBind();
            ddlcity.Items.Insert(0, new ListItem("--Select--", "0"));
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

        public void GetStream()
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("sp_tblStream", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@action", "GETSTREAM");
            cmd.Parameters.AddWithValue("@qualificationid", ddlqualification.SelectedValue);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            con.Close();
            ddlstream.Enabled = true;
            ddlstream.DataValueField = "streamid";
            ddlstream.DataTextField = "streamname";
            ddlstream.DataSource = dt;
            ddlstream.DataBind();
            ddlstream.Items.Insert(0, new ListItem("--Select--", "0"));
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

        public void GetSkill()
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("sp_tblSkill", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@action", "GETSKILL");
            cmd.Parameters.AddWithValue("@jobprofileid", ddljobprofile.SelectedValue);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            con.Close();
            cblskills.Enabled = true;
            cblskills.DataValueField = "skillid";
            cblskills.DataTextField = "skillname";
            cblskills.DataSource = dt;
            cblskills.DataBind();
        }


        protected void btnsave_Click(object sender, EventArgs e)
        {
            string cblskl = "";
            for (int i=0; i<cblskills.Items.Count; i++)
            {
                if (cblskills.Items[i].Selected == true)
                { 
                    cblskl += cblskills.Items[i].Text+",";
                }
            }
            cblskl = cblskl.TrimEnd(',');

            con.Open();
            SqlCommand cmd = new SqlCommand("sp_tblJobseeker", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@action","INSERT");
            cmd.Parameters.AddWithValue("@name",txtname.Text);
            cmd.Parameters.AddWithValue("@address", txtaddress.Text);
            cmd.Parameters.AddWithValue("@country", ddlcountry.SelectedValue);
            cmd.Parameters.AddWithValue("@state", ddlstate.SelectedValue);
            cmd.Parameters.AddWithValue("@city", ddlcity.SelectedValue);
            cmd.Parameters.AddWithValue("@mobileno", txtmobile.Text);
            cmd.Parameters.AddWithValue("@gender",rblgender.SelectedValue);
            cmd.Parameters.AddWithValue("@qualification",ddlqualification.SelectedValue);
            cmd.Parameters.AddWithValue("@stream",ddlstream.SelectedValue);
            cmd.Parameters.AddWithValue("@jobprofile",ddljobprofile.SelectedValue);
            cmd.Parameters.AddWithValue("@skill", cblskl);
            cmd.Parameters.AddWithValue("@empresume",Path.GetFileName(furesume.PostedFile.FileName) );
            cmd.Parameters.AddWithValue("@empimage", Path.GetFileName(fuimg.PostedFile.FileName));
            cmd.Parameters.AddWithValue("@emailid",txtemail.Text);
            //cmd.Parameters.AddWithValue("confirmemailid",txtconfirmemail.Text);
            cmd.Parameters.AddWithValue("@password", txtpassword.Text);
            //cmd.Parameters.AddWithValue("confirmpassword", txtconfirmpassword.Text);
            cmd.ExecuteNonQuery();
            con.Close();
            furesume.SaveAs(Server.MapPath("JobseekerResume" + "\\"+ Path.GetFileName(furesume.PostedFile.FileName)));
            fuimg.SaveAs(Server.MapPath("JobseekerImage"+"\\"+ Path.GetFileName(fuimg.PostedFile.FileName)));
        }

        protected void ddlcountry_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlcountry.SelectedValue == "0")
            {
                ddlstate.Enabled = false;
                ddlstate.SelectedValue = "0";
                ddlcity.Enabled = false;
                ddlcity.SelectedValue = "0";
            } 
            else
            {
                GetState();
                ddlcity.Enabled = false;
                ddlcity.SelectedValue = "0";
                
            }
            
        }

        protected void ddlstate_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlstate.SelectedValue=="0")
            {
                ddlcity.Enabled = false;
                ddlcity.SelectedValue = "0";
            }
            else
            {
                GetCity();
            }
        }

        protected void ddlqualification_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlqualification.SelectedValue=="0")
            {
                ddlstream.Enabled = false;
                ddlstream.SelectedValue = "0";
            }
            else
            {
                GetStream();
            }
        }

        protected void ddljobprofile_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddljobprofile.SelectedValue=="0")
            {
                cblskills.Enabled = false;
                cblskills.Items.Clear();
                tr_skills.Visible = false;
            }
            else
            {
                tr_skills.Visible = true;
                GetSkill();
            }
        }
    }
}