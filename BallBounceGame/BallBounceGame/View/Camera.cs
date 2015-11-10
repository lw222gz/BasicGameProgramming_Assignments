using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BallBounceGame.View
{
    class Camera
    {

        private const int WallThickness = 5;
        private const int SpaceFromWindow = 10;

        private int VerticalWallLength;
        private int HorizontalWallLength;
        private int EWallX;
        private int SWallY;

        private GraphicsDevice device;


        public Camera(GraphicsDevice device)
        {
            UpdateGameResolutionData(device);
        }

        //Write formulas depending on window size
        public Rectangle GetWestWallCord()
        {
            return new Rectangle(SpaceFromWindow, SpaceFromWindow , WallThickness, VerticalWallLength);
        }

        public Rectangle GetEastWallCord()
        {
            return new Rectangle(EWallX, SpaceFromWindow, WallThickness, VerticalWallLength);
        }

        public Rectangle GetNorthWallCord()
        {
            return new Rectangle(SpaceFromWindow, SpaceFromWindow, HorizontalWallLength, WallThickness);
        }

        public Rectangle GetSouthWallCord()
        {
            return new Rectangle(SpaceFromWindow, SWallY, HorizontalWallLength, WallThickness);
        }

        internal Rectangle GetBallCord()
        {
            return new Rectangle(300, 300, 64, 64);
        }

        public void UpdateGameResolutionData(GraphicsDevice device)
        {
            this.device = device;
            VerticalWallLength = device.Viewport.Height - (2 * SpaceFromWindow);
            HorizontalWallLength = device.Viewport.Width - (2 * SpaceFromWindow);
            EWallX = device.Viewport.Width - SpaceFromWindow - WallThickness;
            SWallY = device.Viewport.Height - SpaceFromWindow - WallThickness;
            //set varibels for coordinates
        }
    }
}
