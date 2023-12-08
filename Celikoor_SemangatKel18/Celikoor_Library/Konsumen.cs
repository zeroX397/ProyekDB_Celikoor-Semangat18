﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace Celikoor_Library
{
    public class Konsumen
    {
        #region Data Members
        private int id_Konsumen;
        private string nama_Konsumen;
        private string email_Konsumen;
        private string noHP_Konsumen;
        private string gender_Konsumen;
        private DateTime ttl_Konsumen;
        private double saldo_Konsumen;
        private string username_Konsumen;
        private string password_Konsumen;
        #endregion

        #region Constructors
        public Konsumen(int id_Konsumen, string nama_Konsumen, string email_Konsumen, string noHP_Konsumen, string gender_Konsumen, 
            DateTime ttl_Konsumen, double saldo_Konsumen, string username_Konsumen, string password_Konsumen)
        {
            Id_Konsumen = id_Konsumen;
            Nama_Konsumen = nama_Konsumen;
            Email_Konsumen = email_Konsumen;
            NoHP_Konsumen = noHP_Konsumen;
            Gender_Konsumen = gender_Konsumen;
            Ttl_Konsumen = ttl_Konsumen;
            Saldo_Konsumen = saldo_Konsumen;
            Username_Konsumen = username_Konsumen;
            Password_Konsumen = password_Konsumen;
        }
        public Konsumen()
        {
            Id_Konsumen = 0;
            Nama_Konsumen = "";
            Email_Konsumen = "";
            NoHP_Konsumen = "";
            Gender_Konsumen = "";
            Ttl_Konsumen = DateTime.Now;
            Saldo_Konsumen = 0;
            Username_Konsumen = "";
            Password_Konsumen = "";
        }

        public Konsumen(int v1, string v2, string v3, string v4, string v5, object p)
        {
            V1 = v1;
            V2 = v2;
            V3 = v3;
            V4 = v4;
            V5 = v5;
            P = p;
        }
        #endregion

        #region Properties
        public int Id_Konsumen { get => id_Konsumen; set => id_Konsumen = value; }
        public string Nama_Konsumen { get => nama_Konsumen; set => nama_Konsumen = value; }
        public string Email_Konsumen { get => email_Konsumen; set => email_Konsumen = value; }
        public string NoHP_Konsumen { get => noHP_Konsumen; set => noHP_Konsumen = value; }
        public string Gender_Konsumen { get => gender_Konsumen; set => gender_Konsumen = value; }
        public DateTime Ttl_Konsumen { get => ttl_Konsumen; set => ttl_Konsumen = value; }
        public double Saldo_Konsumen { get => saldo_Konsumen; set => saldo_Konsumen = value; }
        public string Username_Konsumen { get => username_Konsumen; set => username_Konsumen = value; }
        public string Password_Konsumen { get => password_Konsumen; set => password_Konsumen = value; }
        public int V1 { get; }
        public string V2 { get; }
        public string V3 { get; }
        public string V4 { get; }
        public string V5 { get; }
        public object P { get; }
        #endregion

        #region METHODS
        public static void TambahData(Konsumen obj)
        {
            string sql = "INSERT INTO konsumens(nama, email, no_hp, gender, tgl_lahir, saldo, username, password) " + 
                "VALUES("+
                "'" + obj.Nama_Konsumen + "'," +
                "'" + obj.Email_Konsumen + "'," +
                "'" + obj.NoHP_Konsumen+ "'," +
                "'" + obj.Gender_Konsumen + "'," +
                "'" + obj.Ttl_Konsumen.ToString("yyyy-MM-dd") + "'," +
                "'" + obj.Saldo_Konsumen + "'," +
                "'" + obj.Username_Konsumen + "'," +
                "'" + obj.Password_Konsumen + "');";
            Koneksi.JalankanPerintahNonQuery(sql);
        }
        public static Admin CekLogin(string username, string password)
        {
<<<<<<< Updated upstream
            string sql = "SELECT * FROM konsumens;";

            Koneksi.JalankanPerintahSelect(sql);
=======
            // Password tidak diambil karena tidak perlu menyimpan password pada obyek pembeli untuk alasan keamanan
            string sql = "SELECT nama, email, no_HP,Gender,Ttl, saldo username" +
                " FROM konsumens " +
                " WHERE username='" + username + "' AND password='" + password + "';";

            MySqlDataReader result = Koneksi.JalankanPerintahSelect(sql);

            Konsumen tmp = new Konsumen();
            //if (result.Read())
            //{
            //    userRole tmpRole;
            //    if (result.GetString("role").CompareTo("PENJUAL") == 0)
            //    {
            //        tmpRole = userRole.PEGAWAI;
            //    }
            //    else
            //    {
            //        tmpRole = userRole.KONSUMEN;
            //    }

            //    tmp = new Admin(
            //        result.GetInt32("email"),
            //        result.GetString("nama"),
            //        result.GetString("username"),
            //        "",
            //        result.GetString("password"),
            //        tmpRole);

            //    return tmp;
            //}
            return null;
        }

        public static List<Admin> BacaData(string kriteria, string nilaiKriteria)
        {
            string sql = "SELECT nama, email, no_HP,Gender,Ttl, saldo username" +
                " FROM konsumens " 
            if (kriteria == "")
            {
                sql += ";";
            }
            else
            {
                sql += " WHERE " + kriteria + " LIKE '%" + nilaiKriteria + "%';";
            }
            MySqlDataReader result = Koneksi.JalankanPerintahSelect(sql);
            List<Admin> userList = new List<Admin>();
            while (result.Read())
            {
                Konsumen tmp = new Konsumen(result.GetInt32("id"),
                    result.GetString("nama"),
                    result.GetString("username"),
                    "", result.GetString("alamat"),
                    //(result.GetString("role") == "KONSUMEN" ? userRole.KONSUMEN : userRole.PEGAWAI));

                //userList.Add(tmp);
            }
            return userList;
>>>>>>> Stashed changes
        }
        public static void UbahData(Konsumen obj)
        {   //password tdk boleh diubah melalui method ini
            string perintah = "UPDATE konsumens SET " +
                    "Nama='" + obj.Nama_Konsumen + "', " +
                    "email='" + obj.Email_Konsumen + "', " +
                    "no_hp='" + obj.NoHP_Konsumen + "', " +
                    "gender='" + obj.Gender_Konsumen + "', " +
                    "tgl_lahir='" + obj.Ttl_Konsumen + "', " +
                    "saldo='" + obj.Saldo_Konsumen + "' " +
                    "username='" + obj.Username_Konsumen + "' " +
                    "password='" + obj.Password_Konsumen + "')";

            Koneksi.JalankanPerintahNonQuery(perintah);
        }
        #endregion

    }
}
}
