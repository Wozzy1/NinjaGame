using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace NinjaGame.Content
{
    public abstract class Entity
    {
        public enum Direction {
            NORTH,
            EAST,
            SOUTH,
            WEST
        }

        public string name;
        public int hp;
        public int atk;
        public Vector2 position;
        public Texture2D texture;

        public Direction direction = Direction.SOUTH;

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

        public Entity(string name, int hp, int atk, Vector2 position, Texture2D texture)
        {
            this.name = name;
            this.hp = hp;
            this.atk = atk;
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


        public abstract bool Attack(Entity e);
        public abstract void Update(GameTime gameTime);

        public bool IsDead()
        {
            return hp <= 0;
        }

    }
}
