using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RegastrationOfTheWeddingOrganizer
{
    public class User
    {
        public User(string i, string n, string c)
        {
            Id = i;
            Name = n;
            Cost = c;
        }
        public string Id { get; set; }
        public string Name { get; set; }
        public string Cost { get; set; }

    }
    public class Wedding
    {
        public Wedding(string id, string name, string weddingstartddate, string weddingenddate, string cost, string codes)
        {
            Id = id;
            WeddingName = name;
            WeddingStartDate = weddingstartddate;
            WeddingEndDate = weddingenddate;
            Cost = cost;
            Codes = codes;
        }
        public Wedding() { }
        public string Id { get; set; }
        public string WeddingName { get; set; }
        public string WeddingStartDate { get; set; }
        public string WeddingEndDate { get; set; }
        public string Cost { get; set; }
        public string Codes { get; set; }
    }
    public class ArchiveWedding : Wedding
    {
        public ArchiveWedding():base(){}
        public ArchiveWedding(string id, string name, string weddingstartddate, string weddingenddate, string cost, string codes,string weddingrecorddate):base(id, name, weddingstartddate, weddingenddate, cost, codes)
        {
            WeddingRecordDate = weddingrecorddate;
        }
        public string WeddingRecordDate { get; set; }
    }
}
