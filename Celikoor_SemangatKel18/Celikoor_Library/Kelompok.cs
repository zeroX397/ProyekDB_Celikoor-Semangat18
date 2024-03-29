﻿using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Celikoor_Library
{
    public class Kelompok
    {
        #region DATAMEMBERS
        private int id;
        private string nama;
        #endregion

        #region CONSTRUCTORS
        public Kelompok(int id, string nama)
        {
            Id = id;
            Nama = nama;
        }
        public Kelompok()
        {
            Id = 0;
            Nama = "";
        }
        #endregion

        #region PROPERTIES
        public int Id { get => id; set => id = value; }
        public string Nama { get => nama; set => nama = value; }
        #endregion

        #region METHODS
        public static void TambahData(Kelompok obj)
        {
            string sql = "INSERT INTO kelompoks " + "(nama) VALUES " + "('"
               +
                obj.nama + "');";
            Koneksi.JalankanPerintahNonQuery(sql);
        }
        public static List<Kelompok> BacaData(string filter = "", string nilai = "")
        {
            string perintah;
            if (filter == "")
            {
                perintah = "SELECT * from kelompoks";
            }
            else
            {
                perintah = "SELECT * from kelompoks " +
                    "where " + filter + " like '%" + nilai + "%'";
            }
            MySqlDataReader drHasil = Koneksi.JalankanPerintahSelect(perintah);
            List<Kelompok> listHasil = new List<Kelompok>();
            while (drHasil.Read() == true)//selama data reader masih ada isinya lakukan baca
            {
                Kelompok tampung = new Kelompok();
                tampung.Id = int.Parse(drHasil.GetValue(0).ToString());
                tampung.Nama = drHasil.GetValue(1).ToString();
                listHasil.Add(tampung);
            }
            return listHasil;
        }

        public static void UbahData(int id_kelompok, Kelompok obj)
        {
            string sql = "UPDATE kelompoks " +
                $"SET nama = '{obj.nama}' " +
                $"WHERE id = '{id_kelompok}';";
            Console.WriteLine(sql);
            Koneksi.JalankanPerintahNonQuery(sql);
        }

        public static void HapusData(string KodeHapus)
        {   //susun perintah query
            string perintah = "delete from kelompoks where id='" + KodeHapus + "';";

            Koneksi.JalankanPerintahNonQuery(perintah); //kirim ke command
        }
        #endregion
    }
}
