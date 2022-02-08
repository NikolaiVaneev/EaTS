using System.Security.Claims;

namespace EaTS.Models
{
    public class GetIdentityResponse
    {
      public  ClaimsIdentity claimsIdentity;
      public User user;
    }
}
