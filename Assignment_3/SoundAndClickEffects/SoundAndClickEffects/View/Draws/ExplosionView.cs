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

        private Camera camera;

        private Texture2D explosionTexture;
        private Texture2D particleTexture;
        private Texture2D smokeTexture;

        private SpriteBatch spriteBatch;
        public ExplosionView(SpriteBatch spriteBatch, Camera camera, ContentManager content)
        {
            this.camera = camera;

            this.spriteBatch = spriteBatch;

            explosionTexture = content.Load<Texture2D>("explosion.png");
            particleTexture = content.Load<Texture2D>("spark.png");
            smokeTexture = content.Load<Texture2D>("particlesmoke.png");
        }


        public void DrawExplosions(float scale, Explosion explosion)
        {
            //cords for main explotion sprite
            int spriteXCord = (explosionTexture.Bounds.Width / NumFramesX) * explosion.ExplosionUpdater.FrameX;
            int spriteYCord = (explosionTexture.Bounds.Height / NumFramesY) * explosion.ExplosionUpdater.FrameY;

            //draw code begins
            spriteBatch.Begin();

            //draws after smoke for the explosion
            if (explosion.SmokeSimulator.getSmoke != null)
            {
                foreach (Smoke s in explosion.SmokeSimulator.getSmoke)
                {
                    spriteBatch.Draw(smokeTexture,
                                    camera.GetVisualCords(s.Position, smokeTexture.Bounds.Width * scale, smokeTexture.Bounds.Height * scale) + explosion.Location,
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
            if (explosion.SplitterSystem.Particles != null)
            {
                foreach (SplitterParticle p in explosion.SplitterSystem.Particles)
                {
                    spriteBatch.Draw(particleTexture,
                                     camera.GetVisualCords(p.Position, particleTexture.Bounds.Width * 0.1f * scale, particleTexture.Bounds.Height * 0.1f * scale) + explosion.Location,
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
                             camera.GetVisualCords(new Vector2(0, 0), (explosionTexture.Bounds.Width / NumFramesX) * scale, (explosionTexture.Bounds.Height / NumFramesY) * scale) + explosion.Location,
                             new Rectangle(spriteXCord,
                                           spriteYCord,
                                           explosionTexture.Bounds.Width / NumFramesX,
                                           explosionTexture.Bounds.Height / NumFramesY),
                             Color.White,
                             0,
                             Vector2.Zero,
                             scale,
                             SpriteEffects.None,
                             0);   

            spriteBatch.End();
            //draw code ends
        }
    }
}