using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.Security.JWT
{
    public class AccessToken
    { 
        //anlamsız karaktelerden oluşan bir anahtar değeridir.
        public string Token { get; set; }

        //Anahtar değerinin bitiş zamanını verdiğimiz değer : Expiration
        public DateTime Expiration { get; set; }
    }
}
