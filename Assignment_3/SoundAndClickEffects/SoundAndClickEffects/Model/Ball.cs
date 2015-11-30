using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BallBounceGame.Model
{
    class Ball
    {
        private Vector2 ballLogicCords;
        private float ballLogicSpeedX;
        private float ballLogicSpeedY;
        private const float ballLogicDiameter = 0.05f;

        private float fade;
        private bool isDead;
        Random rnd;

        
        public Ball(Random rnd)           
        {
            isDead = false;
            fade = 1f;
            this.rnd = rnd;
            this.ballLogicCords = GenerateRandomLogicCords();           
            ballLogicSpeedX = GenerateRandomSpeed();
            ballLogicSpeedY = GenerateRandomSpeed();

            //50-50 random chance to get another direction in Y and X led
            if (rnd.Next(0, 2) == 0)
            {
                ballLogicSpeedX = -ballLogicSpeedX;
            }
            if (rnd.Next(0, 2) == 0)
            {
                ballLogicSpeedY = -ballLogicSpeedY;
            }
        }
        public Vector2 BallLogicCords
        {
            get { return ballLogicCords; }      
        }

        public float BallLogicDiameter
        {
            get { return ballLogicDiameter; }
        }
        public float Fade
        {
            get { return fade; }
        }

        //changes the position of a ball
        public void UpdateLocation(float time)
        {
            ballLogicCords.X += time * ballLogicSpeedX;
            ballLogicCords.Y += time * ballLogicSpeedY;
        }

        //Changes the speed aswell as the direction in the horizontal direction. 
        //also sets the Y Cords of the ball to the place of collision
        public void CollisionHorizontalWall()
        {
            if (!isDead) { 
                float NewSpeed = GenerateRandomSpeed();
            
                if (ballLogicCords.Y <= 0)
                {
                    ballLogicCords.Y = 0;
                    ballLogicSpeedY = NewSpeed;
                }
                else
                {
                    ballLogicCords.Y = 1 - ballLogicDiameter;
                    ballLogicSpeedY = -NewSpeed;
                }
            }
        }

        //Changes the speed aswell as the direction in the vertical direction. 
        //also sets the X Cords of the ball to the place of collision
        public void CollisionVerticalWall()
        {
            if (!isDead)
            {          
                //I set the X value because if the ball has passed value 1 or 0 
                float NewSpeed = GenerateRandomSpeed();

                if (ballLogicCords.X <= 0)
                {
                    ballLogicCords.X = 0;
                    ballLogicSpeedX = NewSpeed;
                }
                else
                {
                    ballLogicCords.X = 1 - ballLogicDiameter;
                    ballLogicSpeedX = -NewSpeed;
                }
            }
        }

        //returns a random logic coordinate between 0.1 and 0.9
        private Vector2 GenerateRandomLogicCords()
        {
            //Random rnd = new Random();
            int x = rnd.Next(10, 90);
            int y = rnd.Next(10, 90);
            float xCord = (float)x / 100f;
            float yCord = (float)y / 100f;
            return new Vector2(xCord, yCord);
        }

        private float GenerateRandomSpeed()
        {
            //Random rnd = new Random();
            int speed = rnd.Next(15, 105);
            return (float)speed/100f;
        }

        internal void Dead()
        {
            isDead = true;
            ballLogicSpeedX = 0;
            ballLogicSpeedY = 0;
            fade = 0.5f;
        }
    }
}
