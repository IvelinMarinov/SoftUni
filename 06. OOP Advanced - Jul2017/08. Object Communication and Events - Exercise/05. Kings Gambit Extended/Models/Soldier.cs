
using System;

namespace _05.Kings_Gambit_Extended
{
    public abstract class Soldier
    {
        public event SoldierDeathEventHandler SoldierDeath;

        public Soldier(string name, int hitsLeft)
        {
            this.Name = name;
            this.HitsLeft = hitsLeft;
        }

        public string Name { get; private set; }

        protected int HitsLeft { get; set; }

        public abstract void OnKingUnderAttack(object sender, EventArgs e);

        public void RespondToAttack()
        {
            this.HitsLeft--;
            if (HitsLeft == 0)
            {
                OnSoldierDeath(new SoldierDeathEventArgs(this.Name, OnKingUnderAttack));
            }
        }

        protected void OnSoliderDeath(SoldierDeathEventArgs args)
        {
            if (SoldierDeath != null)
            {
                SoldierDeath(this, args);
            }
        }
    }
}
