
namespace Identity.Application.Users.Queries.GetGenders;

internal sealed class GetRolesQueryHandler : IQueryHandler<GetGendersQuery, GetGendersQueryResponse>
{
    public Task<Result<GetGendersQueryResponse>> Handle(GetGendersQuery request, CancellationToken cancellationToken)
    {
        var roles = Gender.GetNames();
        var response = Result.Success(new GetGendersQueryResponse(roles));
        return Task.FromResult(response);
    }
}
