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
        //if true then a new explosion can be created by the player
        private bool CoolDown;
        //list of all explosion
        List<Explosion> explosions;
        //sound effect for the explosion
        SoundEffect fireSoundEffect;

        //represents the location of a new explosion
        private Vector2 explosionLocation;
        
        //recives a value from the MasterController, value represents the size of the explosion
        private float ExplosionScale;

        //properties for private varibles START
        public List<Explosion> Explosions
        {
            get { return explosions; }
        }
        public Vector2 ExplosionLocation
        {
            get { return explosionLocation; }
        }
        //--- properties for private varibles END


        public GameController(float ExplosionScale, ContentManager content)
        {
            CoolDown = true;
            this.ExplosionScale = ExplosionScale;
            explosions = new List<Explosion>(20);
            //Note to self: How to load in sound
            //double click on Content.mgcb
            //Edit -> Add -> Exsiting Item
            //Chose the file and save.
            this.fireSoundEffect = content.Load<SoundEffect>("fire");
        }

        //returns true if the user has initiated a new explosion
        public bool ReadMouse()
        {
            if (CoolDown && Mouse.GetState().LeftButton == ButtonState.Pressed)
            {
                CoolDown = false;
                explosionLocation = new Vector2(Mouse.GetState().X, Mouse.GetState().Y);
                explosions.Add(new Explosion(ExplosionScale, explosionLocation));
                fireSoundEffect.Play();
                CoolDownTimer();
                return true;
            }
            return false;
        }

        //resets explosion cooldown START
        public void CoolDownTimer()
        {
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
        //--resets explosion cooldown END


        //removes an explosion, is called if a explosion has lasted more than 2 seconds.
        //(the entire visual effect for an explosion lasts for about 1 to 1.5 seconds at max.)
        public void RemoveExplosion(Explosion explosion)
        {
            explosions.Remove(explosion);
        }
    }
}
