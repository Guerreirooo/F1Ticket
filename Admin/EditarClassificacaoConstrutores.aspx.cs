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

namespace PAP___F1_Ticket.Admin
{
    public partial class EditarClassificacaoConstrutores : System.Web.UI.Page
    {
        string ConnectionString = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
        string divHtml = "";
        List<string> nomesEquipas = new List<string>();
        List<int> QuantidadePontos = new List<int>();
        List<byte[]> imagensPreset = new List<byte[]>();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["user"] == null)
                Response.Redirect("Login.aspx");

            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                connection.Open();
                if (!IsPostBack)
                {
                    SqlCommand command = new SqlCommand("SELECT SE.Nome FROM SobreEquipas SE INNER JOIN CampeonatoConstrutores CC ON SE.idEquipa = CC.idEquipa ORDER BY CC.Pontos DESC, CC.MelhorResultado ASC, CC.NumVezes DESC", connection);
                    SqlDataReader readerNomesEquipas = command.ExecuteReader();

                    while (readerNomesEquipas.Read())
                    {
                        string valor = readerNomesEquipas["Nome"].ToString();
                        ListItem item = new ListItem(valor, valor);
                        selectEquipa.Items.Add(item);
                    }
                    readerNomesEquipas.Close();


                    SqlCommand commandRedBull = new SqlCommand("SELECT SE.PreSet FROM SobreEquipas SE INNER JOIN CampeonatoConstrutores CC ON SE.idEquipa = CC.idEquipa ORDER BY CC.Pontos DESC, CC.MelhorResultado ASC, CC.NumVezes DESC", connection);
                    SqlCommand contagemRedBull = new SqlCommand("SELECT COUNT(*) FROM CampeonatoConstrutores", connection);
                    SqlCommand commandLabelNomes = new SqlCommand("SELECT UPPER(SE.Nome) AS Nome FROM SobreEquipas SE INNER JOIN CampeonatoConstrutores CC ON SE.idEquipa = CC.idEquipa ORDER BY CC.Pontos DESC, CC.MelhorResultado ASC, CC.NumVezes DESC", connection);
                    SqlCommand commandPontos = new SqlCommand("SELECT CC.Pontos FROM CampeonatoConstrutores CC INNER JOIN SobreEquipas SE ON CC.idEquipa = SE.idEquipa ORDER BY Pontos DESC, CC.MelhorResultado ASC, CC.NumVezes DESC", connection);
                    int count = (int)contagemRedBull.ExecuteScalar();

                    using (SqlDataReader reader = commandLabelNomes.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            string nome = reader.GetString(0);
                            nomesEquipas.Add(nome);
                        }
                    }
                    using (SqlDataReader reader = commandPontos.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            int pontos = reader.GetInt32(0);
                            QuantidadePontos.Add(pontos);
                        }
                    }

                    using (SqlDataReader reader = commandRedBull.ExecuteReader())
                    {
                        int img = 0;
                        while (reader.Read())
                        {
                            if (!reader.IsDBNull(0))
                            {
                                byte[] imagemBinaria = (byte[])reader.GetValue(0);
                                imagensPreset.Add(imagemBinaria);
                            }
                            img++;
                        }

                        int totalCount = nomesEquipas.Count;
                        int halfCount = totalCount / 2;
                        int i = 0;

                        reader.Close(); // Fechar o leitor antes de reutilizá-lo

                        using (SqlDataReader reader2 = commandRedBull.ExecuteReader()) // Criar um novo leitor
                        {
                            while (reader2.Read() && i < count) // Verificar se há linhas restantes e se o contador é menor que halfCount
                            {
                                if (!reader2.IsDBNull(0))
                                {

                                    string nomePrimeiro = nomesEquipas[i];
                                    int pontosPrimeiro = QuantidadePontos[i];
                                    int indexPrimeiro = i;
                                    byte[] imagemPrimeiro = imagensPreset[indexPrimeiro];

                                    var nomePrimeiroSplit = nomePrimeiro.Split(' ');  // Divide o nome pelo espaço em branco
                                    var primeiroNome = nomePrimeiroSplit[1];
                                    primeiroNome = primeiroNome.ToLower();// Converte para minúsculas
                                    primeiroNome = primeiroNome.Replace("<strong>", "").Replace("</strong>", ""); // Remove a tag <strong>

                                    divHtml += "<div>";
                                    divHtml += "<a class='lblPrimeiro' >" + nomePrimeiro + "</a>";
                                    divHtml += "<asp:TextBox runat='server' id='pontos" + indexPrimeiro + "' class='PontosPrimeiro' ><b>" + pontosPrimeiro + "</b></asp:TextBox>";
                                    divHtml += "<img src='data:image/png;base64," + Convert.ToBase64String(imagemPrimeiro) + "' class='PreSet' />";
                                    divHtml += "</div>";

                                    i++;
                                }
                            }
                        }
                    }
                    imagemteste.InnerHtml = divHtml;
                }
            }
        }

        protected void guardarAlteracoes_Click(object sender, EventArgs e)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                connection.Open();

                SqlCommand commandUpdatePontos = new SqlCommand("UPDATE CampeonatoConstrutores SET Pontos = '" + txtPontos.Text + "' FROM CampeonatoConstrutores CC INNER JOIN SobreEquipas SE ON SE.idEquipa = CC.idEquipa WHERE SE.Nome = '" + selectEquipa.SelectedValue + "'", connection);
                int UpdatePontos = (int)commandUpdatePontos.ExecuteNonQuery();

                SqlCommand commandUpdateMelhorResultado = new SqlCommand("UPDATE CampeonatoConstrutores SET MelhorResultado = '" + txtMelhorResultado.Text + "' FROM CampeonatoConstrutores CC INNER JOIN SobreEquipas SE ON SE.idEquipa = CC.idEquipa WHERE SE.Nome = '" + selectEquipa.SelectedValue + "'", connection);
                int UpdateMelhorResultado = (int)commandUpdateMelhorResultado.ExecuteNonQuery();

                SqlCommand commandUpdateNumVezes = new SqlCommand("UPDATE CampeonatoConstrutores SET NumVezes = '" + txtNumVezes.Text + "' FROM CampeonatoConstrutores CC INNER JOIN SobreEquipas SE ON SE.idEquipa = CC.idEquipa WHERE SE.Nome = '" + selectEquipa.SelectedValue + "'", connection);
                int UpdateNumVezes = (int)commandUpdateNumVezes.ExecuteNonQuery();

                Response.Redirect("~/Admin/EditarClassificacaoConstrutores.aspx");
            }

        }

        protected void cancelar_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/PaginaInicial.aspx");
        }
    }
}