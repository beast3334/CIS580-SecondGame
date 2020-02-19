using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
namespace MonoGameWindowsStarter
{
    public class Trail
    {
        Game1 game;
        Texture2D texture;
        public BoundingRectangle bounds;
        public Trail(Game1 game, Texture2D texture, Vector2 destination)
        {
            this.game = game;
            this.texture = texture;
            LoadContent(destination);
        }
        public void LoadContent(Vector2 destination)
        {
            bounds.Width = 2;
            bounds.Height = 2;
            bounds.X = destination.X + 7.5f;
            bounds.Y = destination.Y + 7.5f;
            
        }

        public void Draw(SpriteBatch spriteBatch, float rotation)
        {
            spriteBatch.Draw(texture, bounds, null, Color.White, rotation, new Vector2(0, 0), SpriteEffects.None, 0f);
        }
    }
}
