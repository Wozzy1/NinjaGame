
using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using NinjaGame.Content;

namespace NinjaGame
{
    public class Player : Entity
    {
        //List<Entity> collisionGroup;
        public Direction facing;


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

        /**
         * Returns the updated position as a Rectangle
         */
        public override Rectangle Rect
        {
            get
            {
                return new Rectangle((int)position.X, (int)position.Y, 100, 100);
            }
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
                System.Diagnostics.Debug.WriteLine("I am facing " + Enum.GetName(direction));

            }
            if (Keyboard.GetState().IsKeyDown(Keys.A) || Keyboard.GetState().IsKeyDown(Keys.Left))
            {
                dX -= 4;
                facing = Direction.WEST;
                System.Diagnostics.Debug.WriteLine("I am facing " + Enum.GetName(direction));

            }

            position.X += dX;

            //foreach (var entity in collisionGroup)
            //{
            //    if (entity.Rect.Intersects(Rect))
            //    {
            //        position.X -= dX;
            //    }
            //}

            if (Keyboard.GetState().IsKeyDown(Keys.W) || Keyboard.GetState().IsKeyDown(Keys.Up))
            {
                dY -= 4;
                facing = Direction.NORTH;
                System.Diagnostics.Debug.WriteLine("I am facing " + Enum.GetName(direction));

            }
            if (Keyboard.GetState().IsKeyDown(Keys.S) || Keyboard.GetState().IsKeyDown(Keys.Down))
            {
                dY += 4;
                facing = Direction.SOUTH;
                System.Diagnostics.Debug.WriteLine("I am facing " + Enum.GetName(direction));

            }

            position.Y += dY;

            //foreach (var entity in collisionGroup)
            //{
            //    if (entity.Rect.Intersects(Rect))
            //    {
            //        position.Y -= dY;
            //    }
            //}

        }
    }

}