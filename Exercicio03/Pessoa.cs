using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Exercicio03
{
    public class Pessoa
    {
        public string Nome = "";

        public int Idade = 0;
    

    public void ExibirDados()
        {
            Console.WriteLine($"Ola {Nome},");
        }

    }
}