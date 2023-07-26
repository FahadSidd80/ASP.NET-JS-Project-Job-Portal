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
    public partial class RecruiterHome : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["job_portal"].ConnectionString);

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["recruiterid"] != null & Session["recruiterid"].ToString() != "")
                {
                    lblrecruitermsg.Text = Session["recruitername"].ToString();
                }
                else
                {
                    Response.Redirect("Logout.aspx");
                }
                GetGridRecruiter();

            }
            
        }

        public void GetGridRecruiter()
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("sp_tblRecruiter", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@action", "GETRECRUITERPROFILE");
            cmd.Parameters.AddWithValue("@recruiterid", Session["recruiterid"]);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            con.Close();
            grdrecruiter.DataSource = dt;
            grdrecruiter.DataBind();
        }
        protected  void grdrecruiter_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Del")
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("sp_tblRecruiter", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@action", "DELETEPROFILE");
                cmd.Parameters.AddWithValue("@recruiterid", e.CommandArgument);
                //cmd.Parameters.AddWithValue("@recruiterid", Session["recruiterid"]);
                cmd.ExecuteNonQuery();
                con.Close();
                //Session["RecruiterID"] = e.CommandArgument;
                lbldeletemsg.Text = "your account has been deleted successfully, it's safe to logout !!";
                lbldeletemsg.ForeColor = Color.ForestGreen;
                Session.Abandon();
                Response.Redirect("Logout.aspx");



            }
            //Response.Redirect("RecruiterHome.aspx");
            //Response.Redirect("Logout.aspx");
            else if (e.CommandName == "Edt")
            {
                //Session["recruiterid"] = e.CommandArgument;
                //Response.Redirect("JobrecruiterForm.aspx");// send value by using session variable
                //Response.Redirect("JobrecruiterForm.aspx?Qs=" + e.CommandArgument);  //  send value by using query string variable
            }

        }
       
    }
}