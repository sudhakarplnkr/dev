using System.Collections.Generic;

namespace OnBoarding.Contract
{
    public class PageRequest
    {
        public int PageNumber { get; set; }
        
        public int PerPageCount { get; set; }
        
        public Dictionary<string, bool> SortColumns { get; set; }
        
        public Dictionary<string, string> SearchParams { get; set; }
    }
}
