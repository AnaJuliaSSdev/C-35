using Alura.Adopet.Console.Modelos;
using Alura.Adopet.Console.Util;

namespace Alura.Adopet.Testes
{
    public class PetAPartirDoCsvTeste
    {
        [Fact]
        public void QuandoStringForValidaDeveRetornarUmPet()
        {
            string linha = "456b24f4-19e2-4423-845d-4a80e8854a41;Lima Limão;1";
            Pet pet = linha.ConverteDoTexto();
            Assert.NotNull(pet);
        }

        [Fact]
        public void QuandoStringForNulaDeveLancarArgumentNullException()
        {
            string? linha = null;
            Assert.Throws<ArgumentNullException>(() => linha.ConverteDoTexto());
        }

        [Fact]
        public void QuandoStringVaziaDeveLancarArgumentException()
        {
            string? linha = string.Empty;
            Assert.Throws<ArgumentException>(() => linha.ConverteDoTexto());
        }

        [Fact]
        public void QuandoCamposInsuficientesDeveLancarArgumentException()
        {
            string linha = "456b24f4-19e2-4423-845d-4a80e8854a41;1";
            Assert.Throws<ArgumentException>(() => linha.ConverteDoTexto());
        }

        [Fact]
        public void QuandoGuidInvalidoDeveLancarArgumentException()
        {
            string linha = "umGuidInvalido;Lima Limão;1";
            Assert.Throws<ArgumentException>(() => linha.ConverteDoTexto());
        }

        [Fact]
        public void QuandoTipoInvalidoDeveLancarArgumentException()
        {
            string linha = "456b24f4-19e2-4423-845d-4a80e8854a41;Lima Limão;3";
            Assert.Throws<ArgumentException>(() => linha.ConverteDoTexto());
        }
    }
}
