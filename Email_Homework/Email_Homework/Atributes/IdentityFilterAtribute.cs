using Email_Domen.Entity.Enum;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Security.Claims;
using System.Text.Json;

namespace Email_Homework.Atributes
{
    [AttributeUsage(AttributeTargets.Enum | AttributeTargets.Method | AttributeTargets.Class)]
    public class IdentityFilterAtribute : Attribute, IAuthorizationFilter
    {
        private readonly int _permissionId;
        public IdentityFilterAtribute(Permission permission)
        {
            _permissionId = (int)permission;
        }

        public void OnAuthorization(AuthorizationFilterContext context)
        {

            var identity = context.HttpContext.User.Identity as ClaimsIdentity;

            var permissionsId = identity.FindFirst("Permissions")?.Value;

            var result = JsonSerializer.Deserialize<List<int>>(permissionsId).Any(x => _permissionId == x);

            if (!result)
            {
                context.Result = new ForbidResult();
                return;
            }
        }
    }
}
