using System;
using System.Collections.Generic;
using System.Linq;

namespace _05.Kings_Gambit_Extended
{
    public class Program
    {
        public static void Main()
        {
            King king = new King(Console.ReadLine());

            List<Soldier> army = new List<Soldier>();

            string[] royalGuards = Console.ReadLine().Split();

            foreach (var royalGuardName in royalGuards)
            {
                RoyalGuard guard = new RoyalGuard(royalGuardName);
                army.Add(guard);
                king.UnderAttack += guard.OnKingUnderAttack;
            }

            string[] footmen = Console.ReadLine().Split();

            foreach (var footmanName in footmen)
            {
                Footman footman = new Footman(footmanName);
                army.Add(footman);
                king.UnderAttack += footman.OnKingUnderAttack;
            }

            string[] command = Console.ReadLine().Split();
            while (command[0] != "End")
            {
                switch (command[0])
                {
                    case "Kill":
                        Soldier soldier = army.FirstOrDefault(s => s.Name == command[1]);
                        king.UnderAttack -= soldier.OnKingUnderAttack;
                        army.Remove(soldier);
                        break;
                    case "Attack":
                        king.OnUnderAttack();
                        break;
                }

                command = Console.ReadLine().Split();
            }
        }
    }
}
