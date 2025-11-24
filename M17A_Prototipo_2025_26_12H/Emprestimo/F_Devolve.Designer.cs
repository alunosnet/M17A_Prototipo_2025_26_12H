namespace M17A_Prototipo_2025_26_12H.Emprestimo
{
    partial class F_Devolve
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
            this.lb_emprestimos = new System.Windows.Forms.ListBox();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lb_emprestimos
            // 
            this.lb_emprestimos.FormattingEnabled = true;
            this.lb_emprestimos.Location = new System.Drawing.Point(103, 58);
            this.lb_emprestimos.Name = "lb_emprestimos";
            this.lb_emprestimos.Size = new System.Drawing.Size(228, 277);
            this.lb_emprestimos.TabIndex = 0;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(404, 244);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(173, 90);
            this.button1.TabIndex = 1;
            this.button1.Text = "Receber";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // F_Devolve
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.lb_emprestimos);
            this.Name = "F_Devolve";
            this.Text = "F_Devolve";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox lb_emprestimos;
        private System.Windows.Forms.Button button1;
    }
}