using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;

namespace dynamicmapsize
{

    public class Game1 : Microsoft.Xna.Framework.Game
    {
        GraphicsDeviceManager graphics;
        public static SpriteBatch spriteBatch;
        SpriteFont MSGothic31, Corsiva8, Corsiva15, Corsiva20, Corsiva30, Corsiva40;
        Rectangle[,] gameGrid = new Rectangle[100, 100];
        public static Texture2D map;
        public static Texture2D pixel;
        MouseCord mouse = new MouseCord();
        createMap gamemap = new createMap();
      
        public static Rectangle confirmbutton;
      
        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            graphics.PreferredBackBufferWidth = 1800;  // set this value to the desired width of your window
            graphics.PreferredBackBufferHeight = 980;   // set this value to the desired height of your window
            graphics.IsFullScreen = false;
        }

        protected override void Initialize()
        {
            this.IsMouseVisible = true;

            base.Initialize();
        }


        protected override void LoadContent()
        {
           // Corsiva8 = Content.Load<SpriteFont>("Corsiva8");
            Corsiva15 = Content.Load<SpriteFont>("Corsiva15");
            //Corsiva20 = Content.Load<SpriteFont>("Corsiva20");
           // Corsiva30 = Content.Load<SpriteFont>("Corsiva30");
           // Corsiva40 = Content.Load<SpriteFont>("Corsiva40");
            spriteBatch = new SpriteBatch(GraphicsDevice);
            pixel = new Texture2D(GraphicsDevice, 1, 1, false, SurfaceFormat.Color);
            pixel.SetData(new[] { Color.White });
            map = Content.Load<Texture2D>("map");
            mouse.clickbox.Add(confirmbutton);

        }


        protected override void UnloadContent()
        {

        }


        protected override void Update(GameTime gameTime)
        {

            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed)
                this.Exit();
            

            base.Update(gameTime);
            mouse.myMouse(gameTime);
            mouse.checkmouse( confirmbutton);

        }
       
        
        

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);
           

            spriteBatch.Begin(SpriteSortMode.Immediate, BlendState.AlphaBlend);


            
            gamemap.drawgrid(250,150,32);
            gamemap.checkgrid();
            spriteBatch.DrawString(Corsiva15, "mouse x:" + mouse.m_mousePos.X.ToString(), new Vector2(10, 25), Color.Red);
           spriteBatch.DrawString(Corsiva15, "mouse y:" + mouse.m_mousePos.Y.ToString(), new Vector2(10, 55), Color.Red);
            spriteBatch.DrawString(Corsiva15, "Height:" + createMap.height.ToString(), new Vector2(10, 85), Color.Red);
            spriteBatch.DrawString(Corsiva15, "Width:" + createMap.width.ToString(), new Vector2(10, 115), Color.Red);
            spriteBatch.DrawString(Corsiva15, "Width:" + createMap.currentRect.ToString(), new Vector2(10, 145), Color.Red);
            drawconfirmbtn(780, 700);

            spriteBatch.End();

            base.Draw(gameTime);
        }
        public void drawconfirmbtn(int confirmboxX, int confirmboxY)
        {
            createMap.DrawBorder(confirmbutton = new Rectangle(confirmboxX, confirmboxY, 180, 70), 3, Color.Yellow);
            spriteBatch.DrawString(Corsiva15, "Confirm", new Vector2(confirmboxX, confirmboxY + 6), Color.LawnGreen);
            if (mouse.hover == "confirm")
            {
                createMap.DrawBorder(confirmbutton, 50, Color.Ivory);
                spriteBatch.DrawString(Corsiva15, "Confirm", new Vector2(confirmboxX, confirmboxY + 6), Color.Blue);

            }
            if (mouse.clickstate == "confirm")
            {
                
                createMap.mark = false;
                
                mouse.clickstate = "null";
                MouseCord.mousetf = false;
            }
            }

        }
    

    }
