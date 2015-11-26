using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ParticleSimulation.View
{
    class SplitterParticle
    {
        //the position of the particle relative to the origin of the explosion
        private Vector2 position;
        private Vector2 direction;
        //logical speed in seconds
        private float MaxSpeed = 0.3f;
        private float LowestSpeed = 0.2f;

        //measured in seconds.
        private float MaxLifeSpan = 0.8f;
        private float TimeLived = 0f;

        private float Speed;
        private float size;

        public float Size
        {
            get { return size; }
        }

        public Vector2 Position
        {
            get { return position; }
        }

        //generates a random direction and sets the start position of the particle to 0,0 (that being in the middle of the explosion location)
        public SplitterParticle(Random rand, float ExplosionScale)
        {
            direction = new Vector2((float)rand.NextDouble() - 0.5f, (float)rand.NextDouble() - 0.5f);
            direction.Normalize();
            //if the scale is bigger then the logical direction also needs to be scaled up.
            direction *= ExplosionScale;

            //generates a random speed for a particle
            Speed = (float)rand.Next((int)(LowestSpeed * 100), (int)(MaxSpeed * 100)) / 100f;

            //sets base values for the particle
            size = 1;
            TimeLived = 0;
            position = new Vector2(0, 0);            
        }

        //updates a particles position
        public void UpdatePosition(float time)
        {
            position += (direction * time) * Speed;

            TimeLived += time;
            float lifePercentage = TimeLived / MaxLifeSpan;
            size = 1f - lifePercentage;
            if (lifePercentage >= 1)
            {
                size = 0;
            }

        }

        

        
    }
}
