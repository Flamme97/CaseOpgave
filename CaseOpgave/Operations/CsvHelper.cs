using CaseOpgave.models;
using CsvHelper;
using CsvHelper.Configuration;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace CaseOpgave.Operations
{
    static class CsvHelpers
    {
        public static CsvConfiguration Config()
        {

            var config = new CsvConfiguration(CultureInfo.InvariantCulture)
            {
                HasHeaderRecord = false,
                MissingFieldFound = null
            };
            return config;
        }

        public static List<CurrentUser> ParseCurrentUser()
        {
            CsvConfiguration config = Config();

            using (var reader = new StreamReader(@"C:\Users\olive\source\repos\Case\CaseOpgave\CaseOpgave\Resources\CurrentUserSession.txt"))
            using (var csv = new CsvReader(reader, config))
            {
                var records = csv.GetRecords<CurrentUser>();
                return records.ToList();
            }
        }
        public static List<Product> ParseProduct()
        {
            CsvConfiguration config = Config();

            using (var reader = new StreamReader(@"C:\Users\olive\source\repos\Case\CaseOpgave\CaseOpgave\Resources\Products.txt"))
            using (var csv = new CsvReader(reader, config))
            {
                var records = csv.GetRecords<Product>();
                return records.ToList();
            }
        }
        public static List<User> ParseUser()
        {
            CsvConfiguration config = Config();

            using (var reader = new StreamReader(@"C:\Users\olive\source\repos\Case\CaseOpgave\CaseOpgave\Resources\Users.txt"))
            using (var csv = new CsvReader(reader, config))
            {
                var records = csv.GetRecords<User>();
                return records.ToList();
            }
        }
    }
}