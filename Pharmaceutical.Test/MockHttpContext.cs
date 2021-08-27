using Microsoft.AspNetCore.Http;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Pharmaceutical.Test
{
    public static class MockHttpContext
    {
        public static Mock<IHttpContextAccessor> GetHttpContext()
        {
            Mock<IHttpContextAccessor> mockHttpContextAccessor = new Mock<IHttpContextAccessor>();
            DefaultHttpContext context = new DefaultHttpContext();
            mockHttpContextAccessor.Setup(h => h.HttpContext.User).Returns(user);
            return mockHttpContextAccessor;

        }
        private static ClaimsPrincipal user = new ClaimsPrincipal(new ClaimsIdentity(new Claim[] { new Claim(ClaimTypes.Role, "COMPANY") }, "Basic"));
    }
}
