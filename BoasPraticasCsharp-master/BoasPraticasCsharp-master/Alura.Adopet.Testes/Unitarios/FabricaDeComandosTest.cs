using Alura.Adopet.Console.Comandos;

namespace Alura.Adopet.Testes.Unitarios
{
    public class FabricaDeComandosTest
    {

        [Fact]
        public void DadoUmParametroDeveRetornarUmTipoImport()
        {
            string[] args = { "import", "lista.csv" };
            var comando = FabricaDeComandos.CriarComando(args);
            Assert.IsType<Import>(comando);
        }

        [Fact]
        public void DadoUmParametroInvalidoDeveRetornarNulo()
        {
            string[] args = { "invalid", "lista.csv" };
            var comando = FabricaDeComandos.CriarComando(args);
            Assert.Null(comando);
        }
    }
}
