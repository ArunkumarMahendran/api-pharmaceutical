using System.Linq;
using System.Security.Claims;
using Microsoft.AspNetCore.Http;

namespace Pharmaceutical.Common.Helper
{
    public static class ClaimsHelper
    {
        
        public static void FindUserType(IHttpContextAccessor httpContextAccessor,out int contractId)
        {
            var identity = (ClaimsIdentity)httpContextAccessor.HttpContext.User.Identity;            
            var claimValue = identity.Claims.FirstOrDefault(c => c.Type == "http://schemas.microsoft.com/ws/2008/06/identity/claims/role").Value;
            contractId = -1;
            if (claimValue == Constants.Constant.Company)
            {
                contractId = 0;
            }
            else if (claimValue == Constants.Constant.Contract)
            {
                int.TryParse(identity.Claims.FirstOrDefault(c => c.Type == "http://schemas.xmlsoap.org/ws/2005/05/identity/claims/nameidentifier").Value, out contractId);
            }
        }
    }
}
