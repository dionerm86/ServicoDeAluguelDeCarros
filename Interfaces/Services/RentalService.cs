using Interfaces.Entities;
using System;

namespace Interfaces.Services
{
    class RentalService //Serviço de Aluguel
    {
        public double PricePerHour { get; private set; }
        public double PricePerDay { get; private set; }

        /*Propriedade _brazilTaxService para a solução da questão sem utilizar Interface
        private BrazilTaxService _brazilTaxService = new BrazilTaxService();
        */
        private ITaxService _taxService;

        public RentalService(double pricePerHour, double pricePerDay, ITaxService taxService)
        {
            PricePerHour = pricePerHour;
            PricePerDay = pricePerDay;
            _taxService = taxService; 
        } 

        public void ProcessInvoice(CarRental carRental)
        {
            TimeSpan duration = carRental.Finish.Subtract(carRental.Start);
            double basicPayment = 0.0;
            if (duration.TotalHours <= 12.0)
            {
                basicPayment = PricePerHour * Math.Ceiling(duration.TotalHours);
            }
            else
            {
                basicPayment = PricePerDay * Math.Ceiling(duration.TotalDays);
            }

            double tax = _taxService.Tax(basicPayment);

            carRental.Invoice = new Invoice(basicPayment, tax);
        }
    }
}
