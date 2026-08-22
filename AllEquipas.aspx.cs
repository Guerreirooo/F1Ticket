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

namespace PAP___F1_Ticket
{
    public partial class AllEquipas : System.Web.UI.Page
    {
        string divHtml = "";
        string ConnectionString = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
        string bandeiraEquipa = string.Empty;
        string bandeiraPiloto = string.Empty;
        string nacionalidade = string.Empty;
        int podios = 0;
        int vitorias = 0;
        int corridasFeitas = 0;
        int anoDebut = 0;
        string nomePiloto = string.Empty;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["user"] == null)
                Response.Redirect("Login.aspx");

            if (!IsPostBack)
            {
                string paginaAnterior = Request.UrlReferrer.ToString();

                linkRedirecionamento.Attributes["href"] = paginaAnterior;



                string nome = Request.QueryString["nome"];
                lblNomeCima.Text = nome;

                using (SqlConnection connection = new SqlConnection(ConnectionString))
                {
                    connection.Open();

                    SqlCommand commandFotos = new SqlCommand("SELECT Emblema FROM SobreEquipas WHERE Nome = '" + nome + "'", connection);
                    byte[] FotoEquipaByte = (byte[])commandFotos.ExecuteScalar();
                    string FotoEquipa = Convert.ToBase64String(FotoEquipaByte);

                    divHtml += "<img id='FotoEquipa' src='data:image/png;base64," + FotoEquipa + "' class='FotoEquipa'/>";

                    divFoto.InnerHtml = divHtml;
                    SqlCommand commandValores = new SqlCommand("SELECT SE.nacionalidade, SE.Podios, SE.Vitorias, SE.CorridasFeitas, SE.AnoDebut, SP.Nome FROM SobrePilotos SP INNER JOIN SobreEquipas SE ON SP.idEquipa = SE.idEquipa WHERE SE.Nome ='" + nome + "'", connection);
                    SqlCommand commandImagemEquipa = new SqlCommand("SELECT bandeiraPais FROM SobreEquipas WHERE Nome ='" + nome + "'", connection);
                    byte[] ImagemEquipaByte = (byte[])commandImagemEquipa.ExecuteScalar();
                    SqlCommand commandImagemPiloto = new SqlCommand("SELECT SP.bandeiraPais FROM SobrePilotos SP INNER JOIN SobreEquipas SE ON SP.idEquipa = SE.idEquipa WHERE SE.Nome = '" + nome + "'", connection);
                    byte[] ImagemPilotoByte = (byte[])commandImagemPiloto.ExecuteScalar();

                    using (SqlDataReader reader = commandValores.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                             bandeiraEquipa = Convert.ToBase64String(ImagemEquipaByte);
                             bandeiraPiloto = Convert.ToBase64String(ImagemPilotoByte);
                             nacionalidade = reader.GetString(0);
                             podios = reader.GetInt32(1);
                             vitorias = reader.GetInt32(2);
                             corridasFeitas = reader.GetInt32(3);
                             anoDebut = reader.GetInt32(4);
                             nomePiloto = reader.GetString(5);
                        }

                    }

                            SqlCommand commandPiloto2 = new SqlCommand("SELECT SP.Nome FROM SobrePilotos SP INNER JOIN SobreEquipas SE ON SP.idEquipa = SE.idEquipa WHERE SE.Nome ='" + nome + "' and SP.Nome != '" + nomePiloto + "'", connection);
                            string nomePiloto2 = (string)commandPiloto2.ExecuteScalar(); 
                            
                            SqlCommand commandbandeiraPais2 = new SqlCommand("SELECT bandeiraPais FROM SobrePilotos WHERE Nome ='" + nomePiloto2 + "'", connection);
                            byte[] ImagemPiloto2Byte = (byte[])commandbandeiraPais2.ExecuteScalar();
                            string bandeiraPiloto2 = Convert.ToBase64String(ImagemPiloto2Byte);

                            // Atribuir os valores às divs correspondentes
                            if (nome.Length > 26)
                                {
                                    string[] palavras = nome.Split(' ');
                                    string nomeAbreviado = string.Join(" ", palavras.Take(2));
                                    lblNomeCima.Text = nomeAbreviado;
                                }
                                else
                                {
                                    lblNomeCima.Text = nome;
                                }
                            divNomeEquipa.InnerHtml = nome;
                            divPodios.InnerHtml = podios.ToString() + " Pódios";
                            divVitorias.InnerHtml = vitorias.ToString() + " Vitórias";
                            divCorridasFeitas.InnerHtml = "<label class='palavra'>" + corridasFeitas.ToString() + " Corridas </label>";
                            divAnoDebut.InnerHtml = "Ano Estreia - " + anoDebut.ToString();
                            divPaisOrigem.InnerHtml = "<img src='data:image/png;base64," + bandeiraEquipa + "' class='bandeira'/> <label class='palavra'>" + nacionalidade + "</label>";
                            divNomePilotos.InnerHtml = "<img src='data:image/png;base64," + bandeiraPiloto + "' class='bandeira'/> <label class='palavra'>" + nomePiloto + "</label><br />";
                            divNomePilotos2.InnerHtml += "<img src='data:image/png;base64," + bandeiraPiloto2 + "' class='bandeira'/> <label class='palavra'>" + nomePiloto2 + "</label>"; 
                }
            }
        }
    }
}