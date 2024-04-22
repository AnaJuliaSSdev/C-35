using Alura.Adopet.Console.Modelos;
using Alura.Adopet.Testes.Builder;
using Alura.Adopet.Console.Comandos;
using Alura.Adopet.Console.Util;

namespace Alura.Adopet.Testes
{
    public class ShowTest
    {
        [Fact]
        public async Task QuandoArquivoExistenteDeveRetornarMensagemDeSucesso()
        {
            List<Pet> listaDePet = new();
            var pet = new Pet(new Guid("456b24f4-19e2-4423-845d-4a80e8854a99"),
                              "Lima", TipoPet.Cachorro);
            listaDePet.Add(pet);

            var leitor = LeitorDeArquivosMockBuilder.GetMock(listaDePet);
            leitor.Setup(_ => _.RealizaLeitura()).Returns(listaDePet);

            var show = new Show(leitor.Object);

            var resultado = await show.ExecutarAsync();

            Assert.NotNull(resultado);
            var sucesso = (SuccessWithPets)resultado.Successes[0];
            Assert.Equal("Exibição do arquivo realizada com sucesso!",
                sucesso.Message);
        }
    }
}
