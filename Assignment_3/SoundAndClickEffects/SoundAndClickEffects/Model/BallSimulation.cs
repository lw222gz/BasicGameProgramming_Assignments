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

        //returnes the
        public List<Ball> getBalls(){
            return this.balls;
        }

        //initiates a new instance of the Ball class and calls the UpdateGameResolution to set base values.
        public BallSimulation()
        {
            Random rnd = new Random();
            balls = new List<Ball>(10);
            for (int i = 0; i < 10; i++)
            {
                balls.Add(new Ball(rnd));
            }
                
        }

        //Updates the game:
        //- Updates ball position
        //- Checks for collisions
        public void Update(float timeElapsed)
        {
            foreach (Ball b in balls)
            {
                b.UpdateLocation(timeElapsed);
                CheckCollision(b);
            }               
        }

        //checks if the ball has collided with any wall, if so then it's direction is changed.
        private void CheckCollision(Ball ball)
        {
            //East wall || West wall
            if (ball.BallLogicCords.X + ball.BallLogicDiameter >= 1 || ball.BallLogicCords.X <= 0)
            {                
                ball.CollisionVerticalWall();
            }

            //South wall || North wall
            if (ball.BallLogicCords.Y + ball.BallLogicDiameter>= 1 || ball.BallLogicCords.Y <= 0)
            {
                ball.CollisionHorizontalWall();
            }
        }

        public void CheckIfHit(Vector2 explosionLocation, float aimRadius)
        {
            
            foreach (Ball b in balls)
            {
                if (b.BallLogicCords.X + b.BallLogicDiameter/2 <= explosionLocation.X + aimRadius &&
                    b.BallLogicCords.X + b.BallLogicDiameter/2 >= explosionLocation.X - aimRadius &&
                    b.BallLogicCords.Y + b.BallLogicDiameter/2 <= explosionLocation.Y + aimRadius &&
                    b.BallLogicCords.Y + b.BallLogicDiameter/2 >= explosionLocation.Y - aimRadius)
                {
                    b.Dead();
                }            
            }
        }
    }
}
