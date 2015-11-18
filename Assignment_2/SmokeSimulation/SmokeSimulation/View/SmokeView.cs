using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SmokeSimulation.View
{
    class SmokeView
    {
        Camera camera;
        SmokeSimulator smokeSimulator;
        SpriteBatch spriteBatch;       
        Texture2D smokeTexture;
        
        public SmokeView(GraphicsDevice device, ContentManager content, SmokeSimulator smokeSimulator)
        {
            this.smokeSimulator = smokeSimulator;
            spriteBatch = new SpriteBatch(device);
            camera = new Camera(device);
            smokeTexture = content.Load<Texture2D>("particlesmoke.png");
        }

        public void Draw()
        {
            spriteBatch.Begin();

            foreach (Smoke s in this.smokeSimulator.getSmoke)
            {
                spriteBatch.Draw(smokeTexture, 
                                camera.getSmokeVisualPosition(s.Position, smokeTexture), 
                                null,
                                new Color(s.Fade, s.Fade, s.Fade, s.Fade), 
                                s.Rotation,
                                new Vector2(smokeTexture.Bounds.Width/2, smokeTexture.Bounds.Height/2),
                                s.Size, 
                                SpriteEffects.None,
                                0);
            }
            

            spriteBatch.End();
        }
    }
}
