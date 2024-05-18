using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExemploFundamentos.ExemploFundamentos.ExemploFundamentos.Common.Models
{
    public class Pessoa
    {
        public void main(){

             Console.WriteLine("-------------------------------------------");

             int[] cara = new int[]{1,2,3,3,4,66,99};

            for (int i = 0; i < cara.Length; i++){
                 Console.WriteLine(cara[i]);
            }

            Console.WriteLine("-------------------------------------------");

            string[] person = {"cadu","edu", "jacu"};

            for (int j = 0; j < person.Length; j++){
                 Console.WriteLine(person[j]);
            }

             Console.WriteLine("-------------------------------------------");

            string[] personl = {"cachorro","cavalo", "jacare"};

            foreach (string item in personl)
            {
                Console.WriteLine(item);
            } 

           /*Array.Resize(ref person1, person1 * 2); aumenta o tamanho do array 
           string person1Dobrado = new string{person1.Lenght *2}
           Array.Copy(person1, personDobrado, person1.Lenght)
           */

            List<string> personal = new List<string>();

         personal.Add("SP");
         personal.Add("MG");
         personal.Add("RS");

            foreach (string item1 in personal)
            {
                Console.WriteLine($"O nome do Estado é: {item1}");
                
            } 
        }
    }
}