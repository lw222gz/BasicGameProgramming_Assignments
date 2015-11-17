using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Labb1ChessGame
{
    class ChessModel
    {
        //bool representing if the table is turned 180 degrees
        private bool isTableTurned;

        //A list of int arrays, each array contains a logical coordinate for the chess game
        private List<int[]> chessSquareLogicCords;

        //holds the value for the max amount of tiles (chess board = 8x8)
        private const int chessTileAmount = 8*8;

        public ChessModel()
        {
            isTableTurned = false;
            setChessLogicCords();
        }

        public bool IsTableTurned
        {
            get { return isTableTurned; }
        }

        public bool CanTakeCommand
        {
            get;
            set;
        }


        //returns the List<int[]> of all tiles
        public List<int[]> ChessSquareLogicCords
        {
            get
            {
                return chessSquareLogicCords;         
            }
        }

        //creates a List<int[]> for each tile on a chessboard.
        private void setChessLogicCords()
        {
            chessSquareLogicCords = new List<int[]>(64);
            int xLine = 0;
            int yLine = 0;
            for (int i = 0; i < chessTileAmount; i++)
            {
                chessSquareLogicCords.Add(new int[2]{ xLine, yLine });
                xLine++;
                if (xLine == 8)
                {
                    yLine++;
                    xLine = 0;
                }
                
            }
        }

        //switches isTableTurned boolean.
        public void TurnTable()
        {
            if (IsTableTurned)
            {
                isTableTurned = false;
            }
            else
            {
                isTableTurned = true;
            }
        }


        public void ResetTimeForCommand()
        {
            CanTakeCommand = true;
        }

        public  void SetCoolDownForCommand()
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
