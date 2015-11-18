using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using ParticleSimulation.View;

namespace ParticleSimulation
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class Game1 : Game
    {
        GraphicsDeviceManager graphics;
        ParticleView view;
        SplitterSystem splitterSystem;

        private bool GenerateNewSplitter;
        //time is in millisec
        private const int timeBetweenExplosions = 2500;

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);

            graphics.PreferredBackBufferHeight = 640;
            graphics.PreferredBackBufferWidth = 640;
            graphics.ApplyChanges();

            Content.RootDirectory = "Content";

            GenerateNewSplitter = true;
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
            // Create a new SpriteBatch, which can be used to draw textures.
            splitterSystem = new SplitterSystem();
            view = new ParticleView(GraphicsDevice, Content, splitterSystem);

            // TODO: use this.Content to load your game content here
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
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape)) { 
                Exit();
            }

            //generates a new explosion after each {timeBetweenExplosions} milliseconds pass
            if (GenerateNewSplitter)
            {
                this.splitterSystem.generateParticles();
                ResetTimer();
                
            }

            //updates the particle explosion
            splitterSystem.UpdateParticleLocation(gameTime.TotalGameTime.TotalMilliseconds);

            base.Update(gameTime);
        }

        //time for resetting the explosion boolean.
        private void ResetTimer()
        {
            GenerateNewSplitter = false;

            System.Threading.Timer timer = null;
            timer = new System.Threading.Timer((obj) =>
            {
                ResetExplosion();
                timer.Dispose();
            }, null, timeBetweenExplosions, System.Threading.Timeout.Infinite);
        }

        private void ResetExplosion()
        {
            GenerateNewSplitter = true;
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Black);

            view.Draw();

            base.Draw(gameTime);
        }
    }
}
