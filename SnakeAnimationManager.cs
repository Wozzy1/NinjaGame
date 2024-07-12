using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using SharpDX.Direct2D1;

namespace NinjaGame
{
    internal class SnakeAnimationManager : AnimationManager
    {
        private Snake _snake;
        private int dirCounter;

        public SnakeAnimationManager(Snake _snake, int numFrames, Vector2 size) : base(numFrames, size)
        {
            this._snake = _snake;
            dirCounter = 0;
        }

        public new void Update()
        {
            // make snake move towards player
            dirCounter++;
            if (dirCounter > 60)
            {
                Random rand = new Random();
                int dir = rand.Next(4);

                switch (dir)
                {
                    case 0:
                        _snake.facing = Entity.Direction.NORTH;
                        break;
                    case 1:
                        _snake.facing = Entity.Direction.EAST;
                        break;
                    case 2:
                        _snake.facing = Entity.Direction.SOUTH;
                        break;
                    case 3:
                        _snake.facing = Entity.Direction.WEST;
                        break;
                }
                dirCounter = 0;
            }

            base.Update();
        }

        public override Rectangle GetFrame()
        {
            int pixelOffset;
            switch (_snake.facing)
            {
                case Entity.Direction.NORTH:
                    pixelOffset = 16;
                    break;

                case Entity.Direction.EAST:
                    pixelOffset = 48;
                    break;

                case Entity.Direction.SOUTH:
                    pixelOffset = 0;
                    break;

                case Entity.Direction.WEST:
                    pixelOffset = 32;
                    break;

                default:
                    pixelOffset = 0;
                    break;
            }

            return new Rectangle(pixelOffset, activeFrame * TILE_SIZE, TILE_SIZE, TILE_SIZE);
        }

    }
}
