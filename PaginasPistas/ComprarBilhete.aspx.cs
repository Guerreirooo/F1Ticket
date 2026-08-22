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

namespace PAP___F1_Ticket
{
    public partial class ComprarBilhete : System.Web.UI.Page
    {
        string ConnectionString = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
        string idUser = Membership.GetUser().ProviderUserKey.ToString();
        protected string selectedOption = "A";
        protected int valorContadorT;
        protected int valorContadorQ;
        protected int valorContadorC;
        protected int valorContadorFDS;

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

            if (!IsPostBack)
            {
                selectElementT.SelectedValue = selectedOption;
                contadorT.InnerText = valorContadorT.ToString();
                contadorQ.InnerText = valorContadorQ.ToString();
                contadorC.InnerText = valorContadorC.ToString();
                contadorFDS.InnerText = valorContadorFDS.ToString();

                using (SqlConnection connection = new SqlConnection(ConnectionString))
                {
                    connection.Open();

                    string nomePista = Session["nomePista"] as string;
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
                    // Quantidade Lugares Treinos
                    SqlCommand command2 = new SqlCommand("SELECT lugares FROM BancadaT where idPista = '" + idPista + "' and letraBancada = '" + selectedOption + "'", connection);
                    int lugaresT = (int)command2.ExecuteScalar();

                    lblLugaresT.InnerText = lugaresT.ToString() + " Lugares Restantes";
                    // Quantidade Lugares Qualificação
                    SqlCommand command3 = new SqlCommand("SELECT lugares FROM BancadaQ where idPista = '" + idPista + "' and letraBancada = '" + selectedOption + "'", connection);
                    int lugaresQ = (int)command3.ExecuteScalar();

                    lblLugaresQ.InnerText = lugaresQ.ToString() + " Lugares Restantes";
                    // Quantidade Lugares Corrida
                    SqlCommand command4 = new SqlCommand("SELECT lugares FROM BancadaC where idPista = '" + idPista + "' and letraBancada = '" + selectedOption + "'", connection);
                    int lugaresC = (int)command4.ExecuteScalar();

                    lblLugaresC.InnerText = lugaresC.ToString() + " Lugares Restantes";

                    int lugaresFDS = lugaresT;

                    if (lugaresQ < lugaresFDS)
                    {
                        lugaresFDS = lugaresQ;
                    }

                    if (lugaresC < lugaresFDS)
                    {
                        lugaresFDS = lugaresC;
                    }
                    // Quantidade Lugares Fim de Semana
                    lblLugaresFDS.InnerText = lugaresFDS.ToString() + " Lugares Restantes";
                    // Letras das Bancadas
                    SqlCommand command = new SqlCommand("SELECT letraBancada FROM BancadaT where idPista = '" + idPista + "';", connection);
                    SqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        string valor = reader["letraBancada"].ToString();
                        ListItem item = new ListItem(valor, valor);
                        selectElementT.Items.Add(item);
                        selectElementQ.Items.Add(item);
                        selectElementC.Items.Add(item);
                        selectElementFDS.Items.Add(item);
                    }

                    reader.Close();
                    // Preço bilhetes Treinos
                    SqlCommand commandValorT = new SqlCommand("SELECT preco FROM BancadaT where idPista = '" + idPista + "' and letraBancada = '" + selectedOption + "'", connection);
                    string valorT = Convert.ToString(commandValorT.ExecuteScalar());
                    lblValorT.InnerText = "Valor p/bilhete : " + valorT + " €";
                    // Preço bilhetes Qualificação
                    SqlCommand commandValorQ = new SqlCommand("SELECT preco FROM BancadaQ where idPista = '" + idPista + "' and letraBancada = '" + selectedOption + "'", connection);
                    string valorQ = Convert.ToString(commandValorQ.ExecuteScalar());
                    lblValorQ.InnerText = "Valor p/bilhete : " + valorQ + " €";
                    // Preço bilhetes Corrida
                    SqlCommand commandValorC = new SqlCommand("SELECT preco FROM BancadaC where idPista = '" + idPista + "' and letraBancada = '" + selectedOption + "'", connection);
                    string valorC = Convert.ToString(commandValorC.ExecuteScalar());
                    lblValorC.InnerText = "Valor p/bilhete : " + valorC + " €";
                    // Preço bilhetes Fim de semana
                    SqlCommand commandValorFDS = new SqlCommand("SELECT preco FROM BancadaFDS where idPista = '" + idPista + "' and letraBancada = '" + selectedOption + "'", connection);
                    string valorFDS = Convert.ToString(commandValorFDS.ExecuteScalar());
                    lblValorFDS.InnerText = "Valor p/bilhete : " + valorFDS + " €";
                }
            }
        }
        protected void selectElementT_SelectedIndexChanged(object sender, EventArgs e)
        {
            string nomePista = Session["nomePista"] as string;
            selectedOption = selectElementT.SelectedValue;

            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                connection.Open();
                // Id Pista
                SqlCommand commandID = new SqlCommand("SELECT MAX(idPista) FROM Pistas WHERE nomePista = '" + nomePista + "'", connection);
                int idPista = (int)commandID.ExecuteScalar();
                // Quantidade Lugares Treinos
                SqlCommand command2 = new SqlCommand("SELECT lugares FROM BancadaT where idPista = '" + idPista + "' and letraBancada = '" + selectedOption + "'", connection);
                int lugaresT = (int)command2.ExecuteScalar();

                lblLugaresT.InnerText = lugaresT.ToString() + " Lugares Restantes";
                // Preço bilhetes Treinos
                SqlCommand commandValorT = new SqlCommand("SELECT preco FROM BancadaT where idPista = '" + idPista + "' and letraBancada = '" + selectedOption + "'", connection);
                string valorT = Convert.ToString(commandValorT.ExecuteScalar());
                lblValorT.InnerText = "Valor p/bilhete : " + valorT + " €";

                connection.Close();
            }
        }
        protected void selectElementQ_SelectedIndexChanged(object sender, EventArgs e)
        {
            string nomePista = Session["nomePista"] as string;
            selectedOption = selectElementQ.SelectedValue;

            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                connection.Open();
                // Id Pista
                SqlCommand commandID = new SqlCommand("SELECT MAX(idPista) FROM Pistas WHERE nomePista = '" + nomePista + "'", connection);
                int idPista = (int)commandID.ExecuteScalar();
                // Quantidade Lugares Qualificação
                SqlCommand command3 = new SqlCommand("SELECT lugares FROM BancadaQ where idPista = '" + idPista + "' and letraBancada = '" + selectedOption + "'", connection);
                int lugaresQ = (int)command3.ExecuteScalar();

                lblLugaresQ.InnerText = lugaresQ.ToString() + " Lugares Restantes";
                // Preço bilhetes Qualificação
                SqlCommand commandValorQ = new SqlCommand("SELECT preco FROM BancadaQ where idPista = '" + idPista + "' and letraBancada = '" + selectedOption + "'", connection);
                string valorQ = Convert.ToString(commandValorQ.ExecuteScalar());
                lblValorQ.InnerText = "Valor p/bilhete : " + valorQ + " €";

                connection.Close();
            }
        }
        protected void selectElementC_SelectedIndexChanged(object sender, EventArgs e)
        {
            string nomePista = Session["nomePista"] as string;
            selectedOption = selectElementC.SelectedValue;

            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                connection.Open();
                // Id Pista
                SqlCommand commandID = new SqlCommand("SELECT MAX(idPista) FROM Pistas WHERE nomePista = '" + nomePista + "'", connection);
                int idPista = (int)commandID.ExecuteScalar();
                // Quantidade Lugares Corrida
                SqlCommand command4 = new SqlCommand("SELECT lugares FROM BancadaC where idPista = '" + idPista + "' and letraBancada = '" + selectedOption + "'", connection);
                int lugaresC = (int)command4.ExecuteScalar();

                lblLugaresC.InnerText = lugaresC.ToString() + " Lugares Restantes";
                // Preço bilhetes Corrida
                SqlCommand commandValorC = new SqlCommand("SELECT preco FROM BancadaC where idPista = '" + idPista + "' and letraBancada = '" + selectedOption + "'", connection);
                string valorC = Convert.ToString(commandValorC.ExecuteScalar());
                lblValorC.InnerText = "Valor p/bilhete : " + valorC + " €";

                connection.Close();
            }
        }
        protected void selectElementFDS_SelectedIndexChanged(object sender, EventArgs e)
        {
            string nomePista = Session["nomePista"] as string;
            selectedOption = selectElementFDS.SelectedValue;

            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                connection.Open();
                // Id Pista
                SqlCommand commandID = new SqlCommand("SELECT MAX(idPista) FROM Pistas WHERE nomePista = '" + nomePista + "'", connection);
                int idPista = (int)commandID.ExecuteScalar();
                // Quantidade Lugares Treino
                SqlCommand command2 = new SqlCommand("SELECT lugares FROM BancadaT where idPista = '" + idPista + "' and letraBancada = '" + selectedOption + "'", connection);
                int lugaresT = (int)command2.ExecuteScalar();
                // Quantidade Lugares Qualificação
                SqlCommand command3 = new SqlCommand("SELECT lugares FROM BancadaQ where idPista = '" + idPista + "' and letraBancada = '" + selectedOption + "'", connection);
                int lugaresQ = (int)command3.ExecuteScalar();
                // Quantidade Lugares Corrida
                SqlCommand command4 = new SqlCommand("SELECT lugares FROM BancadaC where idPista = '" + idPista + "' and letraBancada = '" + selectedOption + "'", connection);
                int lugaresC = (int)command4.ExecuteScalar();


                int lugaresFDS = lugaresT;

                if (lugaresQ < lugaresFDS)
                {
                    lugaresFDS = lugaresQ;
                }

                if (lugaresC < lugaresFDS)
                {
                    lugaresFDS = lugaresC;
                }

                lblLugaresFDS.InnerText = lugaresFDS.ToString() + " Lugares Restantes";
                // Preço bilhetes Fim de semana
                SqlCommand commandValorFDS = new SqlCommand("SELECT preco FROM BancadaFDS where idPista = '" + idPista + "' and letraBancada = '" + selectedOption + "'", connection);
                string valorFDS = Convert.ToString(commandValorFDS.ExecuteScalar());
                lblValorFDS.InnerText = "Valor p/bilhete : " + valorFDS + " €";

                connection.Close();
            }
        }
        protected void btnAtualizarT_Click(object sender, EventArgs e)
        {
            string nomePista = Session["nomePista"] as string;
            string nomePistaRedirect = nomePista.Replace(" ", "");
            selectedOption = selectElementT.SelectedValue;
            valorContadorT = int.Parse(contadorT.InnerText);

            if (valorContadorT > 0)
            {
                using (SqlConnection connection = new SqlConnection(ConnectionString))
                {
                    connection.Open();

                    // Id Pista
                    SqlCommand commandID = new SqlCommand("SELECT MAX(idPista) FROM Pistas WHERE nomePista = '" + nomePista + "'", connection);
                    int idPista = (int)commandID.ExecuteScalar();

                    // Selecionar Preço da bancada que o utilizador escolheu nos treinos
                    SqlCommand commandValorT = new SqlCommand("SELECT preco FROM BancadaT where idPista = '" + idPista + "' and letraBancada = '" + selectedOption + "'", connection);
                    string valort = Convert.ToString(commandValorT.ExecuteScalar());

                    // Selecionar id da bancada que o utilizador escolheu nos treinos
                    SqlCommand commandBancadaT = new SqlCommand("SELECT idBancada FROM BancadaT where idPista = '" + idPista + "' and letraBancada = '" + selectedOption + "'", connection);
                    string bancadaT = Convert.ToString(commandBancadaT.ExecuteScalar());

                    int valorT = int.Parse(valort) * valorContadorT;

                    // Verifica se já existe algo daqueles treinos no carrinho
                    SqlCommand commandVerificaT = new SqlCommand("SELECT quantidade FROM Carrinho where idUser = '" + idUser + "' and idPista = '" + idPista + "' and idBancada = '" + bancadaT + "' and tipo = 'Treinos'", connection);
                    int verificaT = Convert.ToInt32(commandVerificaT.ExecuteScalar());

                    if (verificaT == 0)
                    {
                        // Cria a linha na tabela Carrinho
                        SqlCommand commandCarrinhoT = new SqlCommand("INSERT INTO Carrinho (idUser, quantidade, idPista, idBancada, preco, tipo) VALUES('" + idUser + "','" + valorContadorT + "' , '" + idPista + "','" + bancadaT + "','" + valorT + "', 'Treinos' )", connection);
                        string carrinhoT = Convert.ToString(commandCarrinhoT.ExecuteScalar());

                        Response.Redirect("ComprarBilhete.aspx");
                    }
                    else
                    {
                        int quantidadeT = valorContadorT + verificaT;
                        int valorTAtualizado = int.Parse(valort) * quantidadeT;

                        // Edita a linha existente na tabela Carrinho
                        SqlCommand commandAtualizarT = new SqlCommand("UPDATE Carrinho SET quantidade = '" + quantidadeT + "' , preco = '" + valorTAtualizado + "'where idUser = '" + idUser + "' and idPista = '" + idPista + "' and idBancada = '" + bancadaT + "' and tipo = 'Treinos'", connection);
                        string carrinhoT = Convert.ToString(commandAtualizarT.ExecuteScalar());

                        Response.Redirect("ComprarBilhete.aspx");
                    }

                    connection.Close();
                }
            }
            else 
            {
                Response.Redirect("ComprarBilhete.aspx");
            }
        }
        protected void btnAtualizarQ_Click(object sender, EventArgs e)
        {
            string nomePista = Session["nomePista"] as string;
            string nomePistaRedirect = nomePista.Replace(" ", "");
            selectedOption = selectElementQ.SelectedValue;
            valorContadorQ = int.Parse(contadorQ.InnerText);

            if (valorContadorQ > 0)
            {
                using (SqlConnection connection = new SqlConnection(ConnectionString))
                {
                    connection.Open();

                    // Id Pista
                    SqlCommand commandID = new SqlCommand("SELECT MAX(idPista) FROM Pistas WHERE nomePista = '" + nomePista + "'", connection);
                    int idPista = (int)commandID.ExecuteScalar();

                    // Selecionar Preço da bancada que o utilizador escolheu na qualificação
                    SqlCommand commandValorQ = new SqlCommand("SELECT preco FROM BancadaQ where idPista = '" + idPista + "' and letraBancada = '" + selectedOption + "'", connection);
                    string valorq = Convert.ToString(commandValorQ.ExecuteScalar());

                    // Selecionar id da bancada que o utilizador escolheu na qualificação
                    SqlCommand commandBancadaQ = new SqlCommand("SELECT idBancada FROM BancadaQ where idPista = '" + idPista + "' and letraBancada = '" + selectedOption + "'", connection);
                    string bancadaQ = Convert.ToString(commandBancadaQ.ExecuteScalar());

                    int valorQ = int.Parse(valorq) * valorContadorQ;

                    // Verifica se já existe algo daquela qualificação no carrinho
                    SqlCommand commandVerificaQ = new SqlCommand("SELECT quantidade FROM Carrinho where idUser = '" + idUser + "' and idPista = '" + idPista + "' and idBancada = '" + bancadaQ + "' and tipo = 'Qualificação'", connection);
                    int verificaQ = Convert.ToInt32(commandVerificaQ.ExecuteScalar());

                    if (verificaQ == 0)
                    {
                        // Cria a linha na tabela Carrinho
                        SqlCommand commandCarrinhoQ = new SqlCommand("INSERT INTO Carrinho (idUser, quantidade, idPista, idBancada, preco, tipo) VALUES('" + idUser + "','" + valorContadorQ + "' , '" + idPista + "','" + bancadaQ + "','" + valorQ + "', 'Qualificação' )", connection);
                        string carrinhoQ = Convert.ToString(commandCarrinhoQ.ExecuteScalar());

                        Response.Redirect("ComprarBilhete.aspx");
                    }
                    else
                    {
                        int quantidadeQ = valorContadorQ + verificaQ;
                        int valorQAtualizado = int.Parse(valorq) * quantidadeQ;
                        // Edita a linha existente na tabela Carrinho
                        SqlCommand commandAtualizarQ = new SqlCommand("UPDATE Carrinho SET quantidade = '" + quantidadeQ + "' , preco = '" + valorQAtualizado + "'where idUser = '" + idUser + "' and idPista = '" + idPista + "' and idBancada = '" + bancadaQ + "' and tipo = 'Qualificação'", connection);
                        string carrinhoQ = Convert.ToString(commandAtualizarQ.ExecuteScalar());

                        Response.Redirect("ComprarBilhete.aspx");
                    }

                    connection.Close();
                }
            }
            else 
            {
                Response.Redirect(nomePistaRedirect + ".aspx");
            }
        }
        protected void btnAtualizarC_Click(object sender, EventArgs e)
        {
            string nomePista = Session["nomePista"] as string;
            string nomePistaRedirect = nomePista.Replace(" ", "");
            selectedOption = selectElementC.SelectedValue;
            valorContadorC = int.Parse(contadorC.InnerText);

            if (valorContadorC > 0)
            {
                using (SqlConnection connection = new SqlConnection(ConnectionString))
                {
                    connection.Open();
                    // Id Pista
                    SqlCommand commandID = new SqlCommand("SELECT MAX(idPista) FROM Pistas WHERE nomePista = '" + nomePista + "'", connection);
                    int idPista = (int)commandID.ExecuteScalar();

                    // Selecionar Preço da bancada que o utilizador escolheu na corrida
                    SqlCommand commandValorC = new SqlCommand("SELECT preco FROM BancadaC where idPista = '" + idPista + "' and letraBancada = '" + selectedOption + "'", connection);
                    string valorc = Convert.ToString(commandValorC.ExecuteScalar());

                    // Selecionar id da bancada que o utilizador escolheu na corrida
                    SqlCommand commandBancadaC = new SqlCommand("SELECT idBancada FROM BancadaC where idPista = '" + idPista + "' and letraBancada = '" + selectedOption + "'", connection);
                    string bancadaC = Convert.ToString(commandBancadaC.ExecuteScalar());

                    int valorC = int.Parse(valorc) * valorContadorC;

                    // Verifica se já existe algo daquela corrida no carrinho
                    SqlCommand commandVerificaC = new SqlCommand("SELECT quantidade FROM Carrinho where idUser = '" + idUser + "' and idPista = '" + idPista + "' and idBancada = '" + bancadaC + "' and tipo = 'Corrida'", connection);
                    int verificaC = Convert.ToInt32(commandVerificaC.ExecuteScalar());

                    if (verificaC == 0)
                    {

                        // Cria a linha na tabela Carrinho
                        SqlCommand commandCarrinhoC = new SqlCommand("INSERT INTO Carrinho (idUser, quantidade, idPista, idBancada, preco, tipo) VALUES('" + idUser + "','" + valorContadorC + "' , '" + idPista + "','" + bancadaC + "','" + valorC + "', 'Corrida' )", connection);
                        string carrinhoC = Convert.ToString(commandCarrinhoC.ExecuteScalar());

                        Response.Redirect("ComprarBilhete.aspx");
                    }
                    else
                    {
                        int quantidadeC = valorContadorC + verificaC;
                        int valorCAtualizado = int.Parse(valorc) * quantidadeC;

                        // Edita a linha existente na tabela Carrinho
                        SqlCommand commandAtualizarC = new SqlCommand("UPDATE Carrinho SET quantidade = '" + quantidadeC + "' , preco = '" + valorCAtualizado + "'where idUser = '" + idUser + "' and idPista = '" + idPista + "' and idBancada = '" + bancadaC + "' and tipo = 'Corrida'", connection);
                        string carrinhoC = Convert.ToString(commandAtualizarC.ExecuteScalar());

                        Response.Redirect("ComprarBilhete.aspx");
                    }


                    connection.Close();
                }
            }
            else
            {
                Response.Redirect("ComprarBilhete.aspx");
            }
        }
        protected void btnAtualizarFDS_Click(object sender, EventArgs e)
        {
            string nomePista = Session["nomePista"] as string;
            string nomePistaRedirect = nomePista.Replace(" ", "");
            selectedOption = selectElementFDS.SelectedValue;
            valorContadorFDS = int.Parse(contadorFDS.InnerText);

            if (valorContadorFDS > 0)
            {
                using (SqlConnection connection = new SqlConnection(ConnectionString))
                {
                    connection.Open();

                    //Id Pista
                    SqlCommand commandID = new SqlCommand("SELECT MAX(idPista) FROM Pistas WHERE nomePista = '" + nomePista + "'", connection);
                    int idPista = (int)commandID.ExecuteScalar();

                    // Selecionar Preço da bancada que o utilizador escolheu no fim de semana
                    SqlCommand commandValorFDS = new SqlCommand("SELECT preco FROM BancadaFDS where idPista = '" + idPista + "' and letraBancada = '" + selectedOption + "'", connection);
                    string valorfds = Convert.ToString(commandValorFDS.ExecuteScalar());

                    // Selecionar id da bancada que o utilizador escolheu no fim de semana
                    SqlCommand commandBancadaFDS = new SqlCommand("SELECT idBancada FROM BancadaFDS where idPista = '" + idPista + "' and letraBancada = '" + selectedOption + "'", connection);
                    string bancadaFDS = Convert.ToString(commandBancadaFDS.ExecuteScalar());

                    int valorFDS = int.Parse(valorfds) * valorContadorFDS;

                    // Verifica se já existe algo daquele fim de semana no carrinho
                    SqlCommand commandVerificaFDS = new SqlCommand("SELECT quantidade FROM Carrinho where idUser = '" + idUser + "' and idPista = '" + idPista + "' and idBancada = '" + bancadaFDS + "' and tipo = 'Fim de semana Completo'", connection);
                    int verificaFDS = Convert.ToInt32(commandVerificaFDS.ExecuteScalar());

                    if (verificaFDS == 0)
                    {

                        // Cria a linha na tabela Carrinho
                        SqlCommand commandCarrinhoFDS = new SqlCommand("INSERT INTO Carrinho (idUser, quantidade, idPista, idBancada, preco, tipo) VALUES('" + idUser + "','" + valorContadorFDS + "' , '" + idPista + "','" + bancadaFDS + "','" + valorFDS + "', 'Fim de semana Completo' )", connection);
                        string carrinhoFDS = Convert.ToString(commandCarrinhoFDS.ExecuteScalar());

                        Response.Redirect("ComprarBilhete.aspx");
                    }
                    else
                    {
                        int quantidadeFDS = valorContadorFDS + verificaFDS;
                        int valorFDSAtualizado = int.Parse(valorfds) * quantidadeFDS;

                        // Edita a linha existente na tabela Carrinho
                        SqlCommand commandAtualizarFDS = new SqlCommand("UPDATE Carrinho SET quantidade = '" + quantidadeFDS + "' , preco = '" + valorFDSAtualizado + "'where idUser = '" + idUser + "' and idPista = '" + idPista + "' and idBancada = '" + bancadaFDS + "' and tipo = 'Fim de semana Completo'", connection);
                        string carrinhoFDS = Convert.ToString(commandAtualizarFDS.ExecuteScalar());

                        Response.Redirect("ComprarBilhete.aspx");
                    }

                    connection.Close();
                }
            }
            else
            {
                Response.Redirect("ComprarBilhete.aspx");
            }
        }

        // Função para aumentar o contador T
        public void MaisT_Click(object sender, EventArgs e)
        {
            if (int.TryParse(contadorT.InnerText, out valorContadorT))
            {
                valorContadorT++;
                contadorT.InnerText = valorContadorT.ToString();

            }
        }

        // Função para diminuir o contador T
        protected void MenosT_Click(object sender, EventArgs e)
        {
            valorContadorT = int.Parse(contadorT.InnerText);
            if (valorContadorT > 0)
            {
                valorContadorT--;
                contadorT.InnerText = valorContadorT.ToString();
            }
        }

        // Função para aumentar o contador Q
        protected void MaisQ_Click(object sender, EventArgs e)
        {
            if (int.TryParse(contadorQ.InnerText, out valorContadorQ))
            {
                valorContadorQ++;
                contadorQ.InnerText = valorContadorQ.ToString();

            }
        }

        // Função para diminuir o contador Q
        protected void MenosQ_Click(object sender, EventArgs e)
        {
            valorContadorQ = int.Parse(contadorQ.InnerText);
            if (valorContadorQ > 0)
            {
                valorContadorQ--;
                contadorQ.InnerText = valorContadorQ.ToString();
            }
        }

        // Função para aumentar o contador C
        protected void MaisC_Click(object sender, EventArgs e)
        {
            if (int.TryParse(contadorC.InnerText, out valorContadorC))
            {
                valorContadorC++;
                contadorC.InnerText = valorContadorC.ToString();

            }
        }

        // Função para diminuir o contador C
        protected void MenosC_Click(object sender, EventArgs e)
        {
            valorContadorC = int.Parse(contadorC.InnerText);
            if (valorContadorC > 0)
            {
                valorContadorC--;
                contadorC.InnerText = valorContadorC.ToString();
            }
        }

        // Função para aumentar o contador FDS
        protected void MaisFDS_Click(object sender, EventArgs e)
        {
            if (int.TryParse(contadorFDS.InnerText, out valorContadorFDS))
            {
                valorContadorFDS++;
                contadorFDS.InnerText = valorContadorFDS.ToString();

            }
        }
        protected void MenosFDS_Click(object sender, EventArgs e)
        {
            valorContadorFDS = int.Parse(contadorFDS.InnerText);
            if (valorContadorFDS > 0)
            {
                valorContadorFDS--;
                contadorFDS.InnerText = valorContadorFDS.ToString();
            }
        }
    }
}