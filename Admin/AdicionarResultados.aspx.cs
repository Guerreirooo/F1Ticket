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
    public partial class AdicionarPista : System.Web.UI.Page
    {
        string ConnectionString = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
        string[] pilotoArray = new string[21];
        string[] tempoArray = new string[21];

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["user"] == null)
                Response.Redirect("Login.aspx");

            pilotoArray[0] = "";
            pilotoArray[1] = Piloto1.Text;
            pilotoArray[2] = Piloto2.Text;
            pilotoArray[3] = Piloto3.Text;
            pilotoArray[4] = Piloto4.Text;
            pilotoArray[5] = Piloto5.Text;
            pilotoArray[6] = Piloto6.Text;
            pilotoArray[7] = Piloto7.Text;
            pilotoArray[8] = Piloto8.Text;
            pilotoArray[9] = Piloto9.Text;
            pilotoArray[10] = Piloto10.Text;
            pilotoArray[11] = Piloto11.Text;
            pilotoArray[12] = Piloto12.Text;
            pilotoArray[13] = Piloto13.Text;
            pilotoArray[14] = Piloto14.Text;
            pilotoArray[15] = Piloto15.Text;
            pilotoArray[16] = Piloto16.Text;
            pilotoArray[17] = Piloto17.Text;
            pilotoArray[18] = Piloto18.Text;
            pilotoArray[19] = Piloto19.Text;
            pilotoArray[20] = Piloto20.Text;

            tempoArray[0] = "";
            tempoArray[1] = Tempo1.Text;
            tempoArray[2] = Tempo2.Text;
            tempoArray[3] = Tempo3.Text;
            tempoArray[4] = Tempo4.Text;
            tempoArray[5] = Tempo5.Text;
            tempoArray[6] = Tempo6.Text;
            tempoArray[7] = Tempo7.Text;
            tempoArray[8] = Tempo8.Text;
            tempoArray[9] = Tempo9.Text;
            tempoArray[10] = Tempo10.Text;
            tempoArray[11] = Tempo11.Text;
            tempoArray[12] = Tempo12.Text;
            tempoArray[13] = Tempo13.Text;
            tempoArray[14] = Tempo14.Text;
            tempoArray[15] = Tempo15.Text;
            tempoArray[16] = Tempo16.Text;
            tempoArray[17] = Tempo17.Text;
            tempoArray[18] = Tempo18.Text;
            tempoArray[19] = Tempo19.Text;
            tempoArray[20] = Tempo20.Text;

            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                connection.Open();

                if (!IsPostBack)
                {
                    SqlCommand commandPistas = new SqlCommand("SELECT nomePista FROM Pistas WHERE dataCorridaInicio < GETDATE()", connection);
                    SqlDataReader readerNomesPistas = commandPistas.ExecuteReader();
                    while (readerNomesPistas.Read())
                    {
                        string valor = readerNomesPistas["nomePista"].ToString();
                        ListItem item = new ListItem(valor, valor);
                        selectPista.Items.Add(item);
                    }
                    readerNomesPistas.Close();
                }
            }
        }

        protected void Adicionar_OnClick(object sender, EventArgs e)
        {
            int i = 1;

            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                connection.Open();

                SqlCommand contagemPilotos = new SqlCommand("SELECT COUNT(*) FROM CampeonatoPilotos", connection);
                int count = (int)contagemPilotos.ExecuteScalar();

                SqlCommand commandIdPista = new SqlCommand("SELECT idPista FROM Pistas WHERE nomePista = '" + selectPista.SelectedValue + "'", connection);
                int idPista = (int)commandIdPista.ExecuteScalar();

                SqlCommand commandApaga= new SqlCommand("DELETE FROM ResultadosCorridas WHERE idPista = '" + idPista + "'", connection);
                commandApaga.ExecuteReader().Close();

                SqlCommand commandApaga2 = new SqlCommand("DELETE FROM VoltaRapida WHERE idPista = '" + idPista + "'", connection);
                commandApaga2.ExecuteReader().Close();

                while (i <= count)
                {
                    SqlCommand commandIdPiloto = new SqlCommand("SELECT idPilotos FROM SobrePilotos WHERE Nome = '" + pilotoArray[i] + "'", connection);
                    int idPiloto = (int)commandIdPiloto.ExecuteScalar();

                    SqlCommand commandInsert = new SqlCommand("INSERT INTO ResultadosCorridas(idPista, Lugar, idPilotos, Tempo) VALUES('" + idPista + "', '" + i + "', '" + idPiloto + "', '" + tempoArray[i] + "')", connection);
                    commandInsert.ExecuteReader().Close();

                    i++;
                }

                SqlCommand commandIdPilotoVoltaRapida = new SqlCommand("SELECT idPilotos FROM SobrePilotos WHERE Nome = '" + txtPilotoVoltaRapida.Text + "'", connection);
                int idPilotoVoltaRapida = (int)commandIdPilotoVoltaRapida.ExecuteScalar();

                SqlCommand commandVoltaRapida = new SqlCommand("INSERT INTO VoltaRapida(idPista, idPilotos, Tempo) VALUES ('" + idPista + "', '" + idPilotoVoltaRapida +"', '" + txtTempoVoltaRapida.Text + "')", connection);
                commandVoltaRapida.ExecuteReader().Close();

                Response.Redirect("PaginaInicial.aspx");
            }
        }
    }
}