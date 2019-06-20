using System;
using System.Collections.Generic;
using System.Text;
using System.Globalization;

namespace Interfaces.Entities
{
    class Invoice // Fatura
    {
        public double BasicPayment { get; set; }
        public double Tax { get; set; }

        public Invoice(double basicPayment, double tax)
        {
            BasicPayment = basicPayment;
            Tax = tax;
        }

        public double TotalPayment
        {
            get { return BasicPayment + Tax; }
        }

        public override string ToString()
        {
            return "BasicPayment: "
                + BasicPayment.ToString("F2", CultureInfo.InvariantCulture)
                + "\nTax: "
                + Tax.ToString("F2", CultureInfo.InvariantCulture)
                + "\nTotalPayment: "
                + TotalPayment.ToString("F2", CultureInfo.InvariantCulture);
        }
    }
}
