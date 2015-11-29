using SoundAndClickEffects.View;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Timers;
using ParticleSimulation.View;
using SmokeSimulation.View;
using SoundAndClickEffects.View.Draws;
using BallBounceGame.Model;
using SoundAndClickEffects.View.ParticleSimulations;
using System.Collections.Generic;
using SoundAndClickEffects.Controller;
using Microsoft.Xna.Framework.Audio;

namespace SoundAndClickEffects
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class MasterController : Game
    {
        GraphicsDeviceManager graphics;
        MainView mainView;
        BallSimulation ballSimulation;
        GameController gameController;

        private float ExplosionScale;       

        public MasterController()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";

            graphics.PreferredBackBufferWidth = 760;
            graphics.PreferredBackBufferHeight = 760;
            graphics.ApplyChanges();

            //sets the scale for the explosion
            //1 is default size
            ExplosionScale = 1f;
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
            //makes the mouse visible on the game screen
            this.IsMouseVisible = true;
            
            gameController = new GameController(ExplosionScale, Content);            
            
            ballSimulation = new BallSimulation();
            mainView = new MainView(GraphicsDevice, Content, ballSimulation, ExplosionScale);
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
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
            {
                Exit();
            }

            gameController.ReadMouse();

            foreach (Explosion explosion in gameController.Explosions)
            {
                explosion.UpdateExplosion((float)gameTime.ElapsedGameTime.TotalSeconds);
            }
            
            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Gray);

            mainView.DrawGame(gameController.Explosions);

            base.Draw(gameTime);
        }
    }
}
