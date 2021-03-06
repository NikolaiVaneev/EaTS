using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace EaTS.Service
{
    public class AuthOptions
    {
        public const string ISSUER = "EaTSServer"; // издатель токена
        public const string AUDIENCE = "EaTSClient"; // потребитель токена
        const string KEY = "@yJsf8vbX*Z6V&T+";   // ключ для шифрации
        public const int LIFETIME = 5; 
        public static SymmetricSecurityKey GetSymmetricSecurityKey()
        {
            return new SymmetricSecurityKey(Encoding.ASCII.GetBytes(KEY));
        }
    }
}
