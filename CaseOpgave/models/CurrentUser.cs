using CsvHelper.Configuration.Attributes;

namespace CaseOpgave.models
{
    // get and set for current User CSV File
    internal class CurrentUser
    {
        [Index(0)]
        public int userID { get; set; }
        [Index(1)]
        public int productID { get; set; }
    }
}
