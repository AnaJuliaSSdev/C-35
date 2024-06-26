﻿using MovieApi.Models;
using System;
using System.ComponentModel.DataAnnotations;

public class Cinema
{
    [Key]
    [Required]
    public int Id { get; set; }
    [Required(ErrorMessage = "The field 'name' is mandatory.")]
    public string Name { get; set; }
    public int AddressId { get; set; }
    public virtual Address Address { get; set; }
    public virtual ICollection<Session> Sessions { get; set; }
}
