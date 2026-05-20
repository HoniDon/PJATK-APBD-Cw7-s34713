using APBD_Cw7.DTOs;
using APBD_Cw7.Exceptions;

using APBD_Cw7.Services;
using Microsoft.AspNetCore.Mvc;

namespace APBD_Cw7.Controllers;

[ApiController]
[Route("api/pcs")]
public class PCsController(IPCService service) : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> GetPCs(CancellationToken cancellationToken)
    {
        var pcs = await service.GetAllPCsAsyncs(cancellationToken);
        return Ok(pcs);
    }
    
    [HttpGet("{id:int}/components")]
    public async Task<IActionResult> GetPCComponents([FromRoute] int id, CancellationToken cancellationToken)
    {
        try
        {
            var pc = await service.GetPCByIdAsync(id, cancellationToken);
            return Ok(pc);
        }
        catch (NotFoundException e)
        {
            return NotFound(e.Message);
        }
    }
    
    [HttpPost]
    public async Task<IActionResult> CreatePC([FromBody] CreatePCDto dto, CancellationToken cancellationToken)
    {
        var created = await service.CreatePCAsync(dto, cancellationToken);
        return CreatedAtAction(nameof(GetPCComponents), new {id = created.Id}, created);
    }
    
    [HttpPut("{id:int}")]
    public async Task<IActionResult> UpdatePC([FromRoute] int id, [FromBody] UpdatePCDto dto, CancellationToken cancellationToken)
    {
        try
        {
            await service.UpdatePCAsync(id, dto, cancellationToken);
            return NoContent();
        }
        catch (NotFoundException e)
        {
            return NotFound(e.Message);
        }
    }
    
    [HttpDelete("{id:int}")]
    public async Task<IActionResult> DeletePC([FromRoute] int id, CancellationToken cancellationToken)
    {
        try
        {
            await service.DeletePCAsync(id, cancellationToken);
            return NoContent();
        }
        catch (NotFoundException e)
        {
            return NotFound(e.Message);
        }
    }
    
}