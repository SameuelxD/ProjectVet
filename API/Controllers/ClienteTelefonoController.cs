using API.Dtos;
using AutoMapper;
using Core.Entities;
using Core.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

public class ClienteTelefonoController : BaseControllerApi
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public ClienteTelefonoController(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<IEnumerable<ClienteTelefonoDto>>> Get()
    {
        var clientestelefono = await _unitOfWork.ClientesTelefono.GetAllAsync();

        //var paises = await _unitOfWork.Paises.GetAllAsync();
        return _mapper.Map<List<ClienteTelefonoDto>>(clientestelefono);
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<ClienteTelefono>> Post(ClienteTelefonoDto clientetelefonoDto)
    {
        var clientetelefono = _mapper.Map<ClienteTelefono>(clientetelefonoDto);
        this._unitOfWork.ClientesTelefono.Add(clientetelefono);
        await _unitOfWork.SaveAsync();
        if (clientetelefono == null)
        {
            return BadRequest();
        }
        clientetelefonoDto.Id = clientetelefono.Id;
        return CreatedAtAction(nameof(Post), new { id = clientetelefonoDto.Id }, clientetelefonoDto);
    }
    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<ClienteTelefonoDto>> Get(int id)
    {
        var clientetelefono = await _unitOfWork.Paises.GetByIdAsync(id);
        if (clientetelefono == null){
            return NotFound();
        }
        return _mapper.Map<ClienteTelefonoDto>(clientetelefono);
    }
    [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<ClienteTelefonoDto>> Put(int id, [FromBody] ClienteTelefonoDto clientetelefonoDto)
    {
        if (clientetelefonoDto == null)
            return NotFound();
        var clientestelefono = _mapper.Map<ClienteTelefono>(clientetelefonoDto);
        _unitOfWork.ClientesTelefono.Update(clientestelefono);
        await _unitOfWork.SaveAsync();
        return clientetelefonoDto;
    }

    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Delete(int id)
    {
        var clientetelefono = await _unitOfWork.ClientesTelefono.GetByIdAsync(id);
        if (clientetelefono == null)
        {
            return NotFound();
        }
        _unitOfWork.ClientesTelefono.Remove(clientetelefono);
        await _unitOfWork.SaveAsync();
        return NoContent();
    }
}