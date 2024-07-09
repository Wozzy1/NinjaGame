using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using SharpDX.Direct2D1.Effects;

namespace NinjaGame
{
    internal class PlayerAnimationManager : AnimationManager
    {
        private Player _player;
        public PlayerAnimationManager(Player _player, int numFrames, Vector2 size) 
            : base(numFrames, size) 
        { 
            this._player = _player;
            //System.Diagnostics.Debug.WriteLine("During construction of PAM, facing: " + _player.direction);
        }


        public new void Update()
        {
            if (_player.isIdle)
            {
                counter = 0;
                activeFrame = 0;
                return;
            }
            if (Keyboard.GetState().IsKeyDown(Keys.LeftShift))
            {
                counter+=2;
            }
            if (activeFrame == 0 || activeFrame == 2)
            {
                counter += 4;
            }
            base.Update();

        }

        public override Rectangle GetFrame()
        {
            int pixelOffset;
            switch (_player.facing)
            {
                case Entity.Direction.NORTH:
                    //System.Diagnostics.Debug.WriteLine("NORTH");
                    pixelOffset = 16;
                    break;

                case Entity.Direction.EAST:
                    //System.Diagnostics.Debug.WriteLine("EAST");
                    pixelOffset = 48;
                    break;

                case Entity.Direction.SOUTH:
                    //System.Diagnostics.Debug.WriteLine("SOUTH");
                    pixelOffset = 0;
                    break;

                case Entity.Direction.WEST:
                    //System.Diagnostics.Debug.WriteLine("WEST");
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
