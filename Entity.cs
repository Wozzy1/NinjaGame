using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace NinjaGame
{
    public abstract class Entity
    {
        public enum Direction
        {
            NORTH,
            EAST,
            SOUTH,
            WEST
        }

        public string name;
        public EntityStats stats;
        public Vector2 position;
        public Texture2D texture;
        public Direction facing;

        /**
         * This rectangle is the size of the texture.
         */
        public virtual Rectangle Rect
        {
            get
            {
                return new Rectangle((int)position.X, (int)position.Y, 100, 100);
            }
        }

        public Entity(string name, EntityStats stats, Vector2 position, Texture2D texture)
        {
            this.name = name;
            this.stats = stats;
            this.position = position;
            this.texture = texture;
        }

        public Entity(Vector2 position, Texture2D texture)
        {
            //this.name = name;
            //this.hp = hp;
            //this.atk = atk;
            this.position = position;
            this.texture = texture;
        }
        public bool IsDead()
        {
            return stats.hp <= 0;
        }


        public abstract bool Attack(Entity e);
        public abstract void Update(GameTime gameTime);
        public bool InLineOfSight(Vector2 targetPosition) {

            float dist = Vector2.Distance(this.position, targetPosition);

            if (dist > 250)
                return false;

            Vector2 positionDiff = targetPosition - this.position;

            switch (facing)
            {
                case Direction.NORTH:
                    if (positionDiff.Y < 0 && Math.Abs(positionDiff.X) <= Math.Abs(positionDiff.Y))
                    {
                        System.Diagnostics.Debug.WriteLine("Seen north");
                        return true;
                    }
                    break;

                case Direction.EAST:
                    if (positionDiff.X > 0 && Math.Abs(positionDiff.Y) <= Math.Abs(positionDiff.X))
                    {
                        System.Diagnostics.Debug.WriteLine("Seen east");
                        return true;
                    }
                    break;

                case Direction.SOUTH:
                    if (positionDiff.Y > 0 && Math.Abs(positionDiff.X) <= Math.Abs(positionDiff.Y))
                    {
                        System.Diagnostics.Debug.WriteLine("Seen south");
                        return true;
                    }
                    break;

                case Direction.WEST:
                    if (positionDiff.X < 0 && Math.Abs(positionDiff.Y) <= Math.Abs(positionDiff.X))
                    {
                        System.Diagnostics.Debug.WriteLine("Seen west");
                        return true;
                    }
                    break;

            }

            return false;
        }



        /*
        // 
        public static bool InLOS(float AngleDistance, float PositionDistance, Vector2 PositionA, Vector2 PositionB, float AngleB)
        {
            float AngleBetween = (float)Math.Atan2((PositionA.Y - PositionB.Y), (PositionA.X - PositionB.X));
            if ((AngleBetween <= (AngleB + (AngleDistance / 2f / 100f))) && (AngleBetween >= (AngleB - (AngleDistance / 2f / 100f))) && (Vector2.Distance(PositionA, PositionB) <= PositionDistance)) return true;
            else return false;
        }
        */

    }
}
