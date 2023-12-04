using System;
public class Empresa
{
    public int Id { get; set; }
    public string Cnpj { get; set; }
    public string RazaoSocial { get; set; }
    public string NomeFantasia { get; set; }
    public string SituacaoCadastral { get; set; }
    public string RegimeTributario { get; set; }
    public DateTime? DataInicio { get; set; }
    public string Telefone { get; set; }
    public double CapitalSocial { get; set; }
    public string EnderecoCompleto { get; set; }
    public string Tipo { get; set; }
    public string Porte { get; set; }
    public string NaturezaJuridica { get; set; }
    public string NomeProprietario { get; set; }
    public string CpfProprietario { get; set; }

    public Empresa()
    {

    }

    public Empresa(string Rz, string Sc, string Nf, string Rt, DateTime? Di, string Tf, double Cs, string Ec, string Tp, string Pt, string Nj, string Np, string Cp, string cnpj)
    {
        Rz = this.RazaoSocial;
        Sc = this.SituacaoCadastral;
        Nf = this.NomeFantasia;
        Rt = this.RegimeTributario;
        Di = this.DataInicio;
        Tf = this.Telefone;
        Cs = this.CapitalSocial;
        Ec = this.EnderecoCompleto;
        Tp = this.Tipo;
        Pt = this.Porte;
        Nj = this.NaturezaJuridica;
        Np = this.NomeProprietario;
        Cp = this.CpfProprietario;
        cnpj = this.Cnpj;
    }

}



