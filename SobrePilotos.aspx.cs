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
    public partial class SobrePilotos : System.Web.UI.Page
    {
        string ConnectionString = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
        string idUser = Membership.GetUser().ProviderUserKey.ToString();
        string divHtml = "";
        List<string> nomesEquipas = new List<string>();
        List<byte[]> fotos = new List<byte[]>();
        List<byte[]> emblemas = new List<byte[]>();
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

                SqlCommand commandNomes = new SqlCommand("SELECT SP.Nome FROM SobrePilotos SP INNER JOIN CampeonatoPilotos CP on SP.idPilotos = CP.idPilotos ORDER BY CP.Pontos DESC", connection);
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
                    SqlCommand commandEmblema = new SqlCommand("SELECT bandeiraPais FROM SobrePilotos WHERE Nome = @Nome", connection);
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
                    SqlCommand commandEmblema = new SqlCommand("SELECT Foto FROM SobrePilotos WHERE Nome = @Nome", connection);
                    commandEmblema.Parameters.AddWithValue("@Nome", nomeEquipa);

                    using (SqlDataReader reader = commandEmblema.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            byte[] foto = (byte[])reader.GetValue(0);
                            fotos.Add(foto);
                        }
                    }
                }
                foreach (string nomeEquipa in nomesEquipas)
                {
                    SqlCommand commandPilotos = new SqlCommand("SELECT SE.Nome FROM SobreEquipas SE INNER JOIN SobrePilotos SP ON SP.idEquipa = SE.idEquipa WHERE SP.Nome = @Nome", connection);
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
                    SqlCommand commandBandeira = new SqlCommand("SELECT bandeiraPais FROM SobreEquipas WHERE Nome = @Nome", connection);
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

            if (nomesEquipas.Count > 0)
            {
                StringBuilder htmlBuilder = new StringBuilder();
                for (int i = 0; i < nomesEquipas.Count; i++)
                {
                    string segundaPalavra = nomesEquipas[i].Split(' ')[1].ToLower();

                    divHtml += "<div class='blue-border'>"; 
                    divHtml += "<img src='data:image/png;base64," + Convert.ToBase64String(fotos[i]) + "' class='foto'/>";
                    divHtml += "<div class='divNomePiloto'>"; 
                    divHtml += "<img src='data:image/png;base64," + Convert.ToBase64String(emblemas[i]) + "' class='imgPilotos'/><label class='nomePilotos'>" + nomesEquipas[i] + "</label>";
                    divHtml += "</div>";
                    divHtml += "<div class='divNomeEquipa'>";
                    divHtml += "<img src='data:image/png;base64," + Convert.ToBase64String(bandeirasPaises[i]) + "' class='imgPilotos'/><label class='nomePilotos'>" + nomesPilotos[i] + "</label>";
                    divHtml += "</div>";
                    divHtml += "<a href='allPilotos.aspx?nome=" + Uri.EscapeDataString(nomesEquipas[i]) + "' class='btnVer'><b>Ver Mais</b></a>";
                    divHtml += "</div>";
                }

                divEquipas.InnerHtml = divHtml;
            }
        }

        protected void editarPista_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Admin/EditarPilotos.aspx");
        }
    }
}