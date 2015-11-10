using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Labb1ChessGame
{
    class ChessView
    {
        private SpriteBatch spriteBatch;

        private Camera camera;
        private ChessModel chessModel;

        private Texture2D ChessBackground;
        private Texture2D ChessBlackSquare;
        private Texture2D ChessWhiteSquare;
        private Texture2D ChessQueenPiece;

        public ChessView(ChessModel chessModel, ContentManager content, GraphicsDevice device)
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(device);

            camera = new Camera(device, chessModel);
            this.chessModel = chessModel;

            ChessBackground = content.Load<Texture2D>("ChessBackground.png");
            ChessBlackSquare = content.Load<Texture2D>("ChessBlackSquare.png");
            ChessWhiteSquare = content.Load<Texture2D>("ChessWhiteSquare.jpg");
            ChessQueenPiece = content.Load<Texture2D>("ChessQueenImage.png");
        }

        public void DrawGame() {
            bool everyOther = true;
            spriteBatch.Begin();

            spriteBatch.Draw(ChessBackground, camera.GetBackgroundVectorPos(), Color.White);//spriteBatch.Draw(ChessBackground ,camera.GetBackgroundVectorPos(), null, Color.White, 0, new Vector2(0,0), 0.5f, SpriteEffects.None, 0);

            foreach (int[] tileCords in this.chessModel.ChessSquareLogicCords)
            {
                if (everyOther)
                {
                    //draw white
                    spriteBatch.Draw(ChessWhiteSquare, camera.GetVisualCords(tileCords[0], tileCords[1]), Color.White);

                    //if the x value is 7, then it will be a new row, thus the same tile needs to be painted again.
                    if (!(tileCords[0] == 7))
                    {
                        everyOther = false;
                    }
                }
                else
                {
                    //draw black
                    spriteBatch.Draw(ChessBlackSquare, camera.GetVisualCords(tileCords[0], tileCords[1]), Color.White);

                    //if the x value is 7, then it will be a new row, thus the same tile needs to be painted again.
                    if (!(tileCords[0] == 7))
                    {
                        everyOther = true;
                    }
                    
                }
            }

            //test pieces to see the 180 degree switch
            spriteBatch.Draw(ChessQueenPiece, camera.GetVisualCords(3, 5), Color.White);
            spriteBatch.Draw(ChessQueenPiece, camera.GetVisualCords(1, 7), Color.White);
            spriteBatch.Draw(ChessQueenPiece, camera.GetVisualCords(2, 3), Color.White);

            spriteBatch.End();
        }


        public void UpdateGameResolution(GraphicsDevice device)
        {
            camera.UpdateGameResolution(device);
        }


    }


    /*   ASSIGNMENT 2 ACCORDING TO EXAMPLE:
     * Logical coordinates | Visual coordinates
     *          0,0        |       512,512
     *          6,0        |       128,512
     *          2,7        |       384,64 
     *          7,7        |       64,64
     *       
     *     FORMULA: (7-x) * 64 + p = y
     *     where x is the value of the logical coordinate
     *     and y is the value of the visual coordinate
     *     and p is the cords for the top left corner of the game field
     *     
     *     RULE: This only works for 180 degree turns
     */
}
