using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MilliganNathaniel413BowlingLeague.Models.ViewModels
{
    public class IndexViewModel
    {
        public List<Bowler> Bowlers { get; set; }
        public PageNumberingInfo PageNumberingInfo { get; set; }
        public string TeamName { get; set; }
    }
}
