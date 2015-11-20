using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SmokeSimulation.View
{
    class SmokeSimulator
    {
        private const int amountOfSmoke = 60;

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
            smoke = new List<Smoke>(amountOfSmoke);
            rand = new Random();

            //initial smoke, the spawns even up over time.
            for (int i = 0; i < smoke.Capacity; i++)
            {
                Smoke s = new Smoke();
                s.GenerateNewCloudStats(rand);
                smoke.Add(s);
            }      
        }

        //generates a new smoke cloud once one has gone out, if the list capacity still isent filled a new smoke cloud is spawned.
        public void GenerateSmoke(float time)
        {
            currentTime = time;

            if (currentTime > lastUpdate)
            {
                float timeDiff = currentTime - lastUpdate;

                for (int i = 0; i < smoke.Count; i++)
                {
                    //if UpdateSmoke returns true then the smokes lifespan has passed it's limit, thus it's stats are refreshed.
                    if (smoke[i].UpdateSmoke(timeDiff))
                    {
                        smoke[i].GenerateNewCloudStats(rand);                       
                    }
                }

                lastUpdate = currentTime;
            }
        }     
    }
}
