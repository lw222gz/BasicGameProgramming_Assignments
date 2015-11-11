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
        Texture2D BallTexture;
        Texture2D HorizontalWall;
        Texture2D VerticalWall;

        public BallView(GraphicsDevice device, ContentManager content, BallSimulation ballSimulation)
        {
            spriteBatch = new SpriteBatch(device);
            camera = new Camera(device, ballSimulation.WallThickness, ballSimulation.Dissort);
            this.ballSimulation = ballSimulation;

            BallTexture = content.Load<Texture2D>("Ball.png");
            HorizontalWall = content.Load<Texture2D>("WallHorizontal.png");
            VerticalWall = content.Load<Texture2D>("WallVertical.png");
        }


        public void DrawGame()
        {
            spriteBatch.Begin();

            //GetWallVisualCord take a Vextor2 as argument, the vectors X and Y values represent the starting point of the drawn picture (aka the top left corner.)
            //west wall
            spriteBatch.Draw(VerticalWall, camera.GetWallVisualCord(ballSimulation.WestWall), null, Color.White, 0, new Vector2(0,0), camera.GetVerticalWallScale(VerticalWall), SpriteEffects.None, 0f);
            //east wall
            spriteBatch.Draw(VerticalWall, camera.GetWallVisualCord(ballSimulation.EastWall), null, Color.White, 0, new Vector2(0, 0), camera.GetVerticalWallScale(VerticalWall), SpriteEffects.None, 0f);
            //north wall
            spriteBatch.Draw(HorizontalWall, camera.GetWallVisualCord(ballSimulation.NorthWall), null, Color.White, 0, new Vector2(0, 0), camera.GetHorizontalWallScale(HorizontalWall), SpriteEffects.None, 0f);
            //south wall
            spriteBatch.Draw(HorizontalWall, camera.GetWallVisualCord(ballSimulation.SouthWall), null, Color.White, 0, new Vector2(0, 0), camera.GetHorizontalWallScale(HorizontalWall), SpriteEffects.None, 0f);

            //draws the ball
            Ball ball = ballSimulation.getBall();
            spriteBatch.Draw(BallTexture, camera.GetBallVisualCord(BallTexture, ball), null, Color.White, 0, new Vector2(0,0), camera.GetBallScale(BallTexture, ball), SpriteEffects.None, 0f);
            
            spriteBatch.End();
        }

        internal void UpdateGameResolution(GraphicsDevice device)
        {
            this.camera.UpdateGameResolutionData(device);
        }
    }
}
