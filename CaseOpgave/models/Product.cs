using CsvHelper.Configuration.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CaseOpgave.models
{
    internal class Product
    {
        [Index(0)]
        public int id { get; set; }
        [Index(1)]
        public string movieName { get; set; }
        [Index(2)]
        public string year { get; set; }
        [Index(3)]
        public string KeywordONE { get; set; }
        [Index(4)]
        public string KeywordTWO { get; set; }
        [Index(5)]
        public string KeywordTHREE { get; set; }
        [Index(6)]
        public string KeywordFOUR { get; set; }
        [Index(7)]
        public string KeywordFIVE { get; set; }
        [Index(8)]
        public float rating { get; set; }
        [Index(9)]
        public float price { get; set; }
        public string[] allKeywords;

        public void keywordtoList()
        {
            allKeywords[0] = KeywordONE;
            allKeywords[1] = KeywordTWO;
            allKeywords[2] = KeywordTHREE;  
            allKeywords[3] = KeywordFOUR;   
            allKeywords[4] = KeywordFIVE;     
        }
        public List<string> getKeywordsTolist()
        {

            List<string> keywords = new List<string>();
            keywords.Add(this.KeywordONE);
            keywords.Add(this.KeywordTWO);
            keywords.Add(this.KeywordTHREE);
            keywords.Add(this.KeywordFOUR); 
            keywords.Add(this.KeywordFIVE);
        return keywords;
        }
        public static List<string> product(string productSplit)
        {


            List<string> returnlist = new List<string>();

            string[] subs = productSplit.Split(", ");

            foreach (string item in subs)
            {
                returnlist.Add(item);
            }
            return returnlist;
        }


        public Product(int id, string movieName, string year, string keywordONE,
            string keywordTWO, string keywordTHREE, string keywordFOUR, string keywordFIVE,
            float rating, float price)
        {
            this.id = id;
            this.movieName = movieName;
            this.year = year;
            this.KeywordONE = keywordONE;
            this.KeywordTWO = keywordTWO;
            this.KeywordTHREE = keywordTHREE;
            this.KeywordFOUR = keywordFOUR;
            this.KeywordFIVE = keywordFIVE;
            this.rating = rating;
            this.price = price;
            keywordtoList();
        }
        public Product()
        {
        }
    }
}
