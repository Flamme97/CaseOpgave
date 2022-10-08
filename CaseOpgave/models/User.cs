using CsvHelper.Configuration.Attributes;

namespace CaseOpgave.models
{
    internal class User
    {
        [Index(0)]
        public int id { get; set; }
        [Index(1)]
        public string name { get; set; }
        [Index(2)]
        public string viewed { get; set; }
        [Index(3)]
        public string purchased { get; set; }
        //private List<string> purchasedSplit { get; set; }

        // Splitting the string into a new list, so special characters gets removed from list.
        public static List<string> ListSplit(string purchasedSplit)
        {
            List<string> returnlist = new List<string>();

            string[] subs = purchasedSplit.Split(" ;");
            
                foreach (string item in subs)
                {
                    returnlist.Add(item);
                }
                return returnlist;
        }
        public User(int id, string name, string viewed, string purchased)
        {
            this.id = id;
            this.name = name;
            this.viewed = viewed;
            this.purchased = purchased;
        }
        public User()
        {
        }
    }

}
