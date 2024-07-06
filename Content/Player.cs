
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using NinjaGame.Content;

namespace NinjaGame
{
    public class Player : Entity
    {

        public Direction facing = Direction.SOUTH;


        public Player(string name, int hp, int atk, Vector2 position, Texture2D texture)
            : base(name, hp, atk, position, texture)
        {

        }

        /**
         * Attacks an entity e dealing atk damage to e.
         * 
         * For now, returns true if the entity's hp is <= 0
         */
        public override bool Attack(Entity e)
        {
            
            return false;
        }

        public override void Update(GameTime gameTime)
        {
            if (IsDead())
            {
                // do something
            }

            float dX = 0;
            float dY = 0;

            if (Keyboard.GetState().IsKeyDown(Keys.D) || Keyboard.GetState().IsKeyDown(Keys.Right))
            {
                dX += 4;
                facing = Direction.EAST;
            }
            if (Keyboard.GetState().IsKeyDown(Keys.A) || Keyboard.GetState().IsKeyDown(Keys.Left))
            {
                dX -= 4;
                facing = Direction.WEST;
            }

            position.X += dX;

            //foreach (var character in collisionGroup)
            //{
            //    if (character.Rect.Intersects(Rect))
            //    {
            //        position.X -= dX;
            //    }
            //}

            if (Keyboard.GetState().IsKeyDown(Keys.W) || Keyboard.GetState().IsKeyDown(Keys.Up))
            {
                dY -= 4;
                facing = Direction.NORTH;
            }
            if (Keyboard.GetState().IsKeyDown(Keys.S) || Keyboard.GetState().IsKeyDown(Keys.Down))
            {
                dY += 4;
                facing = Direction.SOUTH;
            }

            position.Y += dY;

            //foreach (var character in collisionGroup)
            //{
            //    if (character.Rect.Intersects(Rect))
            //    {
            //        position.Y -= dY;
            //    }
            //}

        }
    }

}