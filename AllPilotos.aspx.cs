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
    public partial class AllPilotos : System.Web.UI.Page
    {
        string divHtml = "";
        string ConnectionString = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["user"] == null)
                Response.Redirect("Login.aspx");

            if (!IsPostBack)
            {

                string paginaAnterior = Request.UrlReferrer.ToString();

                linkRedirecionamento.Attributes["href"] = paginaAnterior;


                string nome = Request.QueryString["nome"];

                // Dividir o nome em palavras
                string[] nomes = nome.Split(' ');

                // Construir a string com formatação especial para o primeiro nome
                string nomeFormatado = nomes[0];

                // Adicionar os nomes restantes em negrito
                for (int i = 1; i < nomes.Length; i++)
                {
                    nomeFormatado += "<b>&nbsp;" + nomes[i].ToUpper() + "</b> ";
                }

                // Exibir o nome formatado na label
                lblNomeCima.Text = nomeFormatado;



                using (SqlConnection connection = new SqlConnection(ConnectionString))
                {
                    connection.Open();

                    SqlCommand commandFotos = new SqlCommand("SELECT Foto FROM SobrePilotos WHERE Nome = '" + nome + "'", connection);
                    byte[] FotoPilotoByte = (byte[])commandFotos.ExecuteScalar();

                    string FotoPiloto = Convert.ToBase64String(FotoPilotoByte);
                    divHtml += "<img src='data:image/png;base64," + FotoPiloto + "' class='FotoPiloto'/>";

                    divFoto.InnerHtml = divHtml;
                    SqlCommand commandValores = new SqlCommand("SELECT SP.nacionalidade, SP.Idade, SP.Podios, SP.Vitorias, SP.CorridasFeitas, SP.AnoDebut, SE.Nome FROM SobrePilotos SP INNER JOIN SobreEquipas SE ON SP.idEquipa = SE.idEquipa WHERE SP.Nome ='" + nome + "'", connection);
                    SqlCommand commandImagemEquipa = new SqlCommand("SELECT SE.bandeiraPais FROM SobreEquipas SE INNER JOIN SobrePilotos SP ON SP.idEquipa = SE.idEquipa WHERE SP.Nome ='" + nome + "'", connection);
                    byte[] ImagemEquipaByte = (byte[])commandImagemEquipa.ExecuteScalar();
                    SqlCommand commandImagemPiloto = new SqlCommand("SELECT bandeiraPais FROM SobrePilotos WHERE Nome ='" + nome + "'", connection);
                    byte[] ImagemPilotoByte = (byte[])commandImagemPiloto.ExecuteScalar();

                    using (SqlDataReader reader = commandValores.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            string bandeiraEquipa = Convert.ToBase64String(ImagemEquipaByte);
                            string bandeiraPiloto = Convert.ToBase64String(ImagemPilotoByte);
                            string nacionalidade = reader.GetString(0);
                            int idade = reader.GetInt32(1);
                            int podios = reader.GetInt32(2);
                            int vitorias = reader.GetInt32(3);
                            int corridasFeitas = reader.GetInt32(4);
                            int anoDebut = reader.GetInt32(5);
                            string nomeEquipa = reader.GetString(6);
                            
                           
                            if (nomeEquipa.Length > 26)
                            {
                                int meio = nomeEquipa.Length / 2;

                                int indiceUltimoEspaco = nomeEquipa.LastIndexOf(' ', meio);

                                string parte1 = nomeEquipa.Substring(0, indiceUltimoEspaco);
                                string parte2 = nomeEquipa.Substring(indiceUltimoEspaco + 1);

                                string nomeEquipaPartido = parte1 + "<br>" + parte2;
                                divNomePiloto.InnerHtml = nomeFormatado;
                                divIdade.InnerHtml = idade.ToString() + " Anos";
                                divPodios.InnerHtml = podios.ToString() + " Pódios";
                                divVitorias.InnerHtml = vitorias.ToString() + " Vitórias";
                                divCorridasFeitas.InnerHtml = "<label class='palavra'>" + corridasFeitas.ToString() + " Corridas </label>";
                                divAnoDebut.InnerHtml = "Ano Estreia - " + anoDebut.ToString();
                                divNacionalidade.InnerHtml = "<img src='data:image/png;base64," + bandeiraPiloto + "' class='bandeira'/> <label class='palavra'>" + nacionalidade + "</label>";
                                divNomeEquipa.InnerHtml = "<img src='data:image/png;base64," + bandeiraEquipa + "' class='bandeira'/> <label class='palavra'>" + nomeEquipaPartido + "</label>";
                           
                            }
                            else
                            {
                                // Atribuir os valores às divs correspondentes
                                divNomePiloto.InnerHtml = nomeFormatado;
                                divIdade.InnerHtml = idade.ToString() + " Anos";
                                divPodios.InnerHtml = podios.ToString() + " Pódios";
                                divVitorias.InnerHtml = vitorias.ToString() + " Vitórias";
                                divCorridasFeitas.InnerHtml = "<label class='palavra'>" + corridasFeitas.ToString() + " Corridas </label>";
                                divAnoDebut.InnerHtml = "Ano Estreia - " + anoDebut.ToString();
                                divNacionalidade.InnerHtml = "<img src='data:image/png;base64," + bandeiraPiloto + "' class='bandeira'/> <label class='palavra'>" + nacionalidade + "</label>";
                                divNomeEquipa.InnerHtml = "<img src='data:image/png;base64," + bandeiraEquipa + "' class='bandeira'/> <label class='palavra'>" + nomeEquipa + "</label>";

                            }
                        }
                    }
                }
            }
        
        }
    }
}