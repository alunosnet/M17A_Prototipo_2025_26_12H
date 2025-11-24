using M17A_Prototipo_2025_26_12H.Emprestimo;
using M17A_Prototipo_2025_26_12H.Livro;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace M17A_Prototipo_2025_26_12H
{
    public partial class F_principal : Form
    {
        BaseDados bd;
        public F_principal()
        {
            InitializeComponent();
            bd = new BaseDados("biblioteca_12h");
        }
        //Ficheiro -> Sair
        private void sairToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        //Editar -> Livros
        private void livrosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            F_Livro f = new F_Livro(bd);
            f.Show();
        }

        private void empréstimosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            F_Emprestimo f = new F_Emprestimo(bd);
            f.Show();
        }

        private void devoluçõesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            F_Devolve f = new F_Devolve(bd);
            f.Show();
        }

        private void cb_consultas_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cb_consultas.SelectedIndex <= 0) return;
            string[] consultas = new string[] { "",
                @"SELECT Emprestimos.*,Leitores.Nome,Livros.Titulo 
                    FROM Emprestimos INNER JOIN Leitores ON Leitores.nleitor = Emprestimos.nleitor
                    INNER JOIN Livros ON Livros.nlivro = Emprestimos.nlivro" };
            DataTable dados = bd.DevolveSQL(consultas[cb_consultas.SelectedIndex]);

            dgv_consultas.DataSource = dados;
        }
    }
}
