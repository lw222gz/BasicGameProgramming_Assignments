using BallBounceGame.Model;
using BallBounceGame.View;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
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
        private GraphicsDevice device;

        private Texture2D aim;
        private float aimRadius = 0.1f;
        private float ExplosionScale;

        public float AimRadius
        {
            get { return aimRadius; }
        }

        public MainView(GraphicsDevice device, ContentManager content, BallSimulation ballSimulation, float ExplosionScale)
        {
            this.device = device;
            spriteBatch = new SpriteBatch(device);
            camera = new Camera(device);

            explosionView = new ExplosionView(spriteBatch, camera, content);
            ballView = new BallView(spriteBatch, camera, content, ballSimulation);

            this.ExplosionScale = ExplosionScale;


            aim = content.Load<Texture2D>("Aim.png");
        }

        
        public void DrawGame(List<Explosion> explosions)
        {         
            
            ballView.DrawBalls();

            foreach (Explosion explosion in explosions)
            {
                explosionView.DrawExplosions(ExplosionScale, explosion);
            }

            int sizeX = (int)(device.Viewport.Width * (aimRadius*2));
            int sizeY = (int)(device.Viewport.Height * (aimRadius*2));
            int x = Mouse.GetState().X - sizeX / 2;
            int y = Mouse.GetState().Y - sizeY / 2;

            spriteBatch.Begin();

            //draws the aim circle around the mouse
            spriteBatch.Draw(aim, 
                            new Rectangle(x , y, sizeX, sizeY), 
                            Color.White);

            spriteBatch.End();
        }






        public Vector2 GetLocalHitCords(Vector2 explosionLocation)
        {
            return camera.GetLogicalCords(explosionLocation);
        }
    }
}
