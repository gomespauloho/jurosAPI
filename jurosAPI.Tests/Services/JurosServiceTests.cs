using System;
using Xunit;
using jurosAPI.Services;

namespace jurosAPI.Tests
{
    public class JurosServiceTests
    {
        [Theory]
        [InlineData(100, 5, 105.10)]
        [InlineData(254.36, 4, 264.68)]
        [InlineData(100, 3, 103.03)]
        [InlineData(152, 0, 152)]
        [InlineData(100, -1, 99)]
        public void ValidarJurosCompostos(double valor, int meses, double resultadoEsperado)
        {
            JurosService juros = new JurosService();

            double resultado = juros.CalcularJurosComposto(valor, meses);    

            Assert.Equal(resultadoEsperado, resultado);
        }
    }
}
