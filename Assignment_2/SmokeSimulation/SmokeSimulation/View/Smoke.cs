using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SmokeSimulation.View
{
    class Smoke
    {
        private Vector2 position;
        private Vector2 direction;

        private float rotation;
        private float rotationSpeed;
        private float size;

        //measured in seconds
        private float timeLived;
        private float maxTimeToLive;
        private const float maxSize = 10f;
        private const float minSize = 0f;

        
        

        private const float maxSpeed = 0.3f;
        private const float minSpeed = 0.1f;
        private float speedModifier;
        private float fade;

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
        public Vector2 Position
        {
            get { return position; }
        }
        
        
        //generates all required stats for a smoke cloud
        public void GenerateNewCloudStats(Random rand)
        {
            fade = 1f;
            timeLived = 0f;
            size = 0f;
            //start position
            position = new Vector2(0.5f, 0.9f);
            //random rotation settings for each smoke
            rotation = (float)rand.Next(0, 20) / 10f;
            rotationSpeed = (float)rand.NextDouble();

            maxTimeToLive = (float)rand.Next(30, 50) / 10f;

            speedModifier = (float)rand.Next((int)(minSpeed * 10), (int)(maxSpeed * 10)) / 10f;

            direction = new Vector2((float)rand.NextDouble() - 0.5f, (float)rand.NextDouble() - 0.5f);
            //adding some width for possible paths
            direction.X = direction.X * 3;
            direction = direction * ((float)rand.NextDouble() * maxSpeed);
        }

        public bool UpdateLocation(float timeEffect)
        {
            //second representation of the total life span for this.smoke
            timeLived += timeEffect;

            //modifies the cloud position, I added a speed modifier because the clouds where moving alot faster than intended at first, any smart way to skip this?
            position.X += direction.X * timeEffect * speedModifier;
            position.Y += direction.Y * timeEffect * speedModifier;

            //adding rotation based on a radomized rotation speed affected by the passed time.
            rotation += rotationSpeed * timeEffect;

            float lifePercent = timeLived / maxTimeToLive;

            //1 - lifePercent gives a decimal deciding the fade of a cloud. 
            //when lifepercent reaches 100% (= 1) the fade = 0 and the cloud wont be visible.
            fade = 1f - lifePercent;

            //calculation for the size of the smoke
            size = minSize + lifePercent * maxSize;

            //acceleration
            direction.Y -= timeEffect;
            //if a cloud has exceeded it's lifespan then the method returns true and a new one will be taking it's place.
            if (lifePercent >= 1)
            {
                return true;
            }
            return false;
        }
    }
}
