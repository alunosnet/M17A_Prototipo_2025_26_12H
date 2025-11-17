using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace M17A_Prototipo_2025_26_12H.Livro
{
    public partial class F_Livro : Form
    {
        string capa = "";
        BaseDados bd;
        int nlivro = 0;
        public F_Livro(BaseDados bd)
        {
            InitializeComponent();
            this.bd = bd;
        }
        //Botão para procurar a imagem para a capa
        private void bt_procurar_Click(object sender, EventArgs e)
        {
            OpenFileDialog ficheiro = new OpenFileDialog();
            ficheiro.InitialDirectory = "C:\\";
            ficheiro.Multiselect = false;
            ficheiro.Filter = "Imagens |*.jpg;*.jpeg;*.png;*.bmp | Todos os ficheiros |*.*";
            if (ficheiro.ShowDialog() == DialogResult.OK)
            {
                string temp = ficheiro.FileName;
                if (System.IO.File.Exists(temp))
                {
                    pb_capa.Image = Image.FromFile(temp);
                    capa = temp;
                }
            }
        }
        //Guardar o livro na base de dados
        private void bt_guardar_Click(object sender, EventArgs e)
        {
            //criar um objeto do tipo livro
            Livro novo = new Livro(bd);
            //preencher os dados do livro
            novo.titulo = tb_titulo.Text;
            novo.autor=tb_autor.Text;
            novo.editora= tb_editora.Text;
            novo.isbn = tb_isbn.Text;
            novo.ano = int.Parse(tb_ano.Text);
            novo.data_aquisicao = dtp_data.Value;
            novo.preco = Decimal.Parse(tb_preco.Text);
            novo.capa = Utils.PastaDoPrograma("M17A_Biblioteca") + @"\" + novo.isbn;
            //validar os dados
            List<string> erros = novo.Validar();
            //se não tiver erros nos dados
            if(erros.Count>0)
            {
                //mostrar os erros
                string mensagem = "";
                foreach(string erro in erros)
                    mensagem += erro + "; ";
                lb_feedback.Text = mensagem;
                lb_feedback.ForeColor = Color.Red;
                return;
            }
            //guardar na base de dados
            novo.Adicionar();
            //copiar a capa para a pasta do programa
            if (capa!="")
            {
                if (System.IO.File.Exists(capa))
                    System.IO.File.Copy(capa,novo.capa,true);
            }
            //limpar o form
            LimparForm();
            //atualizar a lista do livros na datagrid
            ListarLivros();
            //feedback user
            lb_feedback.Text = "Livro adicionado com sucesso.";
            lb_feedback.ForeColor = Color.Black;
        }
        //Atualizar a lista dos livros na datagridview
        private void ListarLivros()
        {
            dgv_livros.AllowUserToAddRows = false;
            dgv_livros.ReadOnly = true;
            dgv_livros.AllowUserToDeleteRows = false;
            dgv_livros.MultiSelect= false;
            dgv_livros.SelectionMode= DataGridViewSelectionMode.FullRowSelect;
            Livro l = new Livro(bd);
            dgv_livros.DataSource = l.Listar();
        }
        //Limpar as tb do formulário
        private void LimparForm()
        {
            tb_ano.Text = "";
            tb_titulo.Text = "";
            tb_editora.Text = "";
            tb_autor.Text = "";
            pb_capa.Image = null;
            capa = "";
            tb_isbn.Text = "";
            dtp_data.Value = DateTime.Now;
            tb_preco.Text = "";
        }

        private void F_Livro_Load(object sender, EventArgs e)
        {
            ListarLivros();
        }

        private void dgv_livros_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            //Não é este evento
        }

        private void dgv_livros_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int linha = dgv_livros.CurrentCell.RowIndex;
            if (linha == -1)
                return;
            nlivro = int.Parse(dgv_livros.Rows[linha].Cells[0].Value.ToString());
        }
        //Elimnar o livro selecionado
        private void bt_eliminar_Click(object sender, EventArgs e)
        {
            EliminarLivro();
        }
        void EliminarLivro()
        {
            if (nlivro==0)
            {
                MessageBox.Show("Tem de selecionar um livro primeiro.");
                return;
            }
            //confirmar
            if (MessageBox.Show("Tem a certeza que pretende remover o livro selecionado?",
                "Confirmar", 
                MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                Livro apagar = new Livro(bd);
                apagar.nlivro= nlivro;
                apagar.Apagar();
                ListarLivros();
            }
        }
    }
}
