
using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace NinjaGame
{
    public class Player : Entity
    {
        //List<Entity> collisionGroup;


        private int idleTime;
        public bool isIdle;

        public Player(string name, EntityStats stats, Vector2 position, Texture2D texture)
            : base(name, stats, position, texture)
        {
            facing = Direction.SOUTH;
            idleTime = 0;
            isIdle = false;
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
                //System.Diagnostics.Debug.WriteLine("I am facing " + Enum.GetName(direction));

            }
            if (Keyboard.GetState().IsKeyDown(Keys.A) || Keyboard.GetState().IsKeyDown(Keys.Left))
            {
                dX -= 4;
                facing = Direction.WEST;
                //System.Diagnostics.Debug.WriteLine("I am facing " + Enum.GetName(direction));

            }

            // Sprinting with shift key
            if (Keyboard.GetState().IsKeyDown(Keys.LeftShift))
            {
                dX *= (float)1.5;
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
                //System.Diagnostics.Debug.WriteLine("I am facing " + Enum.GetName(direction));

            }
            if (Keyboard.GetState().IsKeyDown(Keys.S) || Keyboard.GetState().IsKeyDown(Keys.Down))
            {
                dY += 4;
                facing = Direction.SOUTH;
                //System.Diagnostics.Debug.WriteLine("I am facing " + Enum.GetName(direction));

            }

            if (Keyboard.GetState().IsKeyDown(Keys.LeftShift))
            {
                dY *= (float)1.5;
            }
            position.Y += dY;

            //foreach (var entity in collisionGroup)
            //{
            //    if (entity.Rect.Intersects(Rect))
            //    {
            //        position.Y -= dY;
            //    }
            //}

            if (dX == 0 && dY == 0)
                idleTime++;
            else
                idleTime = 0;

            if (idleTime > 5)
                isIdle = true;
            else
                isIdle = false;

        }
    }

}