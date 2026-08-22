using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PAP___F1_Ticket
{
    public partial class Navbar : System.Web.UI.MasterPage
    {
        string ConnectionString = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
        string idUser = Membership.GetUser().ProviderUserKey.ToString();
        protected void Page_Load(object sender, EventArgs e)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                connection.Open();

                SqlCommand commandCarrinho = new SqlCommand("SELECT COALESCE(SUM(quantidade), 0) FROM Carrinho WHERE idUser = '" + idUser + "'", connection);
                int quantidade = (int)commandCarrinho.ExecuteScalar();

                lblCarrinho.Text = "<strong>" + quantidade.ToString() + "</strong>";
            }
        }

        protected void redirectToLogin(object sender, EventArgs e)
        {
            Session.Clear();
            Session.Abandon();
            string loginUrl = ResolveUrl("~/login.aspx");

            Response.Redirect(loginUrl);
        }
    }
}