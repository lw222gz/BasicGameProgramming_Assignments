using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SoundAndClickEffects.Model
{
    class PlayerAim
    {
        //to follow MVC I made a class for the aim radius, thus the view only reads from the model and the model doesnt read from the view.
        private const float aimRadius = 0.1f;

        public float AimRadius
        {
            get { return aimRadius; }
        }
    }
}
