using System.Reflection;
using Alura.Adopet.Console.Comandos;
using Alura.Adopet.Console.Util;

namespace Alura.Adopet.Testes
{
    public class GeraDocumentacaoTeste
    {
        [Fact]
        public void QuandoExistemComandosDeveRetornarDicionarioNaoVazio()
        {
            Assembly assemblyComOTipoDocComando = Assembly.GetAssembly(typeof(DocComando))!; 
            Dictionary<string, DocComando> dicionario = DocumentacaoDoSistema.ToDictionary(assemblyComOTipoDocComando);  
            Assert.NotEmpty(dicionario);
            Assert.NotNull(dicionario);
            Assert.Equal(4, dicionario.Count);
        }
    }
}
