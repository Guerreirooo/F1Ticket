using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Web.Security;
using System.Text.RegularExpressions;
using System.Globalization;

namespace PAP___F1_Ticket
{
    public partial class Resultados : System.Web.UI.Page
    {
        string ConnectionString = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;

        string divHtml = "";
        string htmlVoltaRapida = "";
        List<string> nomesPilotos = new List<string>();
        List<string> Tempos = new List<string>();
        List<byte[]> imagensPreset = new List<byte[]>();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["user"] == null)
                Response.Redirect("Login.aspx");



            if (Session["nomePista"] == null)
            {
                // Obtém o valor da QueryString e armazena na variável de sessão
                string nomePistaSession = Request.QueryString["nomePista"];
                Session["nomePista"] = nomePistaSession;
            }

            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                connection.Open();

                string nomePista = Session["nomePista"] as string;

                SqlCommand commandTeste = new SqlCommand("SELECT idPista FROM Pistas WHERE nomePista = '" + nomePista + "'", connection);
                int Teste = (int)commandTeste.ExecuteScalar();

                SqlCommand commandTeste2 = new SqlCommand("SELECT COUNT(idPista) FROM ResultadosCorridas WHERE idPista = '" + Teste + "'", connection);
                int Teste2 = (int)commandTeste2.ExecuteScalar();

