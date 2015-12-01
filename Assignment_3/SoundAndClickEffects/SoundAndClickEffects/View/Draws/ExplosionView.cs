using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using ParticleSimulation.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SmokeSimulation.View;
using SoundAndClickEffects.View.ParticleSimulations;

namespace SoundAndClickEffects.View
{
    class ExplosionView
    {

        private const int NumFramesX = 4;
        //this value is 8 because the sprite is taller than it is supposed to be, and by eye meassure I'd say 2 more rows of images could fit.
        private const int NumFramesY = 8;

        private float scale;

        private Camera camera;

        //refrences to textures, values are set in LoadContent method
        private Texture2D explosionTexture;
        private Texture2D particleTexture;
        private Texture2D smokeTexture;

        private SpriteBatch spriteBatch;
        public ExplosionView(SpriteBatch spriteBatch, Camera camera, ContentManager content, float explosionScale)
        {
            this.camera = camera;
            this.spriteBatch = spriteBatch;
            scale = explosionScale;

            LoadContent(content);
        }


        //draws an explosion, takes the scale of the explosion and an instance of the Explosion class as arguments
        public void DrawExplosions(Explosion explosion)
        {
            //cords for main explotion sprite
            int explosionWidth = explosionTexture.Bounds.Width / NumFramesX;
            int explosionHeight = explosionTexture.Bounds.Height / NumFramesY;

            //draw code begins
            spriteBatch.Begin();

            //draws after smoke for the explosion
            if (explosion.SmokeSimulator.getSmoke != null)
            {
                foreach (Smoke s in explosion.SmokeSimulator.getSmoke)
                {
                    spriteBatch.Draw(smokeTexture,
                                    explosion.Location,
                                    null,
                                    new Color(s.Fade, s.Fade, s.Fade, s.Fade),
                                    s.Rotation,
                                    new Vector2(smokeTexture.Bounds.Width / 2, smokeTexture.Bounds.Height / 2),
                                    s.Size * scale,

                                    SpriteEffects.None,
                                    0);
                }
            }

            //draws the explosions splitters
            //, particleTexture.Bounds.Width * 0.1f * scale, particleTexture.Bounds.Height * 0.1f * scale
            if (explosion.SplitterSystem.Particles != null)
            {
                foreach (SplitterParticle p in explosion.SplitterSystem.Particles)
                {
                    spriteBatch.Draw(particleTexture,
                                     camera.GetVisualCords(p.Position) + explosion.Location,
                                     null,
                                     Color.White,
                                     0,
                                     new Vector2(0, 0),
                                     scale * 0.1f * p.Size,
                                     SpriteEffects.None,
                                     0);
                }
            }

            //draws the main explosion, I draw it last so it shows above all other particles.
            spriteBatch.Draw(explosionTexture,
                             explosion.Location,
                             new Rectangle(explosionWidth * explosion.ExplosionUpdater.FrameX,
                                           explosionHeight * explosion.ExplosionUpdater.FrameY,
                                           explosionWidth,
                                           explosionHeight),
                             Color.White,
                             0,
                             new Vector2(explosionWidth / 2, explosionHeight / 2),
                             scale,
                             SpriteEffects.None,
                             0);   

            spriteBatch.End();
            //draw code ends
        }

        //loads all textures
        private void LoadContent(ContentManager content)
        {
            explosionTexture = content.Load<Texture2D>("explosion.png");
            particleTexture = content.Load<Texture2D>("spark.png");
            smokeTexture = content.Load<Texture2D>("particlesmoke.png");
        }
    }
}