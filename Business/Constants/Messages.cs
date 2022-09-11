using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Business.Constants
{
    public static class Messages
    {
        //Success CarService Messages
        public static string CarAdded = "Araç Eklendi.";
        public static string CarUpdated = "Araç Güncellendi.";
        public static string CarDeleted = "Araç Silindi.";
        public static string CarGetById = "Araç Id'ye göre getirildi.";



        public static string CarGetByBrandId = "Araçlar Model Id'ye göre getirildi.";
        public static string CarGetByColorId = "Araçlar Color Id'ye göre getirildi.";
        public static string CarGetCarDetails = "Araç Detayları getirildi.";
        public static string CarsGetAll = "Tüm Araçlar listelendi.";

        //Success BrandService Messages
        public static string BrandAdded = "Marka Eklendi.";
        public static string BrandDeleted = "Marka Silindi.";
        public static string BrandUpdated = "Marka Güncellendi.";
        public static string BrandsGetAll = "Markalar Listelendi.";
        public static string BrandGetById = "Marka Id'ye göre getirildi.";

        //Success UserService Messages
        public static string UserListed = "Kullanıcılar listelendi.";
        public static string UserAdded = "Kullanıcı Eklendi.";
        public static string UserUpdated = "Kullanıcı Güncellendi";
        public static string UsersGetAll = "Kullanıcılar listelendi.";
        public static string UserGetById = "Kullanıcı Id'ye göre getirildi.";

        //Success CustomerService Messages
        public static string CustomerAdded = ("Müşteri Eklendi.");
        public static string CustomerDeleted = ("Müşteri Silindi.");
        public static string CustomerUpdated = ("Müşteri Güncellendi.");
        public static string CustomerGetAll = ("Müşteriler Listelendi.");
        public static string CustomerGetById = ("Müşteri Id'ye göre getirildi.");
        public static string CustomerGetByUserId = ("Müşteri UserId'ye göre getirildi.");

        //Success CarImageService Messages
        public static string CarImageDeleted = "Resim Silindi.";
        public static string CarImageAdded = "Resim Eklendi.";
        public static string CarImageUpdated = "Resim Güncellendi.";
        public static string CarImagesListed = "Resimler Listelendi.";
        public static string CarImageLimitExceded = "Resim Yükleme Limiti Aşıldı.";

        public static string BrandAlreadyExist = "Marka Mevcut.";
        public static string UserNotFound = "Kullanıcı Bulunamadı.";

        public static string PasswordError = "Parola Hatası.";
        public static string SuccessfulLogin = "Giriş Başarılı.";
        public static string UserAlreadyExists = "Kullanıcı Mevcut.";
        public static string AccessTokenCreated = "Access Token Created.";

        public static string AuthorizationDenied = "Yetkiniz Yok";

        public static string CarSelectionErrorForCarImages = "Lütfen Araba Seçiniz.";

        public static string UserRegistered = "Kullanıcı Kaydedildi.";

        public static string PasswordNotContainMustCharacters =
            "Parolanız en az bir büyük harf, bir küçük harf ve bir rakam içermelidir.";

        public static string ColorExist = "Renk Zaten Mevcut.";

        public static string CustomerAlreadyExist = "Müşteri Zaten Mevcut.";
        public static string NotSuitableForRentalCar = "Araç Kiralamaya Uygun Değil.";
        public static string CarRented = "Araç Kiralandı.";

        public static string RentalDetailsListed = "Kiralama Detayları Listelendi.";
    }
}
