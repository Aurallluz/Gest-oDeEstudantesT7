using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Data;

namespace GestãoDeEstudanteT7
{
    internal class MeuBancoDeDados
    {
        /*Conexão com Banco de Dados.*/
        MySqlConnection conexao = new MySqlConnection
            ("datasource=localhost;port=3306;username=root;password=;database=sga_estudantes_bd_t7");
        /*Acessor da variável "conexão".*/
        public MySqlConnection getConexao
        {
            get
            {
                return conexao;
            }
        }
        /*Função para "abrir" a conexão com o banco de dados.*/
        public void abrirConexao()
        {
            if (conexao.State == ConnectionState.Closed)
            { 
            conexao.Open();
            }
        }
        /*Função para "fechar" a conexão com banco de dados.*/
        public void fecharConexao()
        {
            if (conexao.State != ConnectionState.Open) 
            {
            conexao.Close();
            }
        }
    }
}
