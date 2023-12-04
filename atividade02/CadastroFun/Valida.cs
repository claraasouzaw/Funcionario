
using System.Windows.Forms;
using System;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.Linq;

public static class Valida
{
    public static bool CPF(string cpf)
    {
        cpf = cpf.Replace(".", "");
        cpf = cpf.Replace("-", "");
        int soma = 0;
        int soma1 = 0;
        int pd;
        int sd = 0;
        double resto = 0;
        double resto1 = 0;
        double ver = 0;
        double veri = 0;
        int[] somaT;
        if (cpf.Length != 11)
        {
            return false;
        }


        for (int i = 10; i >= 2; i--)
        {
            for (int j = 0; j <= cpf.Length - 3; j++)
            {
                pd = Convert.ToInt32(cpf[j].ToString()) * i--;
                soma += pd;



            }

        }
        resto = soma % 11;
        if (resto < 2)
        {
            if (Convert.ToInt32(cpf[9].ToString()) != 0)
            {
                return false;
            }
        }
        else
        {
            ver = 11 - resto;
            if (Convert.ToInt32(cpf[9].ToString()) != ver)
            {
                return false;
            }
        }







        for (int l = 11; l >= 2; l--)
        {
            for (int k = 0; k <= cpf.Length - 2; k++)
            {
                sd = (Convert.ToInt32(cpf[k].ToString()) * l--);
                soma1 += sd;


            }

        }
        resto1 = soma1 % 11;
        if (resto1 < 2)
        {
            if (Convert.ToInt32(cpf[10].ToString()) != 0)
            {
                return false;
            }
        }
        else
        {
            veri = 11 - resto1;
            if (Convert.ToInt32(cpf[10].ToString()) != veri)
            {
                return false;
            }
        }

        return true;

    }

    public static bool Email(string email)
    {
        try
        {
            var enderecoEmail = new System.Net.Mail.MailAddress(email);
            return enderecoEmail.Address == email;
        }
        catch
        {
            return false;
        }
    }
}

