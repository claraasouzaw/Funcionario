using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MariaV1
{
    public partial class CadastroDeFuncionario : Form
    {
        public CadastroDeFuncionario()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
        private bool ExistemTextBoxsVazios()
        {

            foreach (Control control in this.Controls)
            {
                if (control is TextBox || control is MaskedTextBox || control is DateTimePicker || control is ComboBox)
                {
                    var text = control.Text.Replace(",", "").Replace("-", "").Trim();

                    if (text == "" || text == null)
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                Funcionario f = new Funcionario();
                f.Nome = tx_nome.Text;
                f.Rg = tx_rg.Text;
                f.Telefone = tx_telefone.Text;
                f.DataNascimento = Convert.ToDateTime(dataNascimento.Text);
                f.Cpf = Cpf.Text;
                f.Email = tx_email.Text;
                f.Estado_Civil = estado_civil.Text;
                f.Funcao = Funcao.Text;
                f.Salario = Convert.ToDouble(tx_salario.Text);
                f.Rua = tx_rua.Text;
                f.Numero = Convert.ToInt32(tx_numero.Text);
                f.Avenida = tx_avenida.Text;
                f.Estado = estado.Text;
                f.Cidade = tx_cidade.Text;
                f.Complemento = tx_complet.Text;
                if (ExistemTextBoxsVazios() == true)
                {
                    MessageBox.Show("Todos os campos são obrigatórios. Por favor preencher os campos corretamente.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                }
                else if (f.Estado_Civil == "" || f.Estado == "" || f.Funcao == "")
                {
                    MessageBox.Show("Todos os campos são obrigatórios. Por favor preencher os campos corretamente.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                else if (Valida.CPF(f.Cpf) == false)
                {
                    MessageBox.Show("CPF inválido", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                else if (Valida.Email(f.Email) == false)
                {
                    MessageBox.Show("Email inválido", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                else if (f.Nome == "" || f.Nome == null || f.Rg == "" || f.Rg == null || f.Telefone == "" || f.Telefone == null || f.DataNascimento == null || f.Estado_Civil == "" || f.Estado_Civil == null || f.Funcao == "" || f.Funcao == null || f.Salario == null || f.Rua == "" || f.Rua == null || f.Avenida == "" || f.Avenida == null || f.Estado == "" || f.Estado == null || f.Cidade == "" || f.Cidade == null || f.Complemento == "" || f.Complemento == null)
                {
                    MessageBox.Show("Todos os campos são obrigatórios. Por favor preencher os campos corretamente.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                else if (string.IsNullOrWhiteSpace(tx_telefone.Text) == true)
                {
                    MessageBox.Show("Todos os campos são obrigatórios. Por favor preencher os campos corretamente.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                else
                {
                    MessageBox.Show("Funcionário cadastrado com sucesso!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro encontrado" + ex);
            }
        }
    }
}
