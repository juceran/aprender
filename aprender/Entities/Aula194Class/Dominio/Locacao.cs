using System;

namespace aprender.Entities.Aula194Class
{
    class Locacao
    {
        public DateTime Inicio { get; set; }
        public DateTime Termino { get; set; }
        public Veiculo Veiculo { get; set; }
        public Imposto Imposto { get; set; }

        public Locacao(DateTime inicio, DateTime termino, Veiculo veiculo)
        {
            Inicio = inicio;
            Termino = termino;
            Veiculo = veiculo;
        }
    }
}
