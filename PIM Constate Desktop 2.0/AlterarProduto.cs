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
    public partial class AlterarProduto : Form
    {
        // ==============================
        // Adição da conexão
        // ==============================
        private clnConexao conexao;
        private string connectionString = "Data Source=localhost;Initial Catalog=FAZENDA_AGROCONNECT;Integrated Security=True;Encrypt=False";
        private string origemFormulario;
        public AlterarProduto(string origem)
        {
            InitializeComponent();
            origemFormulario = origem;  // Define de onde o formulário foi aberto
            conexao = new clnConexao(connectionString);
        }

        public AlterarProduto()
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
                string query = "SELECT * FROM dbo.Produtos WHERE CodigoProduto = @codigo";
                string Codigo = txtCodigoRastreio.Text;




                // Criando o comando SQL
                SqlCommand command = new SqlCommand(query, conexao.GetConnection());
                command.Parameters.AddWithValue("@codigo", Codigo); // Protegendo contra SQL Injection

                // Executando a consulta e obtendo os dados
                SqlDataReader reader = command.ExecuteReader();

                // Verificando se encontrou algum dado
                if (reader.HasRows)
                {
                    reader.Read(); // Lê a primeira linha de resultado

                    // Preenche os TextBox com os valores retornados
                    txtNome.Text = reader["NomeProduto"].ToString();
                    txtQuantidade.Text = reader["Quantidadeproduto"].ToString();
                    txtPreco.Text = reader["PrecoProduto"].ToString();
                    cmbCategoria.SelectedItem = reader["CategoriaProduto"].ToString();

                    // Habilita os campos para edição
                    txtNome.Enabled = true;
                    txtQuantidade.Enabled = true;
                    txtPreco.Enabled = true;
                    cmbCategoria.Enabled = true;
                    txtCodigoRastreio.Enabled = false;
                    reader.Close();
                }
                else
                {
                    MessageBox.Show("Produto não encontrado.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao buscar Produto: {ex.Message}");
            }
            finally
            {
                conexao.Close();
            }
        }

        private void btnAlterar_Click(object sender, EventArgs e)
        {
            // Atribuindo os valores inseridos
            string NomeProduto = txtNome.Text;
            string QuantidadeProduto = txtQuantidade.Text;
            decimal PrecoProduto = decimal.Parse(txtPreco.Text); // Converter o preço para decimal
            string CategoriaProduto = cmbCategoria.SelectedItem.ToString();
            string CodigoProduto = txtCodigoRastreio.Text;

            bool sucesso = conexao.alterarProduto(NomeProduto, QuantidadeProduto, PrecoProduto, CategoriaProduto, CodigoProduto);
            
            if (sucesso)
            {
                MessageBox.Show("Produto alterado com sucesso! Código: " + CodigoProduto);
                txtNome.Text = "";
                txtQuantidade.Text = "";
                txtPreco.Text = "";
                cmbCategoria.SelectedIndex = -1;  // Volta para a categoria padrão
                txtCodigoRastreio.Text = "";  // Limpa o código gerado
            }
            else
            {
                MessageBox.Show("Erro ao alterar o produto.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtNome.Text = "";
                txtQuantidade.Text = "";
                txtPreco.Text = "";
                cmbCategoria.SelectedIndex = -1;  // Volta para a categoria padrão
                txtCodigoRastreio.Text = "";  // Limpa o código gerado
            }
            
            txtCodigoRastreio.Enabled = true;
            txtNome.Enabled = false;
            txtQuantidade.Enabled = false;
            txtPreco.Enabled = false;
            cmbCategoria.Enabled = false;

        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            {
                if (string.IsNullOrWhiteSpace(txtCodigoRastreio.Text))
                {
                    MessageBox.Show("Necessário pesquisar Código do produto!!!");
                    return;
                }
                if (string.IsNullOrEmpty(txtNome.Text) || string.IsNullOrEmpty(cmbCategoria.Text) || string.IsNullOrEmpty(txtCodigoRastreio.Text))
                {
                    MessageBox.Show("Necessário pesquisar Código do produto!!!");
                    return;
                }

                try
                {
                    conexao.Open();
                    string query = "SELECT * FROM dbo.Produtos WHERE CodigoProduto = @codigo";
                    string Codigo = txtCodigoRastreio.Text;
                    // Criando o comando SQL
                    SqlCommand command = new SqlCommand(query, conexao.GetConnection());
                    command.Parameters.AddWithValue("@codigo", Codigo); // Protegendo contra SQL Injection

                    // Executando a consulta e obtendo os dados
                    SqlDataReader reader = command.ExecuteReader();

                    // Verificando se encontrou algum dado
                    if (reader.HasRows)
                    {
                        reader.Read(); // Lê a primeira linha de resultado

                        // Preenche os TextBox com os valores retornados
                        txtNome.Text = reader["NomeProduto"].ToString();
                        txtQuantidade.Text = reader["Quantidadeproduto"].ToString();
                        txtPreco.Text = reader["PrecoProduto"].ToString();
                        cmbCategoria.SelectedItem = reader["CategoriaProduto"].ToString();


                        // Fechando o SqlDataReader antes de executar outro comando
                        reader.Close();

                        // Mensagem de confirmação
                        var result = MessageBox.Show("Tem certeza que deseja excluir o produto?",
                                                     "Confirmar Exclusão",
                                                     MessageBoxButtons.YesNo,
                                                     MessageBoxIcon.Question);

                        // Se o usuário clicar em 'Sim', continua a exclusão
                        if (result == DialogResult.Yes)
                        {
                            try
                            {
                                // Novo comando para a exclusão
                                string query2 = "DELETE FROM dbo.Produtos WHERE CodigoProduto = @codigo";

                                SqlCommand command2 = new SqlCommand(query2, conexao.GetConnection());
                                command2.Parameters.AddWithValue("@codigo", Codigo);

                                int rowsAffected = command2.ExecuteNonQuery();

                                if (rowsAffected > 0)
                                {
                                    MessageBox.Show("produto excluído com sucesso.");

                                }
                                else
                                {
                                    MessageBox.Show("Nenhum produto encontrado para exclusão.");
                                }
                            }
                            catch
                            {
                                MessageBox.Show($"Erro ao excluir produto");
                            }
                        }
                        else
                        {
                            MessageBox.Show("Exclusão cancelada.");
                        }
                    }
                    else
                    {
                        MessageBox.Show("produto não encontrado.");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Erro ao buscar produto: {ex.Message}");
                }
                finally
                {
                    conexao.Close();
                    txtNome.Text = "";
                    txtQuantidade.Text = "";
                    txtPreco.Text = "";
                    cmbCategoria.SelectedIndex = -1;  // Volta para a categoria padrão
                    txtCodigoRastreio.Text = "";  // Limpa o código gerado
                    txtCodigoRastreio.Enabled = true;
                    txtNome.Enabled = false;
                    txtQuantidade.Enabled = false;
                    txtPreco.Enabled = false;
                    cmbCategoria.Enabled = false;
                }
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            if (origemFormulario == "Menu")
            {
                // Se veio do menu, volta para o Menu
                var menu = new PIM_Constate_Desktop_2._0.Menu();
                menu.Show();
                this.Hide(); // Esconde o FormAdicionarProduto
            }
            else if (origemFormulario == "TabelaProdutos")
            {
                // Se veio da Tabela de Produtos, volta para TabelaProdutos
                var tabelaProdutosForm = new TabelaProdutos();
                tabelaProdutosForm.Show();
                this.Hide(); // Esconde o FormAdicionarProduto
            }
        }

        private void btnLimpar_Click(object sender, EventArgs e)
        {
            txtNome.Text = "";
            txtQuantidade.Text = "";
            txtPreco.Text = "";
            cmbCategoria.SelectedIndex = -1;  // Volta para a categoria padrão
            txtCodigoRastreio.Text = "";  // Limpa o código gerado
            txtCodigoRastreio.Enabled = true;
            txtNome.Enabled = false;
            txtQuantidade.Enabled = false;
            txtPreco.Enabled = false;
            cmbCategoria.Enabled = false;
        }
    }
    }

