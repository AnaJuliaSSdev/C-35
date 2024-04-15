using System;
using System.ComponentModel.DataAnnotations;

public class UpdateCinemaDto
{
    [Required(ErrorMessage = "The field 'name' is mandatory.")]
    public string Nome { get; set; }
}