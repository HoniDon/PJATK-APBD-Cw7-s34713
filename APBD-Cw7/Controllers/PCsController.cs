using APBD_Cw7.Models;
using Microsoft.AspNetCore.Mvc;

namespace APBD_Cw7.Controllers;

[ApiController]
[Route("api/pcs")]
public class PCsController : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> GetPCs()
    {
        return Ok();
    }
    
    [HttpGet("{id:int}/components")]
    public async Task<IActionResult> GetPCComponents([FromRoute] int id)
    {
        return Ok();
    }
    
    [HttpPost]
    public async Task<IActionResult> CreatePC()
    {
        return Created();
    }
    
    [HttpPut("{id:int}")]
    public async Task<IActionResult> UpdatePC([FromRoute] int id)
    {
        return Ok();
    }
    
    [HttpDelete("{id:int}")]
    public async Task<IActionResult> DeletePC([FromRoute] int id)
    {
        return NoContent();
    }
    
}