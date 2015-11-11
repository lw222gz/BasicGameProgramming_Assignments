using BallBounceGame.Model;
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

        private int WallThickness;
        private int Dissort;

        

        private GraphicsDevice device;


        public Camera(GraphicsDevice device, int WallThickness, int Dissort)
        {
            this.WallThickness = WallThickness;
            this.Dissort = Dissort;
            UpdateGameResolutionData(device);
        }     

        public void UpdateGameResolutionData(GraphicsDevice device)
        {
            this.device = device;
            /*private int VerticalWallLength;
        private int HorizontalWallLength;
        private int EWallX;
        private int SWallY;
            VerticalWallLength = device.Viewport.Height - (2 * SpaceFromWindow);
            HorizontalWallLength = device.Viewport.Width - (2 * SpaceFromWindow);
            EWallX = device.Viewport.Width - SpaceFromWindow - WallThickness;
            SWallY = device.Viewport.Height - SpaceFromWindow - WallThickness;*/
            //set varibels for coordinates
        }

        //Param: Vector2 containg the X and Y START locations for the wall to be drawn on.
        public Vector2 GetWallVisualCord(Vector2 Start)
        {
            float x;
            float y;
            if (Start.X == 1)
            {
                x = (device.Viewport.Width * Start.X) - Dissort - WallThickness;
                y = (device.Viewport.Height * Start.Y) + Dissort;
            }
            else if (Start.Y == 1)
            {
                x = (device.Viewport.Width * Start.X) + Dissort;
                y = (device.Viewport.Height * Start.Y) - Dissort - WallThickness;
            }
            else {
                x = (device.Viewport.Width * Start.X) + Dissort;
                y = (device.Viewport.Height * Start.Y) + Dissort;
            }

            return new Vector2(x, y);
        }



        public Vector2 GetVerticalWallScale(Texture2D wall)
        {
            float scale = (device.Viewport.Height - (float)Dissort * 2) / wall.Bounds.Height;
            //first value is 1 because it represents the wall thickness, wich allways stays the same
            return new Vector2(1, scale);
        }

        public Vector2 GetHorizontalWallScale(Texture2D wall)
        {
            float scale = (device.Viewport.Width - (float)Dissort * 2) / wall.Bounds.Width;
            //second value is 1 because it represents the wall thickness, wich allways stays the same
            return new Vector2(scale, 1);
        }


        public Vector2 GetBallScale(Texture2D ballTexture, Ball ball)
        {
            float x = ((device.Viewport.Width - (float)Dissort * 2) * ball.BallLogicDiameter) / ballTexture.Bounds.Width;
            float y = ((device.Viewport.Height - (float)Dissort * 2) * ball.BallLogicDiameter) / ballTexture.Bounds.Height;
            return new Vector2(x, y);
        }

        public Vector2 GetBallVisualCord(Texture2D ballTexture, Ball ball)
        {
            Vector2 a = new Vector2(0.073f, 0.03f);
            Vector2 scale = GetBallScale(ballTexture, ball);
            float ballW = ballTexture.Bounds.Width * scale.X;
            float ballH = ballTexture.Bounds.Height * scale.Y;
            float x = ball.BallLogicCords.X * (float)(device.Viewport.Width - (float)Dissort * 2);//
            float y = ball.BallLogicCords.Y * (float)(device.Viewport.Height - (float)Dissort * 2);
            x -= ballW / 2;
            y -= ballH / 2;

            return new Vector2(x, y);
        }
    }
}
