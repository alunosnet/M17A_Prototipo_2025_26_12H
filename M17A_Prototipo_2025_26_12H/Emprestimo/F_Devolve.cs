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
    public partial class F_Devolve : Form
    {
        BaseDados bd;
        public F_Devolve(BaseDados bd)
        {
            InitializeComponent();
            this.bd = bd;
            PreencheLB();
        }
        void PreencheLB()
        {
            lb_emprestimos.Items.Clear();
            Livro.Livro l = new Livro.Livro(bd);
            DataTable dados = l.ListarEmprestados();
            foreach (DataRow dr in dados.Rows)
            {
                Livro.Livro n = new Livro.Livro(bd);
                n.nlivro = int.Parse(dr["nlivro"].ToString());
                n.titulo = dr["titulo"].ToString();
                lb_emprestimos.Items.Add(n);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int i = lb_emprestimos.SelectedIndex;
            if (i == -1)
            {
                MessageBox.Show("Tem de selecionar o livro a devolver.");
                return;
            }
            Livro.Livro l = (Livro.Livro)lb_emprestimos.SelectedItem;
            Emprestimo emp = new Emprestimo(bd);
            emp.nlivro = l.nlivro;
            emp.RegistarDevolucao();
            PreencheLB();
        }
    }
}
