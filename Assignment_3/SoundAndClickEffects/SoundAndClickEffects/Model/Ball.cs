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
        private const float ballLogicDiameter = 0.1f;

        
        public Ball()
        {
            this.ballLogicCords = GenerateRandomLogicCords();
            ballLogicSpeedX = GenerateRandomSpeed();
            ballLogicSpeedY = GenerateRandomSpeed();
        }
        public Vector2 BallLogicCords
        {
            get { return ballLogicCords; }      
        }

        public float BallLogicDiameter
        {
            get { return ballLogicDiameter; }
        }


        public void UpdateLocation(float time)
        {
            //time is divided by 1000 since it's value is in milliseconds and I count speed as speed in seconds.
            time /= 1000;
            ballLogicCords.X += time * ballLogicSpeedX;
            ballLogicCords.Y += time * ballLogicSpeedY;
        }

        //Changes the speed aswell as the direction in the horizontal direction. 
        //also sets the Y Cords of the ball to the place of collision
        public void CollisionHorizontalWall()
        {
            float NewSpeed = GenerateRandomSpeed();
            
            if (ballLogicCords.Y <= 0)
            {
                ballLogicCords.Y = 0;
                ballLogicSpeedY = NewSpeed;
            }
            else
            {
                ballLogicCords.Y = 1;
                ballLogicSpeedY = -NewSpeed;
            }
        }

        //Changes the speed aswell as the direction in the vertical direction. 
        //also sets the X Cords of the ball to the place of collision
        public void CollisionVerticalWall()
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
                ballLogicCords.X = 1;
                ballLogicSpeedX = -NewSpeed;
            }
        }

        //returns a random logic coordinate between 0.1 and 0.9
        private Vector2 GenerateRandomLogicCords()
        {
            Random rnd = new Random();
            int x = rnd.Next(10, 90);
            int y = rnd.Next(10, 90);
            float xCord = (float)x / 100f;
            float yCord = (float)y / 100f;
            return new Vector2(xCord, yCord);
        }

        private float GenerateRandomSpeed()
        {
            Random rnd = new Random();
            int speed = rnd.Next(50, 105);
            return (float)speed/100f;
        }
    }
}
