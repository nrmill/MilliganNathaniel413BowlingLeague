using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MilliganNathaniel413BowlingLeague.Models
{
    public partial class Tournament
    {
        public Tournament()
        {
            TourneyMatches = new HashSet<TourneyMatch>();
        }

        public long TourneyId { get; set; }
        public byte[] TourneyDate { get; set; }
        public string TourneyLocation { get; set; }

        public virtual ICollection<TourneyMatch> TourneyMatches { get; set; }
    }
}
