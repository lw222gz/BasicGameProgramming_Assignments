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
        private const int numFramesX = 4;
        private const int numberOfFrames = 24;
        private const float maxTime = 0.5f;
        private float totalTime;


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
            totalTime += timeElapsed;

            float percentAnimated = totalTime / maxTime;
            int frame = (int)(percentAnimated * numberOfFrames);

            frameX = frame % numFramesX;
            frameY = frame / numFramesX;
        }

        public void ResetExplosion()
        {
            totalTime = 0;
        }
    }
}
