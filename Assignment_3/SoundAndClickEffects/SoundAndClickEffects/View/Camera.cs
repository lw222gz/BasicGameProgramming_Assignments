using BallBounceGame.Model;
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
        //I have these as floats because they are used in calculations with float values
        private float Dissort = 10;
        private float WallThickness = 5;

        private GraphicsDevice device;

        public Camera(GraphicsDevice device)
        {
            this.device = device;
        }

        //returns visual cords for a picture
        public Vector2 GetVisualCords(Vector2 logicalCords, float imageWidth, float imageHeight)
        {
            return new Vector2((this.device.Viewport.Width * logicalCords.X) - imageWidth / 2,
                                (this.device.Viewport.Height * logicalCords.Y) - imageHeight / 2);
        }

        //Param: Vector2 containg the X and Y START locations for the wall to be drawn on.
        //returns a vector2 with the visual coordinates for a wall.
        public Vector2 GetWallVisualCord(Vector2 StartDrawPoint)
        {
            float x;
            float y;
            if (StartDrawPoint.X == 1)
            {
                x = (device.Viewport.Width * StartDrawPoint.X) - Dissort - WallThickness;
                y = (device.Viewport.Height * StartDrawPoint.Y) + Dissort;
            }
            else if (StartDrawPoint.Y == 1)
            {
                x = (device.Viewport.Width * StartDrawPoint.X) + Dissort;
                y = (device.Viewport.Height * StartDrawPoint.Y) - Dissort - WallThickness;
            }
            else
            {
                x = (device.Viewport.Width * StartDrawPoint.X) + Dissort;
                y = (device.Viewport.Height * StartDrawPoint.Y) + Dissort;
            }

            return new Vector2(x, y);
        }

        //returns the visual cords for a ball
        public Vector2 GetBallVisualCord(Texture2D ballTexture, Ball ball)
        {
            Vector2 scale = GetBallScale(ballTexture, ball);
            float ballW = ballTexture.Bounds.Width * scale.X;
            float ballH = ballTexture.Bounds.Height * scale.Y;

            float m = Dissort + WallThickness;
            float kX = (device.Viewport.Width - ballW - Dissort - WallThickness) - (Dissort + WallThickness);
            float kY = (device.Viewport.Height - ballH - Dissort - WallThickness) - (Dissort + WallThickness);
            float x = (kX * ball.BallLogicCords.X) + m;
            float y = (kY * ball.BallLogicCords.Y) + m;


            return new Vector2(x, y);
        }

        //returns a vector2 with the scale for a ball in x and y led
        public Vector2 GetBallScale(Texture2D ballTexture, Ball ball)
        {
            float x = ((device.Viewport.Width - (float)Dissort * 2) * ball.BallLogicDiameter) / ballTexture.Bounds.Width;
            float y = ((device.Viewport.Height - (float)Dissort * 2) * ball.BallLogicDiameter) / ballTexture.Bounds.Height;
            return new Vector2(x, y);
        }

        internal Vector2 GetVerticalWallScale(Texture2D VerticalWall)
        {
            float scale = (device.Viewport.Height - (float)Dissort * 2) / VerticalWall.Bounds.Height;
            //first value is 1 because it represents the wall thickness, wich allways stays the same
            return new Vector2(1, scale);
        }

        internal Vector2 GetHorizontalWallScale(Texture2D HorizontalWall)
        {
            float scale = (device.Viewport.Width - (float)Dissort * 2) / HorizontalWall.Bounds.Width;
            //second value is 1 because it represents the wall thickness, wich allways stays the same
            return new Vector2(scale, 1);
        }
    }
}