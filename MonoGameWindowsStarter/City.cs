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
    public class City: CollidableObject
    {
        Game1 game;
        Texture2D texture;
        BoundingRectangle bounds;
        bool isVisible;
        public City(Game1 game, int xBounds)
        {
            this.game = game;
            bounds.X = xBounds;
        }
        public override Rectangle RectBounds()
        {
            return (Rectangle)bounds;
        }
        public void LoadContent(CityModel cityModel, Grid grid)
        {
            bounds.Width = 128;
            bounds.Height = 128;
            bounds.Y = game.GraphicsDevice.Viewport.Height - 128;
            texture = cityModel.Texture;
            grid.Add(this, new Vector2(bounds.X, bounds.Y));
        }
        
        public void Update(GameTime gameTime)
        {

        }
        public override void handleCollision(CollidableObject collidedObject)
        {
            if(collidedObject.GetType() == typeof(EnemyBullet))
            {
                isVisible = false;
            }
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture, bounds, Color.White);
        }
        
    }
}
