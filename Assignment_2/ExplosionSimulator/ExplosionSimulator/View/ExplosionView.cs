using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ExplosionSimulator.View
{
    class ExplosionView
    {

        private const int NumFramesX = 4;
        //this value is 8 because the sprite is taller than it is supposed to be, and by eye meassure I'd say 2 more rows of images could fit.
        private const int NumFramesY = 8;

        private Camera camera;
        private ExplosionUpdater explosionUpdater;

        private GraphicsDevice device;
        private ContentManager content;

        private Texture2D explosionTexture;

        private SpriteBatch spriteBatch;
        public ExplosionView(GraphicsDevice device, ContentManager content, ExplosionUpdater explosionUpdater)
        {
            this.explosionUpdater = explosionUpdater;
            this.device = device;
            this.content = content;
            camera = new Camera(device);
            spriteBatch = new SpriteBatch(device);

            explosionTexture = content.Load<Texture2D>("explosion.png");
        }


        public void Draw()
        {
            spriteBatch.Begin();
            int spriteXCord = (explosionTexture.Bounds.Width / NumFramesX) * explosionUpdater.FrameX;
            int spriteYCord = (explosionTexture.Bounds.Height / NumFramesY) * explosionUpdater.FrameY;

            //explosionTexture.Bounds.Width/NumFramesX, explosionTexture.Bounds.Height/NumFramesY
            spriteBatch.Draw(explosionTexture,
                             camera.GetVisualCords(new Vector2(0.5f, 0.5f), explosionTexture.Bounds.Width / NumFramesX, explosionTexture.Bounds.Height / NumFramesY),
                             new Rectangle(spriteXCord,
                                           spriteYCord, 
                                           explosionTexture.Bounds.Width / NumFramesX, 
                                           explosionTexture.Bounds.Height / NumFramesY),
                             Color.White,
                             0,
                             Vector2.Zero, 
                             1, 
                             SpriteEffects.None, 
                             0);

            spriteBatch.End();
        }
    }
}
