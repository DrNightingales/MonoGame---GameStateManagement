using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace WindowsGame
{
    internal class MenuItem
    {
        /// <summary>
        /// Управляет элементами меню (кнопки)
        /// Содержит конструктор, bool Hovered и Clicked
        /// 
        /// </summary>
        internal string Text { get; private set; }
        internal SpriteFont Font { get; private set; }
        internal Vector2 Position { get; private set; }
        internal Rectangle Rect { get; private set; }
        internal Action Action { get; private set; }

        internal MenuItem(string text, SpriteFont font, Vector2 position, Action action) //принимает на вход string, spritefont, vector2 и action
        {
            Text = text;
            Font = font;
            Vector2 measure = font.MeasureString(Text);

            Position = new Vector2(
              (int)(position.X - measure.X / 2),
              (int)(position.Y - measure.Y / 2));

            Rect = new Rectangle(
              (int)Position.X,
              (int)Position.Y,
              (int)measure.X,
              (int)measure.Y);

            Action = action;
        }
        internal bool Hovered() //Проверяет, находится ли мышь в пределах Rectangle элемента меню
        {
            return Rect.Contains(InputManager.GetMousePositionToPoint());
        }

        internal bool Clicked() //Проверяет нажата ли левая кнопка мыши
        {
            return Hovered() && InputManager.IsMouseLeftClick();
        }

    }
}