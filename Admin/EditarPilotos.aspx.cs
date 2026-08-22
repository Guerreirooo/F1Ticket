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
    public partial class EditarPilotos : System.Web.UI.Page
    {
        string ConnectionString = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
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

                    SqlCommand command = new SqlCommand("SELECT Nome FROM SobrePilotos", connection);
                    SqlDataReader readerNomesPilotos = command.ExecuteReader();

                    while (readerNomesPilotos.Read())
                    {
                        string valor = readerNomesPilotos["Nome"].ToString();
                        ListItem item = new ListItem(valor, valor);
                        SelectPilotoEditar.Items.Add(item);
                        SelectPilotoRemover.Items.Add(item);
                    }
                    readerNomesPilotos.Close();

                    SqlCommand command2 = new SqlCommand("SELECT DISTINCT(Nome) FROM SobreEquipas", connection);
                    SqlDataReader readerNomesEquipas = command2.ExecuteReader();

                    while (readerNomesEquipas.Read())
                    {
                        string valor = readerNomesEquipas["Nome"].ToString();
                        ListItem item = new ListItem(valor, valor);
                        selectEquipaAdicionar.Items.Add(item);
                        selectEquipaEditar.Items.Add(item);
                    }
                    readerNomesEquipas.Close();
                }
            }
        }

        protected void cancelar_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/SobrePilotos.aspx");
        }

        protected void guardarAdd_Click(object sender, EventArgs e)
        {
                byte[] imgarray = fileBandeiraAdicionar.FileBytes;
                byte[] imagemPreSet = filePreSetAdicionar.FileBytes;
                byte[] imagemFoto = fileFotoAdicionar.FileBytes;

                using (SqlConnection connection = new SqlConnection(ConnectionString))
                {
                    connection.Open();

                    SqlCommand commandIdEquipa = new SqlCommand("SELECT idEquipa FROM SobreEquipas WHERE Nome = '" + selectEquipaAdicionar.SelectedValue + "'", connection);
                    int idEquipa = (int)commandIdEquipa.ExecuteScalar();

                    string query = "INSERT INTO SobrePilotos (idEquipa, Nome, PreSet, Foto, Idade, Podios, Vitorias, AnoDebut, CorridasFeitas, nacionalidade, bandeiraPais) VALUES (@idEquipa, @Nome, @PreSet, @Foto, @Idade, @Podios, @Vitorias, @AnoDebut, @CorridasFeitas, @nacionalidade, @bandeiraPais)";

                    using (SqlCommand commandInsert = new SqlCommand(query, connection))
                    {
                        commandInsert.Parameters.AddWithValue("@idEquipa", idEquipa);
                        commandInsert.Parameters.AddWithValue("@Nome", txtNomeAdicionar.Text);
                        commandInsert.Parameters.AddWithValue("@PreSet", imagemPreSet);
                        commandInsert.Parameters.AddWithValue("@Foto", imagemFoto);
                        commandInsert.Parameters.AddWithValue("@Idade", txtIdadeAdicionar.Text);
                        commandInsert.Parameters.AddWithValue("@Podios", txtPodiosAdicionar.Text);
                        commandInsert.Parameters.AddWithValue("@Vitorias", txtVitoriasAdicionar.Text);
                        commandInsert.Parameters.AddWithValue("@AnoDebut", txtAnoDebutAdicionar.Text);
                        commandInsert.Parameters.AddWithValue("@CorridasFeitas", txtCorridasFeitasAdicionar.Text);
                        commandInsert.Parameters.AddWithValue("@nacionalidade", txtNacionalidadeAdicionar.Text);
                        commandInsert.Parameters.AddWithValue("@bandeiraPais", imgarray);

                        int rowsAffected = commandInsert.ExecuteNonQuery();

                        lblSucessoAdicionar.Visible = true;
                    }

                    SqlCommand commandIdPilotoNovo = new SqlCommand("SELECT idPilotos FROM SobrePilotos WHERE Nome = '" + txtNomeAdicionar.Text + "'", connection);
                    int idPilotoNovo = (int)commandIdPilotoNovo.ExecuteScalar();

                    SqlCommand commandCampeonatoPilotos = new SqlCommand("INSERT INTO CampeonatoPilotos(idPilotos, Pontos, MelhorResultado, NumVezes) VALUES('" + idPilotoNovo + "', '0', '20', '0')", connection);
                    SqlDataReader readerCampeonato = commandCampeonatoPilotos.ExecuteReader();
                }
            Response.Redirect("EditarPilotos.aspx");
        }

        protected void guardarRemover_Click(object sender, EventArgs e)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                connection.Open();

                SqlCommand commandId = new SqlCommand("SELECT idPilotos FROM SobrePilotos WHERE Nome = '" + SelectPilotoRemover.SelectedValue + "'", connection);
                int idPiloto = (int)commandId.ExecuteScalar();

                SqlCommand commandDelPista = new SqlCommand("DELETE FROM SobrePilotos WHERE Nome = '" + SelectPilotoRemover.SelectedValue + "'", connection);
                SqlDataReader readerNomesPistas = commandDelPista.ExecuteReader();
                readerNomesPistas.Close();

                SqlCommand commandDelResultado = new SqlCommand("DELETE FROM ResultadosCorridas WHERE idPilotos = '" + idPiloto + "'", connection);
                SqlDataReader readerResultados = commandDelResultado.ExecuteReader();
                readerResultados.Close();

                SqlCommand commandDelCampeonato = new SqlCommand("DELETE FROM CampeonatoPilotos WHERE idPilotos = '" + idPiloto + "'", connection);
                SqlDataReader readerCampeonato = commandDelCampeonato.ExecuteReader();
                readerCampeonato.Close();

                lblSucessoRemover.Visible = true;
            }
            Response.Redirect("EditarPilotos.aspx");
        }

        protected void guardarEdit_Click(object sender, EventArgs e)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                connection.Open();

                SqlCommand commandidEquipa = new SqlCommand("SELECT TOP 1 idEquipa FROM SobreEquipas WHERE Nome = '" + selectEquipaEditar.SelectedValue + "'", connection);
                int idEquipa = (int)commandidEquipa.ExecuteScalar();

                SqlCommand commandUpdate = new SqlCommand("UPDATE SobrePilotos SET idEquipa = '" + idEquipa + "', nacionalidade = '" + txtNacionalidadeEditar.Text + "', Podios = '" + txtPodiosEditar.Text + "', Vitorias = '" + txtVitoriasEditar.Text + "', CorridasFeitas = '" + txtCorridasFeitasEditar.Text + "', Idade = '" + txtIdadeEditar.Text + "' WHERE Nome = '" + SelectPilotoEditar.SelectedValue + "'", connection);
                SqlDataReader readerInfos = commandUpdate.ExecuteReader();
                readerInfos.Close();

                lblSucessoEditar.Visible = true;
                if (fileBandeiraEditar.HasFile)
                {
                    byte[] imagemBytesBandeira = fileBandeiraEditar.FileBytes;
                    string imagemBandeiraString = BitConverter.ToString(imagemBytesBandeira).Replace("-", ""); // Converte para uma string hexadecimal

                    SqlCommand commandUpdateBandeira = new SqlCommand("UPDATE SobrePilotos SET bandeiraPais = CONVERT(varbinary(max), '" + imagemBandeiraString + "', 2) WHERE Nome = '" + SelectPilotoEditar.SelectedValue + "'", connection);
                    SqlDataReader readerBandeira = commandUpdateBandeira.ExecuteReader();
                    readerBandeira.Close(); // Fechar o SqlDataReader

                    lblSucessoEditar.Visible = true;
                }

                if (filePreSetEditar.HasFile)
                {
                    byte[] imagemBytesPreSet = filePreSetEditar.FileBytes;
                    string imagemPreSetString = BitConverter.ToString(imagemBytesPreSet).Replace("-", ""); // Converte para uma string hexadecimal

                    SqlCommand commandUpdatePreSet = new SqlCommand("UPDATE SobrePilotos SET PreSet = CONVERT(varbinary(max), '" + imagemPreSetString + "', 2) WHERE Nome = '" + SelectPilotoEditar.SelectedValue + "'", connection);
                    SqlDataReader readerPreSet = commandUpdatePreSet.ExecuteReader();
                    readerPreSet.Close(); // Fechar o SqlDataReader

                    lblSucessoEditar.Visible = true;
                }

                if (fileFotoEditar.HasFile)
                {
                    byte[] imagemBytesFoto = fileFotoEditar.FileBytes;
                    string imagemFotoString = BitConverter.ToString(imagemBytesFoto).Replace("-", ""); // Converte para uma string hexadecimal

                    SqlCommand commandUpdateFoto = new SqlCommand("UPDATE SobrePilotos SET Foto = CONVERT(varbinary(max), '" + imagemFotoString + "', 2) WHERE Nome = '" + SelectPilotoEditar.SelectedValue + "'", connection);
                    SqlDataReader readerFoto = commandUpdateFoto.ExecuteReader();
                    readerFoto.Close(); // Fechar o SqlDataReader

                    lblSucessoEditar.Visible = true;
                }
            }
            Response.Redirect("EditarPilotos.aspx");
        }
    }
}