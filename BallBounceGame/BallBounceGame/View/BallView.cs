using BallBounceGame.Model;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BallBounceGame.View
{
    class BallView
    {

        private SpriteBatch spriteBatch;
        private Camera camera;
        private BallSimulation ballSimulation;
        Texture2D Ball;
        Texture2D HorizontalWall;
        Texture2D VerticalWall;

        public BallView(GraphicsDevice device, ContentManager content, BallSimulation ballSimulation)
        {
            spriteBatch = new SpriteBatch(device);
            camera = new Camera(device);
            this.ballSimulation = ballSimulation;

            Ball = content.Load<Texture2D>("Ball.png");
            HorizontalWall = content.Load<Texture2D>("WallHorizontal.png");
            VerticalWall = content.Load<Texture2D>("WallVertical.png");
        }


        public void DrawGame()
        {
            spriteBatch.Begin(); 
            //draws the walls
            spriteBatch.Draw(HorizontalWall, camera.GetWestWallCord(), Color.White);
            spriteBatch.Draw(HorizontalWall, camera.GetEastWallCord(), Color.White);
            spriteBatch.Draw(VerticalWall, camera.GetNorthWallCord(), Color.White);
            spriteBatch.Draw(VerticalWall, camera.GetSouthWallCord(), Color.White);

            //draws the ball
            Ball b = ballSimulation.getBall();
            spriteBatch.Draw(Ball, b.BallCord, Color.White);
            
            spriteBatch.End();
        }

        internal void UpdateGameResolution(GraphicsDevice device)
        {
            this.camera.UpdateGameResolutionData(device);
        }
    }
}
