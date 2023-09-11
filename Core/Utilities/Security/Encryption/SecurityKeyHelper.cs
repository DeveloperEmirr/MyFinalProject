using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.Security.Encryption
{
    public class SecurityKeyHelper
    {
        //SecurityKey bunun gelmesi için lambadan using system.identitymodel.tokens diyyerek ekleme işlemi yaptık
        public static SecurityKey CreateSecurityKey(string securitykey)
        {
            //stringi byte haline getirdik
            return new SymmetricSecurityKey(Encoding.UTF8.GetBytes(securitykey));
        }

    }
}
