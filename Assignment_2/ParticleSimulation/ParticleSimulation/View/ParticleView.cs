using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ParticleSimulation.View
{
    class ParticleView
    {
        SplitterSystem splitterSystem;
        Camera camera;
        SpriteBatch spriteBatch;
        Texture2D particleTexture;

        //initiate the spriteBatch, store a refreance to the splitterSystem class, 
        //initiate the camera class and loads the texture.
        public ParticleView(GraphicsDevice device, ContentManager content, SplitterSystem splitterSystem)
        {
            spriteBatch = new SpriteBatch(device);

            this.splitterSystem = splitterSystem;

            camera = new Camera(device);

            particleTexture = content.Load<Texture2D>("Particle.png");
        }

        //draw all particles
        public void Draw()
        {
            spriteBatch.Begin();

            foreach (SplitterParticle p in splitterSystem.Particles)
            {
                spriteBatch.Draw(particleTexture, camera.getParticleVisualCord(p.Position), null, Color.White, 0 , new Vector2(0,0), 0.1f, SpriteEffects.None, 0);
            }   

            spriteBatch.End();
        }
    }
}
