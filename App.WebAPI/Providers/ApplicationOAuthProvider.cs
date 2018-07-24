using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;


namespace App.WebAPI.Providers
{
    //public class ApplicationOAuthProvider : OAuthAuthorizationServerProvider
    //{
    //    private readonly string _publicClientId;

    //    public ApplicationOAuthProvider(string publicClientId)
    //    {
    //        if (publicClientId == null)
    //        {
    //            throw new ArgumentNullException("publicClientId");
    //        }

    //        _publicClientId = publicClientId;
    //    }

    //    public override async Task GrantResourceOwnerCredentials(OAuthGrantResourceOwnerCredentialsContext context)
    //    {
    //        //TeduShopAPIEntities db = new TeduShopAPIEntities();
    //        var userManager = context.OwinContext.GetUserManager<ApplicationUserManager>();

    //        //ApplicationUser user = await userManager.FindAsync(context.UserName, context.Password);
    //        //AppUsers user = await userManager.FindByNameAsync(context.UserName);
    //        var user = new AppUser()
    //        {
    //            UserName = context.UserName,
    //            PasswordHash = context.Password
    //        };
    //        //var user = db.AppUsers.SingleOrDefault(n => n.UserName == context.UserName);
    //        if (user == null)
    //        {
    //            context.SetError("invalid_grant", "The user name or password is incorrect.");
    //            return;
    //        }

    //        //ClaimsIdentity oAuthIdentity = await user.GenerateUserIdentityAsync(userManager,
    //        //   OAuthDefaults.AuthenticationType);
    //        //ClaimsIdentity cookiesIdentity = await user.GenerateUserIdentityAsync(userManager,
    //        //    CookieAuthenticationDefaults.AuthenticationType);

    //        //AuthenticationProperties properties = CreateProperties(user.UserName);
    //        //AuthenticationTicket ticket = new AuthenticationTicket(oAuthIdentity, properties);
    //        //context.Validated(ticket);
    //        //context.Request.Context.Authentication.SignIn(cookiesIdentity);


    //        var identity = new ClaimsIdentity(context.Options.AuthenticationType);

    //        //ClaimsIdentity identity = await user.GenerateUserIdentityAsync(userManager, DefaultAuthenticationTypes.ApplicationCookie);

    //        //string avatar = string.IsNullOrEmpty(user.Avatar) ? "" : user.Avatar;
    //        //string email = string.IsNullOrEmpty(user.Email) ? "" : user.Email;
    //        //identity.AddClaim(new Claim("fullName", user.FullName));
    //        //identity.AddClaim(new Claim("avatar", avatar));
    //        //identity.AddClaim(new Claim("email", email));
    //        identity.AddClaim(new Claim("username", user.UserName));
    //        identity.AddClaim(new Claim("password", user.PasswordHash));
    //        //identity.AddClaim(new Claim("roles", JsonConvert.SerializeObject(roles)));
    //        //identity.AddClaim(new Claim("permissions", JsonConvert.SerializeObject(permissionViewModels)));
    //        var props = new AuthenticationProperties(new Dictionary<string, string>
    //                {
    //                    //{"fullName", user.FullName},
    //                    //{"avatar", avatar },
    //                    //{"email", email},
    //                    {"username", user.UserName},
    //                    {"password", user.PasswordHash}
    //                    //{"permissions",JsonConvert.SerializeObject(permissionViewModels) },
    //                    //{"roles",JsonConvert.SerializeObject(roles) }

    //                });
    //        context.Validated(new AuthenticationTicket(identity, props));
    //    }

    //    public override Task TokenEndpoint(OAuthTokenEndpointContext context)
    //    {
    //        foreach (KeyValuePair<string, string> property in context.Properties.Dictionary)
    //        {
    //            context.AdditionalResponseParameters.Add(property.Key, property.Value);
    //        }

    //        return Task.FromResult<object>(null);
    //    }

    //    public override Task ValidateClientAuthentication(OAuthValidateClientAuthenticationContext context)
    //    {
    //        // Resource owner password credentials does not provide a client ID.
    //        if (context.ClientId == null)
    //        {
    //            context.Validated();
    //        }

    //        return Task.FromResult<object>(null);
    //    }

    //    public override Task ValidateClientRedirectUri(OAuthValidateClientRedirectUriContext context)
    //    {
    //        if (context.ClientId == _publicClientId)
    //        {
    //            Uri expectedRootUri = new Uri(context.Request.Uri, "/");

    //            if (expectedRootUri.AbsoluteUri == context.RedirectUri)
    //            {
    //                context.Validated();
    //            }
    //        }

    //        return Task.FromResult<object>(null);
    //    }

    //    public static AuthenticationProperties CreateProperties(string userName)
    //    {
    //        IDictionary<string, string> data = new Dictionary<string, string>
    //        {
    //            { "userName", userName }
    //        };
    //        return new AuthenticationProperties(data);
    //    }
    //}
}