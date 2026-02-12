using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;

namespace Exercicio06
{
    public class Pessoa
    {
        public string Nome = "Julia";
        public string Sobrenome = "Mauricio";
        public void Apresentar()
        {
            Console.WriteLine($"Nome completo: {Nome} {Sobrenome}");
        }
    }


}

