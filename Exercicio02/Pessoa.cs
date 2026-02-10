using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;

namespace Exercicio02
{
    public class Pessoa
    {
    public string Nome = "Julia";

    public int Idade = 17;
    
    public void ExibirDados()
        {
            Console.WriteLine($"Ola {Nome},");
            Console.WriteLine($"sua idade e {Idade}");

        }
}
    
}