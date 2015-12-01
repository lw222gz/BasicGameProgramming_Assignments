using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SmokeSimulation.View
{
    class SmokeSimulator
    {
        private const int amountOfSmoke = 10;

        private List<Smoke> smoke;
        private Random rand;       

        //creates a random obj used to generate smoke stats
        public SmokeSimulator()
        {
            rand = new Random();
        }

        //Properties of private varibles START
        public List<Smoke> getSmoke
        {
            get { return smoke; }
        }
        //Properties of private varibles END

        
        public void UpdateSmokeClouds(float timeElapsed)
        {
            for (int i = 0; i < smoke.Count; i++)
            {
                smoke[i].UpdateSmoke(timeElapsed);                 
            }
        }

        //generates smokeclouds for an explosion
        public void GenerateSmoke()
        {
            smoke = new List<Smoke>(amountOfSmoke);
            for (int i = 0; i < smoke.Capacity; i++)
            {
                smoke.Add(new Smoke(rand));
            }
        }
    }
}