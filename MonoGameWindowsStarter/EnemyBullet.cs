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
    public class EnemyBullet:CollidableObject
    {
        Game1 game;
        Texture2D texture;
        public BoundingRectangle bounds;
        ContentManager content;
        Random random;
        Grid grid;
        bool isvisible = true;
        public override Rectangle RectBounds()
        {
            return (Rectangle)bounds;
        }
        public bool IsVisible
        { get { return isvisible; } }

        public EnemyBullet(Game1 game, EnemyModel enemyModel, ContentManager content, Random random, Grid grid)
        {
            this.game = game;
            this.texture = enemyModel.Texture;
            this.content = content;
            this.random = random;
            this.grid = grid;
            LoadContent();
        }
        public void LoadContent()
        {
            bounds.Width = 15;
            bounds.Height = 15;
            bounds.Y = 0;
            bounds.X = random.Next(0,1080);
            grid.Add(this, new Vector2(bounds.X, bounds.Y));
        }
        public void Update(GameTime gameTime)
        {
            Vector2 oldBounds = new Vector2(bounds.X, bounds.Y);
            bounds.Y++;
            grid.Move(this, oldBounds, new Vector2(bounds.X, bounds.Y));
        }
        public override void handleCollision(CollidableObject collidedObject)
        {
            if(collidedObject.GetType() == typeof(PlayerBullet))
            {
                isvisible = false;
            }

        }
        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture, bounds, Color.White);
        }
    }
}
