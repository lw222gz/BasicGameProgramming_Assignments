using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SmokeSimulation.View
{
    class SmokeSimulator
    {
        private const int amountOfSmoke = 3;

        private float timeElapsed;
        private float lastUpdate;

        private List<Smoke> smoke;
        private Random rand;

        //propery for smoke clouds
        public List<Smoke> getSmoke
        {
            get { return smoke; }
        }

        //creates a random obj used to generate smoke stats
        public SmokeSimulator()
        {
            rand = new Random();
        }

        //generates a new smoke cloud once one has gone out, if the list capacity still isent filled a new smoke cloud is spawned.
        public void UpdateSmokeClouds(float time)
        {
            timeElapsed += time;

            if (timeElapsed > lastUpdate)
            {
                float timeDiff = timeElapsed - lastUpdate;

                for (int i = 0; i < smoke.Count; i++)
                {
                    smoke[i].UpdateSmoke(timeDiff);                 
                }

                lastUpdate = timeElapsed;
            }
        }

        //generates a couple of clouds to fade out after the explosion
        public void GenerateSmoke()
        {
            smoke = new List<Smoke>(amountOfSmoke);
            for (int i = 0; i < smoke.Capacity; i++)
            {
                Smoke s = new Smoke();
                s.GenerateNewSmokeStats(rand);
                smoke.Add(s);
            }
        }
    }
}