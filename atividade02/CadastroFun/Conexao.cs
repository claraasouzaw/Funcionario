using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cadastramento_de_Funcionário.Configuracao
{
    class Conexao
    {
        private string _servidor = "localhost";
        private string _porta = "3306";
        private string _ususario = "root";
        private string _senha = "Anjo 123";
        private string _bancoDadosNome = "Empresa_X2a";
        private MySqlConnection connection;
        private MySqlCommand command;

        public Conexao()
        {
            try
            {
                connection = new MySqlConnection($"server={_servidor};database={_bancoDadosNome};port={_porta};user={_ususario};password={_senha}");
                connection.Open();
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public MySqlCommand Comando(string comando)
        {
            try
            {
                command = connection.CreateCommand();
                command.CommandType = CommandType.Text;
                command.CommandText = comando;

                return command;

            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}
