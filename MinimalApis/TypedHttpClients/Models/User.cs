namespace MinimalApis.TypedHttpClients.Models;

public sealed record User( 
    string Id,
    string Title,
    string FirstName,
    string LastName,
    string Picture);