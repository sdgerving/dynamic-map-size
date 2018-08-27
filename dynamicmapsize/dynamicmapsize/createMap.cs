using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace dynamicmapsize
{
    class createMap
    {
        
        public static Rectangle currentRect;
        Rectangle[,] gameGrid = new Rectangle[100, 100];
        //Rectangle[,] mappiece = new Rectangle[100,100];
        int[,] mapkey = new int[100, 100];
        public static int width, height;
        int numtemp;
        public static bool mark;
        Random random = new Random();
        public void drawgrid(int locx, int locy, int gridsize)
        {
            if(mark==false)
            {
                for (int x = 0; x < width; ++x)
                    for (int y = 0; y < height; ++y)
                    {
                        gameGrid[x, y] = new Rectangle(0, 0, 0, 0);
                    }
                        width = randomnumber(1, 20);
                height = randomnumber(1, 20);
                mark = true;
            }
            


            for (int x = 0; x <= width ; x++)
                for (int y = 0; y <=height ; y++)
                {
                    gameGrid[x, y] = new Rectangle(locx + (x * gridsize), locy + (y * gridsize), gridsize, gridsize);
                    Game1.spriteBatch.Draw(Game1.map,gameGrid[x,y],Color.White);
                }
        }
        public int randomnumber(int minnum, int maxnum)
        {

            numtemp = (int)Math.Round(random.NextDouble() * (maxnum - minnum) + minnum);
            return numtemp;
        }
        public void checkgrid()
        {
            MouseState currentMouseState = Mouse.GetState();

            foreach (Rectangle grid in gameGrid)
            {
                if (grid.Contains(new Point(currentMouseState.X, currentMouseState.Y)))
                {
                    currentRect = grid;
                    DrawBorder(grid, 1, Color.Red);
                }
               
            }
        }
        public static void DrawBorder(Rectangle rectangleToDraw, int thicknessOfBorder, Color borderColor)
        {
            // Draw top line
           Game1.spriteBatch.Draw(Game1.pixel, new Rectangle(rectangleToDraw.X, rectangleToDraw.Y, rectangleToDraw.Width, thicknessOfBorder), borderColor);
            // Draw left line
            Game1.spriteBatch.Draw(Game1.pixel, new Rectangle(rectangleToDraw.X, rectangleToDraw.Y, thicknessOfBorder, rectangleToDraw.Height), borderColor);
            // Draw right line
            Game1.spriteBatch.Draw(Game1.pixel, new Rectangle((rectangleToDraw.X + rectangleToDraw.Width - thicknessOfBorder), rectangleToDraw.Y, thicknessOfBorder, rectangleToDraw.Height), borderColor);
            // Draw bottom line
            Game1.spriteBatch.Draw(Game1.pixel, new Rectangle(rectangleToDraw.X, rectangleToDraw.Y + rectangleToDraw.Height - thicknessOfBorder, rectangleToDraw.Width, thicknessOfBorder), borderColor);
        }
    }
}
