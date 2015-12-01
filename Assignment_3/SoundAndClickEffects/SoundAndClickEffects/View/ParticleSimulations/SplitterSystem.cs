using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ParticleSimulation.View
{
    class SplitterSystem
    {
        //represents the scale of the explosion, this value if important when creating a splitterParticle.
        private float ExplosionScale;

        private Random rand;
        private List<SplitterParticle> particles;

        //decides how many particles are gonna be renderd
        private const int amountOfParticles = 100;

        public SplitterSystem(float ExplosionScale)
        {
            this.ExplosionScale = ExplosionScale;
            rand = new Random();
        }

        //properties for private varibles START
        public List<SplitterParticle> Particles
        {
            get { return particles; }
        }
        //-- properties for private varibles END

        //creates a list of <SplitterParticle>
        public void generateParticles()
        {        
            particles = new List<SplitterParticle>(100);

            for (int i = 0; i < amountOfParticles; i++)
            {
                particles.Add(new SplitterParticle(rand, ExplosionScale));
            }               
        }   

        //updates all particles positions
        public void UpdateParticleLocation(float timeElapsed)
        {
            foreach (SplitterParticle p in particles){
                p.UpdatePosition(timeElapsed);
            }
        }
    }
}
