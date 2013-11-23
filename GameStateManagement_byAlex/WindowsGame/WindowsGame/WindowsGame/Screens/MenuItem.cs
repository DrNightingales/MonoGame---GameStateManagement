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
        internal string Text { get; private set; }
        internal SpriteFont Font { get; private set; }
        internal Vector2 Position { get; private set; }
        internal Rectangle Rect { get; private set; }
        internal Action Action { get; private set; }

        internal MenuItem(string text, SpriteFont font, Vector2 position, Action action) // элемент меню (кнопка)
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
        internal bool Hovered()
        {
            return Rect.Contains(InputManager.GetMousePositionToPoint());
        }

        internal bool Clicked()
        {
            return Hovered() && InputManager.IsMouseLeftClick();
        }

    }
}