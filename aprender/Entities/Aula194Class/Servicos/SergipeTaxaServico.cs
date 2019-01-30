namespace aprender.Entities.Aula194Class
{
    class SergipeTaxaServico : ITaxaServico
    {
        public double Taxa(double valor)
        {
            if (valor <= 100.0)
            {
                return valor * 0.25;
            }
            else
            {
                return valor * 0.20;
            }
        }
    }
}
