namespace fiscal
{
    partial class NotaFiscal
    {
        /// <summary>
        /// Variável de designer necessária.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpar os recursos que estão sendo usados.
        /// </summary>
        /// <param name="disposing">true se for necessário descartar os recursos gerenciados; caso contrário, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código gerado pelo Windows Form Designer

        /// <summary>
        /// Método necessário para suporte ao Designer - não modifique 
        /// o conteúdo deste método com o editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(NotaFiscal));
            this.btnVoltar = new System.Windows.Forms.Button();
            this.btnGerarNota = new System.Windows.Forms.Button();
            this.txtNotaFiscal = new System.Windows.Forms.Label();
            this.txtEndereco = new System.Windows.Forms.TextBox();
            this.txtPreco1 = new System.Windows.Forms.TextBox();
            this.txtQuantidade1 = new System.Windows.Forms.TextBox();
            this.txtProduto1 = new System.Windows.Forms.TextBox();
            this.txtCPF = new System.Windows.Forms.TextBox();
            this.txtNomeCliente = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnVoltar
            // 
            this.btnVoltar.Location = new System.Drawing.Point(819, 159);
            this.btnVoltar.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnVoltar.Name = "btnVoltar";
            this.btnVoltar.Size = new System.Drawing.Size(139, 46);
            this.btnVoltar.TabIndex = 50;
            this.btnVoltar.Text = "Voltar";
            this.btnVoltar.UseVisualStyleBackColor = true;
            this.btnVoltar.Click += new System.EventHandler(this.btnVoltar_Click);
            // 
            // btnGerarNota
            // 
            this.btnGerarNota.Location = new System.Drawing.Point(625, 159);
            this.btnGerarNota.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnGerarNota.Name = "btnGerarNota";
            this.btnGerarNota.Size = new System.Drawing.Size(139, 46);
            this.btnGerarNota.TabIndex = 49;
            this.btnGerarNota.Text = "Gerar Nota Fiscal";
            this.btnGerarNota.UseVisualStyleBackColor = true;
            this.btnGerarNota.Click += new System.EventHandler(this.btnGerarNota_Click);
            // 
            // txtNotaFiscal
            // 
            this.txtNotaFiscal.AutoSize = true;
            this.txtNotaFiscal.Font = new System.Drawing.Font("Cambria", 14.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNotaFiscal.Location = new System.Drawing.Point(665, 62);
            this.txtNotaFiscal.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.txtNotaFiscal.Name = "txtNotaFiscal";
            this.txtNotaFiscal.Size = new System.Drawing.Size(257, 28);
            this.txtNotaFiscal.TabIndex = 48;
            this.txtNotaFiscal.Text = "Numero da nota fiscal:";
            // 
            // txtEndereco
            // 
            this.txtEndereco.Location = new System.Drawing.Point(271, 231);
            this.txtEndereco.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtEndereco.Name = "txtEndereco";
            this.txtEndereco.Size = new System.Drawing.Size(207, 22);
            this.txtEndereco.TabIndex = 47;
            // 
            // txtPreco1
            // 
            this.txtPreco1.Location = new System.Drawing.Point(292, 469);
            this.txtPreco1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtPreco1.Name = "txtPreco1";
            this.txtPreco1.Size = new System.Drawing.Size(207, 22);
            this.txtPreco1.TabIndex = 46;
            // 
            // txtQuantidade1
            // 
            this.txtQuantidade1.Location = new System.Drawing.Point(308, 417);
            this.txtQuantidade1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtQuantidade1.Name = "txtQuantidade1";
            this.txtQuantidade1.Size = new System.Drawing.Size(207, 22);
            this.txtQuantidade1.TabIndex = 45;
            // 
            // txtProduto1
            // 
            this.txtProduto1.Location = new System.Drawing.Point(271, 370);
            this.txtProduto1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtProduto1.Name = "txtProduto1";
            this.txtProduto1.Size = new System.Drawing.Size(207, 22);
            this.txtProduto1.TabIndex = 44;
            // 
            // txtCPF
            // 
            this.txtCPF.Location = new System.Drawing.Point(197, 180);
            this.txtCPF.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtCPF.Name = "txtCPF";
            this.txtCPF.Size = new System.Drawing.Size(207, 22);
            this.txtCPF.TabIndex = 43;
            // 
            // txtNomeCliente
            // 
            this.txtNomeCliente.Location = new System.Drawing.Point(337, 127);
            this.txtNomeCliente.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtNomeCliente.Name = "txtNomeCliente";
            this.txtNomeCliente.Size = new System.Drawing.Size(207, 22);
            this.txtNomeCliente.TabIndex = 42;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Cambria", 14.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(111, 464);
            this.label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(137, 28);
            this.label8.TabIndex = 41;
            this.label8.Text = "Valor Total:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Cambria", 14.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(111, 412);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(158, 28);
            this.label7.TabIndex = 40;
            this.label7.Text = "Quantidades:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Cambria", 14.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(111, 366);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(118, 28);
            this.label6.TabIndex = 39;
            this.label6.Text = "Produtos:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Cambria", 14.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(192, 292);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(239, 28);
            this.label5.TabIndex = 38;
            this.label5.Text = "Detalhes do produto:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Cambria", 15.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(109, 231);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(132, 32);
            this.label4.TabIndex = 37;
            this.label4.Text = "Endereço:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Cambria", 15.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(109, 174);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 32);
            this.label3.TabIndex = 36;
            this.label3.Text = "CPF:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Cambria", 14.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(111, 122);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(194, 28);
            this.label2.TabIndex = 35;
            this.label2.Text = "Nome Do Cliente:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Cambria", 14.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(219, 62);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(200, 28);
            this.label1.TabIndex = 34;
            this.label1.Text = "Gerar nota fiscal:";
            // 
            // NotaFiscal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1067, 554);
            this.Controls.Add(this.btnVoltar);
            this.Controls.Add(this.btnGerarNota);
            this.Controls.Add(this.txtNotaFiscal);
            this.Controls.Add(this.txtEndereco);
            this.Controls.Add(this.txtPreco1);
            this.Controls.Add(this.txtQuantidade1);
            this.Controls.Add(this.txtProduto1);
            this.Controls.Add(this.txtCPF);
            this.Controls.Add(this.txtNomeCliente);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "NotaFiscal";
            this.Text = "Nota Fiscal";
            this.Load += new System.EventHandler(this.NotaFiscal_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnVoltar;
        private System.Windows.Forms.Button btnGerarNota;
        private System.Windows.Forms.Label txtNotaFiscal;
        private System.Windows.Forms.TextBox txtEndereco;
        private System.Windows.Forms.TextBox txtPreco1;
        private System.Windows.Forms.TextBox txtQuantidade1;
        private System.Windows.Forms.TextBox txtProduto1;
        private System.Windows.Forms.TextBox txtCPF;
        private System.Windows.Forms.TextBox txtNomeCliente;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
    }
}

