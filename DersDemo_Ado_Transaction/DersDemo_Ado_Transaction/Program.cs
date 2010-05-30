using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Transactions;

namespace DersDemo_Ado_Transaction
{
    class Program
    {
        static void Main(string[] args)
        {
            // Transaction'ı oluşturuyoruz.
            using (TransactionScope ts = new TransactionScope())
            // bağlantıyı açıyoruz.
            using (SqlConnection sc = new SqlConnection(
                "Data Source=.; Initial Catalog=Store;" +
                "Integrated Security=true"))
            {
                // hataya karşı try bloğu başlatıyoruz.
                try
                {
                    SqlCommand scom = sc.CreateCommand();
                    scom.CommandText = "INSERT INTO TUser " +
                        "(UserName, Password) " +
                        "VALUES (@UserName, @Password);";

                    scom.Parameters.Add(
                        "@UserName",
                        System.Data.SqlDbType.NVarChar,
                        50,
                        "UserName");

                    scom.Parameters.Add(
                        "@Password",
                        System.Data.SqlDbType.NVarChar,
                        50,
                        "Password");

                    sc.Open();

                    // 1. Kişi
                    scom.Parameters["@UserName"].Value = "zzz";
                    scom.Parameters["@Password"].Value = "999";

                    scom.ExecuteNonQuery();

                    // 2. Kişi
                    scom.Parameters["@UserName"].Value = "yyy";
                    scom.Parameters["@Password"].Value = "888";

                    scom.ExecuteNonQuery();

                    throw new ApplicationException("Hata");

                    // 3. Kişi
                    scom.Parameters["@UserName"].Value = "xxx";
                    scom.Parameters["@Password"].Value = "777";

                    scom.ExecuteNonQuery();

                    ts.Complete();
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Hata : {0}", ex.Message);
                }
            }

        }
    }
}
