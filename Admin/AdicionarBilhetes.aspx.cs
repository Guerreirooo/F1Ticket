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
    public partial class RemoverPista : System.Web.UI.Page
    {
        string ConnectionString = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
        string auxOpcao;
        string[] precoArray = new string[21];
        string[] lugarArray = new string[21];

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["user"] == null)
                Response.Redirect("Login.aspx");

            precoArray[0] = "";
            precoArray[1] = Preco1.Text;
            precoArray[2] = Preco2.Text;
            precoArray[3] = Preco3.Text;
            precoArray[4] = Preco4.Text;
            precoArray[5] = Preco5.Text;
            precoArray[6] = Preco6.Text;
            precoArray[7] = Preco7.Text;
            precoArray[8] = Preco8.Text;
            precoArray[9] = Preco9.Text;
            precoArray[10] = Preco10.Text;
            precoArray[11] = Preco11.Text;
            precoArray[12] = Preco12.Text;
            precoArray[13] = Preco13.Text;
            precoArray[14] = Preco14.Text;
            precoArray[15] = Preco15.Text;
            precoArray[16] = Preco16.Text;
            precoArray[17] = Preco17.Text;
            precoArray[18] = Preco18.Text;
            precoArray[19] = Preco19.Text;
            precoArray[20] = Preco20.Text;

            lugarArray[0] = "";
            lugarArray[1] = Lugar1.Text;
            lugarArray[2] = Lugar2.Text;
            lugarArray[3] = Lugar3.Text;
            lugarArray[4] = Lugar4.Text;
            lugarArray[5] = Lugar5.Text;
            lugarArray[6] = Lugar6.Text;
            lugarArray[7] = Lugar7.Text;
            lugarArray[8] = Lugar8.Text;
            lugarArray[9] = Lugar9.Text;
            lugarArray[10] = Lugar10.Text;
            lugarArray[11] = Lugar11.Text;
            lugarArray[12] = Lugar12.Text;
            lugarArray[13] = Lugar13.Text;
            lugarArray[14] = Lugar14.Text;
            lugarArray[15] = Lugar15.Text;
            lugarArray[16] = Lugar16.Text;
            lugarArray[17] = Lugar17.Text;
            lugarArray[18] = Lugar18.Text;
            lugarArray[19] = Lugar19.Text;
            lugarArray[20] = Lugar20.Text;

            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                connection.Open();

                if (!IsPostBack)
                {
                    SqlCommand commandPistas = new SqlCommand("SELECT nomePista FROM Pistas WHERE dataCorridaInicio > GETDATE()", connection);
                    SqlDataReader readerNomesPistas = commandPistas.ExecuteReader();
                    while (readerNomesPistas.Read())
                    {
                        string valor = readerNomesPistas["nomePista"].ToString();
                        ListItem item = new ListItem(valor, valor);
                        selectPista.Items.Add(item);
                    }
                    readerNomesPistas.Close();

                    lblNumBancadas.Text = "Quantas bancadas terá a pista de " + selectPista.SelectedValue + " ?";
                }
            }

            auxOpcao = selectTipo.SelectedValue;
        }

        protected void selectPista_SelectedIndexChanged(object sender, EventArgs e)
        {
            lblNumBancadas.Text = "Quantas bancadas terá a pista de " + selectPista.SelectedValue + " ?";
        }

        protected void txtNumBancadas_TextChanged(object sender, EventArgs e)
        {
            int numi = int.Parse(txtNumBancadas.Text);
            int auxi = 1;

            if (numi <= 20)
            {
                while (auxi <= numi)
                {
                    selectTipo.Style["display"] = "block";
                    lblPrecoBancadas.Text = "Insira o preço dos bilhetes por bancada, e a quantidade de acentos por bancada";

                    char letra = (char)(auxi - 1 + 'A');
                    string divID = "divBilhetes" + letra;

                    Control div = FindControl(divID);
                    if (div != null)
                    {
                        div.Visible = true;
                    }

                    auxi++;
                }
            }
            else
            {
                lblPrecoBancadas.Text = "Numero de bancadas inválido, o máximo são 20 bancadas por pista";
                selectTipo.Style["display"] = "none";
            }
        }

        protected void cancelar_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/PaginaInicial.aspx");
        }

        protected void adicionar_Click(object sender, EventArgs e)
        {
            int auxi = 1;

            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                connection.Open();

                SqlCommand commandPistas = new SqlCommand("SELECT idPista FROM Pistas WHERE nomePista ='" + selectPista.SelectedValue + "'", connection);
                int idPista = (int)commandPistas.ExecuteScalar();

                int numi = int.Parse(txtNumBancadas.Text);

                    if (auxOpcao == "1")
                    {
                        SqlCommand commandDelTreinos = new SqlCommand("DELETE FROM BancadaT WHERE idPista = '" + idPista + "'", connection);
                        SqlDataReader readerDelTreinos = commandDelTreinos.ExecuteReader();
                        readerDelTreinos.Close();

                        while (auxi <= numi)
                        {
                            char letra = (char)(auxi - 1 + 'A');

                            char i = letra;

                            auxOpcao = selectTipo.SelectedValue;

                            SqlCommand commandInsert = new SqlCommand("INSERT INTO BancadaT(idPista, letraBancada, lugares, preco) VALUES('" + idPista + "', '" + i + "', '" + int.Parse(lugarArray[auxi]) + "', '" + int.Parse(precoArray[auxi]) + "')", connection);
                            SqlDataReader readerInsert = commandInsert.ExecuteReader();
                            readerInsert.Close();

                            auxi++;
                        }

                            Response.Redirect("~/PaginaInicial.aspx");
                    }
                    else if (auxOpcao == "2")
                    {
                        SqlCommand commandDelQualificacao = new SqlCommand("DELETE FROM BancadaQ WHERE idPista = '" + idPista + "'", connection);
                        SqlDataReader readerDelQualificacao = commandDelQualificacao.ExecuteReader();
                        readerDelQualificacao.Close();

                        while (auxi <= numi)
                        {
                            char letra = (char)(auxi - 1 + 'A');

                            char i = letra;

                            auxOpcao = selectTipo.SelectedValue;

                            SqlCommand commandInsert = new SqlCommand("INSERT INTO BancadaQ(idPista, letraBancada, Lugares, preco) VALUES('" + idPista + "', '" + i + "', '" + lugarArray[auxi] + "', '" + precoArray[auxi] + "')", connection);
                            SqlDataReader readerInsert = commandInsert.ExecuteReader();
                            readerInsert.Close();

                            auxi++;
                        }
                            Response.Redirect("~/PaginaInicial.aspx");
                    }
                    else if (auxOpcao == "3")
                    {
                        SqlCommand commandDelCorrida = new SqlCommand("DELETE FROM BancadaC WHERE idPista = '" + idPista + "'", connection);
                        SqlDataReader readerDelCorrida = commandDelCorrida.ExecuteReader();
                        readerDelCorrida.Close();

                        while (auxi <= numi)
                        {
                            char letra = (char)(auxi - 1 + 'A');

                            char i = letra;

                            auxOpcao = selectTipo.SelectedValue;

                            SqlCommand commandInsert = new SqlCommand("INSERT INTO BancadaC(idPista, letraBancada, Lugares, preco) VALUES('" + idPista + "', '" + i + "', '" + lugarArray[auxi] + "', '" + precoArray[auxi] + "')", connection);
                            SqlDataReader readerInsert = commandInsert.ExecuteReader();
                            readerInsert.Close();

                            auxi++;
                        }
                            Response.Redirect("~/PaginaInicial.aspx");
                    }
                    else if (auxOpcao == "4")
                    {
                        SqlCommand commandDelCorrida = new SqlCommand("DELETE FROM BancadaFDS WHERE idPista = '" + idPista + "'", connection);
                        SqlDataReader readerDelCorrida = commandDelCorrida.ExecuteReader();
                        readerDelCorrida.Close();

                        while (auxi <= numi)
                        {
                            char letra = (char)(auxi - 1 + 'A');

                            char i = letra;

                            auxOpcao = selectTipo.SelectedValue;

                            SqlCommand commandInsert = new SqlCommand("INSERT INTO BancadaFDS(idPista, letraBancada, Lugares, preco) VALUES('" + idPista + "', '" + i + "', '" + lugarArray[auxi] + "', '" + precoArray[auxi] + "')", connection);
                            SqlDataReader readerInsert = commandInsert.ExecuteReader();
                            readerInsert.Close();

                            auxi++;
                        }
                            Response.Redirect("~/PaginaInicial.aspx");
                    }
            }
        }
    }
}