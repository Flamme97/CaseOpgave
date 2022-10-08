using CsvHelper.Configuration.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CaseOpgave.models
{
    internal class CurrentUser
    {
        [Index(0)]
        public int userID { get; set; }
        [Index(1)]
        public int productID { get; set; }
    }
}