                if (Teste2 == 0)
                {
                    lblErro.Visible = true;
                }
                else
                {
                    divPistas.Visible = true;
                    divVoltaRapida.Visible = true;
                    divcontainer.Visible = true;
                    lblVoltaRapida.Visible = true;
                    lblLegenda.Visible = true;
                    lblresultados.Visible = true;
                    lblErro.Visible = false;
                    VoltaRapida();
                    if (!IsPostBack)
                    {
                            // Id Pista
                            SqlCommand commandID = new SqlCommand("SELECT MAX(idPista) FROM Pistas WHERE nomePista = '" + nomePista + "'", connection);
                            int idPista = (int)commandID.ExecuteScalar();
                            // Nome da corrida
                            SqlCommand commandNomeCorrida = new SqlCommand("SELECT nomeCorrida FROM Pistas WHERE nomePista = '" + nomePista + "'", connection);
                            string nomeCorrida = (string)commandNomeCorrida.ExecuteScalar();

                            lblNomeCorrida.InnerText = nomeCorrida;
                            // Bandeira do país
                            SqlCommand commandImagemBandeira = new SqlCommand("SELECT bandeiraPais FROM Pistas WHERE nomePista = '" + nomePista + "'", connection);
                            byte[] ImagemBandeira = (byte[])commandImagemBandeira.ExecuteScalar();

                            string imagemSrc = "data:image/png;base64," + Convert.ToBase64String(ImagemBandeira);
                            imgBandeira.ImageUrl = imagemSrc;
                            // Bancadas Pista
                            SqlCommand commandImagemBancada = new SqlCommand("SELECT bancadas FROM Pistas WHERE nomePista = '" + nomePista + "'", connection);
                            byte[] ImagemBancada = (byte[])commandImagemBancada.ExecuteScalar();

                            imagemSrc = "data:image/png;base64," + Convert.ToBase64String(ImagemBancada);
                            imgBancadas.ImageUrl = imagemSrc;

                            SqlCommand commandLabelNomes = new SqlCommand("SELECT CONCAT(SUBSTRING(SP.nome, 1, CHARINDEX(' ', SP.nome) - 1), ' ', '<strong>', UPPER(SUBSTRING(SP.nome, CHARINDEX(' ', SP.nome) + 1, LEN(SP.nome))), '</strong>') AS Nome FROM SobrePilotos SP INNER JOIN ResultadosCorridas RC ON SP.idPilotos = RC.idPilotos INNER JOIN Pistas P on RC.idPista = P.idPista WHERE nomePista = '" + nomePista + "'", connection);
                            SqlCommand commandLabelTempos = new SqlCommand("SELECT RC.Tempo FROM ResultadosCorridas RC INNER JOIN Pistas P on RC.idPista = P.idPista where P.nomePista = '" + nomePista + "'", connection);
                            SqlCommand commandPreSet = new SqlCommand("SELECT SP.PreSet FROM SobrePilotos SP INNER JOIN ResultadosCorridas RC ON SP.idPilotos = RC.idPilotos WHERE RC.idPista = '" + idPista + "'", connection);

                            using (SqlDataReader reader = commandLabelNomes.ExecuteReader())
                            {
                                while (reader.Read())
                                {
                                    string nome = reader.GetString(0);
                                    nomesPilotos.Add(nome);
                                }
                            }
                            using (SqlDataReader reader = commandLabelTempos.ExecuteReader())
                            {
                                while (reader.Read())
                                {
                                    string nome = reader.GetString(0);
                                    Tempos.Add(nome);
                                }
                            }
                            using (SqlDataReader reader = commandPreSet.ExecuteReader())
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

                                int totalCount = nomesPilotos.Count;
                                int halfCount = totalCount / 2; // Quantidade da primeira metade
                                int i = 0;
                                int l = 1;

                                reader.Close();

                                using (SqlDataReader reader2 = commandLabelNomes.ExecuteReader()) // Criar um novo leitor
                                {
                                    while (reader2.Read() && i < halfCount) // Verificar se há linhas restantes e se o contador é menor que halfCount
                                    {
                                        if (!reader2.IsDBNull(0))
                                        {
                                            string nomePrimeiro = nomesPilotos[i];
                                            string nomeUltimo = nomesPilotos[i + halfCount];

                                            string tempoPrimeiro = Tempos[i];
                                            string tempoUltimo = Tempos[i + halfCount];

                                            int indexPrimeiro = i;
                                            int indexSegundo = i + halfCount;

                                            int ultimosLugares = l + halfCount;

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

                                            divHtml += "<div style='position: relative;'>";
                                            if (l > 9)
                                            {
                                                divHtml += "<label id='PrimeiroLugar' class='lblPrimeiro' style='margin-left: -0.7%;'><b>" + l + "</b></label>";
                                            }
                                            else
                                            {
                                                divHtml += "<label id='PrimeiroLugar' class='lblPrimeiro'><b>" + l + "</b></label>";
                                            }
                                            divHtml += "<a class='lblPrimeiroNome' href='../allPilotos.aspx?nome=" + Uri.EscapeDataString(nomePrimeiroRedirect) + "' >" + nomePrimeiro + "</a>";
                                            divHtml += "<label id='TempoPrimeiro' class='lblPrimeiroTempo'><b>" + tempoPrimeiro + "</b></label>";

                                            divHtml += "<label id='DecimoPrimeiroLugar' class='lblDecimoPrimeiro'><b>" + ultimosLugares + "</b></label>";
                                            divHtml += "<a class='lblDecimoPrimeiroNome' href='../allPilotos.aspx?nome=" + Uri.EscapeDataString(nomeUltimoRedirect) + "' >" + nomeUltimo + "</a>";
                                            divHtml += "<label id='TempoDecimoPrimeiro' class='lblDecimoPrimeiroTempo'><b>" + tempoUltimo + "</b></label>";
                                            divHtml += "<img src='data:image/png;base64," + Convert.ToBase64String(imagemPrimeiro) + "' class='PreSet' />";
                                            divHtml += "<img src='data:image/png;base64," + Convert.ToBase64String(imagemSegundo) + "' class='PreSetEscondido' />";
                                            divHtml += "</div>";

                                            i++;
                                            l++;
                                        }
                                    }
                                }
                            }
                            divLugares.InnerHtml = divHtml;
                        }
                    }
                }
            }
        private void VoltaRapida()
        {
            string nomePista = Session["nomePista"] as string;

            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                connection.Open();

                SqlCommand commandPreSet = new SqlCommand("SELECT SP.PreSet FROM SobrePilotos SP INNER JOIN VoltaRapida VR ON SP.idPilotos = VR.idPilotos INNER JOIN Pistas P ON P.idPista = VR.idPista WHERE nomePista = '" + nomePista + "'", connection);
                byte[] PreSet = (byte[])commandPreSet.ExecuteScalar();

                SqlCommand commandTempo = new SqlCommand("SELECT VR.Tempo FROM VoltaRapida VR INNER JOIN Pistas P ON VR.idPista = P.idPista WHERE nomePista = '" + nomePista + "'", connection);
                string tempo = (string)commandTempo.ExecuteScalar();

                SqlCommand commandLabelNomes = new SqlCommand("SELECT CONCAT(SUBSTRING(SP.nome, 1, CHARINDEX(' ', SP.nome) - 1), ' ', '<strong>', UPPER(SUBSTRING(SP.nome, CHARINDEX(' ', SP.nome) + 1, LEN(SP.nome))), '</strong>') AS Nome FROM SobrePilotos SP INNER JOIN VoltaRapida RP ON SP.idPilotos = RP.idPilotos INNER JOIN Pistas P ON RP.idPista = P.idPista WHERE nomePista ='" + nomePista + "'", connection);
                string NomePilotoVoltaRapida = (string)commandLabelNomes.ExecuteScalar();

                string[] palavrasP = NomePilotoVoltaRapida.Split(' ');

                // Obter a última palavra
                string ultimaPalavraP = palavrasP[palavrasP.Length - 1];
                // Converter a primeira letra para maiúscula e o restante para minúscula
                string ultimaPalavraFormatadaP = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(ultimaPalavraP.ToLower());
                // Substituir a última palavra no texto original
                palavrasP[palavrasP.Length - 1] = ultimaPalavraFormatadaP;
                // Reunir as palavras novamente em uma string
                string nomePrimeiroFormatado = string.Join(" ", palavrasP);

                string nomePrimeiroRedirect = Regex.Replace(nomePrimeiroFormatado, "<.*?>", string.Empty);

                htmlVoltaRapida += "<div style='position: relative;'>";
                htmlVoltaRapida += "<a class='lblPilotoVoltaRapida' href='../allPilotos.aspx?nome=" + Uri.EscapeDataString(nomePrimeiroRedirect) + "' >" + NomePilotoVoltaRapida + "</a>";
                htmlVoltaRapida += "<label class='lblTempoVoltaRapida' style='color: #e710ce'><b>" + tempo + "</b></label>";
                htmlVoltaRapida += "<img src='data:image/png;base64," + Convert.ToBase64String(PreSet) + "' style='height: 30px; width: 100%;'/>";
                htmlVoltaRapida += "</div>";

                divVoltaRapida.InnerHtml = htmlVoltaRapida;
            }
        }
    }
}