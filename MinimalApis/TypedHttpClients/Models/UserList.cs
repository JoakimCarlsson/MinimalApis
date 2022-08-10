namespace MinimalApis.TypedHttpClients.Models;

public sealed record UserList(
    IEnumerable<User> Data,
    int Total,
    int Page,
    int Limit
);