using Alura.Adopet.Console.Util;
using FluentResults;
using System;

namespace Alura.Adopet.Console.Comandos
{
    [DocComando(instrucao: "show", documentacao: " adopet show <ARQUIVO> comando que exibe no terminal o conteúdo do arquivo importado.")]
    public class Show : IComando
    {
        private readonly LeitorDeArquivoCsv leitorDeArquivo;

        public Show(LeitorDeArquivoCsv leitorDeArquivo)
        {
            this.leitorDeArquivo = leitorDeArquivo;
        }

        public Task<Result> ExecutarAsync()
        {
            return this.ExibeConteudoDoArquivo();
        }

        private async Task<Result> ExibeConteudoDoArquivo()
        {
            try
            {
                var listaDePets = leitorDeArquivo.RealizaLeitura();
                foreach (var pet in listaDePets)
                {
                    System.Console.WriteLine(pet);
                }

                return Result.Ok().WithSuccess(success: new SuccessWithPets(listaDePets, "Exibição do arquivo realizada com sucesso!"));
            }
            catch (Exception exception)
            {
                return Result.Fail(new Error("Erro na exibição do arquivo!").CausedBy(exception));
            }
        }
    }
}
