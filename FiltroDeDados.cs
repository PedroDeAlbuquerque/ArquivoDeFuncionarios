using System;
using System.Text.RegularExpressions;

namespace ArquivoDeFuncionarios
{
    internal class FiltroDeDados
    {
        private const string PadraoParaFiltroDeNome = @"^([\w'\-,.][^0-9_!¡?÷?¿/\\+=@#$%ˆ&*(){}|~<>;:[\]]{2,})$";
        private const string PadraoParaFiltroDeEmail = @"^[\w-\.]+@([\w-]+\.)+[\w-]{2,4}$";
        private const string PadraoParaFiltroDeRG = @"(^\d{1,2}).?(\d{3}).?(\d{3})-?(\d{1}|X|x$)";
        private const string PadraoParaFiltroDeTelefone = @"(^[0-9]{2})?(\s|-)?(9?[0-9]{4})-?([0-9]{4}$)";
        private const string PadraoParaFiltroDeSalario = @"^[1-9]{1}([0-9]+)([,.]?)([0-9]{1,2})?$";
        private readonly Regex FiltroDeNome = new(PadraoParaFiltroDeNome);
        private readonly Regex FiltroDeEmail = new(PadraoParaFiltroDeEmail);
        private readonly Regex FiltroDeRG = new(PadraoParaFiltroDeRG);
        private readonly Regex FiltroDeTelefone = new(PadraoParaFiltroDeTelefone);
        private readonly Regex FiltroDeSalario = new(PadraoParaFiltroDeSalario);

        public Boolean FiltrarDado(Enum campoParaAplicarFiltro, string inputDoUsuario)
        {
            Boolean resultadoDoFiltro = false;

            switch (campoParaAplicarFiltro)
            {
                case Funcionario.CampoDeDados.Nome:
                    resultadoDoFiltro = FiltrarNome(inputDoUsuario);
                    break;
                case Funcionario.CampoDeDados.Email:
                    resultadoDoFiltro = FiltrarEmail(inputDoUsuario);
                    break;
                case Funcionario.CampoDeDados.RG:
                    resultadoDoFiltro = FiltrarRG(inputDoUsuario);
                    break;
                case Funcionario.CampoDeDados.Telefone:
                    resultadoDoFiltro = FiltrarTelefone(inputDoUsuario);
                    break;
                case Funcionario.CampoDeDados.Salario:
                    resultadoDoFiltro = FiltrarSalario(inputDoUsuario);
                    break;
            }

            ChecarValidadeDeDadoEAcusarInvalidade(resultadoDoFiltro);

            return resultadoDoFiltro;
        }

        private Boolean FiltrarNome(string inputDoUsuario)
        {
            return this.FiltroDeNome.IsMatch(inputDoUsuario);
        }

        private Boolean FiltrarEmail(string inputDoUsuario)
        {
            return this.FiltroDeEmail.IsMatch(inputDoUsuario);
        }

        private Boolean FiltrarRG(string inputDoUsuario)
        {
            return this.FiltroDeRG.IsMatch(inputDoUsuario);
        }

        private Boolean FiltrarTelefone(string inputDoUsuario)
        {
            return this.FiltroDeTelefone.IsMatch(inputDoUsuario);
        }

        private Boolean FiltrarSalario(string inputDoUsuario)
        {
            return this.FiltroDeSalario.IsMatch(inputDoUsuario);
        }

        private static void ChecarValidadeDeDadoEAcusarInvalidade(Boolean resultadoDoFiltro)
        {
            if (!resultadoDoFiltro)
                Console.WriteLine("Dado inválido! Por favor, repita o processo.");
        }
    }
}
