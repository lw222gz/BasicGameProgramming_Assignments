﻿using ParticleSimulation.View;
using SmokeSimulation.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SoundAndClickEffects.View
{
    class ExplosionUpdater
    {
        private int frameX;
        private int frameY;
        private const int numFramesX = 4;
        private const int numberOfFrames = 24;
        private const float maxTime = 0.6f;
        private const int StartSplitter = 4;
        private const int StartSmoke = 6;

        private float totalTime;



        private SplitterSystem splitterSystem;
        private SmokeSimulator smokeSimulator;

        private bool hasParticlesSpawned;
        private bool hasSmokeSpawned;

        //sets values used for the new explosion
        public ExplosionUpdater(SplitterSystem splitterSystem, SmokeSimulator smokeSimulator)
        {
            this.splitterSystem = splitterSystem;
            this.smokeSimulator = smokeSimulator;

            hasSmokeSpawned = false;
            hasParticlesSpawned = false;
            totalTime = 0;
        }

        // properties of private varibles START
        public int FrameX
        {
            get { return frameX; }
        }
        public int FrameY
        {
            get { return frameY; }
        }
        //-- properties of private varibles END

        //Updates the main explosion and adds more particle effects as time goes on
        public void UpdateFrame(float timeElapsed)
        {
            totalTime += timeElapsed;

            float percentAnimated = totalTime / maxTime;
            int frame = (int)(percentAnimated * numberOfFrames);

            frameX = frame % numFramesX;
            frameY = frame / numFramesX;

            //includes more particle effects as the explosion goes on.
            if (!hasParticlesSpawned && frame >= StartSplitter)
            {
                hasParticlesSpawned = true;
                this.splitterSystem.generateParticles();
            }
            if (!hasSmokeSpawned && frame >= StartSmoke)
            {
                hasSmokeSpawned = true;
                this.smokeSimulator.GenerateSmoke();
            }
        }
    }
}
