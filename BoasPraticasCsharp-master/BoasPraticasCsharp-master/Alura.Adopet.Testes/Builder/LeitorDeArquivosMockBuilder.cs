﻿using Alura.Adopet.Console.Modelos;
using Alura.Adopet.Console.Util;
using Moq;

namespace Alura.Adopet.Testes.Builder
{
    internal static class LeitorDeArquivosMockBuilder
    {
        public static Mock<LeitorDeArquivoCsv> GetMock(List<Pet> listaDePet)
        {
            var leitorDeArquivo = new Mock<LeitorDeArquivoCsv>(MockBehavior.Default,
                It.IsAny<string>());

            leitorDeArquivo.Setup(_ => _.RealizaLeitura()).Returns(listaDePet);

            return leitorDeArquivo;
        }
    }
}
