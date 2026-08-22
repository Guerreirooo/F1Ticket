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
    public partial class Login : System.Web.UI.Page
    {
        string ConnectionString = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void loginUser_Authenticate(object sender, AuthenticateEventArgs e)
        {
            bool isLogin = Membership.ValidateUser(loginUser.UserName, loginUser.Password);
            if (isLogin)
            {
                loginUser.Visible = true;
                Session["user"] = User.Identity.Name;
                FormsAuthentication.RedirectFromLoginPage(loginUser.UserName, true);

                Response.Redirect("PaginaInicial.aspx");
            }
        }
    }
}