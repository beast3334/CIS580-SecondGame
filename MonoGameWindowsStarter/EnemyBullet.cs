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
    public class EnemyBullet
    {
        Game1 game;
        Texture2D texture;
        public BoundingRectangle bounds;
        ContentManager content;
        Random random;
        public EnemyBullet(Game1 game, Texture2D texture, ContentManager content)
        {
            this.game = game;
            this.texture = texture;
            this.content = content;
        }
        public void LoadContent()
        {
            bounds.Width = 15;
            bounds.Height = 15;
            bounds.Y = -10;
            bounds.X = random.Next(0, 1080);
        }
        public void Update(GameTime gameTime)
        {
            bounds.Y--;
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture, bounds, Color.White);
        }
    }
}
