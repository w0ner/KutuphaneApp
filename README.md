# Kütüphane Yönetim Uygulaması

Bu proje, C# .NET Core MVC 7 kullanılarak geliştirilmiş bir kütüphane yönetim uygulamasını içerir. Kütüphane personelinin kitapları yönetmelerine, kitap durumlarını izlemelerine ve ödünç vermelerine olanak tanır. Uygulama, katmanlı mimari kullanılarak tasarlanmıştır ve veritabanı işlemleri için Entity Framework, Code First kullanılmıştır.

## Teknolojiler ve Araçlar

- ASP.NET Core MVC 7: Web uygulamasının geliştirilmesi için kullanılmıştır.
- MSSQL Veritabanı: Veri depolama amacıyla kullanılmıştır.
- Entity Framework: Veritabanı işlemleri ve ORM işlemleri için kullanılmıştır.
- HTML5: Kullanıcı arayüzünün oluşturulmasında kullanılmıştır.
- Bootstrap: Arayüzün tasarımını geliştirmek için kullanılmıştır.
- jQuery Validation: Kullanıcı girişlerinin doğrulanması için kullanılmıştır.

## Özellikler

- Kitap ekleme 
- Kitap durumlarını görüntüleme (kütüphanedeki veya üyelerdeki)
- Kitap ödünç verme ve iade işlemleri
- Kütüphane üye yönetimi
- Admin paneli ile kolay kullanıcı ve kitap yönetimi

## Proje Yapısı

Proje katmanlı mimari prensiplerine uygun olarak tasarlanmıştır:

- **Kütüphane.Web:** ASP.NET Core MVC web uygulaması. Kullanıcı arayüzünü sunar.
- **Kütüphane.Core:** İş mantığı ve modellerin yer aldığı çekirdek kütüphane.
- **Kütüphane.Infrastructure:** Veritabanı erişim işlemleri için repository ve bağlantı yönetimini sağlar.

## Kurulum

1. Proje klasörünü bilgisayarınıza indirin.
2. Veritabanı bağlantı ayarlarını `appsettings.json` dosyasında yapılandırın.
3. Veritabanı .bak dosyasının kurulumunu yapınız.

