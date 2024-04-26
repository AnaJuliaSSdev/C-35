using Alura.Adopet.Console.Modelos;
using Alura.Adopet.Console.Servicos;
using Alura.Adopet.Console.Util;
using FluentResults;

namespace Alura.Adopet.Console.Comandos
{
    [DocComando(instrucao: "import", documentacao: " adopet import <ARQUIVO> comando que realiza a importação do arquivo de pets.")]
    public class Import : IComando
    {
        private readonly HttpClientPet clientPet;
        private readonly LeitorDeArquivoCsv leitor;

        public Import(HttpClientPet clientPet, LeitorDeArquivoCsv leitor)
        {
            this.clientPet = clientPet;
            this.leitor = leitor;
        }

        public virtual async Task<Result> ExecutarAsync()
        {
            return await this.ImportacaoArquivoPetAsync();
        }

        private async Task<Result> ImportacaoArquivoPetAsync()
        {
            try
            {
                List<Pet> listaDePet = leitor.RealizaLeitura();
                foreach (var pet in listaDePet)
                {
                    System.Console.WriteLine(pet);
                    await clientPet.CreatePetAsync(pet);
                }
                System.Console.WriteLine("Importação concluída!");
                return Result.Ok().WithSuccess(new SuccessWithPets(listaDePet, "Importação Realizada com Sucesso!"));

            } catch (Exception exception)
            {
                return Result.Fail(new Error("Importação falhou.").CausedBy(exception));
            }
        }
    }
}
        