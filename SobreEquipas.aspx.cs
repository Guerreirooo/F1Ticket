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
using System.Text;
using System.Web.Security;

namespace PAP___F1_Ticket
{
    public partial class SobreEquipas : System.Web.UI.Page
    {
        string ConnectionString = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
        string idUser = Membership.GetUser().ProviderUserKey.ToString();
        string divHtml = "";
        List<string> nomesEquipas = new List<string>();
        List<byte[]> emblemas = new List<byte[]>();
        List<byte[]> carros = new List<byte[]>();
        List<string> nomesPilotos = new List<string>();
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
            }

            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                connection.Open();

                SqlCommand commandNomes = new SqlCommand("SELECT SE.Nome FROM SobreEquipas SE INNER JOIN CampeonatoConstrutores CC on SE.idEquipa = CC.idEquipa ORDER BY CC.Pontos DESC", connection);
                using (SqlDataReader reader = commandNomes.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        string nomeEquipa = reader.GetString(0);
                        nomesEquipas.Add(nomeEquipa);
                    }
                }
                foreach (string nomeEquipa in nomesEquipas)
                {
                    SqlCommand commandEmblema = new SqlCommand("SELECT bandeiraPais FROM SobreEquipas WHERE Nome = @Nome", connection);
                    commandEmblema.Parameters.AddWithValue("@Nome", nomeEquipa);

                    using (SqlDataReader reader = commandEmblema.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            byte[] emblema = (byte[])reader.GetValue(0);
                            emblemas.Add(emblema);
                        }
                    }
                }
                foreach (string nomeEquipa in nomesEquipas)
                {
                    SqlCommand commandCarro = new SqlCommand("SELECT Carro FROM SobreEquipas WHERE Nome = @Nome", connection);
                    commandCarro.Parameters.AddWithValue("@Nome", nomeEquipa);

                    using (SqlDataReader reader = commandCarro.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            byte[] carro = (byte[])reader.GetValue(0);
                            carros.Add(carro);
                        }
                    }
                }
                foreach (string nomeEquipa in nomesEquipas)
                {
                    SqlCommand commandPilotos = new SqlCommand("SELECT SP.Nome FROM SobrePilotos SP INNER JOIN SobreEquipas SE ON SP.idEquipa = SE.idEquipa WHERE SE.Nome = @Nome", connection);
                    commandPilotos.Parameters.AddWithValue("@Nome", nomeEquipa);

                    using (SqlDataReader reader = commandPilotos.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            string nomePiloto = reader.GetString(0);
                            nomesPilotos.Add(nomePiloto);
                        }
                    }
                }
                foreach (string nomePiloto in nomesPilotos)
                {
                    SqlCommand commandBandeira = new SqlCommand("SELECT bandeiraPais FROM SobrePilotos WHERE Nome = @Nome", connection);
                    commandBandeira.Parameters.AddWithValue("@Nome", nomePiloto);

                    using (SqlDataReader reader = commandBandeira.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            byte[] bandeiraPais = (byte[])reader.GetValue(0);
                            bandeirasPaises.Add(bandeiraPais);
                        }
                    }
                }

            }

            int indexPilotos = 0;
            if (nomesEquipas.Count > 0)
            {
                StringBuilder htmlBuilder = new StringBuilder();
                for (int i = 0; i < nomesEquipas.Count; i++)
                {
                    string segundaPalavra = nomesEquipas[i].Split(' ')[1].ToLower();

                    divHtml += "<div class='blue-border'>";
                    divHtml += "<label class='nomeEquipa'><img src='data:image/png;base64," + Convert.ToBase64String(emblemas[i]) + "' style='padding: 0px 10px; margin-left: 20%; height: 30px; width: 55px;'/>" + nomesEquipas[i] + "</label>";
                    divHtml += "<div class='divPilotos'>";

                    if (indexPilotos < nomesPilotos.Count) // Verifica se ainda há pilotos disponíveis
                    {
                        string bandeiraBase64 = Convert.ToBase64String(bandeirasPaises[indexPilotos]);
                        divHtml += string.Format("<img src='data:image/png;base64,{0}' class='imgPilotos'/><label class='nomePilotos'>{1} <b>{2}</b></label>",
                                                bandeiraBase64, nomesPilotos[indexPilotos].Split(' ')[0], nomesPilotos[indexPilotos].Split(' ')[1]);
                        indexPilotos++;
                    }

                    if (indexPilotos < nomesPilotos.Count) // Verifica se ainda há pilotos disponíveis
                    {
                        string nomePiloto = nomesPilotos[indexPilotos];
                        string[] partesNome = nomePiloto.Split(' ');

                        if (partesNome.Length >= 2)
                        {
                            string primeiroNome = partesNome[0];
                            string sobrenome = string.Join(" ", partesNome.Skip(1));

                            string bandeiraBase64 = Convert.ToBase64String(bandeirasPaises[indexPilotos]);
                            divHtml += string.Format("<img src='data:image/png;base64,{0}' class='imgPilotos'/><label class='nomePilotos'>{1} <b>{2}</b></label>",
                                                    bandeiraBase64, primeiroNome, sobrenome);
                        }
                        else
                        {
                            // Caso especial para nomes com uma única palavra
                            string bandeiraBase64 = Convert.ToBase64String(bandeirasPaises[indexPilotos]);
                            divHtml += string.Format("<img src='data:image/png;base64,{0}' class='imgPilotos'/><label class='nomePilotos'><b>{1}</b></label>",
                                                    bandeiraBase64, nomePiloto);
                        }

                        indexPilotos++;
                    }

                    divHtml += "</div>"; 
                    divHtml += "<img src='data:image/png;base64," + Convert.ToBase64String(carros[i]) + "' class='carro'/>"; 
                    divHtml += "<a href='allEquipas.aspx?nome=" + Uri.EscapeDataString(nomesEquipas[i]) + "' class='btnVer'><b>Ver Mais</b></a>";
                    divHtml += "</div>";
                }

                divEquipas.InnerHtml = divHtml;
            }
        }

        protected void editarPista_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Admin/EditarEquipas.aspx");
        }
    }
}