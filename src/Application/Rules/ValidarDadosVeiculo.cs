using System;
using System.Collections.Generic;
using System.Text;

namespace DesignPatternSamples.Application.Rules
{
    public static class ValidarDadosVeiculo
    {
        public static bool PlacaVeiculo(string intPlaca, out string message)
        {
            string[] placa = intPlaca.Split("-");
            if (placa.Length < 2)
            {
                message = "Erro. Ultilizar o seguinte formato: 'AAA-1234'";
                return false;
            }
            if (VerificaPlaca(placa))
            {
                message = "Placa valida";
                return true;
            }
            else
            {
                message = "Placa invalida";
                return false;
            }
        }

        private static bool VerificaPlaca(string[] placa)
        {
            char[] letras = { 'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J', 'K', 'L', 'M', 'N', 'O', 'P', 'Q', 'R', 'S', 'T', 'U', 'V', 'W', 'X', 'Y', 'Z' };
            char[] num = { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9' };
            if (placa[0].Length < 3 || placa[1].Length < 4)
            {
                return false;
            }

            int contadorPlaca = 0;

            for (int i = 0; i < 26; i++)
            {
                if (i < 10 && placa[1].Contains(num[i]))
                {
                    contadorPlaca += VerifcarRepetições(placa[1], num[i]);
                }
                if (placa[0].Contains(letras[i]))
                {
                    contadorPlaca += VerifcarRepetições(placa[0], letras[i]);
                }
            }

            if (contadorPlaca == 7)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private static int VerifcarRepetições(string palavra, char caracter)
        {
            int contador = 0;
            for (int i = 0; i < palavra.Length; i++)
            {
                if (palavra[i] == caracter)
                {
                    contador++;
                }
            }
            return contador;
        }
    }
}
