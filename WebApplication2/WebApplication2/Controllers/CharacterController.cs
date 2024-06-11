using Microsoft.AspNetCore.Mvc;
using WebApplication2.Services;

namespace WebApplication2.Controllers;
[Route("api/[controller]")]
[ApiController]
public class CharacterController : ControllerBase
{
    
    private readonly DbService _dbService;

    public CharacterController(DbService dbService)
    {
        _dbService = dbService;
    }


    [HttpGet]
    [Route("/{id}")]
    public async Task<IActionResult> GetCharacter(int id)
    {

        if (!await _dbService.DoesCharacterExist(id))
        {
            return NotFound($"Character with given id: {id} does not exist");
        }

        var res = await _dbService.GetCharacterInfo(id);

        return Ok(res);
    }

    [HttpPost]
    [Route("/{id}/backpacks")]
    public async Task<IActionResult> AddItemsToCharacter([FromBody] List<int> IDs, int id)
    {
        if (!await _dbService.DoesItemExist(IDs))
        {
            return NotFound("One of given Item does not exist");
        }

        if (!await _dbService.DoesCharacterIsStrongEnough(IDs,id))
        {
            return BadRequest("Sum of weigths is above character maxweigthLimit");
        }

        await _dbService.AddItemsToCharacter(IDs,id);
        return Ok("Items Added");
    }
}