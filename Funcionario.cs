﻿namespace ArquivoDeFuncionarios
{
    internal class Funcionario
    {
        public enum CampoDeDados { Nome, Email, RG, Telefone, Salario };

        public string Nome { get; set; }
        public string Email { get; set; }
        public string RG { get; set; }
        public string Telefone { get; set; }
        public string Salario  { get; set; }
    }
}
