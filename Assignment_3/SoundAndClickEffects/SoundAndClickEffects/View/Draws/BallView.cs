using BallBounceGame.Model;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using SoundAndClickEffects.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BallBounceGame.View
{
    class BallView
    {
        //The logical cords for the walls, these cords represent the STARTING point for being drawn (aka the top left corner)
        private Vector2 northWall = new Vector2(0, 0);
        private Vector2 eastWall = new Vector2(1, 0);
        private Vector2 southWall = new Vector2(0, 1);
        private Vector2 westWall = new Vector2(0, 0);

        private SpriteBatch spriteBatch;
        private Camera camera;
        private BallSimulation ballSimulation;

        //vector2 representing the scale of the balls, gets value from method in camera.
        private Vector2 ballScale;

        //list of balls in the game, value of the list is read from the model
        private List<Ball> balls;
        //texture refrences. Gets their values in LoadContent method.
        private Texture2D BallTexture;
        private Texture2D HorizontalWall;
        private Texture2D VerticalWall;

        //sets values to the private object varibles.
        public BallView(SpriteBatch spriteBatch, Camera camera, ContentManager content, BallSimulation ballSimulation)
        {
            this.spriteBatch = spriteBatch;
            this.camera = camera;
            this.ballSimulation = ballSimulation;

            balls = ballSimulation.getBalls();
            

            //Loads all textures for this view
            LoadContent(content);
        }


        public void DrawBalls()
        {
            spriteBatch.Begin();

            //west wall
            spriteBatch.Draw(VerticalWall, camera.GetWallVisualCord(westWall), null, Color.White, 0, new Vector2(0,0), camera.GetVerticalWallScale(VerticalWall), SpriteEffects.None, 0f);
            //east wall
            spriteBatch.Draw(VerticalWall, camera.GetWallVisualCord(eastWall), null, Color.White, 0, new Vector2(0, 0), camera.GetVerticalWallScale(VerticalWall), SpriteEffects.None, 0f);
            //north wall
            spriteBatch.Draw(HorizontalWall, camera.GetWallVisualCord(northWall), null, Color.White, 0, new Vector2(0, 0), camera.GetHorizontalWallScale(HorizontalWall), SpriteEffects.None, 0f);
            //south wall
            spriteBatch.Draw(HorizontalWall, camera.GetWallVisualCord(southWall), null, Color.White, 0, new Vector2(0, 0), camera.GetHorizontalWallScale(HorizontalWall), SpriteEffects.None, 0f);

            //draws the balls       
            foreach (Ball b in balls)
            {
                ballScale = camera.GetBallScale(BallTexture, b.BallLogicRadius);

                spriteBatch.Draw(BallTexture, 
                                 camera.GetVisualCords(b.BallLogicCords), 
                                 null, 
                                 new Color(b.Fade, b.Fade, b.Fade, b.Fade), 
                                 0,
                                 new Vector2((BallTexture.Bounds.Width * ballScale.X) / 2, (BallTexture.Bounds.Height * ballScale.Y) / 2), 
                                 ballScale, 
                                 SpriteEffects.None, 
                                 0f);
            }
            
            
            spriteBatch.End();
        }

        //Loads in all textures to private varibles
        private void LoadContent(ContentManager content)
        {
            BallTexture = content.Load<Texture2D>("Ball.png");
            HorizontalWall = content.Load<Texture2D>("WallHorizontal.png");
            VerticalWall = content.Load<Texture2D>("WallVertical.png");
        }
    }
}
