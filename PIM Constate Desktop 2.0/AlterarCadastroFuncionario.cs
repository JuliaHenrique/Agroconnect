using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TextBox;

namespace PIM_Constate_Desktop_2._0
{
    public partial class AlterarCadastroFuncionario : Form
    {

        // ==============================
        // Adição da conexão
        // ==============================
        private clnConexao conexao;
        private string connectionString = "Data Source=localhost;Initial Catalog=FAZENDA_AGROCONNECT;Integrated Security=True;Encrypt=False";

        public AlterarCadastroFuncionario()
        {
            InitializeComponent();
            // Inicializa a conexão ao criar o formulário
            conexao = new clnConexao(connectionString);
        }

        private void btnPesquisar_Click(object sender, EventArgs e)
        {

            try
            {
                conexao.Open();
                string query = "SELECT * FROM dbo.tb_funcionario WHERE cpf_funcionario = @cpf";
                string cpf = txtCPF.Text;




                // Criando o comando SQL
                SqlCommand command = new SqlCommand(query, conexao.GetConnection());
                command.Parameters.AddWithValue("@cpf", cpf); // Protegendo contra SQL Injection

                // Executando a consulta e obtendo os dados
                SqlDataReader reader = command.ExecuteReader();

                // Verificando se encontrou algum dado
                if (reader.HasRows)
                {
                    reader.Read(); // Lê a primeira linha de resultado

                    // Preenche os TextBox com os valores retornados
                    txtNome.Text = reader["nome_completo_funcionario"].ToString();
                    DateTime dataNascimento = Convert.ToDateTime(reader["data_nascimento_funcionario"]);
                    txtNascimento.Text = dataNascimento.ToString("dd/MM/yyyy");
                    txtEndereco.Text = reader["endereco_funcionario"]?.ToString();
                    txtEmail.Text = reader["email_funcionario"].ToString();
                    txtCargo.Text = reader["cargo_funcionario"].ToString();
                    txtSalario.Text = reader["salario_funcionario"].ToString();
                    txtStatus.Text = reader["status_funcionario"].ToString();
                    txtUsuario.Text = reader["usuario_funcionario"].ToString();
                    txtSenha.Text = reader["senha_funcionario"].ToString();

                    //Habilita os campos
                    txtNome.Enabled = true;
                    txtEndereco.Enabled = true;
                    txtEmail.Enabled = true;
                    txtCargo.Enabled = true;
                    txtSalario.Enabled = true;
                    txtStatus.Enabled = true;
                    txtUsuario.Enabled = true;
                    txtSenha.Enabled = true;
                }
                else
                {
                    MessageBox.Show("Funcionário não encontrado.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao buscar Funcionário: {ex.Message}");
            }
            finally
            {
                conexao.Close();
            }
        }

        private void btnEnviarAlteracao_Click(object sender, EventArgs e)
        {
            // ==============================
            // Envio dos dados para o banco
            // ==============================
            string nome = txtNome.Text;
            string cpf = txtCPF.Text;
            string nascimento = txtNascimento.Text;
            string endereco = txtEndereco.Text;
            string email = txtEmail.Text;
            string cargo = txtCargo.Text;
            string salario = txtSalario.Text;
            string status = txtStatus.Text;
            string usuario = txtUsuario.Text;     // Considerando que este é o nome de usuário
            string senha = txtSenha.Text;         // Considerando que este é a senha

            try
            {
                conexao.Open();

                string query = "UPDATE dbo.tb_funcionario SET " +
                                     "nome_completo_funcionario = @nome, " +
                                     "endereco_funcionario = @endereco, " +
                                     "data_nascimento_funcionario = @nascimento, " +
                                     "email_funcionario = @email, " +
                                     "cargo_funcionario = @cargo, " +
                                     "salario_funcionario = @salario, " +
                                     "usuario_funcionario = @usuario, " +
                                     "senha_funcionario = @senha, " +
                                     "status_funcionario = @status " +
                                     "WHERE cpf_funcionario = @cpf";

                SqlCommand command = new SqlCommand(query, conexao.GetConnection());
                DateTime.TryParse(nascimento, out DateTime nascimentoo);
                // Adiciona os parâmetros
                command.Parameters.AddWithValue("@nome", nome);
                command.Parameters.AddWithValue("@cpf", cpf);
                command.Parameters.AddWithValue("@nascimento", nascimentoo); // Converte a data de nascimento
                command.Parameters.AddWithValue("@email", email);
                command.Parameters.AddWithValue("@cargo", cargo);
                command.Parameters.AddWithValue("@endereco", endereco);
                command.Parameters.AddWithValue("@salario", decimal.Parse(salario)); // Converte o salário para decimal
                command.Parameters.AddWithValue("@status", 1); // 1 para ativo
                command.Parameters.AddWithValue("@usuario", usuario);
                command.Parameters.AddWithValue("@senha", senha);


                command.ExecuteNonQuery();
                MessageBox.Show("Funcionário cadastrado com sucesso!");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro: " + ex.Message);
            }
            finally
            {
                conexao.Close();
                //Desabilita campos
                txtNome.Enabled = false;
                txtEndereco.Enabled = false;
                txtEmail.Enabled = false;
                txtCargo.Enabled = false;
                txtSalario.Enabled = false;
                txtStatus.Enabled = false;
                txtUsuario.Enabled = false;
                txtSenha.Enabled = false;
            }

            // ==============================
            // Mensagem de visualização
            // ==============================
            MessageBox.Show
               (
               "Nome:" + txtNome.Text + "" +
               "\nCPF:" + txtCPF.Text + "" +
               "\nData de nascimento:" + txtNascimento.Text + "" +
               "\nEndereço:" + txtEndereco.Text + "" +
               "\nE-mail:" + txtEmail.Text + "" +
               "\nCargo:" + txtCargo.Text + "" +
               "\nSalario:" + txtSalario.Text + "" +
               "\nStatus:" + txtStatus.Text + "" +
               "\nCriar usuário:" + txtUsuario.Text + "" +
               "\nCriar senha:" + txtSenha.Text
               );
        }

        private void btnLimpar_Click(object sender, EventArgs e)
        {
            txtNome.Text = "";
            txtCPF.Text = "";
            txtNascimento.Text = "";
            txtEndereco.Text = "";
            txtEmail.Text = "";
            txtCargo.Text = "";
            txtSalario.Text = "";
            txtStatus.Text = "";
            txtUsuario.Text = "";
            txtSenha.Text = "";
            //Desabilita campos
            txtNome.Enabled = false;
            txtEndereco.Enabled = false;
            txtEmail.Enabled = false;
            txtCargo.Enabled = false;
            txtSalario.Enabled = false;
            txtStatus.Enabled = false;
            txtUsuario.Enabled = false;
            txtSenha.Enabled = false;
        }

        private void btnVoltar_Click(object sender, EventArgs e)
        {
            // Cria uma nova instância do formulário Menu
            Menu menuForm = new Menu();

            // Exibe o formulário Menu
            menuForm.Show();

            // Fecha o formulário CadastroFuncionario
            this.Close();
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtCPF.Text))
            {
                MessageBox.Show("Necessário pesquisar CPF funcionário!!!");
                return;
            }
            if (string.IsNullOrEmpty(txtNome.Text) || string.IsNullOrEmpty(txtCPF.Text) || string.IsNullOrEmpty(txtEmail.Text) ||
                string.IsNullOrEmpty(txtCargo.Text) || string.IsNullOrEmpty(txtUsuario.Text) || string.IsNullOrEmpty(txtSenha.Text))
            {
                MessageBox.Show("Necessário pesquisar CPF funcionário!!!");
                return;
            }

