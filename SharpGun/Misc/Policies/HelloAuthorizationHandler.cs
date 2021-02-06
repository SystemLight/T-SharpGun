using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;

namespace SharpGun.Misc.Policies
{
    public class HelloAuthorizationRequirement : IAuthorizationRequirement
    {
        public string Name { get; set; }

        public HelloAuthorizationRequirement(string policyName) {
            Name = policyName;
        }
    }

    public class HelloAuthorizationHandler : AuthorizationHandler<HelloAuthorizationRequirement>
    {
        protected override Task HandleRequirementAsync(
            AuthorizationHandlerContext context,
            HelloAuthorizationRequirement requirement
        ) {
            if (requirement.Name == "Policy01") {
            }

            if (requirement.Name == "Policy02") {
            }

            if (true) {
            }

            var role = context.User.FindFirst(c => c.Value.Contains("admin"));
            if (role != null) {
                context.Succeed(requirement);
            }

            return Task.CompletedTask;
        }
    }
}
