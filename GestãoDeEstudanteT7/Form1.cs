using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GestãoDeEstudanteT7
{
    public partial class Login_Form : Form
    {
        public Login_Form()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void Login_Form_Load(object sender, EventArgs e)
        {
            
        }

        private void buttonLogin_Click(object sender, EventArgs e)
        {
            /*Cria um objeto da classe "MeuBancoDeDados".*/
            MeuBancoDeDados meuBancoDeDados = new MeuBancoDeDados();
            
            MySqlDataAdapter meuAdaptadorSql = new MySqlDataAdapter();
            
            DataTable tabelaDeDados = new DataTable();
            
            MySqlCommand comandSql = new MySqlCommand
                ("SELECT * FROM `usuários` WHERE `nome_de_usuário`=@usuario AND `senha` = @senha", meuBancoDeDados.getConexao);
            
            comandSql.Parameters.Add("@usuario", MySqlDbType.VarChar).Value = textBoxUsuário.Text;
            comandSql.Parameters.Add("@senha", MySqlDbType.VarChar).Value = textBoxSenha.Text;

            meuAdaptadorSql.SelectCommand = comandSql;

            meuAdaptadorSql.Fill(tabelaDeDados);

            if (tabelaDeDados.Rows.Count > 0)
            {
                MessageBox.Show("Login feito com sucesso.", "Login Concluido", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Usuário ou senha inválidos.", "Erro de Login", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void buttonCancelar_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
