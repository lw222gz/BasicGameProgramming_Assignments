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
        private int chessBackgroundSize = 640;
        private int tileSize = 64;
        private ChessModel chessModel;

        public Camera(GraphicsDevice device, ChessModel chessModel)
        {
            this.device = device;
            this.chessModel = chessModel;
        }

        public Vector2 GetBackgroundVectorPos() {
            int x = (this.device.Viewport.Width - chessBackgroundSize) / 2;
            int y = (this.device.Viewport.Height - chessBackgroundSize) / 2;

            return new Vector2(x, y);
        }

        internal Vector2 GetVisualCords(int x, int y)
        {
            //origin Pos is the cords for the top left square. (position of background + 64px indent.)
            Vector2 originPos = GetBackgroundVectorPos() + new Vector2(64,64);

            Vector2 TilePosition = originPos;
            if (!this.chessModel.IsTableTurned)
            {                
                TilePosition.X = tileSize * x + originPos.X;               
                TilePosition.Y = tileSize * y + originPos.Y;               
            }
            else
            {
                //FORMULA: (7-x) * 64 + p = y
                TilePosition.X = (7 - x) * tileSize + originPos.X;
                TilePosition.Y = (7 - y) * tileSize + originPos.Y;               
            }
            

            return TilePosition;
        }
    }
}
