using System;
using System.IO;
using System.Text.RegularExpressions;

namespace ArquivoDeFuncionarios
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ArmazenadorDeDados controlador = new();
            controlador.DefinirEArmazenarDadosDoFuncionario();
        }
    }
}
