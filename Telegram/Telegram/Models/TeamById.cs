using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Telegram.Models
{
    class TeamById
    {
        public int team_id { get; set; }
        public double rating { get; set; }
        public int wins { get; set; }
        public int losses { get; set; }
        public string name { get; set; }
        public string logo_url { get; set; }
    }
}
