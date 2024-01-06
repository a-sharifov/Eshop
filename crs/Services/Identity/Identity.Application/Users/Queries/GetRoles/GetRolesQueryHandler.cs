namespace Identity.Application.Users.Queries.GetRoles;

internal sealed class GetRolesQueryHandler : IQueryHandler<GetRolesQuery, GetRolesQueryResponse>
{
    public async Task<Result<GetRolesQueryResponse>> Handle(GetRolesQuery request, CancellationToken cancellationToken)
    {
        var roles = Enum.GetNames(typeof(Role));

        return Result.Success(
            new GetRolesQueryResponse(roles));
    }
}
