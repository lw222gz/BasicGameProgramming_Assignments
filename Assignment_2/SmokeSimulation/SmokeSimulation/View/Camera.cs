using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SmokeSimulation.View
{
    class Camera
    {
        GraphicsDevice device;
        public Camera(GraphicsDevice device)
        {
            this.device = device;
        }

        //returns visual coordinates for a cloud
        public Vector2 getSmokeVisualPosition(Vector2 logicalPos, Texture2D smokeTexture)
        {
            return new Vector2((logicalPos.X * device.Viewport.Width) - smokeTexture.Bounds.Width/2,
                               (logicalPos.Y * device.Viewport.Height) - smokeTexture.Bounds.Height/2);
        }
    }
}
