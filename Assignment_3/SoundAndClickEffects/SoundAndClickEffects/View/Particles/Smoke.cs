using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SmokeSimulation.View
{
    class Smoke
    {
        //measured in radian
        private float rotation;
        private float rotationSpeed;

        //measured in seconds
        private float timeLived;
        private const float maxTimeToLive = 1f;

        //measuerd in scale
        private const float maxSize = 11f;
        private const float minSize = 0f;
        private float size;

        //measuerd in precentage (0-1)
        private float fade;

        //generates all required stats for a smoke cloud
        public Smoke(Random rand)
        {
            fade = 1f;
            timeLived = 0f;
            size = 0f;

            //random rotation settings for each smoke
            rotation = (float)rand.Next(0, 6);
            rotationSpeed = (float)rand.NextDouble();
        }

        //Properties for private varibles START
        public float Size
        {
            get { return size; }
        }
        public float Rotation
        {
            get { return rotation; }
        }
        public float Fade
        {
            get { return fade; }
        }
        //-- Properties for private varibles END
        
        //Updates the smoke clouds visual values
        public void UpdateSmoke(float timeEffect)
        {
            //second representation of the total life span for this.smoke
            timeLived += timeEffect;

            //adding rotation based on a radomized rotation speed affected by the passed time.
            rotation += rotationSpeed * timeEffect;

            float lifePercent = timeLived / maxTimeToLive;

            //1 - lifePercent gives a decimal deciding the fade of a cloud. 
            //when lifepercent reaches 100% (= 1) the fade = 0 and the cloud wont be visible.
            fade = 1f - lifePercent;

            //calculation for the size of the smoke
            size = minSize + lifePercent * maxSize;
        }
    }
}