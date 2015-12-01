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
        //amount of ball tagets that spawn.
        private const int amountOfBalls = 20;
        //ball obj
        private List<Ball> balls;

        //initiates a new instance of the Ball class and calls the UpdateGameResolution to set base values.
        public BallSimulation()
        {
            Random rnd = new Random();
            balls = new List<Ball>(amountOfBalls);
            for (int i = 0; i < balls.Capacity; i++)
            {
                balls.Add(new Ball(rnd));
            }

        }

        //Properties for private varibles START
        public List<Ball> getBalls(){
            return this.balls;
        }
        //--Properties for private varibles END
       

        //Updates the game:
        //IF the ball is not dead
        //- Updates ball position
        //- Checks for collisions
        public void Update(float timeElapsed)
        {
            foreach (Ball b in balls)
            {
                if (!b.IsDead)
                {
                    b.UpdateLocation(timeElapsed);
                    CheckCollision(b);
                }
                
            }               
        }

        //checks if the ball has collided with any wall, if so then it's direction is changed.
        private void CheckCollision(Ball ball)
        {
            //East wall || West wall
            if (ball.BallLogicCords.X + ball.BallLogicRadius >= 1 || ball.BallLogicCords.X - ball.BallLogicRadius <= 0)
            {                
                ball.CollisionVerticalWall();
            }

            //South wall || North wall
            if (ball.BallLogicCords.Y + ball.BallLogicRadius >= 1 || ball.BallLogicCords.Y - ball.BallLogicRadius <= 0)
            {
                ball.CollisionHorizontalWall();
            }
        }

        //checks if a ball is hit by an explosion, if so it kills it.
        public void CheckIfHit(Vector2 explosionLocation, float aimRadius)
        {           
            foreach (Ball b in balls)
            {
                if (b.BallLogicCords.X + b.BallLogicRadius <= explosionLocation.X + aimRadius &&
                    b.BallLogicCords.X - b.BallLogicRadius >= explosionLocation.X - aimRadius &&
                    b.BallLogicCords.Y + b.BallLogicRadius <= explosionLocation.Y + aimRadius &&
                    b.BallLogicCords.Y - b.BallLogicRadius >= explosionLocation.Y - aimRadius)
                {
                    b.Dead();
                }            
            }
        }
    }
}
