using API.Dtos;
using AutoMapper;
using Core.Entities;
using Core.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;
public class ClienteDireccionController : BaseControllerApi
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public ClienteDireccionController(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    
    public async Task<ActionResult<IEnumerable<ClienteDireccionDto>>> Get()
    {
        var clientesdireccion = await _unitOfWork.ClientesDireccion.GetAllAsync();
        return _mapper.Map<List<ClienteDireccionDto>>(clientesdireccion);
    }   

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<ClienteDireccion>> Post(ClienteDireccionDto clientedireccionDto)
    {
        var clientedireccion = _mapper.Map<ClienteDireccion>(clientedireccionDto);
        this._unitOfWork.ClientesDireccion.Add(clientedireccion);
        await _unitOfWork.SaveAsync();
        if(clientedireccion == null)
        {
            return BadRequest();
        }
        clientedireccionDto.Id = clientedireccion.Id;
        return CreatedAtAction(nameof(Post) , new { id = clientedireccionDto.Id} , clientedireccionDto); 
    }
    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<ClienteDireccionDto>> Get(int id)
    {
        var clientedireccion = await _unitOfWork.ClientesDireccion.GetByIdAsync(id);
        if(clientedireccion == null)
        {
            return NotFound();
        }
        return _mapper.Map<ClienteDireccionDto>(clientedireccion);
    }

    [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<ClienteDireccionDto>> Put(int id, [FromBody]ClienteDireccionDto clientedireccionDto)
    {
        if(clientedireccionDto == null)
        {
            return NotFound();
        }
        var clientesdireccion = _mapper.Map<ClienteDireccion>(clientedireccionDto);
        _unitOfWork.ClientesDireccion.Update(clientesdireccion);
        await _unitOfWork.SaveAsync();
        return clientedireccionDto;
    }

    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]   
    public async Task<IActionResult> Delete(int id)
    {
        var clientedireccion = await _unitOfWork.ClientesDireccion.GetByIdAsync(id);
        if(clientedireccion == null){
            return NotFound();
        }
        _unitOfWork.ClientesDireccion.Remove(clientedireccion);
        await _unitOfWork.SaveAsync();
        return NoContent();
    }   
}