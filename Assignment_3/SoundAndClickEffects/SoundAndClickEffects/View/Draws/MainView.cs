using BallBounceGame.Model;
using BallBounceGame.View;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
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

        public MainView(GraphicsDevice device, ContentManager content, BallSimulation ballSimulation)
        {
            spriteBatch = new SpriteBatch(device);
            camera = new Camera(device);

            explosionView = new ExplosionView(spriteBatch, camera, );
            ballView = new BallView(spriteBatch, camera, ballSimulation);
        }

        
        public void DrawGame()
        {

        }
    }
}
