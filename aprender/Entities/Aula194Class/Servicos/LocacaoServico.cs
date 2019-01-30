using System;
using System.Collections.Generic;
using System.Text;

namespace aprender.Entities.Aula194Class
{
    class LocacaoServico
    {
        public double PrecoPorHora { get; private set; }
        public double PrecoPorDia { get; private set; }

        private ITaxaServico _taxaServico;

        public LocacaoServico(double precoPorHora, double precoPorDia, ITaxaServico taxaServico)
        {
            PrecoPorHora = precoPorHora;
            PrecoPorDia = precoPorDia;
            _taxaServico = taxaServico;
        }

        public void ProcessoImposto(Locacao locacao)
        {
            TimeSpan duracao = locacao.Termino.Subtract(locacao.Inicio);
            double baseCalculo = 0.0;

            if (duracao.TotalHours <= 12.0)
            {
                baseCalculo = PrecoPorHora * Math.Ceiling(duracao.TotalHours);
            }
            else
            {
                baseCalculo = PrecoPorDia * Math.Ceiling(duracao.TotalDays);
            }

            double taxa = _taxaServico.Taxa(baseCalculo);

            locacao.Imposto = new Imposto(baseCalculo, taxa);
        }
    }
}
