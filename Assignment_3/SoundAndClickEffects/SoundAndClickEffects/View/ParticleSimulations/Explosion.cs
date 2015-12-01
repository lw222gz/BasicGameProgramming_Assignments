using Microsoft.Xna.Framework;
using ParticleSimulation.View;
using SmokeSimulation.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SoundAndClickEffects.View.ParticleSimulations
{
    class Explosion
    {
        private ExplosionUpdater explosionUpdater;
        private SplitterSystem splitterSystem;
        private SmokeSimulator smokeSimulator;

        //explosion lifetime in seconds
        private float TotalLifeSpan = 2.0f;
        //it's value represents how long the explosion has existed
        private float timeExsisted;

        //represens the location of the explosion
        private Vector2 location;

        //initiates a new set of classes used to an explosion
        public Explosion(float ExplosionScale, Vector2 location)
        {
            this.splitterSystem = new SplitterSystem(ExplosionScale);
            this.smokeSimulator = new SmokeSimulator();
            this.explosionUpdater = new ExplosionUpdater(splitterSystem, smokeSimulator);

            this.location = location;
        }

        //Properties of private varibles START
        public Vector2 Location
        {
            get { return location; }
        }       
        public ExplosionUpdater ExplosionUpdater
        {
            get { return explosionUpdater; }
        }
        public SplitterSystem SplitterSystem
        {
            get { return splitterSystem; }
        }
        public SmokeSimulator SmokeSimulator
        {
            get { return smokeSimulator; }
        }
        //-- Properties of private varibles END

        //calls functions to update the visual effects of an explosion
        public bool UpdateExplosion(float timeElapsed)
        {
            timeExsisted += timeElapsed;

            explosionUpdater.UpdateFrame(timeElapsed);

            if (splitterSystem.Particles != null)
            {
                splitterSystem.UpdateParticleLocation(timeElapsed);
            }
            if (smokeSimulator.getSmoke != null)
            {
                smokeSimulator.UpdateSmokeClouds(timeElapsed);
            }

            //checks if an explosion has exceeded it's lifespan
            if (timeExsisted / TotalLifeSpan >= 1)
            {
                return true;
            }
            return false;
        }
    }
}
