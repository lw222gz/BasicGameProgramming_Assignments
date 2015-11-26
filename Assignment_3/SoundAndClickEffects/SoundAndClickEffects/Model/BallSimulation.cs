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
        //The logical cords for the walls, these cords represent the STARTING point for being drawn (aka the top left corner)
        private Vector2 northWall = new Vector2(0, 0);
        private Vector2 eastWall = new Vector2(1, 0);
        private Vector2 southWall = new Vector2(0, 1);
        private Vector2 westWall = new Vector2(0, 0);

        //ball obj
        private Ball ball;

        //values respresenting the time stamps the game was/ is updated
        double CurrentTime;
        double LastTimeMoved;

        //returnes the
        public Ball getBall(){
            return this.ball;
        }

        //properties of the wall drawpoint cords
        public Vector2 NorthWall
        {
            get { return northWall; }
        }
        public Vector2 EastWall
        {
            get { return eastWall; }
        }
        public Vector2 SouthWall
        {
            get { return southWall; }
        }
        public Vector2 WestWall
        {
            get { return westWall; }
        }
        //--

        //Boolean if the application can take a keycommand
        public bool CanTakeCommand
        {
            get;
            set;
        }

        //initiates a new instance of the Ball class and calls the UpdateGameResolution to set base values.
        public BallSimulation()
        {
            ball = new Ball();
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
                this.ball.UpdateLocation(diff);
                CheckCollision();
                LastTimeMoved = CurrentTime;
            }
        }

        //checks if the ball has collided with any wall, if so then it's direction is changed.
        private void CheckCollision()
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
