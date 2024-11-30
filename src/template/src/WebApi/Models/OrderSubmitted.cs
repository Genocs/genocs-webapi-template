namespace Genocs.Library.Template.WebApi.Models;

/// <summary>
/// Represents the event that is raised when an order is submitted.
/// </summary>
/// <param name="OrderId">The order Id.</param>
/// <param name="UserId">The order owner.</param>
public record OrderSubmitted(string OrderId, string UserId);
