﻿using Microsoft.AspNetCore.Authorization;

namespace Api.Configurations.Policies
{
    public class OnlySuperAdminChecker : AuthorizationHandler<OnlySuperAdminChecker>, IAuthorizationRequirement
    {
        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, OnlySuperAdminChecker requirement)
        {
            if (context.User.IsInRole("SuperAdmin"))
            {
                context.Succeed(requirement);
                return Task.CompletedTask;
            }
            return Task.CompletedTask;
        }
    }
}