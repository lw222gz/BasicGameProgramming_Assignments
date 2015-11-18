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
     *     FORMULA: (h - a) * s + p = v
     *     h = the highest value a logical cord can have (in this case 7)
     *     a = the value of the logical coordinate that is being transformed to a visual coordinate
     *     s = the tile width or heigth depending on calculation of X or Y visual coordinate, aslong as the tiles are square this value will be the same
     *     p = visual coordinate value of the top left of the gamefield. X value if visual x is being calculated, Y value if visual y is being calculated
     *     v = the value of the visual coordinate
     *     
     *     example: (6,0)
     *     h = 7, s = 64, p = 64
     *     VisualX = (7 - 6) * 64 + 64 = 128
     *     VisualY = (7 - 0) * 64 + 64 = 512
     *     thus the visual coordiantes for (6,0) is (128,512)
     *     
     *     RULE: This only works for 180 degree turns
     */
}
