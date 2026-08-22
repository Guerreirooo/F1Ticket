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
    public partial class EditarClassificacao : System.Web.UI.Page
    {
        string ConnectionString = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
        string divHtml = "";
        string divHtml2 = "";
        List<string> nomesEquipas = new List<string>();
        List<int> QuantidadePontos = new List<int>();
        List<byte[]> imagensPreset = new List<byte[]>();
        List<string> idInputs = new List<string>();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["user"] == null)
                Response.Redirect("Login.aspx");

            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                connection.Open();
                if (!IsPostBack)
                {
                    SqlCommand command = new SqlCommand("SELECT SP.Nome FROM SobrePilotos SP INNER JOIN CampeonatoPilotos CP ON SP.idPilotos = CP.idPilotos ORDER BY CP.Pontos DESC, CP.MelhorResultado ASC, CP.NumVezes DESC", connection);
                    SqlDataReader readerNomesPilotos = command.ExecuteReader();

                    while (readerNomesPilotos.Read())
                    {
                        string valor = readerNomesPilotos["Nome"].ToString();
                        ListItem item = new ListItem(valor, valor);
                        selectPiloto.Items.Add(item);
                    }
                    readerNomesPilotos.Close();

                    SqlCommand commandRedBull = new SqlCommand("SELECT SP.PreSet FROM SobrePilotos SP INNER JOIN CampeonatoPilotos CP ON SP.idPilotos = CP.idPilotos ORDER BY CP.Pontos DESC, CP.MelhorResultado ASC, CP.NumVezes DESC", connection);
                    SqlCommand contagemRedBull = new SqlCommand("SELECT COUNT(*) FROM CampeonatoPilotos", connection);
                    SqlCommand commandLabelNomes = new SqlCommand("SELECT CONCAT(SUBSTRING(SP.nome, 1, CHARINDEX(' ', SP.nome) - 1), ' ', '<strong>', UPPER(SUBSTRING(SP.nome, CHARINDEX(' ', SP.nome) + 1, LEN(SP.nome))), '</strong>') AS Nome FROM SobrePilotos SP INNER JOIN CampeonatoPilotos CP ON SP.idPilotos = CP.idPilotos ORDER BY CP.Pontos DESC, CP.MelhorResultado ASC, CP.NumVezes DESC", connection);
                    SqlCommand commandPontos = new SqlCommand("SELECT Pontos FROM CampeonatoPilotos CP INNER JOIN SobrePilotos SP ON SP.idPilotos = CP.idPilotos ORDER BY Pontos DESC, CP.MelhorResultado ASC, CP.NumVezes DESC", connection);
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
                        int halfCount = totalCount / 2; // Quantidade da primeira metade
                        int i = 0;

                        reader.Close(); // Fechar o leitor antes de reutilizá-lo

                        using (SqlDataReader reader2 = commandRedBull.ExecuteReader()) // Criar um novo leitor
                        {
                            while (reader2.Read() && i < halfCount) // Verificar se há linhas restantes e se o contador é menor que halfCount
                            {
                                if (!reader2.IsDBNull(0))
                                {
                                    string nomePrimeiro = nomesEquipas[i];
                                    string nomeUltimo = nomesEquipas[i + halfCount];

                                    int pontosPrimeiro = QuantidadePontos[i];
                                    int pontosUltimo = QuantidadePontos[i + halfCount];

                                    int indexPrimeiro = i;
                                    int indexSegundo = i + halfCount;

                                    byte[] imagemPrimeiro = imagensPreset[indexPrimeiro];
                                    byte[] imagemSegundo = imagensPreset[indexSegundo];


                                    string[] palavrasP = nomePrimeiro.Split(' ');
                                    string[] palavrasU = nomeUltimo.Split(' ');

                                    // Obter a última palavra
                                    string ultimaPalavraP = palavrasP[palavrasP.Length - 1];
                                    // Converter a primeira letra para maiúscula e o restante para minúscula
                                    string ultimaPalavraFormatadaP = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(ultimaPalavraP.ToLower());
                                    // Substituir a última palavra no texto original
                                    palavrasP[palavrasP.Length - 1] = ultimaPalavraFormatadaP;
                                    // Reunir as palavras novamente em uma string
                                    string nomePrimeiroFormatado = string.Join(" ", palavrasP);

                                    // Obter a última palavra
                                    string ultimaPalavraU = palavrasU[palavrasU.Length - 1];
                                    // Converter a primeira letra para maiúscula e o restante para minúscula
                                    string ultimaPalavraFormatadaU = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(ultimaPalavraU.ToLower());
                                    // Substituir a última palavra no texto original
                                    palavrasU[palavrasU.Length - 1] = ultimaPalavraFormatadaU;
                                    // Reunir as palavras novamente em uma string
                                    string nomeUltimoFormatado = string.Join(" ", palavrasU);


                                    string nomePrimeiroRedirect = Regex.Replace(nomePrimeiroFormatado, "<.*?>", string.Empty);
                                    string nomeUltimoRedirect = Regex.Replace(nomeUltimo, "<.*?>", string.Empty);

                                    var nomePrimeiroSplit = nomePrimeiro.Split(' '); // Divide o nome pelo espaço em branco
                                    var sobrenomePrimeiro = nomePrimeiroSplit[nomePrimeiroSplit.Length - 1]; // Obtém o último elemento (sobrenome)
                                    sobrenomePrimeiro = sobrenomePrimeiro.ToLower();// Converte para minúsculas
                                    sobrenomePrimeiro = sobrenomePrimeiro.Replace("<strong>", "").Replace("</strong>", ""); // Remove a tag <strong>

                                    var nomeUltimoSplit = nomeUltimo.Split(' '); // Divide o nome pelo espaço em branco
                                    var sobrenomeUltimo = nomeUltimoSplit[nomeUltimoSplit.Length - 1]; // Obtém o último elemento (sobrenome)
                                    sobrenomeUltimo = sobrenomeUltimo.ToLower();// Converte para minúsculas
                                    sobrenomeUltimo = sobrenomeUltimo.Replace("<strong>", "").Replace("</strong>", ""); // Remove a tag <strong>

                                    divHtml += "<div>";
                                    divHtml2 += "<div>";
                                    divHtml += "<a class='lblPrimeiro' >" + nomePrimeiro + "</a>";
                                    divHtml2 += "<a class='lblPrimeiro' >" + nomeUltimo + "</a>";
                                    divHtml += "<asp:TextBox runat='server' id='pontos" + indexPrimeiro + "' class='PontosPrimeiro' ><b>" + pontosPrimeiro + "</b></asp:TextBox>";
                                    divHtml2 += "<asp:TextBox runat='server' id='pontos" + indexSegundo + "' class='PontosPrimeiro' ><b>" + pontosUltimo + "</b></asp:TextBox>";
                                    divHtml += "<img src='data:image/png;base64," + Convert.ToBase64String(imagemPrimeiro) + "' class='PreSet' />";
                                    divHtml2 += "<img src='data:image/png;base64," + Convert.ToBase64String(imagemSegundo) + "' class='PreSet' />";
                                    divHtml += "</div>";
                                    divHtml2 += "</div>";

                                    i++;
                                }
                            }
                        }
                    }
                    imagemteste.InnerHtml = divHtml;
                    imagemultimos.InnerHtml = divHtml2;
                }
            }
        }

        protected void guardarAlteracoes_Click(object sender, EventArgs e)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                connection.Open();

                SqlCommand commandUpdatePontos = new SqlCommand("UPDATE CampeonatoPilotos SET Pontos = '" + txtPontos.Text + "' FROM CampeonatoPilotos CP INNER JOIN SobrePilotos SP ON SP.idPilotos = CP.idPilotos WHERE SP.Nome = '" + selectPiloto.SelectedValue + "'", connection);
                int UpdatePontos = (int)commandUpdatePontos.ExecuteNonQuery();

                SqlCommand commandUpdateMelhorResultado = new SqlCommand("UPDATE CampeonatoPilotos SET MelhorResultado = '" + txtMelhorResultado.Text + "' FROM CampeonatoPilotos CP INNER JOIN SobrePilotos SP ON SP.idPilotos = CP.idPilotos WHERE SP.Nome = '" + selectPiloto.SelectedValue + "'", connection);
                int UpdateMelhorResultado = (int)commandUpdateMelhorResultado.ExecuteNonQuery();

                SqlCommand commandUpdateNumVezes = new SqlCommand("UPDATE CampeonatoPilotos SET NumVezes = '" + txtNumVezes.Text + "' FROM CampeonatoPilotos CP INNER JOIN SobrePilotos SP ON SP.idPilotos = CP.idPilotos WHERE SP.Nome = '" + selectPiloto.SelectedValue + "'", connection);
                int UpdateNumVezes = (int)commandUpdateNumVezes.ExecuteNonQuery();

                Response.Redirect("~/Admin/EditarClassificacao.aspx");
            }

        }

        protected void cancelar_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/PaginaInicial.aspx");
        }

    }
}