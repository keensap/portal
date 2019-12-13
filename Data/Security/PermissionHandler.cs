using System;
// using System.Security.Claims;
// using System.Security.Principal;
// using System.Threading.Tasks;
// using Microsoft.AspNetCore.Authorization;
// using System.Linq;

namespace DynamicRoles.Security
{
    // public class PermissionHandler : AuthorizationHandler<PermissionRequirement>
    // {
    //     // private readonly IUserPermissionsRepository permissionRepository;

    //     // public PermissionHandler(IUserPermissionsRepository permissionRepository)
    //     // {
    //     //     if (permissionRepository == null)
    //     //         throw new ArgumentNullException(nameof(permissionRepository));

    //     //     this.permissionRepository = permissionRepository;
    //     // }

    //     // protected override void Handle(AuthorizationContext context, PermissionRequirement requirement)
    //     // {
    //     //     if (context.User == null)
    //     //     {
    //     //         // no user authorizedd. Alternatively call context.Fail() to ensure a failure 
    //     //         // as another handler for this requirement may succeed
    //     //         return null;
    //     //     }

    //     //     bool hasPermission = permissionRepository.CheckPermissionForUser(context.User, requirement.Permission);
    //     //     if (hasPermission)
    //     //     {
    //     //         context.Succeed(requirement);
    //     //     }
    //     // }
    //     Entities.ApplicationDbContext _dbContext;

    //     public PermissionHandler()
    //     {
    //         _dbContext = new Entities.ApplicationDbContext();
    //     }

    //     protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, PermissionRequirement requirement)
    //     {
    //         if (context.User == null)
    //         {
    //             // no user authorizedd. Alternatively call context.Fail() to ensure a failure 
    //             // as another handler for this requirement may succeed
    //             return null;
    //         }
            
    //         bool hasPermission = CheckPermissionForUser(context.User, requirement.Entity, requirement.Action);
    //         if (hasPermission)
    //         {
    //             context.Succeed(requirement);
    //         }

    //         return Task.CompletedTask;
    //     }

    //     private bool CheckPermissionForUser(ClaimsPrincipal user, EntityEnum entity, ActionEnum action)
    //     {
    //         var userId = Int32.Parse(user.Identity.Name);
    //         var entityId = (int)entity;
    //         var actionId = (int)action;
    //         var exists = from p in _dbContext.Permissions
    //             join ur in _dbContext.UserRoles on p.role_id equals ur.role_id
    //             join ea in _dbContext.EntityActions on p.entity_action_id equals ea.id
    //             where ur.user_id == userId && ea.entity_id == entityId && ea.action_id == actionId
    //             select p;
    //         var per = exists.ToList();
    //         return  (per.Count() > 0);
    //     }
    // }
}