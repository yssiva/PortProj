using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PortProj.Models
{
    public class SlotsModel
    {
        public int SlotId { get; set; }

        public int RUID { get; set; }

        public int SLUserID { get; set; }

        public int status { get; set; }
        public DateTime Sdate { get; set; }

        public DateTime Edate { get; set; }

        public int cost { get; set; }
    }
}
