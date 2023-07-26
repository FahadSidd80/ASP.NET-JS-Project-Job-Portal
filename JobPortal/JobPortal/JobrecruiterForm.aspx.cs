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

namespace JobPortal
{
    public partial class JobrecruiterForm : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["job_portal"].ConnectionString);

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                GetCountry();
                ddlstate.Enabled = false;
                ddlcity.Enabled = false;
                ddlstate.Items.Insert(0, new ListItem("--Select--", "0"));
                ddlcity.Items.Insert(0, new ListItem("--Select--", "0"));
                //if (Session["recruiterid"].ToString() != "null" & Session["recruiterid"].ToString() != "")
                //{
                //    GetRecruiterDetail();
                //}

            }
            
        }

        //public void GetRecruiterDetail()
        //{
        //    con.Open();
        //    SqlCommand cmd = new SqlCommand("sp_tblRecruiter", con);
        //    cmd.CommandType = CommandType.StoredProcedure;
        //    cmd.Parameters.AddWithValue("@action", "GETRECRUITERDETAILS");
        //    cmd.Parameters.AddWithValue("@recruiterid", Request.QueryString["Qs"]);// done with query string
        //    //cmd.Parameters.AddWithValue("@recruiterid", Session["recruiterid"]);// done with session variable
        //    SqlDataAdapter da = new SqlDataAdapter(cmd);
        //    DataTable dt = new DataTable();
        //    da.Fill(dt);
        //    con.Close();
        //    if (dt.Rows.Count > 0)
        //    {
        //        //Session["state"] = dt.Rows[0]["state"].ToString();
        //        //Session["city"] = dt.Rows[0]["city"].ToString();

        //        txtcompanyname.Text = dt.Rows[0]["name"].ToString();
        //        txtcompanyurl.Text = dt.Rows[0]["url"].ToString();
        //        ddlcountry.SelectedValue = dt.Rows[0]["country"].ToString();
        //        if (ddlcountry.SelectedValue == "0")
        //        {
        //            ddlstate.Enabled = false;
        //            ddlstate.SelectedValue = "0";
        //            ddlcity.Enabled = false;
        //            ddlcity.SelectedValue = "0";
        //        }
        //        else
        //        {
        //            ddlstate.Enabled = true;
        //            ddlcity.Enabled = true;
        //            //ddlstate.SelectedValue = Session["state"].ToString();
        //            //ddlcity.SelectedValue = Session["city"].ToString();
        //            ddlstate.SelectedValue = dt.Rows[0]["state"].ToString();
        //            ddlcity.SelectedValue = dt.Rows[0]["city"].ToString();
        //            GetState();
        //            GetCity();
        //        }
        //        txtcompanyaddress.Text = dt.Rows[0]["address"].ToString();
        //        txthrname.Text = dt.Rows[0]["hrname"].ToString();
        //        txtcompanymobile.Text = dt.Rows[0]["contactno"].ToString();
        //        tremail.Visible = false;
        //        trpassword.Visible = false;
        //        btnsaverecruiter.Text = "Update";
        //    }
            
        //}

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

        protected void btnsaverecruiter_Click(object sender, EventArgs e)
        {
            if (btnsaverecruiter.Text=="Save") {
                con.Open();
                SqlCommand cmd = new SqlCommand("sp_tblRecruiter", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@action", "INSERT");
                cmd.Parameters.AddWithValue("@name", txtcompanyname.Text);
                cmd.Parameters.AddWithValue("@url", txtcompanyurl.Text);
                cmd.Parameters.AddWithValue("@country", ddlcountry.SelectedValue);
                cmd.Parameters.AddWithValue("@state", ddlstate.SelectedValue);
                cmd.Parameters.AddWithValue("@city", ddlcity.SelectedValue);
                cmd.Parameters.AddWithValue("@address", txtcompanyaddress.Text);
                cmd.Parameters.AddWithValue("@hrname", txthrname.Text);
                cmd.Parameters.AddWithValue("@contactno", txtcompanymobile.Text);
                cmd.Parameters.AddWithValue("@emailid", txtcompanyemail.Text);
                cmd.Parameters.AddWithValue("@password", txtcompanypassword.Text);
                cmd.ExecuteNonQuery();
                con.Close();
            }
            else if (btnsaverecruiter.Text== "Update")
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("sp_tblRecruiter", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@action", "UPDATERECRUITER");
               // cmd.Parameters.AddWithValue("@recruiterid", Session["recruiterid"]);// session variable
               // cmd.Parameters.AddWithValue("@recruiterid", Request.QueryString["Qs"]);// query string
                cmd.Parameters.AddWithValue("@name", txtcompanyname.Text);
                cmd.Parameters.AddWithValue("@url", txtcompanyurl.Text);
                cmd.Parameters.AddWithValue("@country", ddlcountry.SelectedValue);
                cmd.Parameters.AddWithValue("@state", ddlstate.SelectedValue);
                cmd.Parameters.AddWithValue("@city", ddlcity.SelectedValue);
                cmd.Parameters.AddWithValue("@address", txtcompanyaddress.Text);
                cmd.Parameters.AddWithValue("@hrname", txthrname.Text);
                cmd.Parameters.AddWithValue("@contactno", txtcompanymobile.Text);
                cmd.ExecuteNonQuery();
                con.Close();
                //btnsaverecruiter.Text = "Save";
            }
           
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
            if (ddlstate.SelectedValue == "0")
            {
                ddlcity.Enabled = false;
                ddlcity.SelectedValue = "0";
            }
            else
            {
                GetCity();
            }
        }
    }
}