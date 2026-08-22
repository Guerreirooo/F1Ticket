using System;
using System.IO;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Text.RegularExpressions;
using System.Globalization;

namespace PAP___F1_Ticket.Admin
{
    public partial class EditarPista : System.Web.UI.Page
    {
        string ConnectionString = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
        string auxDropOpcao;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["user"] == null)
                Response.Redirect("Login.aspx");
            Page.Form.Attributes.Add("enctype", "multipart/form-data");

            if (!IsPostBack)
            {
                using (SqlConnection connection = new SqlConnection(ConnectionString))
                {
                    connection.Open();

                    SqlCommand command = new SqlCommand("SELECT nomePista FROM Pistas", connection);
                    SqlDataReader readerNomesPistas = command.ExecuteReader();

                    while (readerNomesPistas.Read())
                    {
                        string valor = readerNomesPistas["nomePista"].ToString();
                        ListItem item = new ListItem(valor, valor);
                        SelectPistaEditar.Items.Add(item);
                        SelectPistaRemover.Items.Add(item);
                    }
                    readerNomesPistas.Close();
                }
            }
        }

        protected void cancelar_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/PaginaInicial.aspx");
        }

        protected void limparAdd_Click(object sender, EventArgs e)
        {
            if (auxDropOpcao == "1")
            {
                txtNomeSimples.Text = "";
                txtNomeCompletoAdicionar.Text = "";
                dataInicioAdicionar.Text = "";
                dataFimAdicionar.Text = "";
                fileBandeiraAdicionar.Dispose();
                fileBandeiraAdicionar.DataBind();
                fileBancadaAdicionar.Dispose();
                fileBancadaAdicionar.DataBind();
            }
        }

        protected void guardarAdd_Click(object sender, EventArgs e)
        {
                byte[] imgarray = fileBandeiraAdicionar.FileBytes;
                byte[] imagemBytesBancadas = fileBancadaAdicionar.FileBytes;

                using (SqlConnection connection = new SqlConnection(ConnectionString))
                {
                    connection.Open();

                    string query = "INSERT INTO Pistas (nomePista, nomeCorrida, dataCorridaInicio, dataCorridaFim, bandeiraPais, bancadas) VALUES (@NomePista, @NomeCorrida, @DataInicio, @DataFim, @Bandeira, @Bancadas)";

                    using (SqlCommand commandInsert = new SqlCommand(query, connection))
                    {
                        commandInsert.Parameters.AddWithValue("@NomePista", txtNomeSimples.Text);
                        commandInsert.Parameters.AddWithValue("@NomeCorrida", txtNomeCompletoAdicionar.Text);
                        commandInsert.Parameters.AddWithValue("@DataInicio", DateTime.Parse(dataInicioAdicionar.Text));
                        commandInsert.Parameters.AddWithValue("@DataFim", DateTime.Parse(dataFimAdicionar.Text));
                        commandInsert.Parameters.AddWithValue("@Bandeira", imgarray);
                        commandInsert.Parameters.AddWithValue("@Bancadas", imagemBytesBancadas);

                        int rowsAffected = commandInsert.ExecuteNonQuery();

                    }

                    Response.Redirect("EditarPista.aspx");
                }
        }

        protected void guardarEdit_Click(object sender, EventArgs e)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                connection.Open();

                SqlCommand commandUpdate = new SqlCommand("UPDATE Pistas SET nomeCorrida = '" + txtNomeCompletoEditar.Text + "', dataCorridaInicio = '" + dataInicioEditar.Text + "', dataCorridaFim = '" + dataFimEditar.Text + "' WHERE nomePista = '" + SelectPistaEditar.SelectedValue + "'", connection);
                SqlDataReader readerInfos = commandUpdate.ExecuteReader();

                lblSucessoEditar.Visible = true;
                readerInfos.Close(); // Fechar o SqlDataReader

                if (fileBandeiraEditar.HasFile)
                {
                    byte[] imagemBytesBandeira = fileBandeiraEditar.FileBytes;

                    SqlCommand commandUpdateBandeira = new SqlCommand("UPDATE Pistas SET bandeiraPais = @ImagemBytes WHERE nomePista = @NomePista", connection);
                    commandUpdateBandeira.Parameters.AddWithValue("@ImagemBytes", imagemBytesBandeira);
                    commandUpdateBandeira.Parameters.AddWithValue("@NomePista", SelectPistaEditar.SelectedValue);
                    commandUpdateBandeira.ExecuteNonQuery();

                }

                if (fileBancadaEditar.HasFile)
                {
                    byte[] imagemBytesBancadas = fileBancadaEditar.FileBytes;

                    SqlCommand commandUpdateBancadas = new SqlCommand("UPDATE Pistas SET bancadas = @ImagemBytes WHERE nomePista = @NomePista", connection);
                    commandUpdateBancadas.Parameters.AddWithValue("@ImagemBytes", imagemBytesBancadas);
                    commandUpdateBancadas.Parameters.AddWithValue("@NomePista", SelectPistaEditar.SelectedValue);
                    commandUpdateBancadas.ExecuteNonQuery();

                }

                Response.Redirect("EditarPista.aspx");
            }
        }
        protected void guardarRemover_Click(object sender, EventArgs e)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                connection.Open();

                SqlCommand commandId = new SqlCommand("SELECT idPista FROM Pistas WHERE nomePista = '" + SelectPistaRemover.SelectedValue + "'", connection);
                int idPista = (int)commandId.ExecuteScalar();

                SqlCommand commandDelPista = new SqlCommand("DELETE FROM Pistas WHERE nomePista = '" + SelectPistaRemover.SelectedValue + "'", connection);
                SqlDataReader readerNomesPistas = commandDelPista.ExecuteReader();
                readerNomesPistas.Close();

                SqlCommand commandDelResultado = new SqlCommand("DELETE FROM ResultadosCorridas WHERE idPista = '" + idPista + "'", connection);
                SqlDataReader readerResultados = commandDelResultado.ExecuteReader();

            }
            Response.Redirect("EditarPista.aspx");
        }
    }
}