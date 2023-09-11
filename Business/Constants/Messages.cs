using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Business.Constants
{
    public static class Messages //sabit mesajlar için açtık 
    {
        public static string ProductAdded = "Ürün Eklendi";
        public static string ProductNameInvalid = "Ürün İsmi Geçersiz!";
        public static string MaintenanceTime = "Bakım Zamanı";
        public static string ProductListed = "Ürünler Listelendi";

        public static string ProductCountOfCategoryError = "Kategorideki Ürün Listesi 10 dan Fazla...";
        public static string AuthorizationDenied = "Yetkiniz yok.";
        public static string UserRegistered= "Kayıt olundu";

        public static string UserNotFound = "Kullanıcı bulunamadı";
        public static string PasswordError = "Parola hatası";

        public static string SuccessfulLogin = "Başarılı giriş";
        public static string UserAlreadyExists = "Kullanıcı mevcut";
        public static string AccessTokenCreated = "Token oluşturuldu";
    }
}
