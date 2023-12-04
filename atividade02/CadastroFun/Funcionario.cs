using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CadastroFun
{
    internal class Funcionario
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Rg { get; set; }
        public string Telefone { get; set; }
        public DateTime? DataNascimento { get; set; }
        public string Cpf { get; set; }
        public string Email { get; set; }
        public string Estado_Civil { get; set; }
        public string Funcao {get; set; }
        public double Salario { get; set; }
        public string Rua { get; set; }
        public int Numero { get; set; }
        public string Avenida { get; set; }
        public string Estado { get; set; }
        public string Cidade { get; set; }
        public string Complemento { get; set; }


        public Funcionario()
        {

        }

        public Funcionario(string nome, string rg, string telefone, DateTime? dataNascimento, string cpf, string email, string estado_Civil, string funcao, double salario, string rua, int numero, string avenida, string estado, string cidade, string complemento)
        {
            this.Nome = nome;
            this.Rg = rg;
            this.Telefone = telefone;
            this.DataNascimento = dataNascimento;
            this.Cpf = cpf;
            this.Email = email;
            this.Estado_Civil = estado_Civil;
            this.Funcao = funcao;
            this.Salario = salario;
            this.Rua = rua;
            this.Numero = numero;
            this.Avenida = avenida;
            this.Estado = estado;
            this.Cidade = cidade;
            this.Complemento = complemento;
        }
    }
}
