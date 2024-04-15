using MovieApi.Dtos;
using System;
using System.ComponentModel.DataAnnotations;

public class CreateCinemaDto
{
    [Required(ErrorMessage = "The field 'name' is mandatory.")]
    public string Name { get; set; }
    public int AddressId { get; set; }
}