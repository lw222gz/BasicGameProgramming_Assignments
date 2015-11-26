using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SoundAndClickEffects.View
{
    class Camera
    {
        private GraphicsDevice device;

        public Camera(GraphicsDevice device)
        {
            this.device = device;
        }

        public Vector2 getExplosionLogicalOrigin()
        {
            return new Vector2(0.5f, 0.5f);
        }

        public Vector2 GetVisualCords(Vector2 logicalCords, float imageWidth, float imageHeight)
        {
            return new Vector2((this.device.Viewport.Width * logicalCords.X) - imageWidth / 2,
                                (this.device.Viewport.Height * logicalCords.Y) - imageHeight / 2);
        }
    }
}