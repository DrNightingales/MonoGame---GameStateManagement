using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Graphics;

namespace WindowsGame
{
    internal class MainMenuScreen : Screen
    {
        SpriteFont font;
        List<MenuItem> menuItems = new List<MenuItem>();
        Color itemNormalColor = Color.White;
        Color itemHoverColor = Color.Red;

        internal MainMenuScreen()
            : base("MainMenuScreen")
        {
        }

        internal override bool Initialize()
        {
            font = Commons.Content.Load<SpriteFont>("Font1"); //загрузка шрифта

            menuItems.AddRange(new MenuItem[]
      {
        new MenuItem( // создание элемента меню
          "Play",
          font,
          new Vector2(
            Commons.GraphicsDevice.Viewport.Width / 2,
            Commons.GraphicsDevice.Viewport.Height * 4 / 6),
          new Action(() => { ScreenManager.ActivateScreenByName("TestScreen"); } )), //создание события
        new MenuItem( // создание элемента меню
          "Exit",
          font,
          new Vector2(
            Commons.GraphicsDevice.Viewport.Width / 2,
            Commons.GraphicsDevice.Viewport.Height * 5 / 6),
          new Action(() => { Commons.Game.Exit(); } )), //создание события
      });

            return base.Initialize();
        }

        internal override void Remove()
        {
            base.Remove();
        }

        internal override void Update(GameTime gameTime)
        {
            if (InputManager.IsKeyPress(Keys.Escape)) //проверка
                Commons.Game.Exit();

            for (int i = 0; i < menuItems.Count; i++)
            {
                if (menuItems[i].Clicked())
                {
                    menuItems[i].Action.Invoke();
                    break;
                }
            }

            base.Update(gameTime);
        }

        internal override void Draw(GameTime gameTime) //отрисовка
        {
            Commons.GraphicsDevice.Clear(Color.Gray);

            Commons.SpriteBatch.Begin();

            for (int i = 0; i < menuItems.Count; i++)
            {
                Commons.SpriteBatch.DrawString(
                  font,
                  menuItems[i].Text,
                  menuItems[i].Position,
                  menuItems[i].Hovered() ? itemHoverColor : itemNormalColor);
            }

            Commons.SpriteBatch.End();

            base.Draw(gameTime);
        }

    }
}