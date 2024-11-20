using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using fiscal;

namespace PIM_Constate_Desktop_2._0
{
    public partial class Menu : Form
    {
        
        public Menu()
        {
            InitializeComponent();
          
        }
        //public Menu(bool logged)
        //{
        //    isLoggedIn = logged;
        //    InitializeComponent();
        //    UpdateMenu();
        //}

        private void funcionariosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Visible = false;
            CadastroFuncionario cadastroFuncionario = new CadastroFuncionario();
            cadastroFuncionario.ShowDialog();
        }

        private void loginsToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Visible = false;
            AlterarCadastroFuncionario alterarcadastroFuncionario = new AlterarCadastroFuncionario();
            alterarcadastroFuncionario.ShowDialog();
        }

        private void produtosToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Visible = false;
            TabelaProdutos tabelaProdutos = new TabelaProdutos();
            tabelaProdutos.ShowDialog();
        }

        private void produtosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Verificar se o Menu já está aberto
            if (Application.OpenForms["MenuForm"] == null) // Se não tiver uma instância aberta
            {
                this.Hide(); // Esconde o MenuForm
                AdicionarProduto adicionarProduto = new AdicionarProduto("Menu"); // Passa a origem como "Menu"
                adicionarProduto.ShowDialog();
            }
            else
            {
                // Se o Menu já estiver aberto, apenas mostra a instância já existente
                var menuForm = Application.OpenForms["MenuForm"] as Menu;
                menuForm.Show();
            }
        }

        private void loginsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Verificar se o Menu já está aberto
            if (Application.OpenForms["MenuForm"] == null) // Se não tiver uma instância aberta
            {
                this.Hide(); // Esconde o MenuForm
                LoginFuncionario lf = new LoginFuncionario("Menu"); // Passa a origem como "Menu"
                lf.ShowDialog();
            }
            else
            {
                // Se o Menu já estiver aberto, apenas mostra a instância já existente
                var menuForm = Application.OpenForms["MenuForm"] as Menu;
                menuForm.Show();
            }
        }

        private void acessoToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void notaFiscalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Visible = false;
            NotaFiscal notaFiscal = new NotaFiscal();
            notaFiscal.ShowDialog();
        }

        private void estoqueToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Visible = false;
            if (Application.OpenForms["MenuForm"] == null) // Se não tiver uma instância aberta
            {
                this.Hide(); // Esconde o MenuForm
                AlterarProduto alterarProduto = new AlterarProduto("Menu"); // Passa a origem como "Menu"
                alterarProduto.ShowDialog();
            }
            else
            {
                // Se o Menu já estiver aberto, apenas mostra a instância já existente
                var menuForm = Application.OpenForms["MenuForm"] as Menu;
                menuForm.Show();
            }
        }

        private void Menu_Load(object sender, EventArgs e)
        {
            UpdateMenu();
        }

        private void UpdateMenu()
        {
            // Se o usuário estiver logado
            if (Session.IsLoggedIn)
            {
                // Habilita todos os itens do menu (exceto Login e Cadastro)
                sairToolStripMenuItem.Enabled = true;
                funcionariosToolStripMenuItem.Enabled = true;
                produtosToolStripMenuItem.Enabled = true;
                loginsToolStripMenuItem.Enabled = false;  // Desabilita o item de login
                produtosToolStripMenuItem1.Enabled = true;
                notaFiscalToolStripMenuItem.Enabled = true;
                estoqueToolStripMenuItem.Enabled = true;
                loginsToolStripMenuItem1.Enabled = true;

            }
            else
            {
                // Desabilita as funcionalidades e deixa apenas Cadastro e Login disponíveis
                cadastroToolStripMenuItem.Enabled = true;
                funcionariosToolStripMenuItem.Enabled = true;
                produtosToolStripMenuItem.Enabled = false;
                loginsToolStripMenuItem.Enabled = true;
                produtosToolStripMenuItem1.Enabled = false;
                notaFiscalToolStripMenuItem.Enabled = false;
                estoqueToolStripMenuItem.Enabled = false;
                loginsToolStripMenuItem1.Enabled = false;
                sairToolStripMenuItem.Enabled = false;

            }
        }

        private void sairToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Session.IsLoggedIn = false;
            UpdateMenu();
        }
    }
}
