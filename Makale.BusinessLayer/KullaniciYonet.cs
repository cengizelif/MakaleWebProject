using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Makale.Common;
using Makale.DataAccessLayer;
using Makale.Entities;

namespace Makale.BusinessLayer
{
    public class KullaniciYonet
    {
        private Repository<Kullanici> repo_kul = new Repository<Kullanici>();

        BusinessLayerResult<Kullanici> kul_sonuc = new BusinessLayerResult<Kullanici>();

        public BusinessLayerResult<Kullanici>  KullaniciKaydet(RegisterViewModel model)
        {
            //Kullanıcıadı ve eposta kontrolu
            //Kayıt işlemi
            //Aktivasyon maili gönder
           Kullanici kul= repo_kul.Find(x => x.KullaniciAdi == model.KullaniciAdi || x.Email == model.Email);
     
            if(kul!=null)
            {
                if(kul.KullaniciAdi==model.KullaniciAdi)
                {
                    kul_sonuc.hata.Add("Kullanıcı adı kayıtlı");
                }
                if(kul.Email==model.Email)
                {
                    kul_sonuc.hata.Add("Eposta adresi kayıtlı.");
                }
            }
            else
            {
                int sonuc = repo_kul.Insert(new Kullanici()  {  KullaniciAdi=model.KullaniciAdi,
                    Email=model.Email,
                    Sifre=model.Sifre,
                    AktifGuid=Guid.NewGuid(),
                    Aktif=false,
                    Admin=false
                });

                if(sonuc>0)
                {
                    kul_sonuc.Sonuc = repo_kul.Find(x => x.Email == model.Email && x.KullaniciAdi == model.KullaniciAdi);

                    string siteUrl = ConfigHelper.Get<string>("SiteRootUrl");

                    string activateURL = $"{siteUrl}/Home/UserActivate/{kul_sonuc.Sonuc.AktifGuid}";  

                    string body = $"Merhaba{kul_sonuc.Sonuc.Adi}{kul_sonuc.Sonuc.Soyadi} <br> Hesabınızı aktifleştirmek için, <a href='{activateURL}' target='_blank'> tıklayınız </a>";   //_blank :yeni sekmede aç
                    
                    
                    MailHelper.SendMail(body, kul_sonuc.Sonuc.Email, "Hesap Aktifleştirme");

                    //Aktivasyon maili gönderilecek
                }

            }

            return kul_sonuc;

        }
    
        public BusinessLayerResult<Kullanici> LoginKullanici(LoginViewModel model)
        {
            kul_sonuc.Sonuc = repo_kul.Find(x => x.KullaniciAdi == model.KullaniciAdi && x.Sifre == model.Sifre);

            if(kul_sonuc.Sonuc!=null)
            {
               if(!kul_sonuc.Sonuc.Aktif)
                {
                    kul_sonuc.hata.Add("Kullanıcı aktifleştirilmemiştir. Lütfen e-postanızı kontrol ediniz.");
                }
            }
            else
            {
                kul_sonuc.hata.Add("Kullanıcı adı ya da şifre uyuşmuyor.");
            }
            return kul_sonuc;

        }

        public BusinessLayerResult<Kullanici> ActivateUser(Guid aktifGuid)
        {
            kul_sonuc.Sonuc = repo_kul.Find(x => x.AktifGuid == aktifGuid);

            if(kul_sonuc.Sonuc!=null)
            {
                if(kul_sonuc.Sonuc.Aktif)
                {
                    kul_sonuc.hata.Add("Kullanıcı zaten aktif edilmiştir.");
                    return kul_sonuc;
                }

                kul_sonuc.Sonuc.Aktif = true;
                repo_kul.Update(kul_sonuc.Sonuc);
            }
            return kul_sonuc;

        }
    }
}
