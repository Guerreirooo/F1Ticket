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
    public partial class Carrinho : System.Web.UI.Page
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
                    SqlCommand command = new SqlCommand("SELECT COUNT(*) FROM Carrinho where idUser = '" + idUser + "'", connection);
                    int count = (int)command.ExecuteScalar();

                    if (count == 0)
                    {
                        lblTotal.InnerText = "Total do Carrinho - 0€";
                    }
                    else
                    {
                            SqlCommand command2 = new SqlCommand("SELECT SUM(preco) AS Total FROM Carrinho where idUser = '" + idUser + "'", connection);
                            decimal sum = Convert.ToDecimal(command2.ExecuteScalar());


                        lblTotal.InnerText = "Total do Carrinho - " + sum.ToString() + " €";
                    }

                }
            }   
        }
        private void BindGrid()
        {
            using (SqlConnection con = new SqlConnection(ConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand("select p.nomePista as Pista,b.letraBancada as Bancada,c.quantidade as Quantidade,c.tipo as Tipo,c.preco as Valor from BancadaT b inner join Carrinho c on b.idBancada = c.idBancada inner join Pistas p on p.idPista = c.idPista inner join aspnet_Users u on c.idUser = u.UserId where u.UserId= '" + idUser + "'"))
                {
                    using (SqlDataAdapter sda = new SqlDataAdapter())
                    {
                        cmd.Connection = con;
                        sda.SelectCommand = cmd;
                        using (DataTable dt = new DataTable())
                        {
                            sda.Fill(dt);
                            GVCarrinho.DataSource = dt;
                            GVCarrinho.DataBind();
                            if (GVCarrinho.Rows.Count == 0)
                            {
                                dt.Rows.Add(dt.NewRow());
                                GVCarrinho.DataSource = dt;
                                GVCarrinho.DataBind();
                                int columncount = GVCarrinho.Rows[0].Cells.Count;
                                GVCarrinho.Rows[0].Cells.Clear();
                                GVCarrinho.Rows[0].Cells.Add(new TableCell());
                                GVCarrinho.Rows[0].Cells[0].ColumnSpan = columncount;
                                GVCarrinho.Rows[0].Cells[0].Text = "Não existem itens no carrinho";
                            }
                        }

                    }
                }
            }
        }
        protected void GVCarrinho_RowDataBound(object sender, GridViewRowEventArgs e)
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

        protected void btnLimpar_Click(object sender, EventArgs e)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand("SELECT COUNT(*) FROM Carrinho where idUser = '" + idUser + "'", connection);
                int count = (int)command.ExecuteScalar();

                if (count == 0)
                {
                    Response.Redirect("Carrinho.aspx");
                }
                else
                {
                    SqlCommand command2 = new SqlCommand("DELETE FROM Carrinho WHERE idUser = '" + idUser + "'", connection);
                    command2.ExecuteNonQuery();
                    this.BindGrid();
                    Response.Redirect("Carrinho.aspx");
                }

            }
        }
        protected void OnPageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GVCarrinho.PageIndex = e.NewPageIndex;
            this.BindGrid();
        }
        protected void btnComprar_Click(object sender, EventArgs e)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand("SELECT COUNT(*) FROM Carrinho where idUser = '" + idUser + "'", connection);
                int count = (int)command.ExecuteScalar();

                if (count == 0)
                {
                    Response.Redirect("Carrinho.aspx");
                }
                else
                {
                    Response.Redirect("FinalizarCompra.aspx");
                }

            }
        }
    }
}