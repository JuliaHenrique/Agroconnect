using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PIM_Constate_Desktop_2._0
{
    public partial class AdicionarProduto : Form
    {


        // ==============================
        // Adição da conexão
        // ==============================
        private clnConexao conexao;
       
        private string connectionString = "Data Source=localhost;Initial Catalog=FAZENDA_AGROCONNECT;Integrated Security=True;Encrypt=False";

        public string NomeProduto { get; set; }
        public string QuantidadeProduto { get; set; }
        public decimal PrecoProduto { get; set; }
        public string CategoriaProduto { get; set; }
        public string CodigoProduto { get; set; }

        // Propriedade para armazenar a origem de onde o formulário foi aberto
        private string origemFormulario;

        // Construtor para passar a origem
        public AdicionarProduto(string origem)
        {
            InitializeComponent();
            origemFormulario = origem;  // Define de onde o formulário foi aberto
        }

        // Evento de carregamento do formulário
        public AdicionarProduto()
        {
            InitializeComponent();
            // Inicializa a conexão ao criar o formulário
            conexao = new clnConexao(connectionString);
        }

        private string GerarCodigoProduto()
        {
            // Gerar um código simples com base no nome, categoria e um número aleatório
            string nomeParcial = txtNome.Text.Length > 3 ? txtNome.Text.Substring(0, 3).ToUpper() : txtNome.Text.ToUpper();  // Primeiros 3 caracteres do nome
            string categoriaParcial = cmbCategoria.SelectedItem?.ToString().Substring(0, 3).ToUpper() ?? "GEN";  // Primeiros 3 caracteres da categoria

            Random rand = new Random();
            int numeroAleatorio = rand.Next(1000, 9999);  // Número aleatório entre 1000 e 9999

            // Concatenando o nome, categoria e número aleatório para gerar o código
            string codigoProduto = $"{nomeParcial}-{categoriaParcial}-{numeroAleatorio}";
            return codigoProduto;
        }

        private void btnAdicionar_Click(object sender, EventArgs e)
        {
            // Validações simples
            if (string.IsNullOrEmpty(txtNome.Text) || string.IsNullOrEmpty(txtQuantidade.Text) || string.IsNullOrEmpty(txtPreco.Text))
            {
                MessageBox.Show("Por favor, preencha todos os campos.");
                return;
            }

            // Atribuindo os valores inseridos
            NomeProduto = txtNome.Text;
            QuantidadeProduto = txtQuantidade.Text;
            PrecoProduto = decimal.Parse(txtPreco.Text); // Converter o preço para decimal
            CategoriaProduto = cmbCategoria.SelectedItem.ToString();

            // Gerando o código único para o produto (GUID)
            CodigoProduto = GerarCodigoProduto();

            // Exibindo o código gerado no formulário
            txtCodigoRastreio.Text = CodigoProduto;

            // Criar uma instância da classe de conexão
            clnConexao conexao = new clnConexao(connectionString);

            // Tentar salvar o produto no banco de dados
            bool sucesso = conexao.InserirProduto(NomeProduto, QuantidadeProduto, PrecoProduto, CategoriaProduto, CodigoProduto);

            // Verificar se a inserção foi bem-sucedida
            if (sucesso)
            {
                MessageBox.Show("Produto adicionado com sucesso! Código: " + CodigoProduto);
            }
            else
            {
                MessageBox.Show("Erro ao adicionar o produto.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            // Limpar os campos para adicionar um novo produto
            txtNome.Text = "";
            txtQuantidade.Text = "";
            txtPreco.Text = "";
            cmbCategoria.SelectedIndex = 0;  // Volta para a categoria padrão
            txtCodigoRastreio.Text = "";  // Limpa o código gerado

            // Foco no primeiro campo para agilizar o próximo cadastro
            txtNome.Focus();
        }

        private void label1_Click(object sender, EventArgs e)
        {
            // Preencher o ComboBox com categorias
            cmbCategoria.Items.Add("Legume");
            cmbCategoria.Items.Add("Fruta");
            cmbCategoria.Items.Add("Verdura");
            cmbCategoria.SelectedIndex = 0; // Seleciona o primeiro item por padrão
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            if (origemFormulario == "Menu")
            {
                // Se veio do menu, volta para o Menu
                var menu = new Menu();
                menu.Show();
                this.Hide(); // Esconde o FormAdicionarProduto
            }
            else if (origemFormulario == "TabelaProdutos")
            {
                // Se veio da Tabela de Produtos, volta para TabelaProdutos
                var tabelaProdutosForm = new TabelaProdutos();
                
                this.Hide(); // Esconde o FormAdicionarProduto
            }
        }
    }
}
