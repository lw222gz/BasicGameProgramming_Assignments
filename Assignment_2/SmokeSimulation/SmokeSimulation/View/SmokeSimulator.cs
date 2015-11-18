using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SmokeSimulation.View
{
    class SmokeSimulator
    {
        private const int initialSmokeClouds = 40;

        private float currentTime;
        private float lastUpdate;

        private List<Smoke> smoke;
        private Random rand;

        //propery for smoke clouds
        public List<Smoke> getSmoke
        {
            get { return smoke; }
        }
        public SmokeSimulator()
        {
            //initiate a couple of smoke objects
            smoke = new List<Smoke>(61);
            rand = new Random();
            //initial smoke, more smoke spaws over time
            for (int i = 0; i < initialSmokeClouds; i++)
            {
                AddSmoke();
            }            
        }

        //generates a new smoke cloud once one has gone out, if the list capacity still isent filled a new smoke cloud is spawned.
        public void GenerateSmoke(float time)
        {
            currentTime = time / 1000;

            if (currentTime > lastUpdate)
            {
                float timeDiff = currentTime - lastUpdate;

                for (int i = 0; i < smoke.Count; i++)
                {
                    if (smoke[i].UpdateLocation(timeDiff))
                    {
                        smoke[i].GenerateNewCloudStats(rand);
                        if (smoke.Count < smoke.Capacity)
                        {
                            AddSmoke();
                        }
                    }
                }

                lastUpdate = currentTime;
            }
        }

        

        //adds a new smoke obj to the list
        public void AddSmoke()
        {
            Smoke s = new Smoke();
            s.GenerateNewCloudStats(rand);
            smoke.Add(s);
        }

        
    }
}
