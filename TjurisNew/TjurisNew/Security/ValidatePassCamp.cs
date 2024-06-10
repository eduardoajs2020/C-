using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace TjurisNew.Security
{
    public static class ValidatePassCamp
    {
        static string VerificarForcaSenha(string senha)
        {
            int comprimentoMinimo = 8;
            bool temLetraMaiuscula = false;
            bool temLetraMinuscula = false;
            bool temNumero = false;
            bool temCaractereEspecial = false;

            //Verificando o comprimento da senha
            if (senha.Length < comprimentoMinimo)
                return "Sua senha e muito curta. Recomenda-se no minimo 8 caracteres.";

            // Verificando se a senha contém letras maiúsculas e minúsculas
            temLetraMaiuscula = senha.Any(char.IsUpper);
            temLetraMinuscula = senha.Any(char.IsLower);

            // Verificando se a senha contém sequências comuns
            string[] sequenciasComuns = ["123456", "abcdef"];
            if (NewMethod(senha, sequenciasComuns))
                return "Sua senha contem uma sequencia comum. Tente uma senha mais complexa.";

            // Verificando se a senha contém palavras comuns
            string[] palavrasComuns = ["password", "123456", "qwerty"];
            if (palavrasComuns.Contains(senha))
                return "Sua senha e muito comum. Tente uma senha mais complexa.";

            // Verificando se a senha contém números e caracteres especiais
            temNumero = senha.Any(char.IsDigit);
            temCaractereEspecial = senha.Any(c => !char.IsLetterOrDigit(c));

            if (temLetraMinuscula && temLetraMaiuscula && temNumero && temCaractereEspecial)
                return "Sua senha atende aos requisitos de seguranca. Parabens!";
            else
                return "Sua senha nao atende aos requisitos de seguranca.";
        }

        private static bool NewMethod(string senha, string[] sequenciasComuns)
        {
            return sequenciasComuns.Any(s => senha.Contains(s));
        }

        static void Main(string[] args)
        {
            var senha = Console.ReadLine().Trim();

            string resultado = VerificarForcaSenha(senha);

            Console.WriteLine(resultado);
        }


    }
}