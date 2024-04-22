using Alura.Adopet.Console.Comandos;

namespace Alura.Adopet.Testes
{
    public class HelpTest
    {
        [Fact]
        public async Task QuandoComandoNaoExistirDeveRetornarFalha()
        {
            var comando = "Inválido";
            var help = new Help(comando);

            var resultado = await help.ExecutarAsync();

            Assert.NotNull(resultado);
            Assert.True(resultado.IsFailed);
        }

        [Theory]
        [InlineData("help")]
        [InlineData("show")]
        [InlineData("list")]
        [InlineData("import")]
        public async Task QuandoComandoExistirDeveRetornarSucesso(string comando)
        {
            var help = new Help(comando);
            var resultado = await help.ExecutarAsync();
            Assert.NotNull(resultado);
            Assert.True(resultado.IsSuccess);
        }
    }
}
