﻿using Alura.Adopet.Console.Comandos;
using Alura.Adopet.Console.Modelos;
using Alura.Adopet.Console.Servicos;
using Alura.Adopet.Console.Util;
using Moq;

namespace Alura.Adopet.Testes.integration
{
    public class ImportIntegrationTeste
    {
        [Fact]
        public async void QuandoAPIEstaNoArDeveRetornarListaDePet()
        {
            var leitorDeArquivo = new Mock<LeitorDeArquivoCsv>(MockBehavior.Default, It.IsAny<string>());
            var listaDePet = new List<Pet>();
            var pet = new Pet(new Guid("456b24f4-19e2-4423-845d-4a80e8854a41"), "Lima", TipoPet.Cachorro);
            listaDePet.Add(pet);

            leitorDeArquivo.Setup(_ => _.RealizaLeitura()).Returns(listaDePet);

            var httpClientPet = new HttpClientPet(new AdopetAPIClientFactory().CreateClient());
            var import = new Import(httpClientPet, leitorDeArquivo.Object);

            string[] args = { "import", "lista.csv" };
            await import.ExecutarAsync();

            var listaPet = await httpClientPet.ListPetsAsync();
            Assert.NotNull(listaPet);

        }
    }
}
