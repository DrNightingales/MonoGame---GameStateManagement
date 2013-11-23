using Microsoft.Xna.Framework;

namespace WindowsGame
{
    internal class Screen
    {
        internal string Name { get; private set; }

        internal Screen(string name)
        {
            Name = name;
        }

        internal virtual bool Initialize() { return true; }

        internal virtual void Remove() { }

        internal virtual void Update(GameTime gameTime) { }

        internal virtual void Draw(GameTime gameTime) { }

    }
}