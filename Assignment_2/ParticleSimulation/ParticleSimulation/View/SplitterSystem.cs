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
        private double currentTime;
        private double lastUpdate;

        private List<SplitterParticle> particles;

        //gravitational effect PER SECOND
        private const float gravitation = 1f;

        //decides how many particles are gonna be renderd
        private const int amountOfParticles = 100;

        public float Gravitation
        {
            get {  return gravitation; }
        }

        //creates a list of <SplitterParticle>
        public void generateParticles()
        {
            Random rand = new Random();
            particles = new List<SplitterParticle>(100);

            for (int i = 0; i < amountOfParticles; i++)
            {                               
                particles.Add(new SplitterParticle(rand));
            }
                
        }

        public List<SplitterParticle> Particles
        {
            get { return particles; }
        }

        //updates all particles positions by looping them.
        public void UpdateParticleLocation(double timePassed)
        {
            currentTime = timePassed;

            if (currentTime > lastUpdate && particles != null)
            {
                double timeDiff = currentTime - lastUpdate;
                double gravifyEffect = gravitation * (timeDiff / 1000f);

                foreach (SplitterParticle p in particles){
                    p.UpdatePosition((float)gravifyEffect);
                }

                lastUpdate = currentTime;
            }
        }
    }
}
