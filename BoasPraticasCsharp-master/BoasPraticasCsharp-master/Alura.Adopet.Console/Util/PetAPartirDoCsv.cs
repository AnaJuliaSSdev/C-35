using Alura.Adopet.Console.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alura.Adopet.Console.Util
{
    public static class PetAPartirDoCsv
    {
        public static Pet ConverteDoTexto(this string? linha)
        {
            if(linha is null) throw new ArgumentNullException(nameof(linha), "Texto não pode ser nulo.");
            if(string.IsNullOrEmpty(linha)) throw new ArgumentException(nameof(linha), "Texto não pode ser vazio.");

            string[]? propriedades = linha.Split(';');

            if (propriedades.Length < 3) throw new ArgumentException(nameof(linha), "Campos insuficientes para criar um pet.");

            bool sucesso = Guid.TryParse(propriedades[0], out Guid petId);
            if (!sucesso) throw new ArgumentException(nameof(linha), "Guid inválido.");

            sucesso = int.TryParse(propriedades[2], out int tipoPet);
            if (!sucesso) throw new ArgumentException(nameof(linha), "Tipo de pet inválido.");
            if (tipoPet > 1 || tipoPet < 0) throw new ArgumentException(nameof(linha), "Enum inválido.");

            return new Pet(petId, propriedades[1], tipoPet == 0 ? TipoPet.Gato : TipoPet.Cachorro); 
        }
    }
}
