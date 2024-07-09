using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NinjaGame
{
    public class EntityStats
    {
        public int hp;
        public int atk;
        public float atkSpeed;

        public EntityStats()
        {
            hp = 0;
            atk = 0;
            atkSpeed = 0;
        }

        public EntityStats(int hp, int atk, float atkSpeed)
        {
            this.hp = hp;
            this.atk = atk;
            this.atkSpeed = atkSpeed;
        }
    }
}
