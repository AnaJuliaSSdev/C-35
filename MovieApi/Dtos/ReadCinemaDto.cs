using MovieApi.Dtos;
using System;

public class ReadCinemaDto
{
    public int Id { get; set; }
    public string Name { get; set; }
    public ReadAddressDto ReadAddressDto { get; set; }
}