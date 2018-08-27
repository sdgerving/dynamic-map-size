using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace dynamicmapsize
{
    class MouseCord
    {
        public Vector2 m_mousePos;
        public List<Rectangle> clickbox = new List<Rectangle>();
        public string hover = "null", clickstate = "null";
        public static MouseState currentMouseState;
        public static MouseState previousMouseState;
        public static int generalcount = 0;
        public static bool mousetf;
        public void myMouse(GameTime gameTime)
        {
            MouseState mouseState = Mouse.GetState();
            m_mousePos.X = mouseState.X;
            m_mousePos.Y = mouseState.Y;
            MouseState currentMouseState = Mouse.GetState(); //Get the state
            if (currentMouseState.LeftButton == ButtonState.Pressed &&
                previousMouseState.LeftButton == ButtonState.Released) //Will be true only if the user is currently clicking, but wasn't on the previous call.
            {
                mousetf = !mousetf; //Toggle the state between true and false.
            }
            previousMouseState = currentMouseState;
        }
        public void checkmouse( Rectangle confirmbutton)
        {
            foreach (Rectangle rect in clickbox)
            {

                Point p = new Point(Convert.ToInt32(m_mousePos.X), Convert.ToInt32(m_mousePos.Y));

                if (confirmbutton.Contains(p))
                {
                    hover = "confirm";
                    if (mousetf == true)
                    {

                        clickstate = "confirm";
                    }

                }
                
                else hover = "";
                
            }
        }
        }
}
