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
using System.Web.Security;

namespace PAP___F1_Ticket
{
    public partial class CampeonatoConstrutores : System.Web.UI.Page
    {
        string ConnectionString = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
        string idUser = Membership.GetUser().ProviderUserKey.ToString();
        string divHtml = "";
        List<string> nomesEquipas = new List<string>();
        List<int> QuantidadePontos = new List<int>();
        List<byte[]> imagensPreset = new List<byte[]>();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["user"] == null)
                Response.Redirect("Login.aspx");

            if (!IsPostBack)
            {
                //botoes e funcionalidades admin
                using (SqlConnection connection = new SqlConnection(ConnectionString))
                {
                    connection.Open();

                    SqlCommand commandAdmin = new SqlCommand("SELECT Admin FROM Admin WHERE UserID = '" + idUser + "'", connection);
                    string validacao = (string)commandAdmin.ExecuteScalar();

                    if (validacao == "Sim")
                    {
                        botoesAdmin.Visible = true;
                    }
                    else
                    {
                        botoesAdmin.Visible = false;
                    }
                }
            }

            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                connection.Open();

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
                                divHtml += "<a class='lblPrimeiro' href='allEquipas.aspx?nome=" + Uri.EscapeDataString(nomesEquipas[i]) + "' >" + nomePrimeiro + "</a>";
                                divHtml += "<label class='PontosPrimeiro' ><b>" + pontosPrimeiro + "</b></label>";
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
        protected void editarClassificacao_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Admin/EditarClassificacaoConstrutores.aspx");
        }
    }
}