using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace CulinaryCrossroads1._1.Extensions
{
    public static class ClaimsPrincipalExtentions
    {
        public static string Id(this ClaimsPrincipal user)
        {
            return user.FindFirst(ClaimTypes.NameIdentifier).Value;
        }
    }
}
