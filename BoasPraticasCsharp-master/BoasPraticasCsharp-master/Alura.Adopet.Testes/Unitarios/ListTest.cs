﻿using Alura.Adopet.Console.Modelos;
using Alura.Adopet.Console.Util;
using Alura.Adopet.Testes.Builder;

namespace Alura.Adopet.Testes.Unitarios
{
    public class ListTest
    {
        [Fact]
        public async Task QuandoExecutarComandoListDeveRetornarListaDePets()
        {
            List<Pet>? listaDePet = new();
            var pet = new Pet(new Guid("456b24f4-19e2-4423-845d-4a80e8854a99"),
                                                "Lima", TipoPet.Cachorro);
            listaDePet.Add(pet);

            var httpClientPet = HttpClientPetMockBuilder.GetMockList(listaDePet);

            var retorno = await new Console.Comandos.List(httpClientPet.Object)
                    .ExecutarAsync();

            var resultado = (SuccessWithPets)retorno.Successes[0];
            Assert.Single(resultado.Data);
        }
    }
}
