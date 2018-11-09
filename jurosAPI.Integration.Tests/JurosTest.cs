using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Xunit;

namespace jurosAPI.Integration.Tests
{
    public class JurosTest
    {
        private HttpClient Client { get; set; }
        private TestServer _server;

        private async Task<string> PegarContentGet(string url)
        {
            var response = await Client.GetAsync(url);
            response.EnsureSuccessStatusCode();

            return await response.Content.ReadAsStringAsync();
        }

        public JurosTest()
        {
            _server = new TestServer(new WebHostBuilder().UseStartup<Startup>());
            Client = _server.CreateClient();
        }

        [Theory]
        [InlineData(100, 5, "105,1")]
        [InlineData(0, 0, "0")]
        public async Task CalculaJuros(double valorInicial, int meses, string resultadoEsperado)
        {
            string url = string.Format("/calculajuros?valorinicial={0}&meses={1}", valorInicial, meses);

            string content = await PegarContentGet(url);
            
            Assert.Equal(resultadoEsperado, content);
        }

        [Fact]
        public async Task CalculaJurosSemParametros()
        {
            string content = await PegarContentGet("/calculajuros");

            Assert.Equal("0", content);
        }

        [Fact]
        public async Task UrlInvalida()
        {
            var response = await Client.GetAsync("/asdf");
            Assert.Equal(HttpStatusCode.NotFound, response.StatusCode);
        }

        [Fact]
        public async Task ResponseShowMeToCode()
        {
            string content = await PegarContentGet("/showmethecode");

            Assert.Equal("https://github.com/paulloh3n/jurosAPI", content);
        }
    }
}
