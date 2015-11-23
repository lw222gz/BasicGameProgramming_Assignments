using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ExplosionSimulator.View
{
    class ExplosionUpdater
    {
        private int frameX;
        private int frameY;
        //total number of images in the sprite in the x-led
        private const int numFramesX = 4;
        //Total number of frames in the sprite
        private const int numberOfFrames = 24;
        //current time for the explosion
        private float totalExplosionTime;
        //time durotation for the explotion (seconds)
        private const float maxTime = 0.5f;
        


        public int FrameX
        {
            get { return frameX; }
        }
        public int FrameY
        {
            get { return frameY; }
        }
        public void UpdateFrame(float timeElapsed)
        {
            totalExplosionTime += timeElapsed;

            float percentAnimated = totalExplosionTime / maxTime;
            int frame = (int)(percentAnimated * numberOfFrames);

            //set values for the sprite "grid" 
            frameX = frame % numFramesX;
            frameY = frame / numFramesX;
        }

        public void ResetExplosion()
        {
            totalExplosionTime = 0;
        }
    }
}
