using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Labb1ChessGame
{
    class Camera
    {
        private GraphicsDevice device;
        private ChessModel chessModel;

        //values for the chessboard size and tile sizes.
        //I use int because I want a whole value.
        private int chessBackgroundSizeX;
        private int chessBackgroundSizeY;
        private int tileSizeX;
        private int tileSizeY;
        

        public Camera(GraphicsDevice device, ChessModel chessModel)
        {
            this.device = device;
            this.chessModel = chessModel;
            UpdateResolutionValues();
        }

        //returns a Rectangle obj containg background cords and size.
        public Rectangle GetBackgroundVectorPos() {
            return new Rectangle(device.Viewport.Width/2 - chessBackgroundSizeX/2, 
                                 device.Viewport.Height/2 - chessBackgroundSizeY/2, 
                                 chessBackgroundSizeX, 
                                 chessBackgroundSizeY);
        }

        //returns a Rectangle obj containg tile cords and size.
        internal Rectangle GetVisualCords(int x, int y)
        {
            //origin Pos is the cords for the top left square. (position of background + pixel indent.)
            Rectangle originPos = GetBackgroundVectorPos();
            originPos.X += tileSizeX;
            originPos.Y += tileSizeY;

            if (!this.chessModel.IsTableTurned)
            {
                return new Rectangle(tileSizeX * x + originPos.X, 
                                     tileSizeY * y + originPos.Y, 
                                     tileSizeX, 
                                     tileSizeY);             
            }
            else
            {
                return new Rectangle((7 - x) * tileSizeX + originPos.X, 
                                     (7 - y) * tileSizeY + originPos.Y, 
                                     tileSizeX, 
                                     tileSizeY);            
            }          
        }

        //updates the game device with the new game window values.
        public void UpdateGameResolution(GraphicsDevice device)
        {
            this.device = device;
            UpdateResolutionValues();
        }

        private void UpdateResolutionValues()
        {
            int lowest;
            if (device.Viewport.Height >= device.Viewport.Width)
            {
                lowest = device.Viewport.Width;
            }
            else
            {
                lowest = device.Viewport.Height;
            }
            tileSizeX = lowest / 10;
            tileSizeY = lowest / 10;
            chessBackgroundSizeX = lowest;
            chessBackgroundSizeY = lowest;
        }
    }
}
