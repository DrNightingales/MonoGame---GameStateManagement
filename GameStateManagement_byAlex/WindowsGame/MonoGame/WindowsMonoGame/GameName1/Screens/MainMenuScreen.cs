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
        /// <summary>
        /// Наследуется от класса Screen
        /// Управляет экраном главного меню
        /// Содержит методы Remove, Update, Draw, конструктор, bool Initialize
        /// </summary>
        SpriteFont font;
        List<MenuItem> menuItems = new List<MenuItem>();
        Color itemNormalColor = Color.White;
        Color itemHoverColor = Color.Red;

        internal MainMenuScreen() //конструктор, наследуемый от Screen
            : base("MainMenuScreen")
        {
        }

        internal override bool Initialize() // загружает шрифты и создает элементы меню, возвращает true
        {
            font = Commons.Content.Load<SpriteFont>("Font1");

            menuItems.AddRange(new MenuItem[]
      {
        new MenuItem(
          "Play",
          font,
          new Vector2(
            Commons.GraphicsDevice.Viewport.Width / 2,
            Commons.GraphicsDevice.Viewport.Height * 4 / 6),
          new Action(() => { ScreenManager.ActivateScreenByName("TestScreen"); } )), 
        new MenuItem(
          "Exit",
          font,
          new Vector2(
            Commons.GraphicsDevice.Viewport.Width / 2,
            Commons.GraphicsDevice.Viewport.Height * 5 / 6),
          new Action(() => { Commons.Game.Exit(); } )), 
      });

            return base.Initialize();
        }

        internal override void Remove() // уничтожает объекты класса Screen
        {
            base.Remove();
        }

        internal override void Update(GameTime gameTime) // содержит проверку на нажатие клавиш
        {

            if (InputManager.IsKeyPress(Keys.Escape))
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

        internal override void Draw(GameTime gameTime) //Отрисовка объектов класса menuItem
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