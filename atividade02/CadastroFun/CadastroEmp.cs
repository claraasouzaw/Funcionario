using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Cadastramento_de_Funcionário.Configuracao;
using CpfCnpjLibrary;

namespace CadastroFun
{
    public partial class CadastroEmp : Form
    {
        public CadastroEmp()
        {
            InitializeComponent();
        }
        void inserirempresa (Empresa empresa)
        {
            try
            {
                Conexao conexao = new Conexao();

                var comando = conexao.Comando("INSERT INTO Empresa VALUES (null, @cnpj, @razao, @nome, @situacao, @regime, @data, @telefone, @capital, @endereco, @tipo, @porte, @natureza, @nomeP, @cpf)");

                comando.Parameters.AddWithValue("null", empresa.Id);
                comando.Parameters.AddWithValue("@cnpj", empresa.Cnpj);
                comando.Parameters.AddWithValue("@razao", empresa.RazaoSocial);
                comando.Parameters.AddWithValue("@nome", empresa.NomeFantasia);
                comando.Parameters.AddWithValue("@situacao", empresa.SituacaoCadastral);
                comando.Parameters.AddWithValue("@regime", empresa.RegimeTributario);
                comando.Parameters.AddWithValue("@data", empresa.DataInicio);
                comando.Parameters.AddWithValue("@telefone", empresa.Telefone);
                comando.Parameters.AddWithValue("@capital", empresa.CapitalSocial);
                comando.Parameters.AddWithValue("@endereco", empresa.EnderecoCompleto);
                comando.Parameters.AddWithValue("@tipo", empresa.Tipo);
                comando.Parameters.AddWithValue("@porte", empresa.Porte);
                comando.Parameters.AddWithValue("@natureza", empresa.NaturezaJuridica);
                comando.Parameters.AddWithValue("@nomeP", empresa.NomeProprietario);
                comando.Parameters.AddWithValue("@cpf", empresa.CpfProprietario);

                var resultado = comando.ExecuteNonQuery();

                if (resultado > 0)
                {
                    MessageBox.Show("Cadastramento de empresa concluída");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro encontrado" + ex);
            }
        }
        private bool ExistemTextBoxsVazios()
        {
            foreach (Control control in this.Controls)
            {
                if (control is TextBox || control is MaskedTextBox || control is DateTimePicker || control is RadioButton)
                {
                    var text = control.Text.Replace(",", "").Replace("-", "").Trim();

                    if (text == "")
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        private void groupBox3_Enter(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void button7_Click(object sender, EventArgs e)
        {
            try
            {
                Empresa ep = new Empresa();
                ep.RazaoSocial = razao_social.Text;
                ep.NomeFantasia = nome_fantasia.Text;
                ep.SituacaoCadastral = situacao_cadastral.Text;
                ep.DataInicio = Convert.ToDateTime(data.Text);
                ep.Telefone = telefone.Text;
                ep.CapitalSocial = Convert.ToDouble(capital_social.Text);
                ep.EnderecoCompleto = endereco_completo.Text;
                ep.NaturezaJuridica = natureza_juridica.Text;
                ep.NomeProprietario = nome_proprietario.Text;
                ep.CpfProprietario = cpf_proprietario.Text;

                if (mt.Checked == true)
                {
                    ep.Tipo = mt.Text;
                }
                else
                {
                    ep.Tipo = filial.Text;
                }

                if (peq.Checked == true)
                {
                    ep.Porte = peq.Text;
                }
                else if (med.Checked == true)
                {
                    ep.Porte = med.Text;
                }
                else if (gran.Checked == true)
                {
                    ep.Porte = gran.Text;
                }

                if (sim.Checked == true)
                {
                    ep.RegimeTributario = sim.Text;
                }
                else if (luc.Checked == true)
                {
                    ep.RegimeTributario = luc.Text;
                }
                else if (real.Checked == true)
                {
                    ep.RegimeTributario = real.Text;
                }
                ep.Cnpj = cnpj.Text;
                Cnpj.Validar(ep.Cnpj);
                if (ExistemTextBoxsVazios() == true)
                {
                    MessageBox.Show("Todos os campos são obrigatórios. Por favor preencher os campos corretamente.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                }
                else if (Cnpj.Validar(ep.Cnpj) == false)
                {
                    MessageBox.Show("CNPJ inválido", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                else if (Valida.CPF(ep.CpfProprietario) == false)
                {
                    MessageBox.Show("CPF inválido", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                else if (ep.RazaoSocial == "" || ep.RazaoSocial == null || ep.NomeFantasia == "" || ep.NomeFantasia == null || ep.SituacaoCadastral == "" || ep.SituacaoCadastral == null || ep.Telefone == "" || ep.Telefone == null || ep.CapitalSocial == null || ep.EnderecoCompleto == null || ep.EnderecoCompleto == "" || ep.NaturezaJuridica == null || ep.NaturezaJuridica == "" || ep.NomeProprietario == null || ep.NomeProprietario == "")
                {
                    MessageBox.Show("Todos os campos são obrigatórios. Por favor preencher os campos corretamente.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                }
                else if (mt.Checked == false && filial.Checked == false)
                {
                    MessageBox.Show("Todos os campos são obrigatórios. Por favor preencher os campos corretamente.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }

                else if (peq.Checked == false && med.Checked == false && gran.Checked == false)
                {
                    MessageBox.Show("Todos os campos são obrigatórios. Por favor preencher os campos corretamente.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }

                else if (sim.Checked == false && luc.Checked == false && real.Checked == false)
                {
                    MessageBox.Show("Todos os campos são obrigatórios. Por favor preencher os campos corretamente.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                else
                {
                    inserirempresa(ep);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            ConsultarEmpresa emp = new ConsultarEmpresa();
            this.Visible= false;
            emp.ShowDialog();
            this.Visible= true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Menu eT = new Menu();
            this.Visible = false;
            eT.ShowDialog();
            this.Visible = true;
        }
    }
}
