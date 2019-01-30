using System.Globalization;

namespace aprender.Entities.Aula191Class
{
    class Invoice
    {
        public double BasycPayment { get; set; }
        public double Tax { get; set; }

        public Invoice(double basycPayment, double tax)
        {
            BasycPayment = basycPayment;
            Tax = tax;
        }

        public double totalPayment
        {
            get { return BasycPayment + Tax;  }
        }

        public override string ToString()
        {
            return "Basic payment: "
                + BasycPayment.ToString("f2", CultureInfo.InvariantCulture)
                + "\nTax: "
                +Tax.ToString("f2", CultureInfo.InvariantCulture)
                +"\nTotal payment: "
                +totalPayment.ToString("f2", CultureInfo.InvariantCulture);
        }
    }
}
