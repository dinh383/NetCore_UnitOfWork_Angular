
using App.Service;
using App.WebAPI.Infrastructure.Core;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;

namespace App.WebAPI.Providers
{
    //public class AuthorizationServerProvider : OAuthAuthorizationServerProvider
    //{
    //    public AuthorizationServerProvider()
    //    {
    //    }
    //    public override async Task ValidateClientAuthentication(OAuthValidateClientAuthenticationContext context)
    //    {
    //        context.Validated();
    //        await Task.FromResult<object>(null);
    //    }

    //    public override async Task GrantResourceOwnerCredentials(OAuthGrantResourceOwnerCredentialsContext context)
    //    {
    //        DB_AppEntities db = new DB_AppEntities();

    //        UserManager<AppUser> userManager = context.OwinContext.GetUserManager<UserManager<AppUser>>();
    //        AppUser user;
    //        try
    //        {
    //            var passwordHash = new PasswordHashLib().Encrypt(string.Concat(context.UserName, context.Password));
    //            user = db.AppUsers.SingleOrDefault(n => n.UserName == context.UserName);
    //            if (user != null && passwordHash != user.PasswordHash)
    //            {
    //                user = null;
    //            }
    //        }
    //        catch (Exception ex)
    //        {
    //            // Could not retrieve the user due to error.
    //            context.SetError("server_error", "Lỗi trong quá trình xử lý.");
    //            context.Rejected();
    //            return;
    //        }
    //        if (user != null)
    //        {
    //            var actions = ServiceFactory.Get<IPermissionsService>().GetActionsForUser(context.UserName);
    //            //var permissions = ServiceFactory.Get<IPermissionService>().GetByUserId(user.Id);
    //            //var permissionViewModels = AutoMapper.Mapper.Map<ICollection<Permission>, ICollection<PermissionViewModel>>(permissions);
    //            //var roles = userManager.GetRoles(user.Id);

    //            //ClaimsIdentity identity = await userManager.CreateIdentityAsync(user, DefaultAuthenticationTypes.ExternalBearer);
    //            var identity = new ClaimsIdentity(context.Options.AuthenticationType);

    //            //ClaimsIdentity identity = await user.GenerateUserIdentityAsync(userManager, DefaultAuthenticationTypes.ApplicationCookie);

    //            //string avatar = string.IsNullOrEmpty(user.Avatar) ? "" : user.Avatar;
    //            //string email = string.IsNullOrEmpty(user.Email) ? "" : user.Email;
    //            //identity.AddClaim(new Claim("fullName", user.FullName));
    //            //identity.AddClaim(new Claim("avatar", avatar));
    //            identity.AddClaim(new Claim("email", "tung@gmail.com"));
    //            identity.AddClaim(new Claim("username", user.UserName));
    //            //identity.AddClaim(new Claim("password", user.PasswordHash));
    //            //identity.AddClaim(new Claim("roles", JsonConvert.SerializeObject(roles)));
    //            //identity.AddClaim(new Claim("permissions", JsonConvert.SerializeObject(permissionViewModels)));
    //            identity.AddClaim(new Claim("actions", JsonConvert.SerializeObject(actions)));
    //            var props = new AuthenticationProperties(new Dictionary<string, string>
    //                {
    //                    //{"fullName", user.FullName},
    //                    //{"avatar", avatar },
    //                    //{"email", email},
    //                    {"username", user.UserName},
    //                    //{"password", user.PasswordHash}
    //                    //{"permissions",JsonConvert.SerializeObject(permissionViewModels) },
    //                    //{"roles",JsonConvert.SerializeObject(roles) }
    //                    {"actions",JsonConvert.SerializeObject(actions) }

    //                });
    //            context.Validated(new AuthenticationTicket(identity, props));
    //        }
    //        else
    //        {
    //            context.SetError("invalid_grant", "Tài khoản hoặc mật khẩu không đúng.");
    //            context.Rejected();
    //        }
    //    }
    //    public override Task TokenEndpoint(OAuthTokenEndpointContext context)
    //    {
    //        foreach (KeyValuePair<string, string> property in context.Properties.Dictionary)
    //        {
    //            context.AdditionalResponseParameters.Add(property.Key, property.Value);
    //        }
    //        return Task.FromResult<object>(null);
    //    }

    //}
}