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

        private float speed = 0.2f;
        

        private const float maxSpeed = 0.8f;
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
        
        
        //generate a random speed, rotation and lifetime
        public Smoke(Random rand)
        {
            fade = 1f;
            //start position
            position = new Vector2(0.5f , 0.9f);
            //random rotation settings for each smoke
            rotation = (float)rand.Next(0, 20) / 10f;
            rotationSpeed = (float)rand.NextDouble();

            maxTimeToLive = (float)rand.Next(20, 40) / 10f;


            direction = new Vector2((float)rand.NextDouble()-0.5f, (float)rand.NextDouble() - 0.9f);
            //direction.Normalize();
            direction = direction * ((float)rand.NextDouble() * maxSpeed);
        }

        public bool UpdateLocation(float timeEffect)
        {
            timeLived += timeEffect;

            position.X += direction.X * timeEffect * speed;
            position.Y += direction.Y * timeEffect * speed;

            rotation += rotationSpeed * timeEffect;

            float lifePercent = timeLived / maxTimeToLive;
            fade = 1f - lifePercent;
            size = 1 + lifePercent * maxSize;

            direction.Y -= timeEffect;
            if (lifePercent >= 1)
            {
                return true;
            }
            return false;
        }
    }
}
