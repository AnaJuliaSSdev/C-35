using Alura.Adopet.Console.Modelos;

namespace Alura.Adopet.Console.Util
{
    public class LeitorDeArquivo
    {
        private string caminhoDoArquivoASerLido;
        public LeitorDeArquivo(string caminhoDoArquivoASerLido)
        {
            this.caminhoDoArquivoASerLido = caminhoDoArquivoASerLido;
        }

        public virtual List<Pet> RealizaLeitura()
        {
            if (string.IsNullOrEmpty(this.caminhoDoArquivoASerLido))
            {
                return null;
            }
            List<Pet> listaDePet = new List<Pet>();
            using (StreamReader sr = new StreamReader(caminhoDoArquivoASerLido))
            {
                while (!sr.EndOfStream)
                {
                    string[] propriedades = sr.ReadLine()!.Split(';');
                    Pet pet = new Pet(Guid.Parse(propriedades[0]),
                    propriedades[1],
                    int.Parse(propriedades[2]) == 1 ? TipoPet.Gato : TipoPet.Cachorro
                    );
                    listaDePet.Add(pet);
                }
            }

            return listaDePet;
        }
    }
}
