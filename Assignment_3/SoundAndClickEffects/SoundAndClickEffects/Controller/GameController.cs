using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Input;
using SoundAndClickEffects.View.ParticleSimulations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace SoundAndClickEffects.Controller
{
    class GameController
    {
        private bool CoolDown;
        List<Explosion> explosions;
        SoundEffect fireSoundEffect;

        private float ExplosionScale;

        public List<Explosion> Explosions
        {
            get { return explosions; }
        }
        public GameController(float ExplosionScale, ContentManager content)
        {
            CoolDown = true;
            this.ExplosionScale = ExplosionScale;
            explosions = new List<Explosion>(20);
            //this.fireSoundEffect = content.Load<SoundEffect>("fire.wav");
        }
        public void ReadMouse()
        {
            if (CoolDown && Mouse.GetState().LeftButton == ButtonState.Pressed)
            {
                CoolDown = false;
                explosions.Add(new Explosion(ExplosionScale, new Vector2(Mouse.GetState().X, Mouse.GetState().Y)));
                //fireSoundEffect.Play();
                CoolDownTimer();
            }          
        }

        public void CoolDownTimer()
        {
            //Resets the boolean after 500 milliseconds.
            //source: http://stackoverflow.com/questions/545533/c-sharp-delayed-function-calls
            System.Threading.Timer timer = null;
            timer = new Timer((obj) =>
            {
                ResetCoolDown();
                timer.Dispose();
            }, null, 250, Timeout.Infinite);
        }

        public void ResetCoolDown()
        {
            CoolDown = true;
        }
    }
}
