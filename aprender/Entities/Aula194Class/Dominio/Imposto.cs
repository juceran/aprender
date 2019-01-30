using System.Globalization;

namespace aprender.Entities.Aula194Class
{
    class Imposto
    {
        public double BaseCalculo { get; set; }
        public double Taxa { get; set; }

        public Imposto(double baseCalculo, double taxa)
        {
            BaseCalculo = baseCalculo;
            Taxa = taxa;
        }

        public double TotalDoImposto
        {
            get { return BaseCalculo + Taxa; }
        }

        public override string ToString()
        {
            return 
                "Base de Cálculo: "
                + BaseCalculo
                + "\nTaxa: "
                + Taxa.ToString("f2", CultureInfo.InvariantCulture)
                + "\nTotal com Imposto: "
                + TotalDoImposto.ToString("f2", CultureInfo.InvariantCulture);
        }
    }
}
