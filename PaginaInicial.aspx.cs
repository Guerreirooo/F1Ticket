using System;
using System.IO;
using System.Globalization;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Text;
using System.Data;
using System.Web.Security;
using System.Text.RegularExpressions;

namespace PAP___F1_Ticket
{
    public partial class PaginaInicial : System.Web.UI.Page
    {
        string ConnectionString = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
        DateTime dataInicioDateTime;
        string idUser = Membership.GetUser().ProviderUserKey.ToString();
        string divPista = "";
        string divPiloto = "";
        string textoa = "";
        int quantidadeExibicao = 3;
        List<string> nomesPilotos = new List<string>();
        List<int> QuantidadePontos = new List<int>();
        List<byte[]> imagensPreset = new List<byte[]>();
        List<string> nomesPistas = new List<string>();
        List<string> DataPistasInicio = new List<string>();
        List<string> DataPistasFim = new List<string>();
        List<string> DataPistasCombinadas = new List<string>();
        List<byte[]> bandeirasPaises = new List<byte[]>();
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

                    // Limpar a variável de sessão "nomePista"
                    Session["nomePista"] = null;
            }
            else
            {
                if (Session["nomePista"] == null)
                {
                    // Obtém o valor da QueryString e armazena na variável de sessão
                    string nomePistaSession = Request.QueryString["nomePista"];
                    Session["nomePista"] = nomePistaSession;
                }
            }
            CampP();
            BindGrid();
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                connection.Open();

