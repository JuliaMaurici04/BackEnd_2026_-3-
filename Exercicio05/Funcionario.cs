using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Exercicio05 
{
    public class Funcionario : Pessoa
    {
        public int Salario = 2000;

        public void ExibirDados()
        {
            Console.WriteLine($"Nome:{Nome}");
            Console.WriteLine($"Salario:{Salario}");
        }

    }
}