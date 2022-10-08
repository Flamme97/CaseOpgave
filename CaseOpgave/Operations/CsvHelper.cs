using CaseOpgave.models;
using CsvHelper;
using CsvHelper.Configuration;
using System.Globalization;

namespace CaseOpgave.Operations
{
    static class CsvHelpers
    {   
        // Using Cvs library, csv configuration to read Csv from assigment packets.
        public static CsvConfiguration Config()
        { 
            var config = new CsvConfiguration(CultureInfo.InvariantCulture)
            {
                HasHeaderRecord = false,
                MissingFieldFound = null,
            };
            return config;
        }
        // Adding CSV Data to record list. List with CurrentUser Data.
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
        // Adding CSV Data to record list. List with Product Data.
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
        // Adding CSV Data to record list. List with User ID.
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