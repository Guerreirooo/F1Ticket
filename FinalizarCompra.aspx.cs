using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace PAP___F1_Ticket
{
    public partial class FinalizarCompra : System.Web.UI.Page
    {
        string ConnectionString = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
        string idUser = Membership.GetUser().ProviderUserKey.ToString();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["user"] == null)
                Response.Redirect("Login.aspx");

            btnCancelar.CausesValidation = false;

            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                connection.Open();

                SqlCommand command = new SqlCommand("SELECT SUM(preco) AS Total FROM Carrinho where idUser = '" + idUser + "'", connection);
                decimal sum = Convert.ToDecimal(command.ExecuteScalar());

                connection.Close();

                lblConfirma.Text = "<b>Total do Carrinho - " + sum.ToString() + " €</b>";
            }
        }

        protected void btnConfirma_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                using (SqlConnection connection = new SqlConnection(ConnectionString))
                {
                    connection.Open();

                    SqlCommand command9 = new SqlCommand("SELECT COUNT(*) FROM Carrinho where idUser = '" + idUser + "'", connection);
                    int contagem = Convert.ToInt32(command9.ExecuteScalar());
                    while (contagem != 0)
                    {
                        SqlCommand command2 = new SqlCommand("SELECT quantidade FROM Carrinho where idUser = '" + idUser + "'", connection);
                        string carrinho = Convert.ToString(command2.ExecuteScalar());

                        SqlCommand command3 = new SqlCommand("SELECT idPista FROM Carrinho where idUser = '" + idUser + "'", connection);
                        string carrinho2 = Convert.ToString(command3.ExecuteScalar());

                        SqlCommand command4 = new SqlCommand("SELECT idBancada FROM Carrinho where idUser = '" + idUser + "'", connection);
                        string carrinho3 = Convert.ToString(command4.ExecuteScalar());

                        SqlCommand command5 = new SqlCommand("SELECT preco FROM Carrinho where idUser = '" + idUser + "'", connection);
                        string carrinho4 = Convert.ToString(command5.ExecuteScalar());

                        SqlCommand command6 = new SqlCommand("SELECT tipo FROM Carrinho where idUser = '" + idUser + "'", connection);
                        string carrinho5 = Convert.ToString(command6.ExecuteScalar());

                        SqlCommand command7 = new SqlCommand("INSERT INTO Transfers(idUser, quantidade, idPista, idBancada, preco, tipo, dataCompra) VALUES('" + idUser + "','" + carrinho + "','" + carrinho2 + "','" + carrinho3 + "','" + carrinho4 + "','" + carrinho5 + "',GETDATE())", connection);
                        string sum = Convert.ToString(command7.ExecuteScalar());

                        SqlCommand command8 = new SqlCommand("DELETE FROM Carrinho WHERE idUser = '" + idUser + "' and quantidade = '" + carrinho + "' and idPista = '" + carrinho2 + "' and idBancada = '" + carrinho3 + "' and preco = '" + carrinho4 + "' and tipo = '" + carrinho5 + "'", connection);
                        string apagar = Convert.ToString(command8.ExecuteScalar());

                        if(carrinho5 == "Treinos")
                        {
                            SqlCommand commandlugaresT = new SqlCommand("SELECT lugares FROM BancadaT where idBancada = '" + carrinho3 + "'", connection);
                            string lugaresTotal = Convert.ToString(commandlugaresT.ExecuteScalar());

                            int lugaresPosCompra = int.Parse(lugaresTotal) - int.Parse(carrinho);

                            SqlCommand commandUpdateT = new SqlCommand("UPDATE BancadaT SET lugares = @lugaresPosCompra WHERE idBancada = @idBancada", connection);
                            commandUpdateT.Parameters.AddWithValue("@lugaresPosCompra", lugaresPosCompra);
                            commandUpdateT.Parameters.AddWithValue("@idBancada", carrinho3);
                            commandUpdateT.ExecuteNonQuery();
                        }
                        else if (carrinho5 == "Qualificação")
                        {
                            SqlCommand commandlugaresQ = new SqlCommand("SELECT lugares FROM BancadaQ where idBancada = '" + carrinho3 + "'", connection);
                            string lugaresTotal = Convert.ToString(commandlugaresQ.ExecuteScalar());

                            int lugaresPosCompra = int.Parse(lugaresTotal) - int.Parse(carrinho);

                            SqlCommand commandUpdateQ = new SqlCommand("UPDATE BancadaQ SET lugares = @lugaresPosCompra WHERE idBancada = @idBancada", connection);
                            commandUpdateQ.Parameters.AddWithValue("@lugaresPosCompra", lugaresPosCompra);
                            commandUpdateQ.Parameters.AddWithValue("@idBancada", carrinho3);
                            commandUpdateQ.ExecuteNonQuery();
                        }
                        else if (carrinho5 == "Corrida")
                        {
                            SqlCommand commandlugaresC = new SqlCommand("SELECT lugares FROM BancadaC where idBancada = '" + carrinho3 + "'", connection);
                            string lugaresTotal = Convert.ToString(commandlugaresC.ExecuteScalar());

                            int lugaresPosCompra = int.Parse(lugaresTotal) - int.Parse(carrinho);

                            SqlCommand commandUpdateC = new SqlCommand("UPDATE BancadaC SET lugares = @lugaresPosCompra WHERE idBancada = @idBancada", connection);
                            commandUpdateC.Parameters.AddWithValue("@lugaresPosCompra", lugaresPosCompra);
                            commandUpdateC.Parameters.AddWithValue("@idBancada", carrinho3);
                            commandUpdateC.ExecuteNonQuery();
                        }
                        else if (carrinho5 == "Fim de semana Completo")
                        {
                            SqlCommand commandlugaresFDS = new SqlCommand("SELECT lugares FROM BancadaFDS where idBancada = '" + carrinho3 + "'", connection);
                            string lugaresTotal = Convert.ToString(commandlugaresFDS.ExecuteScalar());

                            int lugaresPosCompra = int.Parse(lugaresTotal) - int.Parse(carrinho);

                            SqlCommand commandUpdateFDS = new SqlCommand("UPDATE BancadaFDS SET lugares = @lugaresPosCompra WHERE idBancada = @idBancada", connection);
                            SqlCommand commandUpdateC = new SqlCommand("UPDATE BancadaC SET lugares = @lugaresPosCompra WHERE idBancada = @idBancada", connection);
                            SqlCommand commandUpdateQ = new SqlCommand("UPDATE BancadaQ SET lugares = @lugaresPosCompra WHERE idBancada = @idBancada", connection);
                            SqlCommand commandUpdateT = new SqlCommand("UPDATE BancadaT SET lugares = @lugaresPosCompra WHERE idBancada = @idBancada", connection);
                            commandUpdateT.Parameters.AddWithValue("@lugaresPosCompra", lugaresPosCompra);
                            commandUpdateT.Parameters.AddWithValue("@idBancada", carrinho3);
                            commandUpdateT.ExecuteNonQuery();
                            commandUpdateQ.Parameters.AddWithValue("@lugaresPosCompra", lugaresPosCompra);
                            commandUpdateQ.Parameters.AddWithValue("@idBancada", carrinho3);
                            commandUpdateQ.ExecuteNonQuery();
                            commandUpdateC.Parameters.AddWithValue("@lugaresPosCompra", lugaresPosCompra);
                            commandUpdateC.Parameters.AddWithValue("@idBancada", carrinho3);
                            commandUpdateC.ExecuteNonQuery();
                            commandUpdateFDS.Parameters.AddWithValue("@lugaresPosCompra", lugaresPosCompra);
                            commandUpdateFDS.Parameters.AddWithValue("@idBancada", carrinho3);
                            commandUpdateFDS.ExecuteNonQuery();
                        }

                        contagem --;
                    }

                    connection.Close();

                    Response.Redirect("Carrinho.aspx");
                }
            }
        }
        protected void btnCancelar_Click(object sender, EventArgs e)
        {
        }

    }
}