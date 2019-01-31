using System;
using System.Collections.Generic;
using System.Text;

namespace aprender.Entities.Aula218Class
{
    class Funcionario
    {
        public string Nome { get; set; }
        public double Salario { get; set; }
        public string Email { get; set; }

        public Funcionario(string nome, double salario, string email)
        {
            Nome = nome;
            Salario = salario;
            Email = email;
        }
    }
}
