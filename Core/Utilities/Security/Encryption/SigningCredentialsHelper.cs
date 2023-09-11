using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.Security.Encryption
{
    public class SigningCredentialsHelper
    {
        // web apiden gelen json web token doğrulması için
        public static SigningCredentials CreateSigningCredentials( SecurityKey securityKey)
        {
            //securityKey anahtar olarak bunu kullan, güvenlik algoritmalarından SecurityAlgorithms.HmacSha512Signature bunu kullan dedik
            return new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha512Signature);
        }
    }
}
