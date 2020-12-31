using System;
using System.Collections.Generic;
using System.Text;

namespace DesignPatternSamples.Application.Rules
{
    public static class ValidarDadosCNH
    {
        public static bool Registro(string registro, out string message)
        {
            if (registro.Length != 11)
            {
                message = "O registro da CNH deve ter 11 caracteres";
                return false;
            }

            message = "O Registro é Valido";
            return true;
        }
        public static bool DataNascimento(DateTime date, out string message)
        {
            if ((DateTime.Now.Year - date.Year) < 18)
            {
                message = "Data de nascimento incorreta";
                return false;
            }

            message = "Data de nascimento é valido";
            return true;
        }
        public static bool CPF(string CPF, out string message)
        {
            if (string.IsNullOrWhiteSpace(CPF))
            {
                message = "É necessario informar o CPF.";
                return false;
            }



            int[] multiplierOne = new int[9] { 10, 9, 8, 7, 6, 5, 4, 3, 2 };
            int[] multiplierTwo = new int[10] { 11, 10, 9, 8, 7, 6, 5, 4, 3, 2 };
            List<string> cpfInvalido = new List<string> { "00000000000", "11111111111", "22222222222", "33333333333", "44444444444", "55555555555", "66666666666", "77777777777", "88888888888", "99999999999" };
            string aux;
            string digit;
            int sum, rest;

            var value = CPF.Trim();
            value = CPF.Replace(".", "").Replace("-", "");

            if (value.Length != 11)
            {
                message = "O CPF deve ter 11 caracteres";
                return false;
            }

            foreach (string item in cpfInvalido)
            {
                if (item == CPF)
                {
                    message = "CPF invalido";
                    return false;
                }
            }

            aux = value.Substring(0, 9);
            sum = 0;

            for (int i = 0; i < 9; i++)
                sum += int.Parse(aux[i].ToString()) * multiplierOne[i];

            rest = sum % 11;

            if (rest < 2)
                rest = 0;
            else
                rest = 11 - rest;

            digit = rest.ToString();
            aux = aux + digit;
            sum = 0;

            for (int i = 0; i < 10; i++)
                sum += int.Parse(aux[i].ToString()) * multiplierTwo[i];

            rest = sum % 11;

            if (rest < 2)
                rest = 0;
            else
                rest = 11 - rest;

            digit = digit + rest.ToString();

            if (!value.EndsWith(digit))
            {
                message = "CPF invalido";
                return false;
            }
            message = "O CPF é valido";
            return true;
        }

       
    }
}
