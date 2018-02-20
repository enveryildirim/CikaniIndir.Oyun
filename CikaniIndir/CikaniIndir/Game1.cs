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

namespace CikaniIndir
{
    /// <summary>
    /// This is the main type for your game
    /// </summary>
    public class Game1 : Microsoft.Xna.Framework.Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        List<AHedef> Hedefler;
        Rectangle Rec_Nisan;
        Texture2D Tx_Nisan;
        List<AHedef> vurulan;
        int Sure = 2;
        int Skor=0;
        SoundEffect ses;
        MouseState ms,pms;
        SpriteFont SkorFont;
        Vector2 SkorPosition;
        Texture2D Background1;
        Texture2D Background2;
        SpriteFont GameOverFont;
        Vector2 GameOverPosition;
        Rectangle Background1Position;
        Rectangle Background2Position;
      
        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            Hedefler = new List<AHedef>();
           
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
           
            base.Initialize();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);
            Background1 = Content.Load<Texture2D>("Background");
            Background2 = Content.Load<Texture2D>("Background");
            Background1Position = new Rectangle(0, 0, Background1.Width, Background1.Height);
            Background2Position = new Rectangle(Background1.Width, 0, Background2.Width, Background2.Height);
            Tx_Nisan = Content.Load<Texture2D>("nisan");
            Rec_Nisan = new Rectangle(0, 0, 64, 64);
            ses = Content.Load<SoundEffect>("Magnum");
            SkorFont = Content.Load<SpriteFont>("Skor");
            SkorPosition = new Vector2(3, 3);
            GameOverFont = Content.Load<SpriteFont>("gameover");
            GameOverPosition = new Vector2(graphics.PreferredBackBufferWidth/2,graphics.PreferredBackBufferHeight/2);
         
         
            if (Hedefler.Count != 0)
            {
                foreach (var item in Hedefler)
                {
                    item.Load(Content);
                }
            }
            else
            {
                Random r = new Random();
                int temp = r.Next(0, 4);
                Adam a = new Adam(0, Rastgele.R(300).Y, Rastgele.R(300).Hiz, ((resim)temp).ToString());
                a.Load(Content);
                Hedefler.Add(a);
            }
            // TODO: use this.Content to load your game content here
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// all content.
        /// </summary>
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        /// 
        double total=0;
        protected override void Update(GameTime gameTime)
        {
           
            Rec_Nisan = new Rectangle(Mouse.GetState().X - (32 / 2), Mouse.GetState().Y - (32/2), 32, 32);
            total += gameTime.ElapsedGameTime.TotalSeconds;
            if (total > Sure)
            {
                Random r=new Random();
                int temp=r.Next(0,4);
                Adam a = new Adam(0, Rastgele.R(300).Y, Rastgele.R(300).Hiz,((resim)temp).ToString());
                a.Load(Content);
                Hedefler.Add(a);
                total=0;
            }
                //Hedef yonlendirir;
                foreach (var item in Hedefler)
                {
                    item.Update(graphics);
                }

                ms = Mouse.GetState();

                if (ms.LeftButton == ButtonState.Pressed && pms.LeftButton == ButtonState.Released)
                {
                    ses.Play();
                    vurulan = new List<AHedef>();

                    foreach (var item in Hedefler)
                    {
                        if (item.Rec.Intersects(Rec_Nisan))
                        {
                            Skor++;
                            vurulan.Add(item);
                        }
                    }
                    foreach (var item in vurulan)
                    {
                        Hedefler.Remove(item);
                    }

                }

                pms = ms;
            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);
            
            // TODO: Add your drawing code here
            spriteBatch.Begin();
            if (Hedefler.Count > 11)
            {
                spriteBatch.DrawString(GameOverFont, "Oyun Bitti ", GameOverPosition + Vector2.One, Color.Black);
                spriteBatch.DrawString(GameOverFont, "Oyun Bitti ", GameOverPosition, Color.White);
            }
            else
            {
                spriteBatch.Draw(Background1, Background1Position, Color.White);
                spriteBatch.Draw(Background2, Background2Position, Color.White);
                if (Hedefler.Count != 0)
                {
                    foreach (var item in Hedefler)
                    {
                        item.Draw(spriteBatch);
                    }
                }

                spriteBatch.Draw(Tx_Nisan, Rec_Nisan, Color.White);
                spriteBatch.DrawString(SkorFont, "Skor : " + Skor, SkorPosition + Vector2.One, Color.Black);
                spriteBatch.DrawString(SkorFont, "Skor : " + Skor, SkorPosition, Color.White);
            }
            spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}
