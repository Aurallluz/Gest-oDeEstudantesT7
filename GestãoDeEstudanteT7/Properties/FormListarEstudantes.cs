﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GestãoDeEstudanteT7;
using MySql.Data.MySqlClient;

namespace GestorDeEstudantesT7
{
    public partial class FormListarEstudantes : Form
    {
        public FormListarEstudantes()
        {
            InitializeComponent();
        }

        Estudante estudante = new Estudante();

        private void FormListarEstudantes_Load(object sender, EventArgs e)
        {
            // Preenche o dataGridView com as informações dos estudantes.
            MySqlCommand comando = new MySqlCommand("SELECT * FROM `estudantes`");
            // Impede que os dados exibidos na tabela sejam alterados.
            dataGridViewListaDeAlunos.ReadOnly = true;
            // Cria uma coluna para exibir as fotos dos alunos.
            DataGridViewImageColumn colunaDeFotos = new DataGridViewImageColumn();
            // Determina uma altura padrão para as linhas da tabela.
            dataGridViewListaDeAlunos.RowTemplate.Height = 80;
            // Determina a origem dos dados da tabela.
            dataGridViewListaDeAlunos.DataSource = estudante.getEstudantes(comando);
            // Determinar qual SERÁ a coluna com as imagens.
            colunaDeFotos = (DataGridViewImageColumn)dataGridViewListaDeAlunos.Columns[7];
            colunaDeFotos.ImageLayout = DataGridViewImageCellLayout.Stretch;
            // Impede o usuário de incluir linhas.
            dataGridViewListaDeAlunos.AllowUserToAddRows = false;

        }

        private void dataGridViewListaDeAlunos_DoubleClick(object sender, EventArgs e)
        {
            // exibir as informaçõe do estudante ao clicar nele duas vezes.
        }

        private void buttonAtualizar_Click(object sender, EventArgs e)
        {
            // atualiza a lista de estudantes.
        }
    }
}