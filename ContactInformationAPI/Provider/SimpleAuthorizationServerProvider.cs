using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.Owin.Security;
using Microsoft.Owin.Security.OAuth;
using System.Web.Http.Cors;
using System.Security.Claims;
using System.Threading.Tasks;
using DataAccessLayer;

namespace ContactInformationAPI.Provider
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class SimpleAuthorizationServerProvider : OAuthAuthorizationServerProvider
    {
        public override async Task ValidateClientAuthentication(OAuthValidateClientAuthenticationContext context)
        {
            context.Validated(); 
        }

        public override async Task GrantResourceOwnerCredentials(OAuthGrantResourceOwnerCredentialsContext context)
        {
            var identity = new ClaimsIdentity(context.Options.AuthenticationType);
            context.OwinContext.Response.Headers.Add("Access-Control-Allow-Origin", new[] { "*" });

            var db = new ContactDBEntities();

            var user = db.user_info.FirstOrDefault(x=> x.user_name==context.UserName && x.password  == context.Password);
           
            if (user != null)
            {
                identity.AddClaim(new Claim("Age", "16"));

                var props = new AuthenticationProperties(new Dictionary<string, string>  
                            {  
                                {  
                                    "userdisplayname", context.UserName  
                                },  
                                {  
                                     "role", "admin"  
                                }  
                             });

                var ticket = new AuthenticationTicket(identity, props);
                context.Validated(ticket);
            }
            else
            {
                context.SetError("incorrect user credentials", "Provided username and password is incorrect");
                context.Rejected();
            }
        }
    }
 }


