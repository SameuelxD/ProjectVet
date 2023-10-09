using API.Dtos;
using AutoMapper;
using Core.Entities;
using Core.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

public class MascotaController : BaseControllerApi
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public MascotaController(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<IEnumerable<MascotaDto>>> Get()
    {
        var mascotas = await _unitOfWork.Paises.GetAllAsync();

        //var paises = await _unitOfWork.Paises.GetAllAsync();
        return _mapper.Map<List<MascotaDto>>(mascotas);
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<Mascota>> Post(MascotaDto mascotaDto)
    {
        var mascota = _mapper.Map<Mascota>(mascotaDto);
        this._unitOfWork.Mascotas.Add(mascota);
        await _unitOfWork.SaveAsync();
        if (mascota == null)
        {
            return BadRequest();
        }
        mascotaDto.Id = mascota.Id;
        return CreatedAtAction(nameof(Post), new { id = mascotaDto.Id }, mascotaDto);
    }
    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<MascotaDto>> Get(int id)
    {
        var mascota = await _unitOfWork.Mascotas.GetByIdAsync(id);
        if (mascota == null){
            return NotFound();
        }
        return _mapper.Map<MascotaDto>(mascota);
    }
    [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<MascotaDto>> Put(int id, [FromBody] MascotaDto mascotaDto)
    {
        if (mascotaDto == null)
            return NotFound();
        var mascotas = _mapper.Map<Mascota>(mascotaDto);
        _unitOfWork.Mascotas.Update(mascotas);
        await _unitOfWork.SaveAsync();
        return mascotaDto;
    }

    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Delete(int id)
    {
        var mascota = await _unitOfWork.Mascotas.GetByIdAsync(id);
        if (mascota == null)
        {
            return NotFound();
        }
        _unitOfWork.Mascotas.Remove(mascota);
        await _unitOfWork.SaveAsync();
        return NoContent();
    }
}