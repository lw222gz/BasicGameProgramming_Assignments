using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ParticleSimulation.View
{
    class SplitterSystem
    {
        //varibles that store the time between updates
        private float timeElapsedTime;
        private float lastUpdate;
        private float ExplosionScale;

        private List<SplitterParticle> particles;

        //decides how many particles are gonna be renderd
        private const int amountOfParticles = 100;

        public SplitterSystem(float ExplosionScale)
        {
            this.ExplosionScale = ExplosionScale;
        }

        //creates a list of <SplitterParticle>
        public void generateParticles()
        {
            Random rand = new Random();
            particles = new List<SplitterParticle>(100);

            for (int i = 0; i < amountOfParticles; i++)
            {                               
                particles.Add(new SplitterParticle(rand, ExplosionScale));
            }
                
        }

        public List<SplitterParticle> Particles
        {
            get { return particles; }
        }

        //updates all particles positions by looping them.
        public void UpdateParticleLocation(float timePassed)
        {
            timeElapsedTime += timePassed;

            if (timeElapsedTime > lastUpdate)
            {
                float timeDiff = timeElapsedTime - lastUpdate;

                foreach (SplitterParticle p in particles){
                    p.UpdatePosition(timeDiff);
                }

                lastUpdate = timeElapsedTime;
            }
        }
    }
}
