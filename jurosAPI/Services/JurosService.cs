using System;

namespace jurosAPI.Services
{
    public class JurosService
    {
        public double CalcularJurosComposto(double valor, int meses)
        {
            double resultado = valor * Math.Pow((1 + 0.01), meses);

            return Math.Truncate(resultado * 100) / 100;
        }
    }
}
