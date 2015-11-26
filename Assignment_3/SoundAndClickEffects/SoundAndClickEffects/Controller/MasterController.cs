using SoundAndClickEffects.View;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Timers;
using ParticleSimulation.View;
using SmokeSimulation.View;
using SoundAndClickEffects.View.Draws;
using BallBounceGame.Model;

namespace SoundAndClickEffects
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class MasterController : Game
    {
        GraphicsDeviceManager graphics;
        MainView mainView;
        ExplosionUpdater explosionUpdater;
        SplitterSystem splitterSystem;
        SmokeSimulator smokeSimulator;

        BallSimulation ballSimulation;


        private float ExplosionScale;


        public MasterController()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";

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
            splitterSystem = new SplitterSystem(ExplosionScale);
            smokeSimulator = new SmokeSimulator();
            explosionUpdater = new ExplosionUpdater(splitterSystem, smokeSimulator);

            ballSimulation = new BallSimulation();
            mainView = new MainView(GraphicsDevice, Content, ballSimulation);

            //http://stackoverflow.com/questions/11632419/how-can-i-make-an-infinite-loop-with-5-second-pauses
            System.Timers.Timer aTimer;
            aTimer = new System.Timers.Timer();
            aTimer.Elapsed += new ElapsedEventHandler(ResetExplosion);
            aTimer.Interval = 2500;
            aTimer.Enabled = true;
            // TODO: use this.Content to load your game content here
        }

        private void ResetExplosion(object source, ElapsedEventArgs e)
        {
            explosionUpdater.ResetExplosion();
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

            
            explosionUpdater.UpdateFrame((float)gameTime.ElapsedGameTime.TotalSeconds);

            if (splitterSystem.Particles != null)
            {
                splitterSystem.UpdateParticleLocation((float)gameTime.ElapsedGameTime.TotalSeconds);
            }
            if (smokeSimulator.getSmoke != null)
            {
                smokeSimulator.UpdateSmokeClouds((float)gameTime.ElapsedGameTime.TotalSeconds);
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

            explosionView.Draw(ExplosionScale);

            base.Draw(gameTime);
        }
    }
}
