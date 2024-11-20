using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PIM_Constate_Desktop_2._0;

namespace fiscal
{
    public partial class NotaFiscal : Form
    {
        public NotaFiscal()
        {
            InitializeComponent();
        }

        private void NotaFiscal_Load(object sender, EventArgs e)
        {

        }

        private void btnGerarNota_Click(object sender, EventArgs e)
        {
            
            // Coletar os dados do cliente
            string nomeCliente = txtNomeCliente.Text;
            string cpfCliente = txtCPF.Text;
            string enderecoCliente = txtEndereco.Text;

            // Coletar os dados dos produtos (Produto 1 e Produto 2)
            string produto1 = txtProduto1.Text;
            int quantidade1 = Convert.ToInt32(txtQuantidade1.Text);
            decimal preco1 = Convert.ToDecimal(txtPreco1.Text);

            // Criando a instância do Form2 (ExibirNota) e passando os dados
            ExibirNota exibirNota = new ExibirNota(nomeCliente, cpfCliente, enderecoCliente,
                produto1, quantidade1, preco1);

            // Exibindo o Form2
            exibirNota.ShowDialog();
        }

        private void btnVoltar_Click(object sender, EventArgs e)
        {
            PIM_Constate_Desktop_2._0.Menu menuForm = new PIM_Constate_Desktop_2._0.Menu();

            // Exibe o formulário Menu
            menuForm.Show();

            // Fecha o formulário CadastroFuncionario
            this.Close();
        }
    }
}
