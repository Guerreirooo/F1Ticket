using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PAP___F1_Ticket
{
    public partial class Perfil : System.Web.UI.Page
    {
        string ConnectionString = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
        string idUser = Membership.GetUser().ProviderUserKey.ToString();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["user"] == null)
                Response.Redirect("Login.aspx");

            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                connection.Open();

                SqlCommand command = new SqlCommand("SELECT UserName FROM aspnet_Users where UserId = '" + idUser + "'", connection);
                string sum = (string)command.ExecuteScalar();

                SqlCommand command2 = new SqlCommand("SELECT Email FROM aspnet_Membership where UserId = '" + idUser + "'", connection);
                string email = (string)command2.ExecuteScalar();

                SqlCommand command3 = new SqlCommand("SELECT CreateDate FROM aspnet_Membership where UserId = '" + idUser + "'", connection);
                DateTime data = (DateTime)command3.ExecuteScalar();

                lblUserName.InnerText = sum;
                lblEmail.InnerText = email;
                lblData.InnerText = data.ToString("dd/MM/yyyy");
            }
        }
    }
}