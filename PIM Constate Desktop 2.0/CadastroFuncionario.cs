using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Extensions.Configuration;


namespace PIM_Constate_Desktop_2._0
{
    public partial class CadastroFuncionario : Form
    {

        // ==============================
        // Adição da conexão
        // ==============================
        private clnConexao conexao;
        private string connectionString = "Data Source=localhost;Initial Catalog=FAZENDA_AGROCONNECT;Integrated Security=True;Encrypt=False";

        public CadastroFuncionario()
        {
            InitializeComponent();
            // Inicializa a conexão ao criar o formulário
            conexao = new clnConexao(connectionString);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            // Cria uma nova instância do formulário Menu
            Menu menuForm = new Menu();

            // Exibe o formulário Menu
            menuForm.Show();

            // Fecha o formulário CadastroFuncionario
            this.Close();
        }

        private void btnEnviar_Click(object sender, EventArgs e)
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
                string query = "INSERT INTO dbo.tb_funcionario (nome_completo_funcionario, cpf_funcionario, data_nascimento_funcionario, email_funcionario, cargo_funcionario, salario_funcionario, usuario_funcionario, senha_funcionario, status_funcionario) VALUES (@nome, @cpf, @nascimento, @email, @cargo, @salario, @usuario, @senha, @status)";
                SqlCommand command = new SqlCommand(query, conexao.GetConnection());
                DateTime.TryParse(nascimento, out DateTime nascimentoo);
                // Adiciona os parâmetros
                command.Parameters.AddWithValue("@nome", nome);
                command.Parameters.AddWithValue("@cpf", cpf);
                command.Parameters.AddWithValue("@nascimento", nascimentoo); // Converte a data de nascimento
                command.Parameters.AddWithValue("@email", email);
                command.Parameters.AddWithValue("@cargo", cargo); // Usar o cargo fornecido
                command.Parameters.AddWithValue("@salario", decimal.Parse(salario)); // Converte o salário para decimal
                command.Parameters.AddWithValue("@status", 1); // 1 para ativo
                command.Parameters.AddWithValue("@usuario", usuario);
                command.Parameters.AddWithValue("@senha", senha); // Considere criptografar a senha antes de salvar
               

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
               "\nStatus" + txtStatus.Text + "" +
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
        }

       
    }
}
