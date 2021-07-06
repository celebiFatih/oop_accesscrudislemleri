using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.OleDb;

namespace kitaplık_test
{
    class Kitap_Vt
    {
        OleDbConnection baglanti = new OleDbConnection(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Users\Hstn\Desktop\Kitaplık.accdb");

        public List<Kitap> Liste()
        {
            List<Kitap> ktp = new List<Kitap>();
            baglanti.Open();
            OleDbCommand komut = new OleDbCommand("select * from Kitaplar", baglanti);
            OleDbDataReader dr = komut.ExecuteReader();
            while (dr.Read())
            {
                Kitap k = new Kitap();
                k.ID=Convert.ToInt32(dr[0]);
                k.ADI = dr[1].ToString();
                k.YAZAR= dr[2].ToString();

                ktp.Add(k);
            }
            baglanti.Close();
            return ktp;
        }

        public void kitapEkle(Kitap kt)
        {
            baglanti.Open();
            OleDbCommand komut = new OleDbCommand("insert into Kitaplar (KITAPAD,YAZAR) values (@p1,@p2)", baglanti);
            komut.Parameters.AddWithValue("@p1",kt.ADI);
            komut.Parameters.AddWithValue("@p2",kt.YAZAR);
            komut.ExecuteNonQuery();
            baglanti.Close();
            
        }
        public void kitapSil(Kitap kt)
        {
            baglanti.Open();
            OleDbCommand komut = new OleDbCommand("delete from Kitaplar where ID=@p1", baglanti);
            komut.Parameters.AddWithValue("@p1", kt.ID);
            komut.ExecuteNonQuery();
            baglanti.Close();
        }
        public void kitapGuncelle(Kitap kt)
        {
            baglanti.Open();
            OleDbCommand komut = new OleDbCommand("update Kitaplar set KITAPAD=@p1, YAZAR=@p2 where ID=@p3", baglanti);
            komut.Parameters.AddWithValue("@p1", kt.ADI);
            komut.Parameters.AddWithValue("@p2", kt.YAZAR);
            komut.Parameters.AddWithValue("@p3", kt.ID);
            komut.ExecuteNonQuery();
            baglanti.Close();
        }
    }
}
