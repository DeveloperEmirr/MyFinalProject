using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.Security.Hashing
{
   public class HashingHelper
    {
        //verdiğimiz şifreyi hash yapısına çeviricek metot out byte [] ile dışarıya verileri yollucaz
        public static void CreatePasswordHash(string password, out byte [] passwordHash, out byte[] passwordSalt)
        {
            //using içerisinde system güvenliğinde hangi parolama yapısını seçiceğimizi söledik
            using (var hmac= new System.Security.Cryptography.HMACSHA512())
            {
               
                passwordSalt = hmac.Key; //burda passwordsalt hmacde bulunan keyi alsın dedik
                passwordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
                //burada hash değerini alsın dedik ama neyin hash değeri gönderdiğmiz şifrenin hash değerini alacak
                //fakat bizim bunu byte çevirmemiz gerek stringi byte çevirirken; Encoding.UTF8.GetBytes() bunu kullaniliriz.
            }
        }

        //password hashi doğrulamak için bu metodu kullanıyoruz
        public static bool VerifyPasswordHash(string password, byte[] passwordHash, byte[] passwordSalt)
        {

 
            using (var hmac = new System.Security.Cryptography.HMACSHA512(passwordSalt))
            {
                //sisteme tekrardan girdiği parolayı yeniden hashleme işlemi yapıyoruz.
     
               var computedHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));

                //burada verdiğimiz şifrelerle veri tabanındaki hash karşılaştırıyor ve bize ona göre false true döndürüyor
                for (int i = 0; i < computedHash.Length; i++)
                {
                    if (computedHash[i]!=passwordHash[i])
                    {
                        return false;
                    }
                }
                return true;
            }

        }
    }
}
