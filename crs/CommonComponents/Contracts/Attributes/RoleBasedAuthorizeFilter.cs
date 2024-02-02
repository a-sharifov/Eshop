//using Contracts.Enumurations;
//using Microsoft.AspNetCore.Authentication;
//using Microsoft.AspNetCore.Mvc;
//using Microsoft.AspNetCore.Mvc.Filters;

//namespace Contracts.Attributes;

//public class RoleBasedAuthorizeFilter(Role role) : IAuthorizationFilter
//{
//    private readonly Role role = role;

//    public void OnAuthorization(AuthorizationFilterContext context)
//    {
//        if (!context.HttpContext.User.Identity.IsAuthenticated)
//        {
//            context.Result = new ChallengeResult();
//            return;
//        }
//    }
//}
