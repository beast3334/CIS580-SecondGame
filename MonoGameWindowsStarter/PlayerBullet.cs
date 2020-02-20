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
    public class PlayerBullet: CollidableObject
    {
        Game1 game;
        Texture2D texture;
        Texture2D explodedTexture;
        BoundingRectangle bounds;
        Vector2 destination;
        Vector2 newDestination;
        bool isVisible = true;
        bool exploded = false;
        Grid grid;
        SoundEffect explosion;
        TimeSpan animationTimer, explodedTimer, trailTimer;
        const int FRAME_WIDTH = 296 , FRAME_HEIGHT = 260, ANIMATION_FRAME_RATE = 124;
        int frame, state;
        float rotation;
        List<Trail> trails = new List<Trail>();
        public bool IsVisible
        {
            get { return isVisible; }
        }
        public override Rectangle RectBounds()
        {
            return (Rectangle)bounds;
        }
        public override bool visiblity()
        {
            return isVisible;
        }
        public PlayerBullet(Game1 game, int xBounds, int yBounds, float rotation, Vector2 destination,  PlayerBulletModel playerBulletModel, Grid grid, SoundEffect explosion)
        {
            this.game = game;
            this.destination = destination;
            this.rotation = rotation;
            bounds.X = xBounds;
            bounds.Y = yBounds;
            this.grid = grid;
            this.explosion = explosion;
            LoadContent(playerBulletModel);
        }
        public void LoadContent(PlayerBulletModel playerBulletModel)
        {
            bounds.Width = 20;
            bounds.Height = 20;
            texture = playerBulletModel.Texture;
            explodedTexture = playerBulletModel.ExplodedTexture;
            grid.Add(this, new Vector2(bounds.X, bounds.Y));
        }

        public void Update(GameTime gameTime)
        {
            //trailTimer += gameTime.ElapsedGameTime;
            Vector2 oldLocation = new Vector2(bounds.X, bounds.Y);
            
            if(!exploded)
            {
                newDestination = Vector2.Lerp(new Vector2(bounds.X, bounds.Y), destination, 0.03f);
                bounds.X = newDestination.X;
                bounds.Y = newDestination.Y;
                if (bounds.Y < 0 || bounds.X < 0 || bounds.X > game.GraphicsDevice.Viewport.Width)
                {
                    isVisible = false;
                }
                //if (trailTimer.TotalMilliseconds >= 100)
                //{
                //    trailTimer = animationTimer -= new TimeSpan(0, 0, 0, 0, 0);
                //    trails.Add(new Trail(game, texture, new Vector2(bounds.X, bounds.Y)));
                //}
                if (Vector2.Distance(newDestination, destination) <= 20)
                {
                    exploded = true;
                    explosion.Play();
                    bounds.Y -= 64;
                    bounds.X -= 64;
                    bounds.Width = 128;
                    bounds.Height = 128;
                }

            }
            else
            {
                if(explodedTimer.TotalSeconds >= 2)
                {
                    isVisible = false;
                }
                explodedTimer += gameTime.ElapsedGameTime;
                animationTimer += gameTime.ElapsedGameTime;
                while (animationTimer.TotalMilliseconds > ANIMATION_FRAME_RATE)
                {
                    if (state < 3)
                    {
                        state++;
                    }
                    else if (state == 3)
                    {
                        state = 0;
                    }
                    frame++;
                    animationTimer -= new TimeSpan(0, 0, 0, 0, ANIMATION_FRAME_RATE);
                }
                frame %= 1;
            }
            grid.Move(this, oldLocation, new Vector2(bounds.X, bounds.Y));

        }
     
        public override void handleCollision(CollidableObject collidedObject)
        {
            if(collidedObject.GetType() == typeof(EnemyBullet))
            {
                explosion.Play();
                exploded = true;
                bounds.Width = 128;
                bounds.Height = 128;
            }

        }
           
        public void Draw(SpriteBatch spriteBatch)
        {
            if (!exploded)
            {
                //foreach (Trail trail in trails)
                //{
                //    trail.Draw(spriteBatch, rotation);
                //}
                spriteBatch.Draw(texture, bounds, null, Color.White, rotation, new Vector2(7.5f, 7.5f), SpriteEffects.None, 0f);
                
            }
            else
            {
                var source = new Rectangle(
                    frame * FRAME_WIDTH,
                    (int)state % 3 * FRAME_HEIGHT,
                    FRAME_WIDTH,
                    FRAME_HEIGHT);
                spriteBatch.Draw(explodedTexture, bounds, source, Color.White);
            }
            
            
        }

    }
}
