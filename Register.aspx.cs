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
    public partial class Register : System.Web.UI.Page
    {
        string ConnectionString = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        protected void RegisterUser_CreatedUser(object sender, EventArgs e)
        {
            TextBox txtUserName = (TextBox)RegisterUser.CreateUserStep.ContentTemplateContainer.FindControl("UserName");
            FormsAuthentication.SetAuthCookie(RegisterUser.UserName, false);

            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                connection.Open();

                SqlCommand commandSelect = new SqlCommand("select UserId from aspnet_Users where LoweredUserName = LOWER('" + txtUserName.Text + "')", connection);
                Guid nome = (Guid)commandSelect.ExecuteScalar();

                SqlCommand commandInsert = new SqlCommand("insert into Admin (UserId, Admin) values ('" + nome + "','Nao') ", connection);
                commandInsert.ExecuteScalar();

                Response.Redirect("Login.aspx");
            }
        }
        protected void UserName_TextChanged(object sender, EventArgs e)
        {
            TextBox textBox = sender as TextBox;
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                connection.Open();

                SqlCommand cmd = new SqlCommand("select LoweredUserName from aspnet_Users where LoweredUserName = LOWER('" + textBox.Text + "')", connection);
                if ((string)cmd.ExecuteScalar() != null)
                {
                    Label label = (Label)RegisterUser.CreateUserStep.ContentTemplateContainer.FindControl("labelTextBox");
                    label.Text = "Nome já em uso";
                }
                else
                {
                    Label label = (Label)RegisterUser.CreateUserStep.ContentTemplateContainer.FindControl("labelTextBox");
                    label.Text = "";
                }
                connection.Close();
            }
        }

        protected void Password_TextChanged(object sender, EventArgs e)
        {
            TextBox password = (TextBox)RegisterUser.CreateUserStep.ContentTemplateContainer.FindControl("ConfirmPassword");
            int quantidadeDigitos = password.Text.Length;

            if (quantidadeDigitos < 5)
            {
                Label label = (Label)RegisterUser.CreateUserStep.ContentTemplateContainer.FindControl("labelPassword");
                label.Text = "A password tem de ter no minimo 6 digitos";
            }
            else
            {
                Label label = (Label)RegisterUser.CreateUserStep.ContentTemplateContainer.FindControl("labelPassword");
                label.Text = "";
            }
        }
    }
}