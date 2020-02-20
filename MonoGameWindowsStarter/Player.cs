using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Audio;

namespace MonoGameWindowsStarter
{
    public class Player: CollidableObject
    {
        BoundingRectangle bounds;
        Game1 game;
        Texture2D texture;
        float rotation, turnSpeed;
        PlayerBulletModel playerBulletModel = new PlayerBulletModel();
        List<PlayerBullet> playerBullets = new List<PlayerBullet>();
        double shootLag = 0;
        Grid grid;
        SoundEffect explosion;
        public Player(Game1 game)
        {
            this.game = game;
        }
        public override Rectangle RectBounds()
        {
            return bounds;
        }
        public override bool visiblity()
        {
            return true;
        }
        public void LoadContent(ContentManager content, Grid grid)
        {
            texture = content.Load<Texture2D>("player");
            this.grid = grid;
            bounds.Width = 16;
            bounds.Height = 50;
            bounds.X = game.GraphicsDevice.Viewport.Width / 2 - 16;
            bounds.Y = game.GraphicsDevice.Viewport.Height;
            grid.Add(this, new Vector2(bounds.X, bounds.Y));
            playerBulletModel.LoadContent(content);
            explosion = content.Load<SoundEffect>("Explosion2");
        }
        public void Update(GameTime gameTime)
        {
            shootLag += gameTime.ElapsedGameTime.TotalMilliseconds;
            var keyboardState = Keyboard.GetState();

            int delta_x = Mouse.GetState().X - (int)bounds.X;
            int delta_y = Mouse.GetState().Y - (int)bounds.Y;
            
            rotation = -(float)Math.Atan2(delta_x, delta_y);
            
            //Player Shooting
            if(Mouse.GetState().LeftButton == ButtonState.Pressed && shootLag >= 500)
            {
                shootLag = 0;
                playerBullets.Add(new PlayerBullet(game, (int)bounds.X - 8, (int)bounds.Y - 25, rotation, new Vector2(Mouse.GetState().X, Mouse.GetState().Y),playerBulletModel, grid, explosion));
            }

            //Bullets Update
            for (int i = playerBullets.Count - 1; i >= 0; i--)
            {
                playerBullets[i].Update(gameTime);
                if(!playerBullets[i].IsVisible)
                {
                    playerBullets.RemoveAt(i);
                }
            } 
        }
        public override void handleCollision(CollidableObject collidableObject)
        {

        }
        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture, bounds, null, Color.White, rotation, new Vector2(8,25), SpriteEffects.None, 0f);
            foreach (PlayerBullet bullet in playerBullets)
            {
                bullet.Draw(spriteBatch);
            }
        }

    }
}
