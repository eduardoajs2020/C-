using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExemploExplorando.Models
{
    public class Pessoa
    {

         //Construtor sem argumentos
        public Pessoa()
        {
           
        }

        //Construtor com argumentos
        public Pessoa(string nome, string sobrenome)
        {
            Nome = nome;
            Sobrenome = sobrenome;
        }

        //Desconstrutor
        public void Deconstruct(out string nome, out string sobrenome)
        {
            nome = Nome;
            sobrenome = Sobrenome;
        }


        //Objeto derivado
        private string _nome;
        private int _idade;


        //Propriedades
        public string Nome 
        { 
            get=> _nome.ToUpper(); //Body Expression (sustitui {return _nome.ToUpper()})
            

            set
            {
                if(value == "")

                {
                    throw new ArgumentException("O nome não pode ser vazio");
                }

                _nome = value;

            }
        }

        public string Sobrenome{ get; set;}

        
        public string NomeCompleto => $"{Nome} {Sobrenome}".ToUpper();
        

        public int Idade 

        { 
            get
            {
                return _idade;
            } 
            
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("A idade não pode ser menor que zero");
                }
               else if (value == 0)
                {
                    throw new ArgumentException("O campo idade não pode ser vazio");
                }
                _idade = value;
            }
        }

        //Método Apresentar
        public void Apresentar()
        {
            Console.WriteLine($"Nome: {NomeCompleto}, Idade: {Idade}");
        }
    }
}