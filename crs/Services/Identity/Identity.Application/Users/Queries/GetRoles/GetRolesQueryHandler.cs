namespace Identity.Application.Users.Queries.GetRoles;

internal sealed class GetRolesQueryHandler : IQueryHandler<GetRolesQuery, GetRolesQueryResponse>
{
    public Task<Result<GetRolesQueryResponse>> Handle(GetRolesQuery request, CancellationToken cancellationToken)
    {
        var roles = Enum.GetNames(typeof(Role));
        var response = Result.Success(new GetRolesQueryResponse(roles));

        return Task.FromResult(response);
    }
}
