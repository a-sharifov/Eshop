namespace Identity.Application.Users.Queries.GetGenders;

public sealed record GetGendersQueryResponse(IEnumerable<string> Genders)