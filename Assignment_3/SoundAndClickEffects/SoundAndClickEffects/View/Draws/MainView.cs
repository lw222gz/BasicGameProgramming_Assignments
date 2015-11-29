using BallBounceGame.Model;
using BallBounceGame.View;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using SoundAndClickEffects.View.ParticleSimulations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SoundAndClickEffects.View.Draws
{
    //this class controls the other views and calls their draw functions to draw their graphics
    class MainView
    {
        private SpriteBatch spriteBatch;
        private Camera camera;
        private ExplosionView explosionView;
        private BallView ballView;

        private float ExplosionScale;

        public MainView(GraphicsDevice device, ContentManager content, BallSimulation ballSimulation, float ExplosionScale)
        {
            spriteBatch = new SpriteBatch(device);
            camera = new Camera(device);

            explosionView = new ExplosionView(spriteBatch, camera, content);
            ballView = new BallView(spriteBatch, camera, content, ballSimulation);

            this.ExplosionScale = ExplosionScale;
        }

        
        public void DrawGame(List<Explosion> explosions)
        {
            foreach (Explosion explosion in explosions)
            {
                explosionView.DrawExplosions(ExplosionScale, explosion);
            }
        }
    }
}
