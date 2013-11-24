using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Graphics;

namespace WindowsGame
{
    internal class TestScreen : Screen
    {
        /// <summary>
        /// Управляет экраном игры
        /// Содержит методы Remove, Update, Draw, конструтор и переменную Initialize
        /// </summary>
        SpriteFont font;
        List<MenuItem> menuItems = new List<MenuItem>();
        Color itemNormalColor = Color.White;
        Color itemHoverColor = Color.Red;

        Model sphere;
        Matrix world;
        Matrix view;
        Matrix proj;

        internal TestScreen()
            : base("TestScreen")
        {
            world = Matrix.Identity;
            view = Matrix.CreateLookAt(
              new Vector3(5f, 1f, 0f),
              Vector3.Zero,
              Vector3.Up);
            proj = Matrix.CreatePerspectiveFieldOfView(
              MathHelper.PiOver4,
              Commons.GraphicsDevice.Viewport.AspectRatio,
              0.1f, 10f);
        }

        internal override bool Initialize() //загружает шрифты и модели, создает элементы меню
        {
            font = Commons.Content.Load<SpriteFont>("Font1");
            sphere = Commons.Content.Load<Model>("27");

            menuItems.AddRange(new MenuItem[]
      {
        new MenuItem( 
          "Меню",
          font,
          new Vector2(
            Commons.GraphicsDevice.Viewport.Width - font.MeasureString("Меню").X,
            font.MeasureString("Меню").Y / 2),
          new Action(() => { ScreenManager.ActivateScreenByName("MainMenuScreen"); } )), 
      });

            return base.Initialize();
        }

        internal override void Remove()
        {
            base.Remove();
        }

        internal override void Update(GameTime gameTime)
        {
            if (InputManager.IsKeyPress(Keys.Escape)) 
                ScreenManager.ActivateScreenByName("MainMenuScreen");

            for (int i = 0; i < menuItems.Count; i++)
            {
                if (menuItems[i].Clicked())
                {
                    menuItems[i].Action.Invoke();
                    break;
                }
            }

            world *= Matrix.CreateRotationY((float)gameTime.ElapsedGameTime.TotalSeconds);

            base.Update(gameTime);
        }

        internal override void Draw(GameTime gameTime)
        {
            Commons.GraphicsDevice.Clear(Color.Transparent);

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

            sphere.Draw(world, view, proj);

            base.Draw(gameTime);
        }

    }
}