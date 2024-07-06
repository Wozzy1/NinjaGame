using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using NinjaGame.Content;

namespace NinjaGame
{
    internal class PlayerAnimationManager : AnimationManager
    {
        private Entity _player;
        public PlayerAnimationManager(Entity _player, int numFrames, Vector2 size) 
            : base(numFrames, size) 
        { 
            this._player = _player;
        }


        public new void Update()
        {
            switch (_player.direction)
            { 
                case Entity.Direction.NORTH:
                    // System.Diagnostics.Debug.WriteLine("NORTH");
                    break;
            
                case Entity.Direction.EAST:
                    // System.Diagnostics.Debug.WriteLine("EAST");
                    break;

                case Entity.Direction.SOUTH:
                    System.Diagnostics.Debug.WriteLine("SOUTH but why");
                    break;
                
                case Entity.Direction.WEST:
                    // System.Diagnostics.Debug.WriteLine("WEST");
                    break;


            }

            base.Update();

        }

    }
}
