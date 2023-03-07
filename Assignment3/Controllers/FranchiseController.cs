
using Assignment3.DTO.Characters;
using Assignment3.DTO.Franchises;
using Microsoft.AspNetCore.Mvc;
using Assignment3.Controllers.Services;

using Assignment3.Models;

namespace Assignment3.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [Route("api/franchise")]

public class FranchiseController : ControllerBase
{
    private readonly IFranchiseService _franchiseService;

    public FranchiseController(IFranchiseService franchiseService)
    {
        _franchiseService = franchiseService;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<FranchiseDto>>> GetAll()
    {
        var franchise = await _franchiseService.GetAllFranchisesAsync();
        var franchiseDtos = franchise.Select(f => new FranchiseDto(f));
        return Ok(franchiseDtos);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<FranchiseDto>> GetById(int id)
    {
        var franchise = await _franchiseService.GetFranchiseByIdAsync(id);
        if (franchise == null)
        {
            return NotFound();
        }
        var franchiseDto = new FranchiseDto(franchise);
        return Ok(franchiseDto);
    }

    [HttpPost]
    public async Task<ActionResult<FranchiseDto>> Create(FranchiseCreateDto createDto)
    {
        var franchise = new Franchise(createDto.Name, createDto.Description);
        await _franchiseService.AddFranchiseAsync(franchise);
        var franchiseDto = new FranchiseDto(franchise);
        return CreatedAtAction(nameof(GetById), new { id = franchise.Id }, franchiseDto);
    }

    [HttpPut("{id}")]
    public async Task<ActionResult<FranchiseDto>> Update(int id, FranchiseUpdateDto updateDto)
    {
        var franchise = await _franchiseService.GetFranchiseByIdAsync(id);
        if (franchise == null)
        {
            return NotFound();
        }
        franchise.Update(updateDto.Name, updateDto.Description);
        await _franchiseService.UpdateFranchiseAsync(franchise);
        var franchiseDto = new FranchiseDto(franchise);
        return Ok(franchiseDto);
    }


    [HttpDelete("{id}")]
    public async Task<ActionResult> Delete(int id)
    {
        await _franchiseService.DeleteFranchiseAsync(id);
        return NoContent();
    }

    [HttpPut("{id}/characters")]
    public async Task<ActionResult<FranchiseDto>> UpdateFranchise(int id, UpdateFranchiseDto updateDto)
    {
        var franchise = await _franchiseService.GetFranchiseByIdAsync(id);
        if (franchise == null)
        {
            return NotFound();
        }
        var characters = await _franchiseService.GetFranchiseByIdAsync(updateDto.FranchiseIds);
        franchise.UpdateFranchises(franchise); 
        await _franchiseService.UpdateFranchiseAsync(franchise);
        var franchiseDto = new FranchiseDto(franchise);
        return Ok(franchiseDto);

            throw new NotImplementedException();

        }
    }
}
