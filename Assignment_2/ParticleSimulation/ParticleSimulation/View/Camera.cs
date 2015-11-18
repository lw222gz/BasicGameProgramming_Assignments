using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ParticleSimulation.View
{
    class Camera
    {
        private GraphicsDevice device;
        public Camera(GraphicsDevice device)
        {
            this.device = device;
        }

        public Vector2 getExposionOrigin()
        {
            return new Vector2(this.device.Viewport.Width / 2, this.device.Viewport.Height / 2);
        }
        public Vector2 getVisualCords(Vector2 logicPos)
        {
            float x = logicPos.X * device.Viewport.Width;
            float y = logicPos.Y * device.Viewport.Height;
            return new Vector2(x, y);
        }

        public Vector2 getParticleVisualCord(Vector2 particlePos)
        {
            return getExposionOrigin() + getVisualCords(particlePos);
        }
    }
}
