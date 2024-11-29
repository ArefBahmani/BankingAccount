using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankingAccount.ConectionSQL
{
    public static class Configuration
    {
        public static string ConnectionString { get; set; }

        static Configuration()
        {
            ConnectionString = @"Data Source=DESKTOP-J6I42F2\SQLEXPRESS;Initial Catalog=Bank;User ID=SA;Password=123456;TrustServerCertificate=True;";
        }
    }
}
