using UnityEngine;

namespace Units
{
    public class Swordsman : Soldier
    {
        public int armor = 100;

        public override void GetDamage(int dmg)
        {
            //first deplete armor, than health
            if (armor > 0)
            {
                armor -= dmg;
            }
            else
            {
                health -= dmg;
            }
        }
    }
}