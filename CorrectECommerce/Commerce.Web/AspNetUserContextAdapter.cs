using Commerce.Domain;
using Microsoft.AspNetCore.Http;

namespace Commerce.Web
{
    public class AspNetUserContextAdapter : IUserContext
    {
        private static readonly HttpContextAccessor _accessor = new HttpContextAccessor();

        public bool IsInRole(Role role)
        {
            return _accessor.HttpContext.User.IsInRole(role.ToString());
        }
    }
}