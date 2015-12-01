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

        private int aimX;
        private int aimY;
        private int aimSizeX;
        private int aimSizeY;

        //initiates other views
        public MainView(GraphicsDevice device, ContentManager content, BallSimulation ballSimulation, float ExplosionScale, float aimRadius)
        {
            this.device = device;
            spriteBatch = new SpriteBatch(device);
            camera = new Camera(device);

            explosionView = new ExplosionView(spriteBatch, camera, content, ExplosionScale);
            ballView = new BallView(spriteBatch, camera, content, ballSimulation);

            aim = content.Load<Texture2D>("Aim.png");

            aimSizeX = (int)(device.Viewport.Width * (aimRadius * 2));
            aimSizeY = (int)(device.Viewport.Height * (aimRadius * 2));         
        }

        //- calls the draw functions in BallView and ExplosionView classes
        //- draws the aim for the player.
        public void DrawGame(List<Explosion> explosions)
        {         
            
            ballView.DrawBalls();

            foreach (Explosion explosion in explosions)
            {
                explosionView.DrawExplosions(explosion);
            }


            //position of the aim
            aimX = Mouse.GetState().X - aimSizeX / 2;
            aimY = Mouse.GetState().Y - aimSizeY / 2;

            spriteBatch.Begin();

            spriteBatch.Draw(aim, 
                            new Rectangle(aimX, aimY, aimSizeX, aimSizeY), 
                            Color.White);

            spriteBatch.End();
        }


        //call on a camera function that turns the mouse visual coords to  logical coords and returns it.
        public Vector2 GetLogicalHitCords(Vector2 explosionLocation)
        {
            return camera.GetLogicalCords(explosionLocation);
        }
    }
}
