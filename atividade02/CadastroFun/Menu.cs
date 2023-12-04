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
    public partial class Menu : Form
    {
        public Menu()
        {
            InitializeComponent();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            CadastrarFuncionario f = new CadastrarFuncionario();
            this.Visible = false;
            f.ShowDialog();
            this.Visible = true;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            CadastroEmp emp = new CadastroEmp();
            this.Visible = false;
            emp.ShowDialog();
            this.Visible = true;
        }
    }
}
