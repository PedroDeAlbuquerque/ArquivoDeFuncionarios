using System;
using System.IO;

namespace ArquivoDeFuncionarios
{
    internal class DeletorDeDados
    {
        private readonly FiltroDeDados filtroDeDados = new();

        public void DeletarArquivoDeFuncionario()
        {
            ControladorDeFuncionarios.LimparConsoleEAlternarSuaCorDoTexto(ConsoleColor.Red);

            string rgParaDeletarDeArquivo;
            do
            {
                rgParaDeletarDeArquivo = DefinirRGDeFuncionarioParaDeletarDeArquivo();

                if (ControladorDeFuncionarios.ChecarVoltaParaPassoAnterior(rgParaDeletarDeArquivo))
                    break;
            }
            while (!ChecarExistenciaEDeletarArquivoDeFuncionario(rgParaDeletarDeArquivo));
        }

        private string DefinirRGDeFuncionarioParaDeletarDeArquivo()
        {
            string inputDoUsuario;
            do
            {
                Console.WriteLine("Insira o RG do funcionário que será excluído:");
                inputDoUsuario = Console.ReadLine();

                ControladorDeFuncionarios.ChecarSaidaDoSistema(inputDoUsuario);

                if (ControladorDeFuncionarios.ChecarVoltaParaPassoAnterior(inputDoUsuario))
                    break;
            }
            while (!filtroDeDados.FiltrarDado(Funcionario.CampoDeDados.RG, inputDoUsuario));

            return inputDoUsuario;
        }

        private static Boolean ChecarExistenciaEDeletarArquivoDeFuncionario(string rgParaDeletarArquivo)
        {
            Boolean funcionarioParaSerDeletadoExiste = File.Exists($"arquivo/{rgParaDeletarArquivo}.txt");

            if (funcionarioParaSerDeletadoExiste)
            {
                File.Delete($"arquivo/{rgParaDeletarArquivo}.txt");
                Console.WriteLine("Funcionário removido com sucesso!");
            }
            else
            {
                Console.WriteLine("Arquivo de funcionário inexistente, por favor, insira o rg de um funcionário existente.");
            }

            return funcionarioParaSerDeletadoExiste;
        }
    }
}
