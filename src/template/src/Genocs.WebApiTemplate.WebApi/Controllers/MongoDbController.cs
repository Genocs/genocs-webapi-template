using Genocs.Persistence.MongoDb.Repositories;
using Genocs.WebApiTemplate.Domain.Aggregates;
using Microsoft.AspNetCore.Mvc;

namespace Genocs.WebApiTemplate.WebApi.Controllers;

[ApiController]
[Route("[controller]")]
public class MongoDbRepositoryController : ControllerBase
{
    private readonly IMongoDbRepository<User> _userRepository;

    private readonly ILogger<MongoDbRepositoryController> _logger;

    public MongoDbRepositoryController(ILogger<MongoDbRepositoryController> logger, IMongoDbRepository<User> userRepository)
    {
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        _userRepository = userRepository ?? throw new ArgumentNullException(nameof(userRepository));
    }

    [HttpGet]
    [ProducesResponseType(typeof(string), StatusCodes.Status200OK)]
    public IActionResult Get()
        => Ok("MongoDbRepositoryController");

    [HttpPost("dummy")]
    [ProducesResponseType(typeof(string), StatusCodes.Status200OK)]
    public async Task<IActionResult> PostDummy()
    {
        User user = new User(Guid.NewGuid().ToString(), Guid.NewGuid().ToString(), 21, "ITA");
        var objectId = await _userRepository.InsertAndGetIdAsync(user);
        return Ok(objectId.ToString());
    }
}
