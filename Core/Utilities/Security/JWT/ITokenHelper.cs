using Core.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.Security.JWT
{
   public interface ITokenHelper
    {
        //kullanıcı sisteme başarılı bir şekilde giriş yapınca  user kyullanıcı için veri tabanına gidicek
        //ve bu kullanıcı için OperationClaim veri tabanına gidecek ve orada json.web.token üretip onları buraya verecek
        AccessToken CreateToken(User user, List<OperationClaim> operationClaims);
    }
}
