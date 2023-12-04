using Cadastramento_de_Funcionário.Configuracao;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CadastroFun
{
    public partial class ConsultarFuncionario : Form
    {
        private List<Funcionario> listDosF = new List<Funcionario>();
        public ConsultarFuncionario()
        {
            InitializeComponent();
            Consultar();
        }
        public void Consultar()
        {
            try
            {
                var conexao = new Conexao();
                var comando = conexao.Comando("SELECT * FROM Funcionario");
                var leitor = comando.ExecuteReader();

                while (leitor.Read())
                {
                    var funcionario = new Funcionario();
                    funcionario.Id = DAOHelper.GetInt(leitor, "id_fun");
                    funcionario.Nome = DAOHelper.GetString(leitor, "nome_fun");
                    funcionario.Rg = DAOHelper.GetString(leitor, "rg_fun");
                    funcionario.Telefone = DAOHelper.GetString(leitor, "telefone_fun");
                    funcionario.DataNascimento = DAOHelper.GetDateTime(leitor, "data_nas_fun");
                    funcionario.Cpf = DAOHelper.GetString(leitor, "cpf_fun");
                    funcionario.Email = DAOHelper.GetString(leitor, "email_fun");
                    funcionario.Estado_Civil = DAOHelper.GetString(leitor, "estado_civ_fun");
                    funcionario.Funcao = DAOHelper.GetString(leitor, "funcao_fun");
                    funcionario.Salario = DAOHelper.GetDouble(leitor, "salario_fun");
                    funcionario.Rua = DAOHelper.GetString(leitor, "rua_fun");
                    funcionario.Numero = DAOHelper.GetInt(leitor, "numero_fun");
                    funcionario.Avenida = DAOHelper.GetString(leitor, "avenida_fun");
                    funcionario.Estado = DAOHelper.GetString(leitor, "estado_fun");
                    funcionario.Cidade = DAOHelper.GetString(leitor, "cidade_fun");
                    funcionario.Complemento = DAOHelper.GetString(leitor, "complemento_fun");

                    listDosF.Add(funcionario);
                }

                tabela_funcionario.DataSource = listDosF;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            CadastrarFuncionario eT = new CadastrarFuncionario();
            this.Visible = false;
            eT.ShowDialog();
            this.Visible = true;
        }
    }
}
