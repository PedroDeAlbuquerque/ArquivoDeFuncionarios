using System;

namespace ArquivoDeFuncionarios
{
    internal class ControladorDeFuncionarios
    {
        private enum EtapaDoControladorDeFuncionarios { Armazenamento = 1, Leitura, Delecao };
        private ArmazenadorDeDados armazenadorDeFuncionarios = new();
        private LeitorDeDados leitorDeFuncionarios = new();
        private DeletorDeDados deletorDeFuncionarios = new();
        private EtapaDoControladorDeFuncionarios OpcaoDoUsuario { get; set; }

        public ControladorDeFuncionarios()
        {
            Console.WriteLine("Bem vindo ao arquivo de funcionários!");
        }

        public void executarArquivoDeFuncionarios()
        {
            while (true)
            {
                MostrarMensagemDeOpcoes();
                this.OpcaoDoUsuario = SelecionarOpcaoDoSistema();
                ExecutarFuncionalidadeDoSistemaBaseadoNaOpcaoDoUsuario();
            }
        }

        private static void MostrarMensagemDeOpcoes()
        {
            Console.WriteLine(
                "Digite a opção que deseja utilizar:\n" +
                "1 - Armazenar novo funcionário ou alterar dados de um funcionário existente\n" +
                "2 - Acessar os dados de um funcionário existente\n" +
                "3 - Deletar os dados de um funcionário existente\n" +
                "Digite 'voltar' em qualquer momento para retornar à etapa anterior de uma das funcionalidades do programa.\n" +
                "Digite 'sair' em qualquer momento para finalizar o programa."
                );
        }

        private EtapaDoControladorDeFuncionarios SelecionarOpcaoDoSistema()
        {
            string inputDoUsuario;
            EtapaDoControladorDeFuncionarios inputDoUsuarioConvertidoEmOpcaoDoSistema;
            do
            {
                inputDoUsuario = Console.ReadLine();

                ChecarSaidaDoSistema(inputDoUsuario);
            }
            while (!ValidarOpcaoDoSistema(inputDoUsuario));

            inputDoUsuarioConvertidoEmOpcaoDoSistema = ConverterInputDoUsuarioEmOpcaoDoSistema(inputDoUsuario);

            return inputDoUsuarioConvertidoEmOpcaoDoSistema;
        }

        private EtapaDoControladorDeFuncionarios ConverterInputDoUsuarioEmOpcaoDoSistema(string inputDoUsuario)
        {
            int numeroDaOpcao = (int) Convert.ToDouble(inputDoUsuario);
            EtapaDoControladorDeFuncionarios opcaoDoSistema = (EtapaDoControladorDeFuncionarios)numeroDaOpcao;
        
            return opcaoDoSistema;
        }

        private static Boolean ValidarOpcaoDoSistema(string inputDoUsuario)
        {
            if (inputDoUsuario != "1" && inputDoUsuario != "2" && inputDoUsuario != "3")
            {
                Console.WriteLine("Opção inválida, por favor, digite uma opção válida.");
                return false;
            }
            else
            {
                return true;
            }
        }

        private void ExecutarFuncionalidadeDoSistemaBaseadoNaOpcaoDoUsuario()
        {
            switch (this.OpcaoDoUsuario)
            {
                case EtapaDoControladorDeFuncionarios.Armazenamento:
                    armazenadorDeFuncionarios.DefinirEArmazenarDadosDoFuncionario();
                    break;
                case EtapaDoControladorDeFuncionarios.Leitura:
                    leitorDeFuncionarios.DefinirRGELerArquivoDeFuncionario();
                    break;
                case EtapaDoControladorDeFuncionarios.Delecao:
                    deletorDeFuncionarios.DeletarArquivoDeFuncionario();
                    break;
            }
        }

        public static void ChecarSaidaDoSistema(string inputDoUsuario)
        {
            if (inputDoUsuario == "sair")
            {
                Console.WriteLine("Obrigado por utilizar este sistema.");
                Environment.Exit(0);
            }
        }
    }
}
