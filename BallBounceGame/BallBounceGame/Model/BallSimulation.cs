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
        //The logical cords for the walls, these cords represent the starting point for being drawn (aka the top left corner)
        private Vector2 northWall = new Vector2(0, 0);
        private Vector2 eastWall = new Vector2(1, 0);
        private Vector2 southWall = new Vector2(0, 1);
        private Vector2 westWall = new Vector2(0, 0);
        //ball obj
        private Ball ball;

        double CurrentTime;
        double LastTimeMoved;

        //PIXEL sizes for the thickness of a wall aswell as the px indent from the window
        private const int wallThickness = 5;
        private const int dissort = 10;

        private float logicalWallThicknessX;
        private float logicalWallThicknessY;
        private float logicalDissortX;
        private float logicalDissortY;

        public int WallThickness{
            get { return wallThickness; }
        }
        public int Dissort
        {
            get { return dissort; }
        }

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
        public BallSimulation(GraphicsDevice device)
        {
            ball = new Ball();
            UpdateGameResolution(device);     
        }
        public void UpdateGameResolution(GraphicsDevice device)
        {
            logicalWallThicknessX = (float)wallThickness / (float)(device.Viewport.Width - dissort * 2);
            logicalWallThicknessY = (float)wallThickness / (float)(device.Viewport.Height - dissort * 2);
            logicalDissortX = (float)dissort / (float)(device.Viewport.Width - dissort * 2);
            logicalDissortY = (float)dissort / (float)(device.Viewport.Height - dissort * 2);    
        }

        public void Update(double timeSpan)
        {

            CurrentTime = timeSpan;
            if (CurrentTime > LastTimeMoved)
            {
                float diff = (float)(CurrentTime - LastTimeMoved);
                //float diffInSec = (float)diff.TotalSeconds;
                this.ball.UpdateLocation(diff);
                CheckCollision();
                LastTimeMoved = CurrentTime;
            }
        }

        private void CheckCollision()
        {
            float minDistanceY = 0f + ball.BallLogicDiameter / 2 + logicalDissortY + logicalWallThicknessY;
            float minDistanceX = 0f + ball.BallLogicDiameter / 2 + logicalDissortX + logicalWallThicknessX;

            if (ball.BallLogicCords.X >= 1f - ball.BallLogicDiameter / 2 + logicalWallThicknessX)
            {
                ball.CollisionVertical(minDistanceX);
            }
            else if (ball.BallLogicCords.X <= 0f + ball.BallLogicDiameter / 2 + logicalDissortX + logicalWallThicknessX)
            {
                ball.CollisionVertical(minDistanceX);
            }
            if (ball.BallLogicCords.Y >= 1f - ball.BallLogicDiameter / 2 + logicalWallThicknessY)
            {
                ball.CollisionHorizontal(minDistanceY);
            }
            else if (ball.BallLogicCords.Y <= minDistanceY)
            {
                ball.CollisionHorizontal(minDistanceY);               
            }
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
