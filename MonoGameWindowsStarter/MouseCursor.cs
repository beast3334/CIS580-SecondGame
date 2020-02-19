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
    public class MouseCursor
    {
        Game1 game;
        Texture2D texture;
        BoundingRectangle bounds;
        public MouseCursor(Game1 game)
        {
            this.game = game;
        }
        public void LoadContent(ContentManager content)
        {
            bounds.Width = 64;
            bounds.Height = 64;
            texture = content.Load<Texture2D>("mouse cursor");
        }
        public void Update(GameTime gameTime)
        {
            bounds.X = Mouse.GetState().X - 32;
            bounds.Y = Mouse.GetState().Y - 32;
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture, bounds, Color.White);
        }
    }
}
