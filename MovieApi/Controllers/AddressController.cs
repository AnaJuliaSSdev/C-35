using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using MovieApi.Data;
using MovieApi.Dtos;
using MovieApi.Models;

namespace MovieApi.Controllers;

[ApiController]
[Route("[controller]")]
public class AddressController : ControllerBase
{
    private MovieContext _context;
    private IMapper _mapper;

    public AddressController(MovieContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    [HttpPost]
    public IActionResult AddAddress([FromBody] CreateAddressDto addressDto)
    {
        Address address = _mapper.Map<Address>(addressDto);
        _context.Addresses.Add(address);
        _context.SaveChanges();
        return CreatedAtAction(nameof(GetAddressById), new { Id = address.Id }, address);
    }

    [HttpGet]
    public IEnumerable<ReadAddressDto> GetAddresses()
    {
        return _mapper.Map<List<ReadAddressDto>>(_context.Addresses);
    }

    [HttpGet("{id}")]
    public IActionResult GetAddressById(int id)
    {
        Address endereco = _context.Addresses.FirstOrDefault(endereco => endereco.Id == id)!;
        if (endereco != null)
        {
            ReadAddressDto enderecoDto = _mapper.Map<ReadAddressDto>(endereco);

            return Ok(enderecoDto);
        }
        return NotFound();
    }

    [HttpPut("{id}")]
    public IActionResult UpdateAddress(int id, [FromBody] UpdateAddressDto addressDto)
    {
        Address address = _context.Addresses.FirstOrDefault(address => address.Id == id)!;
        if (address == null)
        {
            return NotFound();
        }
        _mapper.Map(addressDto, address);
        _context.SaveChanges();
        return NoContent();
    }

    [HttpDelete("{id}")]
    public IActionResult DeleteAddress(int id)
    {
        Address address = _context.Addresses.FirstOrDefault(address => address.Id == id)!;
        if (address == null)
        {
            return NotFound();
        }
        _context.Remove(address);
        _context.SaveChanges();
        return NoContent();
    }
}
