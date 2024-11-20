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

namespace PIM_Constate_Desktop_2._0
{
   
    public partial class LoginFuncionario : Form
    {
        private clnConexao conexao;
        private string connectionString = "Data Source=localhost;Initial Catalog=FAZENDA_AGROCONNECT;Integrated Security=True;Encrypt=False";
        private string origemFormulario;
        public LoginFuncionario(string origem)
        {
            InitializeComponent();
            origemFormulario = origem;  // Define de onde o formulário foi aberto
            conexao = new clnConexao(connectionString);
        }
        public LoginFuncionario()
        {
            InitializeComponent();
            // Inicializa a conexão ao criar o formulário
            conexao = new clnConexao(connectionString);
        }
     
        private void btnEnviar_Click(object sender, EventArgs e)
        {
            Visible = false;

            string usuario = txtUser.Text;
            string senha = txtPassword.Text;

            try
            {
                conexao.Open(); // Abre a conexão
                string query = "SELECT COUNT(*) FROM tb_funcionario WHERE usuario_funcionario = @usuario AND senha_funcionario = @senha";
                using (SqlCommand command = new SqlCommand(query, conexao.GetConnection()))
                {
                    command.Parameters.AddWithValue("@usuario", usuario);
                    command.Parameters.AddWithValue("@senha", senha);

                    int userCount = (int)command.ExecuteScalar();

                    if (userCount > 0)
                    {
                        MessageBox.Show("Acesso liberado!!");
                        Session.IsLoggedIn = true;
                        Menu menu = new Menu();
                        
                        menu.ShowDialog();
                        
                    }
                    else
                    {
                        txtUser.Text = "";
                        txtPassword.Text = "";
                        MessageBox.Show("Acesso inválido! \nVerificar usuário e senha.");
                        Session.IsLoggedIn = false;
                        Menu menu = new Menu();

                        menu.ShowDialog();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                conexao.Close(); // Fecha a conexão
            }
    }

        private void btnVoltar_Click(object sender, EventArgs e)
        {
            // Cria uma nova instância do formulário Menu
            Menu menuForm = new Menu();

            // Exibe o formulário Menu
           
            menuForm.Show();
            

            // Fecha o formulário LoginFuncionario
            this.Close();
        }

       
    }
    public static class Session
    {
        // Variável estática para armazenar o estado de login
        public static bool IsLoggedIn { get; set; } = false;

    }
}
