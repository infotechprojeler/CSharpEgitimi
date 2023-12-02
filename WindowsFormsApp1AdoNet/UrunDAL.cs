using System;
using System.Collections.Generic;
using System.Linq;
using System.Data; // veritabanı işlemleri kütüphanesi
using System.Data.SqlClient; // veritabanı işlemleri kütüphanesi

namespace WindowsFormsApp1AdoNet
{
    internal class UrunDAL // Data Access Layer : Veri erişim katmanı
    {
        SqlConnection connection = new SqlConnection(@"server=(localdb)\MSSQLLocalDB; database=AdoNetDb; trusted_connection=true;"); // sql server a bağlanmamızı sağlayacak nesne

        void BaglantiyiAc()
        {
            if (connection.State == ConnectionState.Closed) // eğer yukardaki bağlantı kapalıysa 
            {
                connection.Open(); // bağlantıyı aç
            }
        }

        public List<Urun> UrunleriGetir()
        {
            List<Urun> urunler = new List<Urun>(); // boş liste oluştur
            BaglantiyiAc(); // db bağlantısını aç
            SqlCommand sqlCommand = new SqlCommand("select * from Urunler", connection); // sql komutu yazabilmemizi sağlayan araç
            SqlDataReader reader = sqlCommand.ExecuteReader(); // sqlCommand ile gelecek olan veriyi SqlDataReader nesnesi ile okuyoruz. ExecuteReader metodu ise sorguyu sql de çalıştırabilmemizi sağlar.
            while (reader.Read()) // while döngüsü ile reader nesnesine bulunan veriyi read metoduyla okuyoruz.
            {
                // veritabanından gelen her ürün için aşağıda bir nesne oluşturup gelen veriyi bu nesneye yüklüyoruz
                Urun urun = new Urun()
                {
                    Id = Convert.ToInt32(reader["Id"]),
                    Name = Convert.ToString(reader["Name"]),
                    Description = Convert.ToString(reader["Description"]),
                    Price = Convert.ToDecimal(reader["Price"])
                };
                urunler.Add(urun); // üstte db den okuduğumuz ürünü listeye ekliyoruz
            }
            reader.Close(); // liste hazırlandıktan sonra okuyucuyu kapat
            sqlCommand.Dispose(); // sql komutunu kapat
            connection.Close();  // sql bağlantısını kapat
            return urunler;     // listeyi metodun çağrılacağı yere gönder
        }

        public DataTable UrunleriDatatableileGetir()
        {
            DataTable table = new DataTable(); // boş bir datatable oluştur
            BaglantiyiAc();
            SqlCommand sqlCommand = new SqlCommand("select * from Urunler", connection); // sql komutumuzu çalıştırdık
            SqlDataReader reader = sqlCommand.ExecuteReader(); // sql komutundan gelen datayı okuduk
            table.Load(reader); // yukardaki boş tabloya okunan datayı yükledik
            reader.Close();
            sqlCommand.Dispose();
            table.Dispose();
            connection.Close();
            return table;
        }
        public DataTable UrunleriDatatableileGetir(string kelime)
        {
            DataTable table = new DataTable(); // boş bir datatable oluştur
            BaglantiyiAc();
            SqlCommand sqlCommand = new SqlCommand("select * from Urunler where Name like @kelime", connection); // sql komutumuzu çalıştırdık
            sqlCommand.Parameters.AddWithValue("@kelime", "%" + kelime + "%");
            SqlDataReader reader = sqlCommand.ExecuteReader(); // sql komutundan gelen datayı okuduk
            table.Load(reader); // yukardaki boş tabloya okunan datayı yükledik
            reader.Close();
            sqlCommand.Dispose();
            table.Dispose();
            connection.Close();
            return table;
        }

