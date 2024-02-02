namespace Identity.Application.Users.Queries.GetRoles;

internal sealed class GetRolesQueryHandler : IQueryHandler<GetRolesQuery, GetRolesQueryResponse>
{
    public Task<Result<GetRolesQueryResponse>> Handle(GetRolesQuery request, CancellationToken cancellationToken)
    {
        var roles = Role.GetNames();
        var response = Result.Success(new GetRolesQueryResponse(roles));

        return Task.FromResult(response);
    }
}
