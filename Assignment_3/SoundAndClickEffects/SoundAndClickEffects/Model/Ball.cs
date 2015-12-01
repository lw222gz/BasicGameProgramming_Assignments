using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BallBounceGame.Model
{
    class Ball
    {
        //logical coords for the ball (0-1)
        private Vector2 ballLogicCords;
        //speed per seconds in logical coords
        private float ballLogicSpeedX;
        private float ballLogicSpeedY;
        //radius of the ball in a logical measurement
        private const float ballLogicRadius = 0.025f;

        //set to true if the ball dies, then it nolonger gets updated.
        private bool isDead;
        //fade is used when a ball dies.
        private float fade;
        
        Random rnd;

        //initates a new ball with random direction and spawn point.
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

        //properties of private varibles START
        public Vector2 BallLogicCords
        {
            get { return ballLogicCords; }      
        }

        public float BallLogicRadius
        {
            get { return ballLogicRadius; }
        }
        public float Fade
        {
            get { return fade; }
        }
        public bool IsDead
        {
            get { return isDead; }
        }
        //-- properties of private varibles END

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
            float NewSpeed = GenerateRandomSpeed();
            
            if (ballLogicCords.Y <= 0 + ballLogicRadius)
            {
                ballLogicCords.Y = 0 + ballLogicRadius;
                ballLogicSpeedY = NewSpeed;
            }
            else
            {
                ballLogicCords.Y = 1 - ballLogicRadius;
                ballLogicSpeedY = -NewSpeed;
            }
            
        }

        //Changes the speed aswell as the direction in the vertical direction. 
        //also sets the X Cords of the ball to the place of collision
        public void CollisionVerticalWall()
        { 
            //I set the X value because if the ball has passed value 1 or 0 
            float NewSpeed = GenerateRandomSpeed();

            if (ballLogicCords.X <= 0 + ballLogicRadius)
            {
                ballLogicCords.X = 0 + ballLogicRadius;
                ballLogicSpeedX = NewSpeed;
            }
            else
            {
                ballLogicCords.X = 1 - ballLogicRadius;
                ballLogicSpeedX = -NewSpeed;
            }
            
        }

        //returns a random logic coordinate between 0.1 and 0.9
        private Vector2 GenerateRandomLogicCords()
        {
            //Random rnd = new Random();
            float x = (float)(rnd.Next(10, 90)) / 100f;
            float y = (float)(rnd.Next(10, 90)) / 100f;
            return new Vector2(x, y);
        }

        //returns a new speed between 0.15 - 1.05 logical cords per second
        private float GenerateRandomSpeed()
        {
            return (float)(rnd.Next(15, 105)) / 100f;
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
