using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PAP___F1_Ticket
{
    public partial class Historico : System.Web.UI.Page
    {
        string ConnectionString = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
        string idUser = Membership.GetUser().ProviderUserKey.ToString();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["user"] == null)
                Response.Redirect("Login.aspx");

            if (!this.IsPostBack)
            {
                this.BindGrid();

                using (SqlConnection connection = new SqlConnection(ConnectionString))
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand("SELECT COUNT(*) FROM Transfers where idUser = '" + idUser + "'", connection);
                    int count = (int)command.ExecuteScalar();


                        lblTotal.InnerText = "Transações guardadas - " + count.ToString() + "";

                }
            }
        }
        private void BindGrid()
        {
            using (SqlConnection con = new SqlConnection(ConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand("select p.nomePista as Pista,b.letraBancada as Bancada,t.quantidade as Quantidade,t.tipo as Tipo,t.preco as Preço, t.dataCompra as Data from BancadaT b inner join Pistas p on p.idPista = b.idPista inner join Transfers t on t.idBancada = b.idBancada inner join aspnet_Users u on t.idUser = u.UserId where u.UserId= '" + idUser + "'"))
                {
                    using (SqlDataAdapter sda = new SqlDataAdapter())
                    {
                        cmd.Connection = con;
                        sda.SelectCommand = cmd;
                        using (DataTable dt = new DataTable())
                        {
                            sda.Fill(dt);
                            GVHistórico.DataSource = dt;
                            GVHistórico.DataBind();
                            if (GVHistórico.Rows.Count == 0)
                            {
                                dt.Rows.Add(dt.NewRow());
                                GVHistórico.DataSource = dt;
                                GVHistórico.DataBind();
                                int columncount = GVHistórico.Rows[0].Cells.Count;
                                GVHistórico.Rows[0].Cells.Clear();
                                GVHistórico.Rows[0].Cells.Add(new TableCell());
                                GVHistórico.Rows[0].Cells[0].ColumnSpan = columncount;
                                GVHistórico.Rows[0].Cells[0].Text = "Não existem transações guardadas";
                            }
                        }

                    }
                }
            }
        }
        protected void btnApagar_Click(object sender, EventArgs e)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand("SELECT COUNT(*) FROM transfers where idUser = '" + idUser + "'", connection);
                SqlCommand query = new SqlCommand("DELETE FROM transfers where idUser = '" + idUser + "'", connection);
                int count = (int)command.ExecuteScalar();

                if (count == 0)
                {
                    Response.Redirect("Historico.aspx");
                }
                else
                {
                    query.ExecuteNonQuery();
                    Response.Redirect("Historico.aspx");
                }

            }
        }
        protected void OnPageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GVHistórico.PageIndex = e.NewPageIndex;
            this.BindGrid();
        }
        protected void GVHistorico_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                // Ajuste o índice da coluna "Preço" conforme necessário
                int precoIndex = 4;

                // Acesse a célula da coluna "Preço"
                TableCell precoCell = e.Row.Cells[precoIndex];

                // Acesse o valor atual da célula
                string preco = precoCell.Text;

                // Adicione o símbolo de euro ao valor
                preco = preco + " €";

                // Atualize o texto da célula com o valor atualizado
                precoCell.Text = preco;

            }
        }
    }
}