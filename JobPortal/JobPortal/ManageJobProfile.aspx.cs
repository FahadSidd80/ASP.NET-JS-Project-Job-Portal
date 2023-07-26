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
    public partial class ManageJobProfile : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["job_portal"].ConnectionString);

        protected void Page_Load(object sender, EventArgs e)
        {
           
           
        }
       
        protected void Btnsave_Jobprofile_Click(object sender, EventArgs e)
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("sp_tblJobprofile", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@action", "INSERTJOBPROFILE");
            cmd.Parameters.AddWithValue("@jobprofilename", txtjobprofile.Text);
            cmd.ExecuteNonQuery();
            con.Close();
        }
    }
}