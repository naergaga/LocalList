using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace LocalList.Utilities.Apps
{
    public class ToStringService
    {
        public string GetBuildStr(string code)
        {
            //public dfd ddsfs { get; set; }
            string reg = @"public\s+\w+\s+(\w+)\s+{\s*get\s*;";
            var collection = Regex.Matches(code, reg);
            var sb = new StringBuilder();
            var str1 = "return ";
            sb.Append(str1);
            foreach (Match item in collection)
            {
                var pName = item.Groups[1];
                sb.AppendFormat("\"{0}\" + {0} +\"; \" + ", pName);
            }
            sb.Remove(sb.Length-3, 2);
            sb.Append(";");
            return sb.ToString();
        }
    }
}
