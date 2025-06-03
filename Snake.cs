using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using static NinjaGame.Entity;

namespace NinjaGame
{
    internal class Snake : Entity
    {
        private bool playerSeen;
        private Player _player;
        private short moveCounter;
        private static readonly float Speed = 250f;

        public Snake(string name, EntityStats stats, Vector2 position, Texture2D texture, Player _player)
            : base(name, stats, position, texture)
        {
            facing = Direction.WEST;
            playerSeen = false;
            this._player = _player;
            moveCounter = 0;
        }
        
        public override bool Attack(Entity e)
        {

            return false;
        }
        public override void Update(GameTime gameTime)
        {
            if (playerSeen)
            {
                UpdateHostile(gameTime);
                return;
            }
            if (InLineOfSight(_player.position))
            {
                playerSeen = true;
                return;
            }
            moveCounter++;

            if (moveCounter > 200)
            {
                this.facing ^= Direction.EAST + 1;
                moveCounter = 0;
            }

        }

        private void UpdateHostile(GameTime gameTime)
        {
            if (InLineOfSight(_player.position))
            {
                playerSeen = true;
            }
            else
            {
                playerSeen = false;
                return;
            }

            Vector2 direction = _player.position - this.position;
            direction.Normalize();
            float deltaTime = (float)gameTime.ElapsedGameTime.TotalSeconds;
            Vector2 movement = direction * Speed * deltaTime;
            this.position += movement;

            SetFacingDirection(direction);
        }

        private void SetFacingDirection(Vector2 direction)
        {
            // Use the greater absolute component to determine the dominant direction
            if (Math.Abs(direction.X) > Math.Abs(direction.Y))
            {
                this.facing = direction.X > 0 ? Direction.EAST : Direction.WEST;
            }
            else
            {
                this.facing = direction.Y > 0 ? Direction.SOUTH : Direction.NORTH;
            }
        }
    }
}
