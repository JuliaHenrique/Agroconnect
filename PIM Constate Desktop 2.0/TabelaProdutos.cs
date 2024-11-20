using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static PIM_Constate_Desktop_2._0.TabelaProdutos;

namespace PIM_Constate_Desktop_2._0
{
    public partial class TabelaProdutos : Form
    {
        // Usando BindingList para que o DataGridView se atualize automaticamente
        private BindingList<PRODUTOO> produtos;
        public TabelaProdutos()
        {
            InitializeComponent();
            InicializarProdutos();
        }
        public class PRODUTOO
        {
            public int ID { get; set; }
            public string Nome { get; set; }
            public string Quantidade { get; set; }
            public decimal Preco { get; set; }
            public string Categoria { get; set; }
        }
        private void InicializarProdutos()
        {
            // Inicializando o BindingList com produtos
            produtos = new BindingList<PRODUTOO>
            {
                // Legumes
                new PRODUTOO { ID = 1, Nome = "Abóbora", Quantidade = "Abóbora de cor laranja", Preco = 8.9m, Categoria = "Legume" },
                new PRODUTOO { ID = 2, Nome = "Batata", Quantidade = "Batata comum", Preco = 1.95m, Categoria = "Legume" },
                new PRODUTOO { ID = 3, Nome = "Cenoura", Quantidade = "Cenoura fresca", Preco = 1.9m, Categoria = "Legume" },
                new PRODUTOO { ID = 4, Nome = "Chuchu", Quantidade = "Chuchu verde", Preco = 1.8m, Categoria = "Legume" },
                new PRODUTOO { ID = 5, Nome = "Pimentão", Quantidade = "Pimentão vermelho", Preco = 7.15m, Categoria = "Legume" },
                new PRODUTOO { ID = 6, Nome = "Beterraba", Quantidade = "Beterraba fresca", Preco = 1.85m, Categoria = "Legume" },

                // Frutas
                new PRODUTOO { ID = 7, Nome = "Abacaxi", Quantidade = "Abacaxi fresco", Preco = 6.0m, Categoria = "Fruta" },
                new PRODUTOO { ID = 8, Nome = "Abacate", Quantidade = "Abacate maduro", Preco = 6.5m, Categoria = "Fruta" },
                new PRODUTOO { ID = 9, Nome = "Banana", Quantidade = "Banana prata", Preco = 1.0m, Categoria = "Fruta" },
                new PRODUTOO { ID = 10, Nome = "Kiwi", Quantidade = "Kiwi fresco", Preco = 4.3m, Categoria = "Fruta" },
                new PRODUTOO { ID = 11, Nome = "Laranja", Quantidade = "Laranja doce", Preco = 2.0m, Categoria = "Fruta" },
                new PRODUTOO { ID = 12, Nome = "Mexerica", Quantidade = "Mexerica fresca", Preco = 2.45m, Categoria = "Fruta" },

                // Verduras
                new PRODUTOO { ID = 13, Nome = "Agrião", Quantidade = "Agrião fresco", Preco = 5.5m, Categoria = "Verdura" },
                new PRODUTOO { ID = 14, Nome = "Alecrim", Quantidade = "Alecrim para tempero", Preco = 2.8m, Categoria = "Verdura" },
                new PRODUTOO { ID = 15, Nome = "Alface", Quantidade = "Alface americana", Preco = 3.05m, Categoria = "Verdura" },
                new PRODUTOO { ID = 16, Nome = "Brócolis", Quantidade = "Brócolis frescos", Preco = 9.0m, Categoria = "Verdura" },
                new PRODUTOO { ID = 17, Nome = "Couve-flor", Quantidade = "Couve-flor branca", Preco = 10.9m, Categoria = "Verdura" },
                new PRODUTOO { ID = 18, Nome = "Rabanete", Quantidade = "Rabanete fresco", Preco = 3.45m, Categoria = "Verdura" }
            };

            

            // Configura o DataGridView com a lista de produtos (BindingList)
            dataGridView1.DataSource = produtos;

            // Personalizando as colunas
            dataGridView1.Columns["ID"].HeaderText = "ID do Produto";
            dataGridView1.Columns["Nome"].HeaderText = "Nome do Produto";
            dataGridView1.Columns["Quantidade"].HeaderText = "Quantidade";
            dataGridView1.Columns["Preco"].HeaderText = "Preço";
            dataGridView1.Columns["Categoria"].HeaderText = "Categoria";

            // Formatando a coluna de Preço como moeda
            dataGridView1.Columns["Preco"].DefaultCellStyle.Format = "C2";  // Formatar como moeda
        }

        private void btnAdicionar_Click(object sender, EventArgs e)
        {
            // Criar uma instância do formulário para adicionar produto
            AdicionarProduto formAdicionar = new AdicionarProduto("TabelaProdutos");

            // Exibe o formulário como modal
            if (formAdicionar.ShowDialog() == DialogResult.OK)
            {
                // Adiciona o novo produto à lista
                var novoProduto = new PRODUTOO
                {
                    ID = produtos.Count + 1, // Novo ID único
                    Nome = formAdicionar.NomeProduto,
                    Quantidade = formAdicionar.QuantidadeProduto,
                    Preco = formAdicionar.PrecoProduto,
                    Categoria = formAdicionar.CategoriaProduto
                };

                // Adiciona o produto à lista de produtos
                produtos.Add(novoProduto);
            }
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            // Verifica se há algum item selecionado no DataGridView
            if (dataGridView1.SelectedRows.Count > 0)
            {
                var produtoSelecionado = (PRODUTOO)dataGridView1.SelectedRows[0].DataBoundItem;

                // Remove o produto da lista
                produtos.Remove(produtoSelecionado);
            }
            else
            {
                MessageBox.Show("Selecione um produto para excluir.");
            }
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

        
    }
}
    
