using System;

namespace _05.Kings_Gambit_Extended
{
    public class SoldierDeathEventArgs : EventArgs
    {
        public string Name { get; private set; }

        public KingUnderAttackEventHandler RespondMethod { get; private set; }
    }
}
