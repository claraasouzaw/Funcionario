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
    public partial class ConsultarEmpresa : Form
    {
        List <Empresa> listaEmpresasCad = new List <Empresa> ();
        public ConsultarEmpresa()
        {
            InitializeComponent();
            Consultar();
        }
        void Consultar()
        {
            try
            {
                var conexao = new Conexao();
                var comando = conexao.Comando("SELECT * FROM Empresa");
                var leitor = comando.ExecuteReader();

                while (leitor.Read())
                {
                    var empresa = new Empresa();
                    empresa.Id = DAOHelper.GetInt(leitor, "id_emp");
                    empresa.Cnpj = DAOHelper.GetString(leitor, "cnpj_emp");
                    empresa.RazaoSocial = DAOHelper.GetString(leitor, "razao_soc_emp");
                    empresa.NomeFantasia = DAOHelper.GetString(leitor, "nome_fan_emp");
                    empresa.SituacaoCadastral = DAOHelper.GetString(leitor, "situacao_cad_emp");
                    empresa.RegimeTributario = DAOHelper.GetString(leitor, "regime_tri_emp");
                    empresa.DataInicio = DAOHelper.GetDateTime(leitor, "data_ini_emp");
                    empresa.Telefone = DAOHelper.GetString(leitor, "telefone_emp");
                    empresa.CapitalSocial = DAOHelper.GetDouble(leitor, "capital_soc_emp");
                    empresa.EnderecoCompleto = DAOHelper.GetString(leitor, "endereco_com_emp");
                    empresa.Tipo = DAOHelper.GetString(leitor, "tipo_emp");
                    empresa.Porte = DAOHelper.GetString(leitor, "porte_emp");
                    empresa.NaturezaJuridica = DAOHelper.GetString(leitor, "natureza_jur_emp");
                    empresa.NomeProprietario = DAOHelper.GetString(leitor, "nome_pro_emp");
                    empresa.CpfProprietario = DAOHelper.GetString(leitor, "cpf_pro_emp");
                    listaEmpresasCad.Add(empresa);//esse comando ele insere os campos cadastrados na lista
                }

                tabela_con.DataSource = listaEmpresasCad;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            CadastroEmp eT = new CadastroEmp();
            this.Visible = false;
            eT.ShowDialog();
            this.Visible = true;
        }
    }
}