        public int Add(Urun urun) // bu metot dışarıdan bir urun nesnesi alacak
        {
            BaglantiyiAc();
            int islemSonucu = 0; // işlem sonunda db ye eklenirse geriye bu degisken üzerinden sonucu döndüreceğiz
            SqlCommand sqlCommand = new SqlCommand("insert into Urunler (Name, Description, Price, Stock) values (@Name, @Description, @Price, @Stock)", connection); // kayıt ekleme komutlarımız
            sqlCommand.Parameters.AddWithValue("@Name", urun.Name);
            sqlCommand.Parameters.AddWithValue("@Description", urun.Description);
            sqlCommand.Parameters.AddWithValue("@Price", urun.Price);
            sqlCommand.Parameters.AddWithValue("@Stock", urun.Stock);
            islemSonucu = sqlCommand.ExecuteNonQuery(); // ExecuteNonQuery metodu ado netten gelir ve yazdığımız sql insert komutunu çalıştırır geriye ise sql de etkilenen kayıt sayısını döndürür
            sqlCommand.Dispose();
            connection.Close();
            return islemSonucu;
        }
        public int Update(Urun urun) // bu metot dışarıdan bir urun nesnesi alacak
        {
            BaglantiyiAc();
            int islemSonucu = 0; // işlem sonunda db ye eklenirse geriye bu degisken üzerinden sonucu döndüreceğiz
            SqlCommand sqlCommand = new SqlCommand("update Urunler set Name=@Name, Description=@Description, Price=@Price, Stock=@Stock where Id=@UrunId", connection); // kayıt ekleme komutlarımız
            sqlCommand.Parameters.AddWithValue("@UrunId", urun.Id); // burası çokomelli!!!
            sqlCommand.Parameters.AddWithValue("@Name", urun.Name);
            sqlCommand.Parameters.AddWithValue("@Description", urun.Description);
            sqlCommand.Parameters.AddWithValue("@Price", urun.Price);
            sqlCommand.Parameters.AddWithValue("@Stock", urun.Stock);
            islemSonucu = sqlCommand.ExecuteNonQuery(); // ExecuteNonQuery metodu ado netten gelir ve yazdığımız sql insert komutunu çalıştırır geriye ise sql de etkilenen kayıt sayısını döndürür
            sqlCommand.Dispose();
            connection.Close();
            return islemSonucu;
        }
        public int Delete(int id) // bu metot dışarıdan bir urun nesnesi alacak
        {
            BaglantiyiAc();
            int islemSonucu = 0; // işlem sonunda db ye eklenirse geriye bu degisken üzerinden sonucu döndüreceğiz
            SqlCommand sqlCommand = new SqlCommand("delete from Urunler where Id=@UrunId", connection); // kayıt ekleme komutlarımız
            sqlCommand.Parameters.AddWithValue("@UrunId", id); // burası çokomelli!!!
            islemSonucu = sqlCommand.ExecuteNonQuery(); // ExecuteNonQuery metodu ado netten gelir ve yazdığımız sql insert komutunu çalıştırır geriye ise sql de etkilenen kayıt sayısını döndürür
            sqlCommand.Dispose();
            connection.Close();
            return islemSonucu;
        }
        public Urun UrunGetir(int id)
        {
            Urun urun = new Urun();
            BaglantiyiAc();
            SqlCommand sqlCommand = new SqlCommand("select * from Urunler where Id=@UrunId", connection);
            sqlCommand.Parameters.AddWithValue("@UrunId", id);
            SqlDataReader reader = sqlCommand.ExecuteReader();
            if (reader.Read())
            {
                urun.Id = Convert.ToInt32(reader["Id"]);
                urun.Name = Convert.ToString(reader["Name"]);
                urun.Description = Convert.ToString(reader["Description"]);
                urun.Price = Convert.ToDecimal(reader["Price"]);
                urun.Stock = Convert.ToInt32(reader["Stock"]);
            }
            reader.Close();
            sqlCommand.Dispose();
            connection.Close();
            return urun;
        }
    }
}
