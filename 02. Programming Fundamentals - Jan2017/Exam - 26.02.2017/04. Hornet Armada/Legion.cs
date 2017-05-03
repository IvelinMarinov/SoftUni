using System.Collections.Generic;

namespace _04.Hornet_Armada
{
    public class Legion
    {
        public int LastActivity { get; set; }

        public string Name { get; set; }

        public Dictionary<string, long> Soldiers { get; set; }
    }
}
