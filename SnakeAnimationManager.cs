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

        public SnakeAnimationManager(Snake _snake, int numFrames, Vector2 size) : base(numFrames, size)
        {
            this._snake = _snake;
        }

        public new void Update()
        {
            // make snake move towards player

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
