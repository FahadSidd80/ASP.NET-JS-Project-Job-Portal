using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;
using System.Drawing;

namespace JobPortal.Content
{
    public partial class ChangePasswordCommon : System.Web.UI.UserControl
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["job_portal"].ConnectionString);
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnupdatepassword_Click(object sender, EventArgs e)
        {
            if (Session["usertype"].ToString() == "1")
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("sp_ChangePassword", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@action", "UPDATEADMINPASSWORD");
                cmd.Parameters.AddWithValue("@adminid", Session["adminid"]);
                cmd.Parameters.AddWithValue("@oldpassword", txtoldpassword.Text);
                cmd.Parameters.AddWithValue("@newpassword", txtnewpassword.Text);
                cmd.ExecuteNonQuery();
                con.Close();
            }
            else if (Session["usertype"].ToString() == "2")// jobseeker
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("sp_ChangePassword", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@action", "UPDATEJOBSEEKERPASSWORD");
                cmd.Parameters.AddWithValue("@jid", Session["jid"]);
                cmd.Parameters.AddWithValue("@oldpassword", txtoldpassword.Text);
                cmd.Parameters.AddWithValue("@newpassword", txtnewpassword.Text);
                cmd.ExecuteNonQuery();
                con.Close();
            }
            else if (Session["usertype"].ToString() == "3")
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("sp_ChangePassword", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@action", "UPDATERECRUITERPASSWORD");
                cmd.Parameters.AddWithValue("@recruiterid", Session["recruiterid"]);
                cmd.Parameters.AddWithValue("@oldpassword", txtoldpassword.Text);
                cmd.Parameters.AddWithValue("@newpassword", txtnewpassword.Text);
                cmd.ExecuteNonQuery();
                con.Close();
            }
             
            if (Session["oldpassword"].ToString() == txtoldpassword.Text)
            {
                lblmsg.Text = "Your password updated successfully !!!";
                lblmsg.ForeColor = Color.Green;
               
            }
            else
            {
                lblmsg.Text = "Old password didn't match, Enter correct password!!";
                lblmsg.ForeColor = Color.Red;
            }
        }
    }
}