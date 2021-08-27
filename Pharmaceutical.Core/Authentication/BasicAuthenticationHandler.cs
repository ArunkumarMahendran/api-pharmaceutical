using Microsoft.AspNetCore.Authentication;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using CONS = Pharmaceutical.Common.Constants;
using System;
using System.Text.Encodings.Web;
using System.Threading.Tasks;
using ERRMSG = Pharmaceutical.Common.Constants;
using System.Net.Http.Headers;
using System.Text;
using System.Security.Claims;

namespace Pharmaceutical.Core.Authentication
{
    public class BasicAuthenticationHandler : AuthenticationHandler<AuthenticationSchemeOptions>
    {
        //As base class is required
        public BasicAuthenticationHandler(IOptionsMonitor<AuthenticationSchemeOptions> options,
                                          ILoggerFactory logger,
                                          UrlEncoder encoder,
                                          ISystemClock clock) : base(options, logger, encoder, clock)
        {

        }
        protected override async Task<AuthenticateResult> HandleAuthenticateAsync()
        {
            if (!Request.Headers.ContainsKey(CONS.Constant.Authorization))
                return AuthenticateResult.Fail(ERRMSG.ErrorMessage.AuthorizationNotFound);
            try
            {
                var authenticationHeaderValue = AuthenticationHeaderValue.Parse(Request.Headers[CONS.Constant.Authorization]);
                var headerAuthenticationBytes = Convert.FromBase64String(authenticationHeaderValue.Parameter);
                var credentials = Encoding.UTF8.GetString(headerAuthenticationBytes).Split(":");
                string userName = credentials[0];
                string password = credentials[1];

                AuthenticationTicket ticket;
                //We can check from DB using EF CORE User Identity table
                if (userName.Equals(CONS.Constant.UserNameDemo, StringComparison.CurrentCultureIgnoreCase) &&
                    password.Equals(CONS.Constant.UserNameDemoPassword, StringComparison.CurrentCultureIgnoreCase))
                {
                    ticket = AddClaims(new Claim(ClaimTypes.Role, CONS.Constant.Company));
                }
                else if (userName.Equals(CONS.Constant.UserNameContract1, StringComparison.CurrentCultureIgnoreCase) &&
                    password.Equals(CONS.Constant.UserNameContractPassword1, StringComparison.CurrentCultureIgnoreCase))
                {
                    ticket = AddClaims(new Claim(ClaimTypes.Role, CONS.Constant.Contract), new Claim(ClaimTypes.NameIdentifier, "101"));

                }
                else if (userName.Equals(CONS.Constant.UserNameContract2, StringComparison.CurrentCultureIgnoreCase) &&
                    password.Equals(CONS.Constant.UserNameContractPassword2, StringComparison.CurrentCultureIgnoreCase))
                {
                    ticket = AddClaims(new Claim(ClaimTypes.Role, CONS.Constant.Contract), new Claim(ClaimTypes.NameIdentifier, "102"));

                }
                else
                {
                    return AuthenticateResult.Fail(ERRMSG.ErrorMessage.UnAuthorization);
                }
                return AuthenticateResult.Success(ticket);
            }
            catch (Exception ex)
            {

                return AuthenticateResult.Fail(ERRMSG.ErrorMessage.AuthorizationException);
            }
        }

        private AuthenticationTicket AddClaims(params Claim[] claim)
        {
            var identity = new ClaimsIdentity(claim, Scheme.Name);
            var principle = new ClaimsPrincipal(identity);
            var ticket = new AuthenticationTicket(principle, Scheme.Name);
            return ticket;
        }
    }
}
