using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LocalList.Utilities.Model
{
    public class PageOptionModel
    {
        public PageOption Option { get; set; }
        public Dictionary<string,string> Routes { get; set; }
    }

    public class PageOption
    {
        public int Current { get; set; }
        public int Size { get; set; }
        public int Count { get; set; }
    }
}
