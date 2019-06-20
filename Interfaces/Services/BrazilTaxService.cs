namespace Interfaces.Services
{
    class BrazilTaxService : ITaxService // Realização da Interface
    {
        //Esta classe é obrigada a implementar o método Tax que está no contrato(Interface)
        public double Tax(double amount) //amount = quantia
        {
            if (amount <= 100.0)
            {
                return amount * 0.2;
            }
            else
            {
                return amount * 0.15;
            }
        }
    }
}
