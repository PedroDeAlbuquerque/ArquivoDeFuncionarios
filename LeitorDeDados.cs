using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArquivoDeFuncionarios
{
    internal class LeitorDeDados
    {
        private readonly FiltroDeDados filtroDeDados = new();


        public void DefinirRGELerArquivoDeFuncionario()
        {
            string rgParaLeituraDeArquivo;
            do
            {
                rgParaLeituraDeArquivo = DefinirRGDeFuncionarioParaLeituraDeArquivo();
            }
            while (!LerArquivoDeFuncionario(rgParaLeituraDeArquivo));
        }

        private string DefinirRGDeFuncionarioParaLeituraDeArquivo()
        {
            string inputDoUsuario;
            do
            {
                Console.WriteLine("Insira o RG do funcionário desejado:");
                inputDoUsuario = Console.ReadLine();
            }
            while (!filtroDeDados.FiltrarDado(Funcionario.CampoDeDados.RG, inputDoUsuario));

            return inputDoUsuario;
        }

        private Boolean LerArquivoDeFuncionario(string rgParaLeituraDeArquivo)
        {
            try
            {
                string textoParaLeitura = File.ReadAllText($"arquivo/{rgParaLeituraDeArquivo}.txt");

                Console.WriteLine("Dados do funcionário:");
                Console.WriteLine(textoParaLeitura);

                return true;
            }
            catch (FileNotFoundException erro)
            {
                Console.WriteLine("Não foi possível encontrar o funcionário com o rg digitado, por favor, insira um rg existente.");

                return false;
            }
        }
    }
}
