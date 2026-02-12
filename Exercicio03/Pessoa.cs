using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Exercicio03
{
    public class Pessoa
    {
        public string Nome = "Júlia Maurício";

        public int Idade = 17;
    
        public Pessoa(string n, int i)
        {
            Nome = n;
            Idade = i;

            if(Idade < 0)
            {
                System.Console.WriteLine("Idade < 0 invalida");
                Idade = 0;
            }
        }

    public void ExibirDados()
        {
            Console.WriteLine($"Nome:{Nome}");
            Console.WriteLine($"Idade:{Idade}");
        }

    }
}