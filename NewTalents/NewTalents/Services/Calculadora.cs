using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NewTalents.Services
{
    

    public class Calculadora
    {
        private readonly List<string> listarHistorico;
        public DateTime DataCriacao { get; }



        public Calculadora()
        {
            listarHistorico = new List<string>();
            
        }



        public int Somar(int num1, int num2)
        {
            listarHistorico.Insert(0, "Res" + (num1 + num2) + " em " + DateTime.Now);

            return num1 + num2;
           
        }

        public int Subtrair(int num1, int num2)
        {
            listarHistorico.Insert(0, "Res" + (num1 - num2) + " em " + DateTime.Now);

            return num1 - num2;
        }

        public int Multiplicar(int num1, int num2)
        {
            listarHistorico.Insert(0, "Res" + (num1 * num2) + " em " + DateTime.Now);

            return num1 * num2;
        }

        public int Dividir(int num1, int num2)
        {
            listarHistorico.Insert(0, "Res" + (num1 / num2) + " em " + DateTime.Now);

            return num1 / num2;
        }

        public List<string> historico()
        {
            listarHistorico.RemoveRange(3, listarHistorico.Count -3);
            return listarHistorico;
        }
    }
}