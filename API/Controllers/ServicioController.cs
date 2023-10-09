using API.Dtos;
using AutoMapper;
using Core.Entities;
using Core.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

public class ServicioController : BaseControllerApi
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public ServicioController(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<IEnumerable<ServicioDto>>> Get()
    {
        var servicios = await _unitOfWork.Servicios.GetAllAsync();

        //var paises = await _unitOfWork.Paises.GetAllAsync();
        return _mapper.Map<List<ServicioDto>>(servicios);
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<Pais>> Post(ServicioDto servicioDto)
    {
        var servicio = _mapper.Map<Pais>(servicioDto);
        this._unitOfWork.Paises.Add(servicio);
        await _unitOfWork.SaveAsync();
        if (servicio == null)
        {
            return BadRequest();
        }
        servicioDto.Id = servicio.Id;
        return CreatedAtAction(nameof(Post), new { id = servicioDto.Id }, servicioDto);
    }
    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<ServicioDto>> Get(int id)
    {
        var servicio = await _unitOfWork.Servicios.GetByIdAsync(id);
        if (servicio == null){
            return NotFound();
        }
        return _mapper.Map<ServicioDto>(servicio);
    }
    [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<ServicioDto>> Put(int id, [FromBody] ServicioDto servicioDto)
    {
        if (servicioDto == null)
            return NotFound();
        var servicios = _mapper.Map<Servicio>(servicioDto);
        _unitOfWork.Servicios.Update(servicios);
        await _unitOfWork.SaveAsync();
        return servicioDto;
    }

    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Delete(int id)
    {
        var servicio = await _unitOfWork.Servicios.GetByIdAsync(id);
        if (servicio == null)
        {
            return NotFound();
        }
        _unitOfWork.Servicios.Remove(servicio);
        await _unitOfWork.SaveAsync();
        return NoContent();
    }
}