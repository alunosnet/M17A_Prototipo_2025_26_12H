namespace M17A_Prototipo_2025_26_12H.Emprestimo
{
    partial class F_Emprestimo
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
            this.cb_livros = new System.Windows.Forms.ComboBox();
            this.cb_leitores = new System.Windows.Forms.ComboBox();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // cb_livros
            // 
            this.cb_livros.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_livros.FormattingEnabled = true;
            this.cb_livros.Location = new System.Drawing.Point(171, 41);
            this.cb_livros.Name = "cb_livros";
            this.cb_livros.Size = new System.Drawing.Size(350, 21);
            this.cb_livros.TabIndex = 0;
            // 
            // cb_leitores
            // 
            this.cb_leitores.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_leitores.FormattingEnabled = true;
            this.cb_leitores.Location = new System.Drawing.Point(171, 85);
            this.cb_leitores.Name = "cb_leitores";
            this.cb_leitores.Size = new System.Drawing.Size(350, 21);
            this.cb_leitores.TabIndex = 1;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(169, 140);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(361, 46);
            this.button1.TabIndex = 2;
            this.button1.Text = "Emprestar";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // F_Emprestimo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(643, 310);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.cb_leitores);
            this.Controls.Add(this.cb_livros);
            this.Name = "F_Emprestimo";
            this.Text = "F_Emprestimo";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ComboBox cb_livros;
        private System.Windows.Forms.ComboBox cb_leitores;
        private System.Windows.Forms.Button button1;
    }
}