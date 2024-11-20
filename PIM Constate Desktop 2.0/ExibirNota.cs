using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace fiscal
{
    public partial class ExibirNota : Form
    {
        // Propriedades para armazenar os dados
        public string NomeCliente { get; set; }
        public string CPF { get; set; }
        public string Endereco { get; set; }

        // Propriedades para armazenar os dados dos produtos
        public string Produto1 { get; set; }
        public int Quantidade1 { get; set; }
        public decimal Preco1 { get; set; }

        public string Produto2 { get; set; }
        public int Quantidade2 { get; set; }
        public decimal Preco2 { get; set; }

        // Construtor para receber os dados do Form1
        public ExibirNota(string nomeCliente, string cpf, string endereco,
                          string produto1, int quantidade1, decimal preco1)
        {
            InitializeComponent();

            // Atribuindo os dados recebidos nas propriedades
            NomeCliente = nomeCliente;
            CPF = cpf;
            Endereco = endereco;

            // Atribuindo os dados dos produtos
            Produto1 = produto1;
            Quantidade1 = quantidade1;
            Preco1 = preco1;

            // Exibir a Nota Fiscal
            ExibirNotaFiscal();
        }

        // Método para exibir a nota fiscal na TextBox
        private void ExibirNotaFiscal()
        {
            StringBuilder conteudoNotaFiscal = new StringBuilder();
            conteudoNotaFiscal.AppendLine("Nota Fiscal");
            conteudoNotaFiscal.AppendLine("----------------------------------------");
            conteudoNotaFiscal.AppendLine($"Cliente: {NomeCliente}");
            conteudoNotaFiscal.AppendLine($"CPF: {CPF}");
            conteudoNotaFiscal.AppendLine($"Endereço: {Endereco}");
            conteudoNotaFiscal.AppendLine("----------------------------------------");
            conteudoNotaFiscal.AppendLine("Produtos:");

            decimal valorTotal = 0;

            // Exibindo os produtos
            decimal valorProduto1 = Quantidade1 * Preco1;
            conteudoNotaFiscal.AppendLine($"{Produto1} | Quantidade: {Quantidade1} | Preço Unitário: {Preco1:C} | Total: {valorProduto1:C}");
            valorTotal += valorProduto1;

            decimal valorProduto2 = Quantidade2 * Preco2;
            conteudoNotaFiscal.AppendLine($"{Produto2} | Quantidade: {Quantidade2} | Preço Unitário: {Preco2:C} | Total: {valorProduto2:C}");
            valorTotal += valorProduto2;

            conteudoNotaFiscal.AppendLine("----------------------------------------");
            conteudoNotaFiscal.AppendLine($"Total da Nota Fiscal: {valorTotal:C}");

            // Exibindo a Nota Fiscal na TextBox multilinha
            txtNotaFiscal.Text = conteudoNotaFiscal.ToString();
        }
    }
}
