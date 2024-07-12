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
        private bool playerSeen;
        private Player _player;
        public Snake(string name, EntityStats stats, Vector2 position, Texture2D texture, Player _player)
            : base(name, stats, position, texture)
        {
            facing = Direction.WEST;
            playerSeen = false;
            this._player = _player;
        }
        
        public override bool Attack(Entity e)
        {

            return false;
        }
        public override void Update(GameTime gameTime)
        {
            if (InLineOfSight(_player.position))
            {
                playerSeen = true;
            }
        }

    }
}
