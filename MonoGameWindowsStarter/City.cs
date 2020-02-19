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
    public class City
    {
        Game1 game;
        Texture2D texture;
        BoundingRectangle bounds;
        public City(Game1 game, int xBounds)
        {
            this.game = game;
            bounds.X = xBounds;
        }
        public void LoadContent(CityModel cityModel)
        {
            bounds.Width = 128;
            bounds.Height = 128;
            bounds.Y = game.GraphicsDevice.Viewport.Height - 128;
            texture = cityModel.Texture;
        }
        
        public void Update(GameTime gameTime)
        {

        }
        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture, bounds, Color.White);
        }
        
    }
}
