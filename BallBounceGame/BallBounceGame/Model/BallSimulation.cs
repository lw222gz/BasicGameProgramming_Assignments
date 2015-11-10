using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BallBounceGame.Model
{
    class BallSimulation
    {
        private Ball ball;
        public BallSimulation(GraphicsDevice device)
        {
            int width = device.Viewport.Width/10;
            int height = device.Viewport.Height/10;
            int x = (device.Viewport.Width / 2) - width;
            int y = device.Viewport.Height / 2 - height;
            ball = new Ball(new Rectangle(x, y ,width, height));
            //TODO:set a Rectangle obj to give the ball it's size and cords according to the screen size
            //create an instance of the ball obj
            
        }

        public Ball getBall(){
            return this.ball;
        }


        //Boolean if the application can take a keycommand
        public bool CanTakeCommand
        {
            get;
            set;
        }

        //Makes user abel to execute a command again
        public void ResetTimeForCommand()
        {
            CanTakeCommand = true;
        }

        //initiates a cooldown for taking commands form the user
        public void SetCoolDownForCommand()
        {
            CanTakeCommand = false;
            //Resets the boolean after 500 milliseconds.
            //source: http://stackoverflow.com/questions/545533/c-sharp-delayed-function-calls
            System.Threading.Timer timer = null;
            timer = new System.Threading.Timer((obj) =>
            {
                ResetTimeForCommand();
                timer.Dispose();
            }, null, 500, System.Threading.Timeout.Infinite);
        }
    }
}
