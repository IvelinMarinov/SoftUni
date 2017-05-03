using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _06._01._2017___2.SoftUni_Karaoke
{
    public class Participant
    {
        public string Name { get; set;}

        public List<string> Awards { get; set; }

        public int AwardsCount => Awards.Count;
    }
}
