using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BallBounceGame.Model
{
    class Ball
    {
        private Rectangle ballCords;
        private const float ballSpeed = 0.2f;
        private const float ballRadius = 0.1f;


        public Ball(Rectangle ballCords)
        {
            this.ballCords = ballCords;
        }
        public Rectangle BallCord
        {
            get { return ballCords; }
            set
            {
                ballCords = value;
            }       
        }

        public float BallSpeed
        {
            get { return ballSpeed; }
        }

        public float BallRadius
        {
            get { return ballRadius; }
        }
    }
}
