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
        

        //ball obj
        private List<Ball> balls;

        //values respresenting the time stamps the game was/ is updated
        double CurrentTime;
        double LastTimeMoved;

        //returnes the
        public List<Ball> getBalls(){
            return this.balls;
        }

        //Boolean if the application can take a keycommand
        public bool CanTakeCommand
        {
            get;
            set;
        }

        //initiates a new instance of the Ball class and calls the UpdateGameResolution to set base values.
        public BallSimulation()
        {
            balls = new List<Ball>(10);
            balls.Add(new Ball());
        }

        //Updates the game:
        //- Updates ball position
        //- Checks for collisions
        public void Update(double timeSpan)
        {
            CurrentTime = timeSpan;
            if (CurrentTime > LastTimeMoved)
            {
                float diff = (float)(CurrentTime - LastTimeMoved);
                foreach (Ball b in balls)
                {
                    b.UpdateLocation(diff);
                    CheckCollision(b);
                }
                
                
                LastTimeMoved = CurrentTime;
            }
        }

        //checks if the ball has collided with any wall, if so then it's direction is changed.
        private void CheckCollision(Ball ball)
        {
            //East wall || West wall
            if (ball.BallLogicCords.X >= 1 || ball.BallLogicCords.X <= 0)
            {                
                ball.CollisionVerticalWall();
            }

            //South wall || North wall
            if (ball.BallLogicCords.Y >= 1 || ball.BallLogicCords.Y <= 0)
            {
                ball.CollisionHorizontalWall();
            }
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
