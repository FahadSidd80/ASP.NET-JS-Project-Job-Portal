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
    public partial class Login : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["job_portal"].ConnectionString);

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnlogin_Click(object sender, EventArgs e)
        {
            if (ddlusertype.SelectedValue == "0")
            {
                lblmsg.Text = "Please select usertype !!";
                lblmsg.ForeColor = Color.Red;
            }
            else if (ddlusertype.SelectedValue=="1")
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("sp_AdminLogin", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@action", "ADMINLOGIN");
                cmd.Parameters.AddWithValue("@loginemailid", txtloginemail.Text);
                cmd.Parameters.AddWithValue("@loginpassword", txtloginpassword.Text);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                con.Close();
                if (dt.Rows.Count > 0)
                {
                    Session["adminid"] = dt.Rows[0]["adminid"].ToString();
                    Session["oldpassword"] = dt.Rows[0]["password"].ToString();
                    Session["usertype"] = dt.Rows[0]["usertype"].ToString();
                    Response.Redirect("AdminHome.aspx");
                }
                else
                {
                    lblmsg.Text = "Your Email Id && password is wrong !! please enter correct email & password !!";
                    lblmsg.ForeColor = Color.Red;

                }
                
            }
            else if (ddlusertype.SelectedValue == "2")
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("sp_JobSeekerLogin", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@action", "JOBSEEKERLOGIN");
                cmd.Parameters.AddWithValue("@jobseekeremailid", txtloginemail.Text);
                cmd.Parameters.AddWithValue("@jobseekerpassword", txtloginpassword.Text);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                con.Close();
                if (dt.Rows.Count > 0)
                {
                    Session["jid"] = dt.Rows[0]["jid"].ToString();
                    Session["oldpassword"] = dt.Rows[0]["password"].ToString();
                    Session["usertype"] = dt.Rows[0]["usertype"].ToString();
                    Response.Redirect("JobseekerHome.aspx");
                }
                else
                {
                    lblmsg.Text = "Your Email Id && password is wrong !! please enetr correct email & password !!";
                    lblmsg.ForeColor = Color.Red;

                }
            }
            else if (ddlusertype.SelectedValue == "3")
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("sp_RecruiterLogin", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@action", "RECRUITERLOGIN");
                cmd.Parameters.AddWithValue("@recruiteremail", txtloginemail.Text);
                cmd.Parameters.AddWithValue("@recruiterpassword", txtloginpassword.Text);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                con.Close();

               

                if (dt.Rows.Count > 0)
                {
                    Session["recruiterid"] = dt.Rows[0]["recruiterid"].ToString();
                    Session["recruitername"] = dt.Rows[0]["name"].ToString();
                    Session["oldpassword"] = dt.Rows[0]["password"].ToString();
                    Session["usertype"] = dt.Rows[0]["usertype"].ToString();
                    Session["status"] = dt.Rows[0]["status"].ToString();
                    Session["emailid"] = dt.Rows[0]["emailid"].ToString();
                    Session["password"] = dt.Rows[0]["password"].ToString();

                    if (Session["status"].ToString() == "0")
                    {
                        if (Session["emailid"].ToString() == txtloginemail.Text & Session["password"].ToString() == txtloginpassword.Text)
                        {
                            Response.Redirect("RecruiterHome.aspx");
                        }
                       
                    }
                    else
                    {
                        lblmsg.Text = "you account has been deleted, please signup first !!";
                        lblmsg.ForeColor = Color.Red;
                    }
                    
                }
                else
                {
                    lblmsg.Text = "your emailid & password didn't match, please enter correct details !!";
                }

                //if (Session["status"].ToString() == "0")
                //{
                //    if (Session["emailid"].ToString() == txtloginemail.Text & Session["password"].ToString() == txtloginpassword.Text & Session["status"].ToString() == "0")
                //    {
                //        Response.Redirect("RecruiterHome.aspx");
                //    }
                //    else if (Session["emailid"].ToString() != txtloginemail.Text | Session["password"].ToString() != txtloginpassword.Text | Session["status"].ToString() == "0")
                //    {
                //        lblmsg.Text = "your  emailid  and password doesn't match, please enter correct emailid and password !!";

                //    }

                //}
                //else
                //{
                //    if (Session["emailid"].ToString() == txtloginemail.Text & Session["password"].ToString() == txtloginpassword.Text)
                //    {
                //        lblmsg.Text = "your  account has been deleted, please signup first!!";
                //    }
                //    else if (Session["emailid"].ToString() != txtloginemail.Text & Session["password"].ToString() == txtloginpassword.Text)
                //    {
                //        lblmsg.Text = "your  emailid doesn't match, please enter correct emailid !!";

                //    }
                //    else if (Session["emailid"].ToString() == txtloginemail.Text & Session["password"].ToString() != txtloginpassword.Text)
                //    {
                //        lblmsg.Text = "your  password doesn't match, please enter correct password !!";

                //    }

                //}

            }
        }
    }
}