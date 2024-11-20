namespace fiscal
{
    partial class ExibirNota
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ExibirNota));
            this.txtNotaFiscal = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // txtNotaFiscal
            // 
            this.txtNotaFiscal.Font = new System.Drawing.Font("Cambria", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNotaFiscal.Location = new System.Drawing.Point(231, 15);
            this.txtNotaFiscal.Margin = new System.Windows.Forms.Padding(4);
            this.txtNotaFiscal.Multiline = true;
            this.txtNotaFiscal.Name = "txtNotaFiscal";
            this.txtNotaFiscal.ReadOnly = true;
            this.txtNotaFiscal.Size = new System.Drawing.Size(579, 486);
            this.txtNotaFiscal.TabIndex = 0;
            // 
            // ExibirNota
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1067, 554);
            this.Controls.Add(this.txtNotaFiscal);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "ExibirNota";
            this.Text = "ExibirNota";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtNotaFiscal;
    }
}