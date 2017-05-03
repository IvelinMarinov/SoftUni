using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _23._10._2017_4.Roli___The_Coder
{
    public class Event
    {
        public string ID { get; set; }

        public string Name { get; set; }

        public List<string> Participants { get; set; }

        public int NumberOfParticipants => Participants.Count;
    }
}
