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

        private float TotalLifeSpan = 2.0f;
        private float timeExsisted;


        private Vector2 location;
        public Explosion(float ExplosionScale, Vector2 location)
        {
            this.splitterSystem = new SplitterSystem(ExplosionScale);
            this.smokeSimulator = new SmokeSimulator();
            this.explosionUpdater = new ExplosionUpdater(splitterSystem, smokeSimulator);

            //location of the explosion in VISUAL coordinates
            this.location = location;
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

            if (timeExsisted / TotalLifeSpan >= 1)
            {
                return true;
            }
            return false;
        }

        public Vector2 Location
        {
            get
            {
                return location;
            }
        }
    }
}
