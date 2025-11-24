using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace M17A_Prototipo_2025_26_12H.Emprestimo
{
    public partial class F_Emprestimo : Form
    {
        BaseDados bd;
        public F_Emprestimo(BaseDados bd)
        {
            InitializeComponent();
            this.bd = bd;
            PreencheCBLeitores();
            PreencheCBLivros();
        }
        void PreencheCBLivros()
        {
            cb_livros.Items.Clear();
            Livro.Livro l = new Livro.Livro(bd);
            DataTable dados = l.Listar();
            foreach (DataRow dr in dados.Rows)
            {
                Livro.Livro novo = new Livro.Livro(bd);
                novo.nlivro = int.Parse(dr["nlivro"].ToString());
                novo.titulo = dr["titulo"].ToString();
                novo.estado = bool.Parse(dr["estado"].ToString());
                if (novo.estado==true)
                    cb_livros.Items.Add(novo);
            }
        }
        void PreencheCBLeitores()
        {
            cb_leitores.Items.Clear();
            Leitor.Leitor l =new Leitor.Leitor(bd);
            DataTable dados = l.Listar();
            foreach(DataRow dr in dados.Rows)
            {
                Leitor.Leitor n = new Leitor.Leitor(bd);
                n.nleitor = int.Parse(dr["nleitor"].ToString());
                n.nome = dr["nome"].ToString();
                cb_leitores.Items.Add(n);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (cb_livros.SelectedIndex == -1 || cb_leitores.SelectedIndex == -1)
            {
                MessageBox.Show("Deve selecionar um livro e um leitor.");
                return;
            }

            Leitor.Leitor l= (Leitor.Leitor)cb_leitores.SelectedItem;
            Livro.Livro lv = (Livro.Livro)cb_livros.SelectedItem;
            Emprestimo emp = new Emprestimo(bd);
            emp.nlivro = lv.nlivro;
            emp.nleitor = l.nleitor;
            emp.RegistarEmprestimo();
            PreencheCBLivros();
        }
    }
}
