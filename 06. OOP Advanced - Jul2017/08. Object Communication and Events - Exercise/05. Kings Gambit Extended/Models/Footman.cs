
using System;

namespace _05.Kings_Gambit_Extended
{
    public class Footman : Soldier
    {
        public const int FootmanHits = 2;

        public Footman(string name) 
            : base(name, FootmanHits)
        {
        }

        public override void OnKingUnderAttack(object sender, EventArgs e)
        {
            Console.WriteLine($"Footman {this.Name} is panicking!");
        }
    }
}
