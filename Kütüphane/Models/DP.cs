using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Dapper;
using System.Data.SqlClient;
using System.Data;

namespace Kütüphane.Models
{
    public class DP
    {
        private static string connectionString = "Server=DESKTOP-9KURH7U\\SQLEXPRESS;Database=Kutuphane;Integrated Security=true;";
        public static void ExReturn(string procadi,DynamicParameters param=null)
        {
            using (SqlConnection baglanti = new SqlConnection(connectionString))
            {
                baglanti.Open();
                baglanti.Execute(procadi, param, commandType: CommandType.StoredProcedure);
            }
        }
        public static IEnumerable<T> ReturnList<T>(string procadi, DynamicParameters param = null)
        {
            //t clası temsil eder hangi tablo ile çalışacaksak o tablonun clasını t yerine dahil etmiş olur.
            //herhangi bir class tanımlaması yapıyoruz kolaylıık sağlar.
            using (SqlConnection baglanti = new SqlConnection(connectionString))
            {
                baglanti.Open();
                return baglanti.Query<T>(procadi, param, commandType: CommandType.StoredProcedure);
            }
        }
    }
}