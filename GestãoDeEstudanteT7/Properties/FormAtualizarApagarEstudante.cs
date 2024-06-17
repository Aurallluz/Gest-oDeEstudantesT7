using GestorDeEstudantesT7;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GestãoDeEstudanteT7.Properties
{
    public partial class FormAtualizarApagarEstudante : Form
    {
        public FormAtualizarApagarEstudante()
        {
            InitializeComponent();
        }

        private void FormAtualizarApagarEstudante_DoubleClick(object sender, EventArgs e)
        {
            FormAtualizarApagarEstudante formAtualizarApagarEstudante =
                new FormAtualizarApagarEstudante();

            formAtualizarApagarEstudante.textBoxID.Text =
                dataGridViewListaDeAlunos.CurrentRow.Cells[0].Value.ToString();
            formAtualizarApagarEstudante.textBoxNome.Text =
                dataGridViewListaDeAlunos.CurrentRow.Cells[1].Value.ToString();
            formAtualizarApagarEstudante.textBoxSobrenome.Text =
                dataGridViewListaDeAlunos.CurrentRow.Cells[2].Value.ToString();
            formAtualizarApagarEstudante.dataTimePickerNascimento.Value =
                (DateTime) dataGridViewListaDeAlunos.CurrentRow.Cells[3].Value();

        }

        private void FormAtualizarApagarEstudante_Load(object sender, EventArgs e)
        {

        }

        private void buttonEnviarFoto_Click(object sender, EventArgs e)
        {
            // Abre janela para pesquisar a imagem no computador.
            OpenFileDialog procurarFoto = new OpenFileDialog();

            procurarFoto.Filter = "Selecione a foto (*.jpg;*.png;*.jpeg;*.gif)|*.jpg;*.png;*.jpeg;*.gif";

            if (procurarFoto.ShowDialog() == DialogResult.OK)
            {
                Foto.Image = Image.FromFile(procurarFoto.FileName);
            }
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void Foto_Click(object sender, EventArgs e)
        {

        }

        private void buttonConfirmar_Click(object sender, EventArgs e)
        {
            Estudante estudante = new Estudante();

            int id = Convert ToInt32(TextBox.ID.Text);

            string nome = textBoxNome.Text;
            string sobrenome = textBoxSobrenome.Text;
            DateTime nascimento = dataTimePickerNascimento.Value;
            string telefone = textBoxTelefone.Text;
            string endereco = textBoxEndereco.Text;
            string genero = "Feminino";

            if (radioButtonMasculino.Checked == true)
            { genero = "Masculino"; }
            MemoryStream foto = new MemoryStream();

            // Verificar se o aluno tem entre 10 e 100 anos.
            int anoDeNascimento = dataTimePickerNascimento.Value.Year;
            int anoAtual = DateTime.Now.Year;
            if ((anoAtual - anoDeNascimento) < 10 || (anoAtual - anoDeNascimento) > 100)
            {
                MessageBox.Show("O aluno precisa ter entre 10 e 100 anos.",
                    "Ano de nascimento inválido",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
            else if (Verificar())
            {
                Foto.Image.Save(foto, Foto.Image.RawFormat);
                if (estudante.inserirEstudante(nome, sobrenome, nascimento, telefone,
                   genero, endereco, foto))
                {
                    MessageBox.Show("Dados alterados", "Sucesso!",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Dados não alterados", "Erro!",
                        MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                }
            }
            else
            {
                MessageBox.Show("Existem campos não preenchidos!", "Campos não preenchidos",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private bool Verificar()
        {
            throw new NotImplementedException();
        }

       
     
    }
}