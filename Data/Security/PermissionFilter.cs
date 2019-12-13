using System;
// using System.Threading.Tasks;
// using Microsoft.AspNetCore.Authorization;
// using Microsoft.AspNetCore.Mvc;
// using Microsoft.AspNetCore.Mvc.Filters;

namespace DynamicRoles.Security
{
    // public class PermissionFilter : Attribute, IAsyncAuthorizationFilter
    // {
    //     private readonly IAuthorizationService _authService;
    //     private readonly PermissionRequirement _requirement;

    //     public PermissionFilter(
    //         IAuthorizationService authService, 
    //         PermissionRequirement requirement)
    //     {
    //         //you can inject dependencies via DI            
    //         _authService = authService;

    //         //the requirement contains permissions you set in attribute above
    //         //for example: Permission.Foo, Permission.Bar
    //         _requirement = requirement;
    //     }

    //     public async Task OnAuthorizationAsync(AuthorizationFilterContext context)
    //     {
    //         var result = await _authService.AuthorizeAsync(
    //             context.HttpContext.User, null, _requirement);

    //         if (!result.Succeeded) context.Result = new ChallengeResult();
    //     }
    // }
}