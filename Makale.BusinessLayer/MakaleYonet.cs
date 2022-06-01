using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Makale.DataAccessLayer;
using Makale.Entities;

namespace Makale.BusinessLayer
{
    public class MakaleYonet
    {
        private Repository<Not> repo_not = new Repository<Not>();

        BusinessLayerResult<Not> not_result = new BusinessLayerResult<Not>();

        public List<Not> MakaleGetir()
        {
            return repo_not.List();
        }

        public Not NotBul(int id)
        {
            return repo_not.Find(x => x.Id == id);
        }

        public BusinessLayerResult<Not> NotKaydet(Not not)
        {
            not_result.Sonuc = repo_not.Find(x => x.Baslik == not.Baslik && x.KategoriId == not.KategoriId);

                if(not_result.Sonuc!=null)
            {
                not_result.hata.Add("Bu makale kayıtlı.");
            }
                else
            {
                Not n = new Not();
                n.Kullanici = not.Kullanici;
                n.KategoriId = not.KategoriId;
                n.Baslik = not.Baslik;
                n.Icerik = not.Icerik;
                n.Taslak = not.Taslak;
                n.DegistirenKullanici = not.Kullanici.KullaniciAdi;

                int sonuc=repo_not.Insert(n);
                if(sonuc==0)
                {
                    not_result.hata.Add("Makale kaydedilemedi.");
                }
                else
                {
                    not_result.Sonuc = n;
                }

               
            }


            return not_result;
            
        }

        public void NotUpdate(Not not)
        {
            throw new NotImplementedException();
        }

        public void NotSil(int id)
        {
            throw new NotImplementedException();
        }
    }
}
