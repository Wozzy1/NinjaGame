﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;

namespace NinjaGame
{
    internal class AnimationManager
    {
        protected int numFrames;
        protected Vector2 size;

        protected int counter;
        protected int activeFrame;
        protected int interval;

        protected readonly int TILE_SIZE = 16;

        public AnimationManager(int numFrames, Vector2 size)
        {
            this.numFrames = numFrames;
            this.size = size;

            counter = 0;
            activeFrame = 0;
            interval = 25;

        }


        public void Update()
        {
            counter += 1;
            if (counter > interval)
            {
                counter = 0;
                activeFrame++;
                if (activeFrame >= numFrames)
                {
                    activeFrame = 0;
                }

            }
        }
        public virtual Rectangle GetFrame()
        {
            return new Rectangle(0, activeFrame * TILE_SIZE, TILE_SIZE, TILE_SIZE);
        }

    }
}