            try
            {
                conexao.Open();
                string query = "SELECT * FROM dbo.tb_funcionario WHERE cpf_funcionario = @cpf";
                string cpf = txtCPF.Text;

                // Criando o comando SQL
                SqlCommand command = new SqlCommand(query, conexao.GetConnection());
                command.Parameters.AddWithValue("@cpf", cpf); // Protegendo contra SQL Injection

                // Executando a consulta e obtendo os dados
                SqlDataReader reader = command.ExecuteReader();

                // Verificando se encontrou algum dado
                if (reader.HasRows)
                {
                    reader.Read(); // Lê a primeira linha de resultado

                    // Preenche os TextBox com os valores retornados
                    txtNome.Text = reader["nome_completo_funcionario"].ToString();
                    DateTime dataNascimento = Convert.ToDateTime(reader["data_nascimento_funcionario"]);
                    txtNascimento.Text = dataNascimento.ToString("dd/MM/yyyy");
                    txtEndereco.Text = reader["endereco_funcionario"]?.ToString();
                    txtEmail.Text = reader["email_funcionario"].ToString();
                    txtCargo.Text = reader["cargo_funcionario"].ToString();
                    txtSalario.Text = reader["salario_funcionario"].ToString();
                    txtStatus.Text = reader["status_funcionario"].ToString();
                    txtUsuario.Text = reader["usuario_funcionario"].ToString();
                    txtSenha.Text = reader["senha_funcionario"].ToString();

                    // Fechando o SqlDataReader antes de executar outro comando
                    reader.Close();

                    // Mensagem de confirmação
                    var result = MessageBox.Show("Tem certeza que deseja excluir o funcionário?",
                                                 "Confirmar Exclusão",
                                                 MessageBoxButtons.YesNo,
                                                 MessageBoxIcon.Question);

                    // Se o usuário clicar em 'Sim', continua a exclusão
                    if (result == DialogResult.Yes)
                    {
                        try
                        {
                            // Novo comando para a exclusão
                            string query2 = "DELETE FROM dbo.tb_funcionario WHERE cpf_funcionario = @cpf";

                            SqlCommand command2 = new SqlCommand(query2, conexao.GetConnection());
                            command2.Parameters.AddWithValue("@cpf", cpf);

                            int rowsAffected = command2.ExecuteNonQuery();

                            if (rowsAffected > 0)
                            {
                                MessageBox.Show("Funcionário excluído com sucesso.");
                        
                            }
                            else
                            {
                                MessageBox.Show("Nenhum funcionário encontrado para exclusão.");
                            }
                        }
                        catch
                        {
                            MessageBox.Show($"Erro ao excluir funcionário");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Exclusão cancelada.");
                    }
                }
                else
                {
                    MessageBox.Show("Funcionário não encontrado.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao buscar funcionário: {ex.Message}");
            }
            finally
            {
                conexao.Close();
                txtNome.Enabled = false;
                txtEndereco.Enabled = false;
                txtEmail.Enabled = false;
                txtCargo.Enabled = false;
                txtSalario.Enabled = false;
                txtStatus.Enabled = false;
                txtUsuario.Enabled = false;
                txtSenha.Enabled = false;
            }
        }

    }
}