                SqlCommand commandNomes = new SqlCommand("SELECT nomePista FROM (SELECT nomePista, dataCorridaInicio, 1 AS sortOrder FROM Pistas WHERE dataCorridaInicio >= GETDATE() UNION SELECT nomePista, dataCorridaInicio, 2 AS sortOrder FROM Pistas WHERE dataCorridaInicio < GETDATE()) AS subquery ORDER BY sortOrder, dataCorridaInicio ASC;", connection);
                using (SqlDataReader reader = commandNomes.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        string nomePista = reader.GetString(0);
                        nomesPistas.Add(nomePista);
                    }
                }

                foreach (string nomePista in nomesPistas)
                {
                    SqlCommand commandBandeira = new SqlCommand("SELECT bandeiraPais FROM (SELECT bandeiraPais, dataCorridaInicio, 1 AS sortOrder FROM Pistas WHERE dataCorridaInicio >= GETDATE() UNION SELECT bandeiraPais, dataCorridaInicio, 2 AS sortOrder FROM Pistas WHERE dataCorridaInicio < GETDATE()) AS subquery ORDER BY sortOrder, dataCorridaInicio ASC;", connection);
                    using (SqlDataReader reader = commandBandeira.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            byte[] bandeira = (byte[])reader.GetValue(0);
                            bandeirasPaises.Add(bandeira);
                        }
                    }

                    SqlCommand commandDatas = new SqlCommand("SELECT dataCorridaInicio, dataCorridaFim FROM (SELECT nomePista, dataCorridaInicio, dataCorridaFim, 1 AS sortOrder FROM Pistas WHERE dataCorridaInicio >= GETDATE() UNION SELECT nomePista, dataCorridaInicio, dataCorridaFim, 2 AS sortOrder FROM Pistas WHERE dataCorridaInicio < GETDATE()) AS subquery ORDER BY sortOrder, dataCorridaInicio ASC, dataCorridaFim ASC;", connection);


                    using (SqlDataReader reader = commandDatas.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            DateTime dataCorridaInicio = reader.GetDateTime(0);
                            string dataInicioString = dataCorridaInicio.ToString("yyyy-MM-dd HH:mm:ss");
                            DataPistasInicio.Add(dataInicioString);

                            DateTime dataCorridaFim = reader.GetDateTime(1);
                            string dataFimString = dataCorridaFim.ToString("yyyy-MM-dd HH:mm:ss");
                            DataPistasFim.Add(dataFimString);
                        }
                    }
                }
            }
            if (nomesPistas.Count > 0)
            {
                StringBuilder htmlBuilder = new StringBuilder();
                for (int i = 0; i < nomesPistas.Count; i++)
                {
                    divPista += "<div class='box'>";
                    divPista += "<img src ='data:image/png;base64," + Convert.ToBase64String(bandeirasPaises[i]) + "' style = 'margin-left: 1.9%;'/> ";
                    divPista += "<table style = 'width: 100 %; text-align: center; margin-bottom: 5%;' >";
                    divPista += "<tr>";
                    divPista += "<td>";
                    divPista += "<h3> Grande Prémio de " + nomesPistas[i] + "</h3>";
                    divPista += "</td>";
                    divPista += "</tr>";
                    divPista += "<tr>";
                    divPista += "<td>";


                            string dataInicio = DataPistasInicio[i];
                            string dataFim = DataPistasFim[i];

                            // Extrai o dia e mês da data de início
                            int diaInicio = int.Parse(dataInicio.Substring(8, 2));
                            int mesInicio = int.Parse(dataInicio.Substring(5, 2));

                            // Extrai o dia e mês da data de fim
                            int diaFim = int.Parse(dataFim.Substring(8, 2));
                            int mesFim = int.Parse(dataFim.Substring(5, 2));

                            // Combina os valores em uma única string no formato "DD-MM MMM"
                            string dataCombinada = $"{diaInicio:D2}-{diaFim:D2} {GetNomeMesAbreviado(mesInicio.ToString())}";

                            if (mesInicio != mesFim)
                            {
                                // Se as datas estiverem em meses diferentes, exibe o mês duas vezes
                                dataCombinada = $"{diaInicio:D2} {GetNomeMesAbreviado(mesInicio.ToString())}-{diaFim:D2} {GetNomeMesAbreviado(mesFim.ToString())}";
                            }
                            DateTime dataLimite = new DateTime(2023, DateTime.Now.Month, DateTime.Now.Day, DateTime.Now.Hour, DateTime.Now.Minute, DateTime.Now.Second);
                            if (DateTime.TryParse(dataInicio, out dataInicioDateTime))
                            {
                                if (dataInicioDateTime > dataLimite)
                                {
                                    textoa = "Info";
                                }
                                else
                                {
                                    textoa = "Resultados";
                                }
                            }
                            else
                            {
                                
                            }

                            DataPistasCombinadas.Add(dataCombinada);

                    divPista += "<b>" + DataPistasCombinadas[i] + "</b>";
                    divPista += "</td>";
                    divPista += "</tr>";
                    divPista += "</table>";
                    if (DateTime.Parse(DataPistasInicio[i]) < dataLimite)
                    {
                        divPista += "<a href='PaginasPistas/Resultados.aspx?nomePista=" + Uri.EscapeDataString(nomesPistas[i]) + "' class='btnComprar'>" + textoa + "</a>";
                    }
                    else
                    {
                        divPista += "<a href='PaginasPistas/ComprarBilhete.aspx?nomePista=" + Uri.EscapeDataString(nomesPistas[i]) + "' class='btnComprar'>" + textoa + "</a>";
                    }
                    divPista += "</div>";
                }
                divPistas.InnerHtml = divPista;

            }    
        }
        private string GetNomeMesAbreviado(string mes)
        {
            switch (mes)
            {
                 case "1":
                     return "JAN";
                 case "2":
                     return "FEV";
                 case "3":
                     return "MAR";
                 case "4":
                     return "APR";
                 case "5":
                     return "MAI";
                 case "6":
                     return "JUN";
                 case "7":
                     return "JUL";
                 case "8":
                     return "AUG";
                 case "9":
                     return "SEP";
                 case "10":
                     return "OUT";
                 case "11":
                     return "NOV";
                 case "12":
                     return "DEZ";

                 default:
                         return "";
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
        private void CampP()
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                connection.Open();

                SqlCommand commandRedBull = new SqlCommand("SELECT SP.PreSet FROM SobrePilotos SP INNER JOIN CampeonatoPilotos CP ON SP.idPilotos = CP.idPilotos ORDER BY CP.Pontos DESC; ", connection);
                SqlCommand contagemRedBull = new SqlCommand("SELECT COUNT(*) FROM CampeonatoPilotos", connection);
                SqlCommand commandLabelNomes = new SqlCommand("SELECT CONCAT(SUBSTRING(SP.nome, 1, CHARINDEX(' ', SP.nome) - 1), ' ', '<strong>', UPPER(SUBSTRING(SP.nome, CHARINDEX(' ', SP.nome) + 1, LEN(SP.nome))), '</strong>') AS Nome FROM SobrePilotos SP INNER JOIN CampeonatoPilotos CP ON SP.idPilotos = CP.idPilotos ORDER BY CP.Pontos DESC, CP.MelhorResultado ASC, CP.NumVezes DESC", connection);
                SqlCommand commandPontos = new SqlCommand("SELECT Pontos FROM CampeonatoPilotos ORDER BY Pontos DESC", connection);
                int count = (int)contagemRedBull.ExecuteScalar();

                using (SqlDataReader reader = commandLabelNomes.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        string nome = reader.GetString(0);
                        nomesPilotos.Add(nome);
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

                    int totalCount = nomesPilotos.Count;
                    int j = 0;

                    reader.Close(); // Fechar o leitor antes de reutilizá-lo

                    using (SqlDataReader reader2 = commandRedBull.ExecuteReader()) // Criar um novo leitor
                    {
                        for (j = 0; j < nomesPilotos.Count && j < quantidadeExibicao; j++)
                        {
                            string nomePrimeiro = nomesPilotos[j];

                            int pontosPrimeiro = QuantidadePontos[j];

                            int indexPrimeiro = j;

                            byte[] imagemPrimeiro = imagensPreset[indexPrimeiro];

                            string[] palavrasP = nomePrimeiro.Split(' ');

                            // Obter a última palavra
                            string ultimaPalavraP = palavrasP[palavrasP.Length - 1];
                            // Converter a primeira letra para maiúscula e o restante para minúscula
                            string ultimaPalavraFormatadaP = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(ultimaPalavraP.ToLower());
                            // Substituir a última palavra no texto original
                            palavrasP[palavrasP.Length - 1] = ultimaPalavraFormatadaP;
                            // Reunir as palavras novamente em uma string
                            string nomePrimeiroFormatado = string.Join(" ", palavrasP);

                            string nomePrimeiroRedirect = Regex.Replace(nomePrimeiroFormatado, "<.*?>", string.Empty);

                            var nomePrimeiroSplit = nomePrimeiro.Split(' '); // Divide o nome pelo espaço em branco
                            var sobrenomePrimeiro = nomePrimeiroSplit[nomePrimeiroSplit.Length - 1]; // Obtém o último elemento (sobrenome)
                            sobrenomePrimeiro = sobrenomePrimeiro.ToLower();// Converte para minúsculas
                            sobrenomePrimeiro = sobrenomePrimeiro.Replace("<strong>", "").Replace("</strong>", ""); // Remove a tag <strong>

                            divPiloto += "<div>";
                            divPiloto += "<a class='lblPrimeiro' href='allPilotos.aspx?nome=" + Uri.EscapeDataString(nomePrimeiroRedirect) + "' >" + nomePrimeiro + "</a>";
                            divPiloto += "<label class='PontosPrimeiro' ><b>" + pontosPrimeiro + "</b></label>";
                            divPiloto += "<img src='data:image/png;base64," + Convert.ToBase64String(imagemPrimeiro) + "' class='PreSet' />";
                            divPiloto += "</div>";
                        }
                    }
                }
                divCampP.InnerHtml = divPiloto;
            }
        }
        protected void adicionarResultados_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Admin/AdicionarResultados.aspx");
        }

        protected void editarPista_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Admin/EditarPista.aspx");
        }

        protected void adicionarBilhetes_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Admin/AdicionarBilhetes.aspx");
        }

        protected void editarClassificacao_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Admin/EditarClassificacao.aspx");
        }

        protected void editarClassificacaoConstrutores_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Admin/EditarClassificacaoConstrutores.aspx");
        }
    }
}