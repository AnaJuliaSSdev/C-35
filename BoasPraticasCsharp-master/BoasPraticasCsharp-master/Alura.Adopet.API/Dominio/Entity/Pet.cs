﻿using Alura.Adopet.API.Util;
using System.ComponentModel.DataAnnotations;

namespace Alura.Adopet.API.Dominio.Entity
{
    public class Pet
    {
        public Pet()
        {
            Id = Guid.NewGuid();
        }

        [Key]
        public Guid Id { get; set; }
        public string? Nome { get; set; }
        public TipoPet Tipo { get; set; }
        public Cliente? Proprietario { get; set; }
    }
}
