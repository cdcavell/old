using CDCavell.ClassLibrary.Web.Identity.Models;
using CDCavell.ClassLibrary.Web.Mvc.Models.AppSettings;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace as_api_cdcavell.Data
{
    /// <summary>
    /// Authorization Service Database Initializer
    /// </summary>
    /// <revision>
    /// __Revisions:__~~
    /// | Contributor | Build | Revison Date | Description |~
    /// |-------------|-------|--------------|-------------|~
    /// | Christopher D. Cavell | 1.0.3.0 | 01/21/2021 | Initial build Authorization Service |~ 
    /// | Christopher D. Cavell | 1.0.3.3 | 03/09/2021 | User Authorization Service |~ 
    /// | Christopher D. Cavell | 1.0.4.2 | 03/16/2021 | Email verification |~ 
    /// | Christopher D. Cavell | 1.1.0.0 | 03/23/2021 | Integrate ASP.NET Core Identity |~ 
    /// | Christopher D. Cavell | 1.1.1.0 | 04/11/2021 | Permission-Based Authorization |~ 
    /// </revision>
    public static class DbInitializer
    {
        /// <summary>
        /// Initialize method
        /// &lt;br /&gt;
        /// To Initialize: dotnet ef migrations add InitialCreate
        /// &lt;br /&gt;
        /// To Update:     dotnet ef migrations add UpdateDatabase_&lt;&lt;YYYY-MM-DD&gt;&gt;
        /// &lt;br /&gt;&lt;br /&gt;
        /// EF Core tools reference: https://docs.microsoft.com/en-us/ef/core/cli/dotnet
        /// &lt;br /&gt;
        /// Install EF Core Tools: dotnet tool install --global dotnet-ef
        /// &lt;br /&gt;
        /// Upgrade EF Core Tools: dotnet tool update --global dotnet-ef
        /// &lt;br /&gt;&lt;br /&gt;
        /// _Before you can use the tools on a specific project, you'll need to add the `Microsoft.EntityFrameworkCore.Design` package to it._
        /// </summary>
        /// <param name="context">AuthorizationServiceDbContext</param>
        /// <param name="siteAdministrator">SiteAdministrator</param>
        /// <method>Initialize(MigrateDdContext context)</method>
        public static void Initialize(AuthorizationServiceDbContext context, SiteAdministrator siteAdministrator)
        {
            IEnumerable<string> pending = context.Database.GetPendingMigrations();
            if (pending.Any())
                context.Database.Migrate();

            if (!context.Roles.Any())
            {
                var role = new ApplicationRole();
                role.Name = "SysAdmin";
                role.NormalizedName = role.Name.ToUpper();

                context.Roles.Add(role);
                context.SaveChanges();

                var roleClaim = new ApplicationRoleClaim();
                roleClaim.RoleId = role.Id;
                roleClaim.ClaimType = "SysAdmin";
                roleClaim.ClaimValue = "Active";

                role.RoleClaims.Add(roleClaim);

                context.Roles.Update(role);
                context.SaveChanges();

                role = new ApplicationRole();
                role.Name = "Admin";
                role.NormalizedName = role.Name.ToUpper();

                context.Roles.Add(role);
                context.SaveChanges();

                roleClaim = new ApplicationRoleClaim();
                roleClaim.RoleId = role.Id;
                roleClaim.ClaimType = "View";
                roleClaim.ClaimValue = "Active";

                role.RoleClaims.Add(roleClaim);

                roleClaim = new ApplicationRoleClaim();
                roleClaim.RoleId = role.Id;
                roleClaim.ClaimType = "Edit";
                roleClaim.ClaimValue = "Active";

                role.RoleClaims.Add(roleClaim);

                roleClaim = new ApplicationRoleClaim();
                roleClaim.RoleId = role.Id;
                roleClaim.ClaimType = "Remove";
                roleClaim.ClaimValue = "Active";

                role.RoleClaims.Add(roleClaim);

                roleClaim = new ApplicationRoleClaim();
                roleClaim.RoleId = role.Id;
                roleClaim.ClaimType = "Approve";
                roleClaim.ClaimValue = "Active";

                role.RoleClaims.Add(roleClaim);

                context.Roles.Update(role);
                context.SaveChanges();

                role = new ApplicationRole();
                role.Name = "User";
                role.NormalizedName = role.Name.ToUpper();

                context.Roles.Add(role);
                context.SaveChanges();

                roleClaim = new ApplicationRoleClaim();
                roleClaim.RoleId = role.Id;
                roleClaim.ClaimType = "View";
                roleClaim.ClaimValue = "Active";

                role.RoleClaims.Add(roleClaim);

                roleClaim = new ApplicationRoleClaim();
                roleClaim.RoleId = role.Id;
                roleClaim.ClaimType = "Edit";
                roleClaim.ClaimValue = "Active";

                role.RoleClaims.Add(roleClaim);

                roleClaim = new ApplicationRoleClaim();
                roleClaim.RoleId = role.Id;
                roleClaim.ClaimType = "Remove";
                roleClaim.ClaimValue = "Active";

                role.RoleClaims.Add(roleClaim);

                context.Roles.Update(role);
                context.SaveChanges();
            }

            if (!context.Users.Any())
            {
                var role = context.Roles.Include("RoleClaims")
                    .Where(x => x.NormalizedName == "SYSADMIN")
                    .FirstOrDefault();

                if (role != null)
                {
                    var roleClaim = role.RoleClaims
                        .Where(x => x.NormalizedClaimType == "SYSADMIN")
                        .Where(x => x.NormalizedClaimValue == "ACTIVE")
                        .FirstOrDefault();

                    if (roleClaim != null)
                    {
                        var user = new ApplicationUser();
                        user.Email = siteAdministrator.Email;
                        user.NormalizedEmail = user.Email.ToUpper();
                        user.EmailConfirmed = true;
                        user.UserName = user.Email;
                        user.NormalizedUserName = user.UserName.ToUpper();
                        user.FirstName = siteAdministrator.FirstName;
                        user.LastName = siteAdministrator.LastName;
                        user.RequestDate = DateTime.Now;
                        user.ApprovedDate = DateTime.Now;
                        user.RoleClaims.Add(new AspNetUserRoleClaim()
                        {
                            User = user,
                            Role = role,
                            RoleClaim = roleClaim,
                            Status = AspNetUserRoleClaim.RoleClaimStatus.Approved
                        });

                        context.Add(user);
                        context.SaveChanges();

                        user.ApprovedById = user.Id;
                        foreach (AspNetUserRoleClaim userRoleClaim in user.RoleClaims)
                            userRoleClaim.History.Add(new AspNetUserRoleClaimHistory()
                            {
                                UserRoleClaimId = userRoleClaim.Id,
                                ActionOn = DateTime.Now,
                                ActionById = user.Id,
                                Status = userRoleClaim.Status
                            });

                        context.Update(user);
                        context.SaveChanges();
                    }
                }
            }
        }
    }
}
