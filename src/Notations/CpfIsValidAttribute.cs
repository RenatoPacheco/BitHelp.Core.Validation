using System;
using System.Text.RegularExpressions;

namespace BitHelp.Core.Validation.Notations
{
    [AttributeUsage(AttributeTargets.Property |
           AttributeTargets.Field, AllowMultiple = false)]
    public class CpfIsValidAttribute : ListIsValidAttribute
    {
        protected override bool Check(object value)
        {
            string input = Convert.ToString(value);

            bool retorno;
            string pattern;
            Regex regex;

            // Checando se tem apenas números
            pattern = @"^([0-9]{11})$|^([0-9]{3}\.[0-9]{3}\.[0-9]{3}-[0-9]{2})$";
            regex = new Regex(pattern);
            retorno = regex.Match(input).Success;
            //Checando se não são 11 dígitos iguais
            if (retorno)
            {
                input = input.Replace("-", "");
                input = input.Replace(".", "");
                pattern = @"^([1]{11}|[2]{11}|[3]{11}|[4]{11}|[5]{11}|[6]{11}|[7]{11}|[8]{11}|[9]{11}|[0]{11})$";
                regex = new Regex(pattern);
                retorno = !regex.Match(input).Success;
            }

            if (retorno)
            {
                /**/
                // Para validar calculamos usando os 9 primeiro dígito
                string cpf = input.Substring(0, 9);
                int soma;
                int resto;
                int primeiroDigito;
                int segundoDigito;
                int multiplicador;
                // Calculando o primeiro dígito
                multiplicador = 10;
                soma = 0;
                for (int indice = 0; indice < cpf.Length; indice++)
                {
                    soma += (int.Parse(cpf[indice].ToString()) * multiplicador);
                    multiplicador--;
                }
                resto = soma % 11;
                if (resto < 2)
                {
                    primeiroDigito = 0;
                }
                else
                {
                    primeiroDigito = 11 - resto;
                }
                // Calculando o segundo dígito
                // para calcular adicionamos o digito ao cpf
                cpf += primeiroDigito.ToString();
                multiplicador = 11;
                soma = 0;
                for (int indice = 0; indice < cpf.Length; indice++)
                {
                    soma += (int.Parse(cpf[indice].ToString()) * multiplicador);
                    multiplicador--;
                }
                resto = soma % 11;
                if (resto < 2)
                {
                    segundoDigito = 0;
                }
                else
                {
                    segundoDigito = 11 - resto;
                }
                // Para finalizar adicionamos o digito ao cpf
                cpf += segundoDigito.ToString();
                // Agora que obtivemos um cpf completo comparamos o resultado com o informado
                return (input == cpf);
            }

            return false;
        }
    }
}
