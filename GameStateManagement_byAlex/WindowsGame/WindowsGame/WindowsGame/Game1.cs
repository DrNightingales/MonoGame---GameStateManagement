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

namespace WindowsGame
{
    public class Game1 : Microsoft.Xna.Framework.Game
    {
        GraphicsDeviceManager graphics;

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";

            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            base.Initialize();
        }

        protected override void LoadContent() //загрузка контента
        {
            Commons.Game = this;
            Commons.Content = Content;
            Commons.GraphicsDevice = graphics.GraphicsDevice;
            Commons.SpriteBatch = new SpriteBatch(graphics.GraphicsDevice);

            ScreenManager.AddScreen(new MainMenuScreen());
            ScreenManager.AddScreen(new TestScreen());
            ScreenManager.ActivateScreenByName("MainMenuScreen");
            ScreenManager.Initialize();
        }

        protected override void UnloadContent()
        {
        }

        protected override void Update(GameTime gameTime)
        {
            ScreenManager.Update(gameTime);
            InputManager.Update(gameTime);

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime) //отрисовка
        {
            ScreenManager.Draw(gameTime);

            base.Draw(gameTime);
        }

    }
}