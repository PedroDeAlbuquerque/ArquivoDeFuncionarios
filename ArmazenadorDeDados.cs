using System;
using System.IO;
using System.Text;

namespace ArquivoDeFuncionarios
{
    internal class ArmazenadorDeDados
    {
        private readonly FiltroDeDados filtroDeDados = new();
        private int EtapaDeArmazenamento = (int) Funcionario.CampoDeDados.Nome;

        public void DefinirEArmazenarDadosDoFuncionario()
        {
            Funcionario novoFuncionario = DefinirDadosDoFuncionario();

            ArmazenarDadosDoFuncionario(novoFuncionario);
        }

        private Funcionario DefinirDadosDoFuncionario()
        {
            Funcionario novoFuncionario = new();

            while (this.EtapaDeArmazenamento <= (int) Funcionario.CampoDeDados.Salario)
            {
                switch (this.EtapaDeArmazenamento)
                {
                    case (int) Funcionario.CampoDeDados.Nome:
                        novoFuncionario.Nome = DefinirCampoDoFuncionario();
                        break;
                    case (int) Funcionario.CampoDeDados.Email:
                        novoFuncionario.Email = DefinirCampoDoFuncionario();
                        break;
                    case (int) Funcionario.CampoDeDados.RG:
                        novoFuncionario.RG = DefinirCampoDoFuncionario();
                        break;
                    case (int) Funcionario.CampoDeDados.Telefone:
                        novoFuncionario.Telefone = DefinirCampoDoFuncionario();
                        break;
                    case (int) Funcionario.CampoDeDados.Salario:
                        novoFuncionario.Salario = DefinirCampoDoFuncionario();
                        break;
                }
            }

            return novoFuncionario;
        }

        private static async void ArmazenarDadosDoFuncionario(Funcionario funcionario)
        {
            string textoParaArmazenamento = MontarTextoDeDadosParaArmazenamento(funcionario);

            await File.WriteAllTextAsync($"arquivo/{funcionario.RG}.txt", textoParaArmazenamento);

            Console.WriteLine("Dados do funcionário armazenado com sucesso!");
        }

        private string DefinirCampoDoFuncionario()
        {
            Boolean usuarioVoltouParaOPassoAnterior;

            Enum CampoDaEtapaAtual = (Funcionario.CampoDeDados)this.EtapaDeArmazenamento;

            string inputDoUsuario;
            do
            {
                string campo = CampoDaEtapaAtual.ToString().ToLower();
                Console.WriteLine($"Digite o {campo} do novo funcionário:");
                inputDoUsuario = Console.ReadLine();

                usuarioVoltouParaOPassoAnterior = ChecarVoltaParaPassoAnterior(inputDoUsuario);
                if (usuarioVoltouParaOPassoAnterior)
                    break;
            }
            while (!filtroDeDados.FiltrarDado(CampoDaEtapaAtual, inputDoUsuario));

            AtualizarEtapaDeArmazenamento(usuarioVoltouParaOPassoAnterior);

            return inputDoUsuario;
        }

        private static Boolean ChecarVoltaParaPassoAnterior(string inputDoUsuario)
        {
            if (inputDoUsuario == "voltar")
                return true;
            else
                return false;
        }

        private void AtualizarEtapaDeArmazenamento(Boolean usuarioVoltouParaOPassoAnterior)
        {
            if (!usuarioVoltouParaOPassoAnterior)
                this.EtapaDeArmazenamento++;
            else
                this.EtapaDeArmazenamento--;

            this.EtapaDeArmazenamento = Math.Clamp(this.EtapaDeArmazenamento, (int) Funcionario.CampoDeDados.Nome, ((int) Funcionario.CampoDeDados.Salario) + 1);
        }

        private static string MontarTextoDeDadosParaArmazenamento(Funcionario funcionario)
        {
            StringBuilder textoParaArmazenamento = new();

            string salarioCorrigido = CorrigirSalarioDoFuncionarioParaArmazenamento(funcionario.Salario);

            textoParaArmazenamento.AppendLine("######################################");
            textoParaArmazenamento.AppendLine($"Nome: {funcionario.Nome}");
            textoParaArmazenamento.AppendLine($"Email: {funcionario.Email}");
            textoParaArmazenamento.AppendLine($"RG: {funcionario.RG}");
            textoParaArmazenamento.AppendLine($"Telefone: {funcionario.Telefone}");
            textoParaArmazenamento.AppendLine($"Salário: {funcionario.Salario}");
            textoParaArmazenamento.AppendLine($"Salário corrigido: {salarioCorrigido}");
            textoParaArmazenamento.AppendLine("######################################");
            
            return textoParaArmazenamento.ToString();
        }

        private static string CorrigirSalarioDoFuncionarioParaArmazenamento(string salario)
        {
            double salarioCorrigido;
            double salarioParaCorrecao = Convert.ToDouble(salario.Replace('.', ','));

            if (salarioParaCorrecao < 1700)
            {
                salarioCorrigido = salarioParaCorrecao + 300;
            }
            else
            {
                salarioCorrigido = salarioParaCorrecao + 200;
            }

            return salarioCorrigido.ToString();
        }
    }
}
