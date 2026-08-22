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
    public partial class EditarEquipas : System.Web.UI.Page
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

                    SqlCommand command = new SqlCommand("SELECT Nome FROM SobreEquipas", connection);
                    SqlDataReader readerNomesPilotos = command.ExecuteReader();

                    while (readerNomesPilotos.Read())
                    {
                        string valor = readerNomesPilotos["Nome"].ToString();
                        ListItem item = new ListItem(valor, valor);
                        SelectEquipaEditar.Items.Add(item);
                        SelectEquipaRemover.Items.Add(item);
                    }
                    readerNomesPilotos.Close();
                }
            }
        }

        protected void cancelar_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/SobreEquipas.aspx");
        }

        protected void guardarAdd_Click(object sender, EventArgs e)
        {
                byte[] imgarray = fileBandeiraAdicionar.FileBytes;
                byte[] imagemPreSet = filePreSetAdicionar.FileBytes;
                byte[] imagemEmblema = fileEmblemaAdicionar.FileBytes;
                byte[] imagemCarro = fileCarroAdicionar.FileBytes;

                using (SqlConnection connection = new SqlConnection(ConnectionString))
                {
                    connection.Open();

                    string query = "INSERT INTO SobreEquipas (Nome, PreSet, Emblema, Podios, Vitorias, AnoDebut, CorridasFeitas, Nacionalidade, bandeiraPais, Carro) VALUES (@Nome, @PreSet, @Emblema, @Podios, @Vitorias, @AnoDebut, @CorridasFeitas, @nacionalidade, @bandeiraPais, @Carro)";

                    using (SqlCommand commandInsert = new SqlCommand(query, connection))
                    {
                        commandInsert.Parameters.AddWithValue("@Nome", txtNomeAdicionar.Text);
                        commandInsert.Parameters.AddWithValue("@PreSet", imagemPreSet);
                        commandInsert.Parameters.AddWithValue("@Emblema", imagemEmblema);
                        commandInsert.Parameters.AddWithValue("@Podios", txtPodiosAdicionar.Text);
                        commandInsert.Parameters.AddWithValue("@Vitorias", txtVitoriasAdicionar.Text);
                        commandInsert.Parameters.AddWithValue("@AnoDebut", txtAnoDebutAdicionar.Text);
                        commandInsert.Parameters.AddWithValue("@CorridasFeitas", txtCorridasFeitasAdicionar.Text);
                        commandInsert.Parameters.AddWithValue("@nacionalidade", txtNacionalidadeAdicionar.Text);
                        commandInsert.Parameters.AddWithValue("@bandeiraPais", imgarray);
                        commandInsert.Parameters.AddWithValue("@Carro", imagemCarro);

                        int rowsAffected = commandInsert.ExecuteNonQuery();

                    }

                    SqlCommand commandIdEquipaNova = new SqlCommand("SELECT idEquipa FROM SobreEquipas WHERE Nome = '" + txtNomeAdicionar.Text + "'", connection);
                    int idEquipaNova = (int)commandIdEquipaNova.ExecuteScalar();

                    SqlCommand commandCampeonatoPilotos = new SqlCommand("INSERT INTO CampeonatoConstrutores(idEquipa, Pontos, MelhorResultado, NumVezes) VALUES('" + idEquipaNova + "', '0', '20', '0')", connection);
                    SqlDataReader readerCampeonato = commandCampeonatoPilotos.ExecuteReader();
                }
            Response.Redirect("EditarEquipas.aspx");
        }

        protected void guardarRemover_Click(object sender, EventArgs e)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                connection.Open();

                SqlCommand commandId = new SqlCommand("SELECT idEquipa FROM SobreEquipas WHERE Nome = '" + SelectEquipaRemover.SelectedValue + "'", connection);
                int idEquipa = (int)commandId.ExecuteScalar();

                SqlCommand commandDelPista = new SqlCommand("DELETE FROM SobreEquipas WHERE Nome = '" + SelectEquipaRemover.SelectedValue + "'", connection);
                SqlDataReader readerNomesPistas = commandDelPista.ExecuteReader();
                readerNomesPistas.Close();

                SqlCommand commandDelResultado = new SqlCommand("DELETE FROM CampeonatoConstrutores WHERE idEquipa = '" + idEquipa + "'", connection);
                SqlDataReader readerResultados = commandDelResultado.ExecuteReader();
                readerResultados.Close();

            }
            Response.Redirect("EditarEquipas.aspx");
        }

        protected void guardarEdit_Click(object sender, EventArgs e)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                connection.Open();

                SqlCommand commandUpdate = new SqlCommand("UPDATE SobreEquipas SET Podios = '" + txtPodiosEditar.Text + "', Vitorias = '" + txtVitoriasEditar.Text + "', CorridasFeitas = '" + txtCorridasFeitasEditar.Text + "', Nacionalidade = '" + txtNacionalidadeEditar.Text + "' WHERE Nome = '" + SelectEquipaEditar.SelectedValue + "'", connection);
                SqlDataReader readerInfos = commandUpdate.ExecuteReader();
                readerInfos.Close();

                if (fileBandeiraEditar.HasFile)
                {
                    byte[] imagemBytesBandeira = fileBandeiraEditar.FileBytes;
                    string imagemBandeiraString = BitConverter.ToString(imagemBytesBandeira).Replace("-", ""); // Converte para uma string hexadecimal

                    SqlCommand commandUpdateBandeira = new SqlCommand("UPDATE SobreEquipas SET bandeiraPais = CONVERT(varbinary(max), '" + imagemBandeiraString + "', 2) WHERE Nome = '" + SelectEquipaEditar.SelectedValue + "'", connection);
                    SqlDataReader readerBandeira = commandUpdateBandeira.ExecuteReader();
                    readerBandeira.Close();

                }

                if (filePreSetEditar.HasFile)
                {
                    byte[] imagemBytesPreSet = filePreSetEditar.FileBytes;
                    string imagemPreSetString = BitConverter.ToString(imagemBytesPreSet).Replace("-", ""); // Converte para uma string hexadecimal

                    SqlCommand commandUpdatePreSet = new SqlCommand("UPDATE SobreEquipas SET PreSet = CONVERT(varbinary(max), '" + imagemPreSetString + "', 2) WHERE Nome = '" + SelectEquipaEditar.SelectedValue + "'", connection);
                    SqlDataReader readerPreSet = commandUpdatePreSet.ExecuteReader();
                    readerPreSet.Close();

                }

                if (fileEmblemaEditar.HasFile)
                {
                    byte[] imagemBytesEmblema = fileEmblemaEditar.FileBytes;
                    string imagemEmblemaString = BitConverter.ToString(imagemBytesEmblema).Replace("-", ""); // Converte para uma string hexadecimal

                    SqlCommand commandUpdateEmblema = new SqlCommand("UPDATE SobreEquipas SET Emblema = CONVERT(varbinary(max), '" + imagemEmblemaString + "', 2) WHERE Nome = '" + SelectEquipaEditar.SelectedValue + "'", connection);
                    SqlDataReader readerEmblema = commandUpdateEmblema.ExecuteReader();
                    readerEmblema.Close();

                }

                if (fileCarroEditar.HasFile)
                {
                    byte[] imagemBytesCarro = fileCarroEditar.FileBytes;
                    string imagemCarroString = BitConverter.ToString(imagemBytesCarro).Replace("-", ""); // Converte para uma string hexadecimal

                    SqlCommand commandUpdateCarro = new SqlCommand("UPDATE SobreEquipas SET Carro = CONVERT(varbinary(max), '" + imagemCarroString + "', 2) WHERE Nome = '" + SelectEquipaEditar.SelectedValue + "'", connection);
                    SqlDataReader readerCarro = commandUpdateCarro.ExecuteReader();
                    readerCarro.Close();

                }

            }
            Response.Redirect("EditarEquipas.aspx");
        }
    }
}