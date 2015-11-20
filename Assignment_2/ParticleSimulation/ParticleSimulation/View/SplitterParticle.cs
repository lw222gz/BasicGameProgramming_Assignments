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
        private const float maxSpeed = 0.5f;

        public Vector2 Position
        {
            get { return position; }
        }

        //generates a random direction and sets the start position of the particle to 0,0 (that being in the middle of the explosion location)
        public SplitterParticle(Random rand)
        {
            direction = new Vector2((float)rand.NextDouble() - 0.5f, (float)rand.NextDouble() - 0.5f);
            direction.Normalize();
            direction = direction * ((float)rand.NextDouble() * maxSpeed);

            position = new Vector2(0, 0);            
        }

        //updates a particles position
        public void UpdatePosition(float gravityEffect)
        {
            position = position + direction * gravityEffect;

            //pulls the particle down.
            direction.Y += gravityEffect;
        }
    }
}
