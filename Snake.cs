using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace NinjaGame
{
    internal class Snake : Entity
    {
        public Snake(string name, EntityStats stats, Vector2 position, Texture2D texture)
            : base(name, stats, position, texture)
        {
            facing = Direction.WEST;
        }
        
        public override bool Attack(Entity e)
        {

            return false;
        }
        public override void Update(GameTime gameTime)
        {

        }

    }
}
