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

        private int WallThickness = 5;
        private int Dissort = 10;

        

        private GraphicsDevice device;


        public Camera(GraphicsDevice device)
        {
            UpdateGameResolutionData(device);
        }     

        public void UpdateGameResolutionData(GraphicsDevice device)
        {
            this.device = device;
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
            else {
                x = (device.Viewport.Width * StartDrawPoint.X) + Dissort;
                y = (device.Viewport.Height * StartDrawPoint.Y) + Dissort;
            }

            return new Vector2(x, y);
        }



        //returns a vector2 of the scale for a vertical wall
        public Vector2 GetVerticalWallScale(Texture2D wall)
        {
            float scale = (device.Viewport.Height - (float)Dissort * 2) / wall.Bounds.Height;
            //first value is 1 because it represents the wall thickness, wich allways stays the same
            return new Vector2(1, scale);
        }
        //returns a vector2 of the scale for a horizontal wall
        public Vector2 GetHorizontalWallScale(Texture2D wall)
        {
            float scale = (device.Viewport.Width - (float)Dissort * 2) / wall.Bounds.Width;
            //second value is 1 because it represents the wall thickness, wich allways stays the same
            return new Vector2(scale, 1);
        }


        //returns a vector2 of the ball scale(depends on resolution)
        public Vector2 GetBallScale(Texture2D ballTexture, Ball ball)
        {
            float x = ((device.Viewport.Width - (float)Dissort * 2) * ball.BallLogicDiameter) / ballTexture.Bounds.Width;
            float y = ((device.Viewport.Height - (float)Dissort * 2) * ball.BallLogicDiameter) / ballTexture.Bounds.Height;
            return new Vector2(x, y);
        }

        //returns a vector2 with the balls logical cord
        public Vector2 GetBallVisualCord(Texture2D ballTexture, Ball ball)
        {
            Vector2 scale = GetBallScale(ballTexture, ball);
            float ballW = ballTexture.Bounds.Width * scale.X;
            float ballH = ballTexture.Bounds.Height * scale.Y;

            /* DESCRIPTION FOR ROWS 119-123
             * 
            //the ball allways goes in a linear directions thus I used y = kx + m
            //to decide the X and Y coordinates.
            //calculation x-Coordinate example:
            // Y = Wallthickness + Dissort;
            // Y is the lower possible X cord
             * 
            // X = device.Viewport.Width - ballW - Dissort - WallThickness;
            // X is the highest possible X cord for the ball
             * 
            //these points are an example in the 640x640 screen size. 
            // X = 563
            // Y = 15;
            //point A = (0, Y)  15 is the lower possible X cord because the dissort and wallthickness are constants
            //point B = (1, X) 
            //delta of Y cords divided by the delta of the X cords:
            // 563 - 15 / 1 - 0 = 548 / 1 = 548, k = 548
             * 
            //since the X cords will allways be the same (1 and 0, thus it will allways divide by 1) I can break the formula down to:
            //k = X - Y;
             * 
            //Then for the value m
            // 15 = 543 * 0 + m;
            // 15 = m
             * 
            // and in turn m will allways be m = Y because when x = 0 then m MUST be the value of the lowest possible cord
            // so m = Dissort + WallThickness
             * 
             * */
            float m = Dissort + WallThickness;
            float kX = (device.Viewport.Width - ballW - Dissort - WallThickness) - (Dissort + WallThickness);
            float kY = (device.Viewport.Height - ballH - Dissort - WallThickness) - (Dissort + WallThickness);
            float x = (kX * ball.BallLogicCords.X) + m;
            float y = (kY * ball.BallLogicCords.Y) + m;


            return new Vector2(x, y);
        }
    }
}
