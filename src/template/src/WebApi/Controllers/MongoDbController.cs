using Genocs.Library.Template.Domain.Aggregates;
using Genocs.Persistence.MongoDb.Domain.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace Genocs.Library.Template.WebApi.Controllers;

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
    [ProducesResponseType(typeof(User), StatusCodes.Status200OK)]
    public async Task<IActionResult> PostDummy()
    {
        User user = new User(Guid.NewGuid().ToString(), Guid.NewGuid().ToString(), 21, "ITA");
        var result = await _userRepository.InsertAsync(user);
        return Ok(result);
    }
}
