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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace CadastroFun
{
    public partial class CadastrarFuncionario : Form
    {
        public CadastrarFuncionario()
        {
            InitializeComponent();
        }
        void inserir(Funcionario funcionario)
        {//teste
            try
            {
                Conexao conexao = new Conexao();

                var comando = conexao.Comando("INSERT INTO Funcionario VALUES (null, @nome, @rg, @telefone, @data, @cpf, @email, @ec, @funcao, @salario, @rua, @numero, @avenida, @estado, @cidade, @complemento)");
                ////
                comando.Parameters.AddWithValue("null", funcionario.Id);
                comando.Parameters.AddWithValue("@nome", funcionario.Nome);
                comando.Parameters.AddWithValue("@rg", funcionario.Rg);
                comando.Parameters.AddWithValue("@telefone", funcionario.Telefone);
                comando.Parameters.AddWithValue("@data", funcionario.DataNascimento);
                comando.Parameters.AddWithValue("@cpf", funcionario.Cpf);
                comando.Parameters.AddWithValue("@email", funcionario.Email);
                comando.Parameters.AddWithValue("@ec", funcionario.Estado_Civil);
                comando.Parameters.AddWithValue("@funcao", funcionario.Funcao);
                comando.Parameters.AddWithValue("@salario", funcionario.Salario);
                comando.Parameters.AddWithValue("@rua", funcionario.Rua);
                comando.Parameters.AddWithValue("@numero", funcionario.Numero);
                comando.Parameters.AddWithValue("@avenida", funcionario.Avenida);
                comando.Parameters.AddWithValue("@estado", funcionario.Estado);
                comando.Parameters.AddWithValue("@cidade", funcionario.Cidade);
                comando.Parameters.AddWithValue("@complemento", funcionario.Complemento);

                var resultado = comando.ExecuteNonQuery();

                if (resultado > 0)
                {
                    MessageBox.Show("Cadastramento concluído do funcionário.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro encontrado" + ex);
            }

        }



        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void maskedTextBox1_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {

        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        }

        private void tx_nome_TextChanged(object sender, EventArgs e)
        {

        }

        private void tx_rg_TextChanged(object sender, EventArgs e)
        {

        }

        private void tx_telefone_TextChanged(object sender, EventArgs e)
        {

        }

        private void tx_email_TextChanged(object sender, EventArgs e)
        {

        }

        private void maskedTextBox2_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void tx_salario_TextChanged(object sender, EventArgs e)
        {

        }

        private void tx_numero_TextChanged(object sender, EventArgs e)
        {

        }

        private void tx_avenida_TextChanged(object sender, EventArgs e)
        {

        }

        private void tx_estado_TextChanged(object sender, EventArgs e)
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
        private void tx_cidade_TextChanged(object sender, EventArgs e)
        {

        }

        private void tx_complet_TextChanged(object sender, EventArgs e)
        {

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
                else if(f.Nome == "" || f.Nome == null || f.Rg == "" || f.Rg == null || f.Telefone == "" || f.Telefone == null || f.DataNascimento == null || f.Estado_Civil == "" || f.Estado_Civil == null || f.Funcao == "" || f.Funcao == null || f.Salario == null || f.Rua == "" || f.Rua == null || f.Avenida == "" || f.Avenida == null || f.Estado == "" || f.Estado == null || f.Cidade == "" || f.Cidade == null || f.Complemento == "" || f.Complemento == null)
                {
                    MessageBox.Show("Todos os campos são obrigatórios. Por favor preencher os campos corretamente.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                else if (string.IsNullOrWhiteSpace(tx_telefone.Text) == true)
                {
                    MessageBox.Show("Todos os campos são obrigatórios. Por favor preencher os campos corretamente.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                else
                {
                    inserir(f);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro encontrado" + ex);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
           
        }

        private void button3_Click(object sender, EventArgs e)
        {
            ConsultarFuncionario con = new ConsultarFuncionario();
            this.Visible = false;
            con.ShowDialog();
            this.Visible = true;
        }

        private void CadastrarFuncionario_Load(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            Menu eT = new Menu();
            this.Visible = false;
            eT.ShowDialog();
            this.Visible = true;
        }
    }
}
