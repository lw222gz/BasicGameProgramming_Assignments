using BallBounceGame.Model;
using BallBounceGame.View;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace BallBounceGame
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class MasterController : Game
    {
        GraphicsDeviceManager graphics;
        BallSimulation ballSimulation;
        BallView ballView;


        public MasterController()
        {
            graphics = new GraphicsDeviceManager(this);
            
            //default size;
            graphics.PreferredBackBufferWidth = 640;
            graphics.PreferredBackBufferHeight = 640;
            graphics.ApplyChanges();

            

            Content.RootDirectory = "Content";
            
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            // TODO: Add your initialization logic here

            base.Initialize();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            ballSimulation = new BallSimulation(GraphicsDevice);
            ballSimulation.CanTakeCommand = true;
            ballView = new BallView(GraphicsDevice, Content, ballSimulation);
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// game-specific content.
        /// </summary>
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            if (Keyboard.GetState().IsKeyDown(Keys.Escape)) { 
                Exit();
            }
            if (ballSimulation.CanTakeCommand)
            {        
                //small resolution
                if (Keyboard.GetState().IsKeyDown(Keys.S))
                {
                    graphics.PreferredBackBufferWidth = 320;
                    graphics.PreferredBackBufferHeight = 240;
                    graphics.ApplyChanges();

                    UpdateResolution();
                }
                //default resolution
                else if (Keyboard.GetState().IsKeyDown(Keys.D))
                {
                    graphics.PreferredBackBufferHeight = 640;
                    graphics.PreferredBackBufferWidth = 640;
                    graphics.ApplyChanges();

                    UpdateResolution();
                }
                //large resolution
                else if (Keyboard.GetState().IsKeyDown(Keys.F))
                {
                    graphics.PreferredBackBufferHeight = 900;
                    graphics.PreferredBackBufferWidth = 800;
                    graphics.ApplyChanges();

                    UpdateResolution();
                }
            }
            
            ballSimulation.Update(gameTime.TotalGameTime.TotalMilliseconds);          

            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Black);

            ballView.DrawGame();

            base.Draw(gameTime);
        }


        private void UpdateResolution()
        {
            ballSimulation.SetCoolDownForCommand();
            ballSimulation.UpdateGameResolution(GraphicsDevice);
            ballView.UpdateGameResolution(GraphicsDevice);
        }
    }
}
