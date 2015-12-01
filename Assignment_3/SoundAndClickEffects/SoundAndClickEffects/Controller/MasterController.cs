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
using SoundAndClickEffects.Model;

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
        PlayerAim playerAim;
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
            ExplosionScale = 1.3f;
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
            playerAim = new PlayerAim();
            mainView = new MainView(GraphicsDevice, Content, ballSimulation, ExplosionScale, playerAim.AimRadius);
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

            //if readmouse returns true a click has just been made, therefore I need to check if it was a hit on a ball.
            if (gameController.ReadMouse())
            {
                ballSimulation.CheckIfHit(mainView.GetLogicalHitCords(gameController.ExplosionLocation), playerAim.AimRadius);
            }

            //Updates all the balls positions
            ballSimulation.Update((float)gameTime.ElapsedGameTime.TotalSeconds);

            //Animates the explosions
            for (int i = 0; i < gameController.Explosions.Count; i ++)
            {
                if (gameController.Explosions[i].UpdateExplosion((float)gameTime.ElapsedGameTime.TotalSeconds))
                {
                    gameController.RemoveExplosion(gameController.Explosions[i]);
                }
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

            //draws the game
            mainView.DrawGame(gameController.Explosions);

            base.Draw(gameTime);
        }
    }
}
